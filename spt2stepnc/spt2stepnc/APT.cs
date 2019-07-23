using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spt2stepnc
{
        public abstract class APT { }

        public class PartNo : APT
        {
            private string label;
            public void partno(string label) { this.label = label; }
            public string partno() { return this.label; }
        }

        public class Units : APT
        {
            private string label;
            public void units(string label) { this.label = label; }
            public string units() { return this.label; }
        }

        public class Multax : APT
        {
            private string label;
            public void multax(string label) { this.label = label; }
            public string multax() { return this.label; }

        }

        public class Rapid : APT { }

        public class GoTo : APT
        {
            private double x = 0.0; private double y = 0.0; private double z = 0.0;//position

            public double X { get { return x; } set { x = value; } }
            public double Y { get { return y; } set { y = value; } }
            public double Z { get { return z; } set { z = value; } }

            public GoTo() { }

            public GoTo(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
        }

        public class Circle : APT
        {
            private double x = 0.0; private double y = 0.0; private double z = 0.0; //new position
            private double cx = 0.0; private double cy = 0.0; private double cz = 0.0; //center position
            private double radius;
            private bool dir;//cw or ccw

            public double X { get { return x; } set { x = value; } }
            public double Y { get { return y; } set { y = value; } }
            public double Z { get { return z; } set { z = value; } }
            public double Cx { get { return cx; } set { cx = value; } }
            public double Cy { get { return cy; } set { cy = value; } }
            public double Cz { get { return cz; } set { cz = value; } }
            public double Radius { get { return radius; } set { radius = value; } }
            public bool Direction { get { return dir; } set { dir = value; } }

            public Circle() { }
            public Circle(double x, double y, double z,
                double cx, double cy, double cz, double radius, bool direction)
            {
                this.x = x; this.y = y; this.z = z;
                this.cx = cx; this.cy = cy; this.cz = cz;
                this.radius = radius;
                dir = direction;
            }
        }

        public class Indirv : APT
        {
            private double i = 0.0; public double I { get { return i; } set { i = value; } }
            private double j = 0.0; public double J { get { return j; } set { j = value; } }
            private double k = 0.0; public double K { get { return k; } set { k = value; } }

            public Indirv() { }

            public Indirv(double i, double j, double k) { this.i = i; this.j = j; this.k = k; }
        }

        public class Feedrate : APT
        {
            private double fedrat = 0.0; public double Fedrat { get { return fedrat; } set { fedrat = value; } }
            private string unit = "MPM"; public string Unit { get { return unit; } set { unit = value; } }

            public Feedrate() { }

            public Feedrate(double fedrat, string unit) { this.fedrat = fedrat; this.unit = unit; }
        }

        public class SpindleSpeed : APT
        {
            private double spindleSpeed; public double Spindlespeed { get { return spindleSpeed; } set { spindleSpeed = value; } }
            private string sdir = "CLW"; public string Direction { get { return sdir; } set { sdir = value; } } //string type dir
            private bool bdir = false; public bool bDirection { get { return bdir; } set { bdir = value; } } //boolean type direction
            private string unit = "RPM"; public string Unit { get { return unit; } set { unit = value; } }

            public SpindleSpeed() { }

            public SpindleSpeed(double spindleSpeed, string direction, string unit) //speed with direction given by string
            {
                this.unit = unit;
                sdir = direction;
                this.spindleSpeed = spindleSpeed;
            }

            public SpindleSpeed(double spindleSpeed, bool direction, string unit) //speed with direction given by boolean
            {
                this.unit = unit;
                bdir = direction;
                this.spindleSpeed = spindleSpeed;
            }
        }

        public class Coolant : APT
        {
            private bool activation = true;

            public bool Activation { get { return activation; } set { activation = value; } }

            public Coolant() { }
            public Coolant(bool activation) { this.activation = activation; }
        }

        public class Cutter : APT
        {
            public double Diameter = 0.0;
            public double Length = 0.0;
        }

        public class LoadTL : APT { public int ID = -1; }

        public class TPrint : APT { public string Label = ""; }

}
