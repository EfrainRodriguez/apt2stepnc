using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace spt2stepnc
{
    public enum d_type
    {
        mastercam, ptc_creo, siemens_nx
    }

    static class Parse_APT
    {

        private static d_type dt_flag;

        private static MetaData apt_data;

        private class MetaData
        {
            public PartNo PartNo;
            public Units Units;
            public Multax Multax;
            public Dictionary<int, CutterTool> CutterTools = new Dictionary<int, CutterTool>();
            public List<MachineGroup> MachineGroups = new List<MachineGroup>();
        }

        private class MachineGroup
        {
            public int ID = -1;
            public List<ToolpathGroup> Operations = new List<ToolpathGroup>();
        }

        private class ToolpathGroup
        {
            public int ID = -1;
            public int Tool = -1;
            public List<APT> MachiningData = new List<APT>();
        }

        private class CutterTool
        {
            public int ID;
            public Cutter Tparams;
            public TPrint Label;
        }


        /// <summary>
        /// Parse mastercam APT data
        /// </summary>
        /// <param name="lines">APT data lines</param>
        /// <returns></returns>
        public static void MastercamApt_To_Stepnc(Queue<string> lines, string name /*String filename*/)
        {
            //Queue<string> lines = new Queue<string>(File.ReadAllLines(filename));

            if (lines.Count < 1)
                return;

            dt_flag = d_type.mastercam; //using parser for mastercam apt data
            apt_data = new MetaData();

            while (!lines.Peek().Contains("FINI"))
            {
                if (lines.Peek().Contains("$$Machine Group-"))
                {
                    apt_data.MachineGroups.Add(parse_machine_group(lines)); //add current machine-group to list
                }
                else
                {
                    lines.Dequeue();
                }
            }
            lines.Dequeue();


            apt_to_stepnc(apt_data, name);
        }

        public static void PtccreoApt_To_Stepnc(String filename)
        {
            ///TODO:
        }

        public static void Siemensnx_To_Stepnc(String filename)
        {
            ///TODO:
        }

        private static MachineGroup parse_machine_group(Queue<string> lines)
        {
            MachineGroup mg = new MachineGroup();
            mg.ID = Convert.ToInt32(lines.Peek().Substring("$$Machine Group-".Length));

            while (!lines.Peek().Contains("FINI") || (lines.Peek().Contains("$$Machine Group-") && (Convert.ToInt32(lines.Peek().Substring("$$Machine Group-".Length)) == mg.ID)))
            {
                lines.Dequeue();
                mg.Operations.Add(parse_toolpath_group(lines));
            }

            return mg;
        }

        private static ToolpathGroup parse_toolpath_group(Queue<string> lines)
        {
            ToolpathGroup tpg = new ToolpathGroup();
            Indirv current_indirv = new Indirv();
            string cutter_line = "", tprint_line = "";
            GoTo current_position = new GoTo();
            //double[] c_p = {0.0, 0.0, 0.0};
            string line;

            while (!lines.Peek().Contains("$$Machine Group-") && !lines.Peek().Contains("FINI"))
            {
                line = lines.Dequeue();

                if (line.Contains("PARTNO"))
                {
                    apt_data.PartNo = parse_apt_partno(line);
                    continue;
                }

                if (line.Contains("UNITS"))
                {
                    apt_data.Units = parse_apt_units(line);
                    continue;
                }

                if (line.Contains("MULTAX"))
                {
                    apt_data.Multax = parse_apt_multax(line);
                    continue;
                }

                /*
                if (line.Contains("MACHIN/"))
                {
                    
                    continue;
                }
                */

                if (line.Contains("CUTTER"))
                {
                    cutter_line = line;
                    continue;
                }

                if (line.Contains("TPRINT"))
                {
                    tprint_line = line;
                    continue;
                }

                if (line.Contains("LOAD"))
                {
                    LoadTL current_tool = parse_apt_loadtl(line);
                    if (!apt_data.CutterTools.ContainsKey(current_tool.ID))
                    {
                        CutterTool tool = new CutterTool();
                        tpg.Tool = tool.ID = current_tool.ID;
                        tool.Label = parse_apt_tprint(tprint_line);
                        tool.Tparams = parse_apt_cutter(cutter_line);
                        apt_data.CutterTools.Add(tool.ID, tool);
                    }
                    continue;
                }

                if (line.Contains("RAPID"))
                {
                    tpg.MachiningData.Add(new Rapid());
                    continue;
                }

                if (line.Contains("GOTO/"))
                {
                    current_position = parse_apt_goto(line);
                    tpg.MachiningData.Add(current_position);

                    continue;
                }

                if (line.Contains("INDIRV"))
                {
                    current_indirv = parse_apt_indirv(line);
                    tpg.MachiningData.Add(current_indirv);
                    continue;
                }

                if (line.Contains("CIRCLE/"))
                {
                    Circle current_circle = parse_apt_circle(current_position, current_indirv, line, lines.Dequeue(), lines.Dequeue());

                    current_position = new GoTo();

                    current_position.X = current_circle.X;
                    current_position.Y = current_circle.Y;
                    current_position.Z = current_circle.Z;

                    tpg.MachiningData.Add(current_circle);
                    continue;
                }

                if (line.Contains("FEDRAT"))
                {
                    tpg.MachiningData.Add(parse_apt_fedrate(line));
                    continue;
                }

                if (line.Contains("SPINDL"))
                {
                    tpg.MachiningData.Add(parse_apt_spinlespeed(line));
                    continue;
                }

                if (line.Contains("COOLNT"))
                {
                    tpg.MachiningData.Add(parse_apt_coolant(line));
                    continue;
                }
            }

            return tpg;
        }

        /// <summary>
        /// parses PARTNO instruction from apt line
        /// </summary>
        /// <param name="line">APT line</param>
        /// <returns></returns>
        private static PartNo parse_apt_partno(string line)
        {
            PartNo partno = new PartNo();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    partno.partno(line.Substring("PARTNO/".Length));
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return partno;
        }

        /// <summary>
        /// parses UNITS instrution from apt line
        /// </summary>
        /// <param name="line">APT line</param>
        /// <returns></returns>
        private static Units parse_apt_units(string line)
        {
            Units units = new Units();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    units.units(line.Substring("UNITS/".Length));
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return units;
        }

        /// <summary>
        /// parses MULTAX instrution from apt line
        /// </summary>
        /// <param name="line">APT line</param>
        /// <returns></returns>
        private static Multax parse_apt_multax(string line)
        {
            Multax multax = new Multax();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    multax.multax(line.Substring("MULTAX/".Length));
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return multax;
        }

        private static Cutter parse_apt_cutter(string line)
        {
            Cutter cutter = new Cutter();

            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    string[] substrings = Regex.Split(line.Substring("CUTTER/".Length), ",");
                    cutter.Diameter = Convert.ToDouble(substrings[0].Replace(" ", string.Empty));
                    //tpg.tpgtool.length = Convert.ToDouble(substrings[1].Replace(" ", string.Empty));
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }

            return cutter;
        }

        private static TPrint parse_apt_tprint(string line)
        {
            TPrint tprint = new TPrint();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    tprint.Label = line.Substring("TPRINT/".Length);
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return tprint;
        }

        private static LoadTL parse_apt_loadtl(string line)
        {
            LoadTL thisTool = new LoadTL();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    string[] substrings2 = Regex.Split(line.Substring("LOAD/".Length), ",");
                    thisTool.ID = Convert.ToInt32(substrings2[1].Replace(" ", string.Empty).Replace(".", string.Empty));
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return thisTool;
        }

        /// <summary>
        /// parses GOTO instrution from apt line
        /// </summary>
        /// <param name="line">apt line</param>
        /// <returns></returns>
        private static GoTo parse_apt_goto(string line)
        {
            GoTo gotoxyz = new GoTo();

            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    string[] substrings = Regex.Split(line.Substring("GOTO/".Length), ",");
                    gotoxyz.X = Convert.ToDouble(substrings[0].Replace(" ", string.Empty));
                    gotoxyz.Y = Convert.ToDouble(substrings[1].Replace(" ", string.Empty));
                    gotoxyz.Z = Convert.ToDouble(substrings[2].Replace(" ", string.Empty));
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }

            return gotoxyz;
        }

        private static Indirv parse_apt_indirv(string line)
        {
            Indirv indirv = new Indirv();

            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    string[] substrings = Regex.Split(line.Substring("INDIRV/".Length), ",");
                    indirv.I = Convert.ToDouble(substrings[0].Replace(" ", string.Empty));
                    indirv.J = Convert.ToDouble(substrings[1].Replace(" ", string.Empty));
                    indirv.K = Convert.ToDouble(substrings[2].Replace(" ", string.Empty));
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }

            return indirv;
        }

        private static Circle parse_apt_circle(GoTo startpoint, Indirv indirv, string line_1, string line_2, string line_3)
        {
            Circle circle = new Circle();

            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    //getting center
                    string[] substrings = Regex.Split(line_1.Substring(line_1.IndexOf("CIRCLE/") + "CIRCLE/".Length), ",");
                    circle.Cx = Convert.ToDouble(substrings[0].Replace(" ", string.Empty));
                    circle.Cy = Convert.ToDouble(substrings[1].Replace(" ", string.Empty));
                    circle.Cz = Convert.ToDouble(substrings[2].Replace(" ", string.Empty));
                    //getting radius
                    circle.Radius = Convert.ToDouble(line_2.Substring(0, line_2.IndexOf(")") - 1).Replace(" ", string.Empty));
                    //getting end point
                    string[] substring_2 = line_3.Split(',');
                    circle.X = Convert.ToDouble(substring_2[0].Replace(" ", string.Empty));
                    circle.Y = Convert.ToDouble(substring_2[1].Replace(" ", string.Empty));
                    circle.Z = Convert.ToDouble(substring_2[2].Replace(" ", string.Empty).Replace(")", string.Empty));

                    bool d1 = false;
                    bool d2 = true;

                    //determines the direction of movement
                    if (indirv.I <= 0 && indirv.J < 0)
                    {
                        if (circle.Cx < startpoint.X && circle.Cy >= startpoint.Y)
                        {
                            circle.Direction = d1;//CW
                        }
                        else if (circle.Cx > startpoint.X && circle.Cy <= startpoint.Y)
                        {
                            circle.Direction = d2;//CCW
                        }
                    }

                    if (indirv.I < 0 && indirv.J >= 0)
                    {
                        if (circle.Cx >= startpoint.X && circle.Cy > startpoint.Y)
                        {
                            circle.Direction = d1;//CW
                        }
                        else if (circle.Cx <= startpoint.X && circle.Cy < startpoint.Y)
                        {
                            circle.Direction = d2;//CCW
                        }
                    }

                    if (indirv.I >= 0 && indirv.J > 0)
                    {
                        if (circle.Cx > startpoint.X && circle.Cy <= startpoint.Y)
                        {
                            circle.Direction = d1;//CW
                        }
                        else if (circle.Cx < startpoint.X && circle.Cy >= startpoint.Y)
                        {
                            circle.Direction = d2;//CCW
                        }
                    }

                    if (indirv.I > 0 && indirv.J <= 0)
                    {
                        if (circle.Cx <= startpoint.X && circle.Cy < startpoint.Y)
                        {
                            circle.Direction = d1;//CW
                        }
                        else if (circle.Cx >= startpoint.X && circle.Cy > startpoint.Y)
                        {
                            circle.Direction = d2;//CCW
                        }
                    }
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }

            return circle;
        }

        private static Feedrate parse_apt_fedrate(string line)
        {
            Feedrate fedrate = new Feedrate();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    string[] substrings = Regex.Split(line.Substring("FEDRAT/".Length), ",");
                    fedrate.Fedrat = Convert.ToDouble(substrings[1].Replace(" ", string.Empty));
                    fedrate.Unit = substrings[0].Replace(" ", string.Empty);
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return fedrate;
        }

        private static SpindleSpeed parse_apt_spinlespeed(string line)
        {
            SpindleSpeed spindlespeed = new SpindleSpeed();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    string[] substrings = line.Split(',');
                    spindlespeed.Spindlespeed = Convert.ToDouble(substrings[1].Replace(" ", string.Empty));
                    spindlespeed.Direction = substrings[2].Replace(" ", string.Empty);
                    spindlespeed.Unit = substrings[0].Replace(" ", string.Empty);
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return spindlespeed;
        }

        private static Coolant parse_apt_coolant(string line)
        {
            Coolant coolant = new Coolant();
            switch (dt_flag)
            {
                case d_type.mastercam://apt line from mastercam
                    string foo = line.Substring("COOLNT/".Length).Replace(" ", string.Empty);
                    if (foo == "OFF")
                        coolant.Activation = false;
                    break;
                case d_type.ptc_creo://apt line from ptc creo
                    break;
                case d_type.siemens_nx://apt line from siemens nx
                    break;
                default:
                    break;
            }
            return coolant;
        }

        private static void apt_to_stepnc(MetaData metadata, string outname)
        {
            double multiplier = 1;

            STEPNCLib.AptStepMaker stnc = new STEPNCLib.AptStepMaker();
            STEPNCLib.Feature feature = new STEPNCLib.Feature();
            STEPNCLib.Process process = new STEPNCLib.Process();

            stnc.NewProjectWithCCandWP(metadata.PartNo.partno(), 1, "Main Workplan");//make new project
            //feature.OpenNewWorkpiece("mastercam");
            process.BlockRawpiece("mastercam block", 0, 0, 0, 70, 100, 50);

            //if (metadata.Units == "IN" || metadata.Units == "Inches")
            //    stnc.Inches();
            //else
            //    stnc.Millimeters();

            stnc.Millimeters();

            if (metadata.Multax.multax() == "ON")
                stnc.MultaxOn();

            stnc.CamModeOn();
            stnc.MultaxOn();

            stnc.SetModeMill();

            CutterTool[] tools = new CutterTool[metadata.CutterTools.Keys.Count];

            metadata.CutterTools.Values.CopyTo(tools, 0);

            for (int i = 0; i < tools.Length; i++)//define all tools
            {
                stnc.DefineTool(tools[i].Tparams.Diameter * multiplier, tools[i].Tparams.Diameter / 2 * multiplier, 10.0 * multiplier, 10.0 * multiplier, 1.0 * multiplier, 0.0, 45.0 * multiplier);
            }
            //stnc.Millimeters();
            foreach (MachineGroup machineGroup in metadata.MachineGroups)
            {
                stnc.NestWorkplan("Machine Group-" + machineGroup.ID.ToString());

                foreach (ToolpathGroup toolpahtGroup in machineGroup.Operations)
                {
                    stnc.LoadTool(toolpahtGroup.Tool);//load tool associated with the current operation
                    stnc.Workingstep("WS-" + toolpahtGroup.ID.ToString());

                    foreach (APT mchData in toolpahtGroup.MachiningData)
                    {
                        if (mchData is Rapid)
                        {
                            stnc.Rapid();
                        }
                        if (mchData is GoTo)
                        {
                            GoTo temp = mchData as GoTo;
                            stnc.GoToXYZ("point", temp.X * multiplier, temp.Y * multiplier, temp.Z * multiplier);
                            //Console.WriteLine("{0},{1},{2}",temp.X,temp.Y,temp.Z);
                        }
                        if (mchData is Circle)
                        {
                            Circle temp = mchData as Circle;
                            //Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", temp.X, temp.Y, temp.Z, temp.Cx, temp.Cy, temp.Cz, temp.Radius, temp.Direction);
                            stnc.ArcXYPlane("arc", temp.X * multiplier, temp.Y * multiplier, temp.Z * multiplier, temp.Cx * multiplier, temp.Cy * multiplier, temp.Cz * multiplier, temp.Radius * multiplier, temp.Direction);
                        }
                        if (mchData is Feedrate)
                        {
                            Feedrate temp = mchData as Feedrate;
                            stnc.Feedrate(temp.Fedrat);
                        }
                        if (mchData is SpindleSpeed)
                        {
                            SpindleSpeed temp = mchData as SpindleSpeed;
                            stnc.SpindleSpeed(temp.Spindlespeed);
                        }
                        if (mchData is Coolant)
                        {
                            Coolant temp = mchData as Coolant;
                            if (temp.Activation)
                                stnc.CoolantOn();
                            else
                                stnc.CoolantOff();
                        }
                    }
                }
                stnc.EndWorkplan();
            }
            //stnc.SaveFastAsModules(outname);
            stnc.SaveAsP21(outname);
            //stnc.SaveAsModules(outname);
            return;
        }
    }
}
