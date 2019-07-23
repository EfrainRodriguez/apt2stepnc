using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;

namespace spt2stepnc
{
    public partial class Main_Form : Form
    {
        string filename = null;
        public Main_Form()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            

        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software uses the stepnc.dll to create the STEP-NC data");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MastercamAPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            //textBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);

            filename = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
        }

        private void Btn_ToSTEPNC_Click(object sender, EventArgs e)
        {
            //Queue<string> lines = new Queue<string>(textBox1.Text.Split('\n'));
            Queue<string> lines = new Queue<string>(richTextBox1.Text.Split('\n'));


            if (filename == null)
                return;

            Parse_APT.MastercamApt_To_Stepnc(lines, filename);
            //textBox2.Text = System.IO.File.ReadAllText(filename + ".stpnc");

            try
            {
                richTextBox2.Text = System.IO.File.ReadAllText(filename + ".stpnc");
            }
            catch (FileNotFoundException)
            {
                richTextBox2.Text = System.IO.File.ReadAllText(filename + ".p28");
            }
            
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int lx, ly, sw, sh;

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Bt_clearAPT_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_clearSTEPNC_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = string.Empty;
        }

        private void Btn_saveAPT_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                sw.Write(richTextBox1.Text);

                sw.Close();

            }
        }

        private void Btn_saveSTEPNC_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog2.FileName);

                sw.Write(richTextBox2.Text);

                sw.Close();

            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Panel4_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void SaveAPTDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                sw.Write(richTextBox1.Text);

                sw.Close();

            }
        }

        private void SaveSTEPNCDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog2.FileName);

                sw.Write(richTextBox2.Text);

                sw.Close();

            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            //textBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);

            filename = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            restoring.Visible = false;
            maximize.Visible = true;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            restoring.Visible = true;
            maximize.Visible = false;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
    }
}
