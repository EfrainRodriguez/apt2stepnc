namespace spt2stepnc
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ToSTEPNC = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.close = new System.Windows.Forms.PictureBox();
            this.restoring = new System.Windows.Forms.PictureBox();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.maximize = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAPTDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSTEPNCDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mastercamAPTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siemensNXAPTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pTCCreoAPTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_clearAPT = new System.Windows.Forms.Button();
            this.btn_clearSTEPNC = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_saveAPT = new System.Windows.Forms.Button();
            this.btn_saveSTEPNC = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btn_ToSTEPNC
            // 
            resources.ApplyResources(this.btn_ToSTEPNC, "btn_ToSTEPNC");
            this.btn_ToSTEPNC.Name = "btn_ToSTEPNC";
            this.btn_ToSTEPNC.UseVisualStyleBackColor = true;
            this.btn_ToSTEPNC.Click += new System.EventHandler(this.Btn_ToSTEPNC_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // close
            // 
            resources.ApplyResources(this.close, "close");
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Name = "close";
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // restoring
            // 
            resources.ApplyResources(this.restoring, "restoring");
            this.restoring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restoring.Name = "restoring";
            this.restoring.TabStop = false;
            this.restoring.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // minimize
            // 
            resources.ApplyResources(this.minimize, "minimize");
            this.minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize.Name = "minimize";
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.maximize);
            this.panel4.Controls.Add(this.restoring);
            this.panel4.Controls.Add(this.close);
            this.panel4.Controls.Add(this.minimize);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel4_MouseMove);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // maximize
            // 
            resources.ApplyResources(this.maximize, "maximize");
            this.maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximize.Name = "maximize";
            this.maximize.TabStop = false;
            this.maximize.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAPTDataToolStripMenuItem,
            this.saveSTEPNCDataToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            // 
            // saveAPTDataToolStripMenuItem
            // 
            this.saveAPTDataToolStripMenuItem.Name = "saveAPTDataToolStripMenuItem";
            resources.ApplyResources(this.saveAPTDataToolStripMenuItem, "saveAPTDataToolStripMenuItem");
            this.saveAPTDataToolStripMenuItem.Click += new System.EventHandler(this.SaveAPTDataToolStripMenuItem_Click);
            // 
            // saveSTEPNCDataToolStripMenuItem
            // 
            this.saveSTEPNCDataToolStripMenuItem.Name = "saveSTEPNCDataToolStripMenuItem";
            resources.ApplyResources(this.saveSTEPNCDataToolStripMenuItem, "saveSTEPNCDataToolStripMenuItem");
            this.saveSTEPNCDataToolStripMenuItem.Click += new System.EventHandler(this.SaveSTEPNCDataToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastercamAPTToolStripMenuItem,
            this.siemensNXAPTToolStripMenuItem,
            this.pTCCreoAPTToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            // 
            // mastercamAPTToolStripMenuItem
            // 
            this.mastercamAPTToolStripMenuItem.Name = "mastercamAPTToolStripMenuItem";
            resources.ApplyResources(this.mastercamAPTToolStripMenuItem, "mastercamAPTToolStripMenuItem");
            this.mastercamAPTToolStripMenuItem.Click += new System.EventHandler(this.MastercamAPTToolStripMenuItem_Click);
            // 
            // siemensNXAPTToolStripMenuItem
            // 
            this.siemensNXAPTToolStripMenuItem.Name = "siemensNXAPTToolStripMenuItem";
            resources.ApplyResources(this.siemensNXAPTToolStripMenuItem, "siemensNXAPTToolStripMenuItem");
            // 
            // pTCCreoAPTToolStripMenuItem
            // 
            this.pTCCreoAPTToolStripMenuItem.Name = "pTCCreoAPTToolStripMenuItem";
            resources.ApplyResources(this.pTCCreoAPTToolStripMenuItem, "pTCCreoAPTToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // bt_clearAPT
            // 
            resources.ApplyResources(this.bt_clearAPT, "bt_clearAPT");
            this.bt_clearAPT.Name = "bt_clearAPT";
            this.bt_clearAPT.UseVisualStyleBackColor = true;
            this.bt_clearAPT.Click += new System.EventHandler(this.Bt_clearAPT_Click);
            // 
            // btn_clearSTEPNC
            // 
            resources.ApplyResources(this.btn_clearSTEPNC, "btn_clearSTEPNC");
            this.btn_clearSTEPNC.Name = "btn_clearSTEPNC";
            this.btn_clearSTEPNC.UseVisualStyleBackColor = true;
            this.btn_clearSTEPNC.Click += new System.EventHandler(this.Btn_clearSTEPNC_Click);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // btn_saveAPT
            // 
            resources.ApplyResources(this.btn_saveAPT, "btn_saveAPT");
            this.btn_saveAPT.Name = "btn_saveAPT";
            this.btn_saveAPT.UseVisualStyleBackColor = true;
            this.btn_saveAPT.Click += new System.EventHandler(this.Btn_saveAPT_Click);
            // 
            // btn_saveSTEPNC
            // 
            resources.ApplyResources(this.btn_saveSTEPNC, "btn_saveSTEPNC");
            this.btn_saveSTEPNC.Name = "btn_saveSTEPNC";
            this.btn_saveSTEPNC.UseVisualStyleBackColor = true;
            this.btn_saveSTEPNC.Click += new System.EventHandler(this.Btn_saveSTEPNC_Click);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // richTextBox2
            // 
            resources.ApplyResources(this.richTextBox2, "richTextBox2");
            this.richTextBox2.Name = "richTextBox2";
            // 
            // saveFileDialog2
            // 
            resources.ApplyResources(this.saveFileDialog2, "saveFileDialog2");
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Main_Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_saveSTEPNC);
            this.Controls.Add(this.btn_saveAPT);
            this.Controls.Add(this.btn_clearSTEPNC);
            this.Controls.Add(this.bt_clearAPT);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_ToSTEPNC);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ToSTEPNC;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox restoring;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox maximize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mastercamAPTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siemensNXAPTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTCCreoAPTToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_clearAPT;
        private System.Windows.Forms.Button btn_clearSTEPNC;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_saveAPT;
        private System.Windows.Forms.Button btn_saveSTEPNC;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAPTDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSTEPNCDataToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

