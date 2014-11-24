namespace ScripterNetDemo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_Example9 = new System.Windows.Forms.Button();
            this.b_Example8 = new System.Windows.Forms.Button();
            this.b_Example7 = new System.Windows.Forms.Button();
            this.b_Example_6 = new System.Windows.Forms.Button();
            this.b_Example5 = new System.Windows.Forms.Button();
            this.b_Example4 = new System.Windows.Forms.Button();
            this.b_Example3 = new System.Windows.Forms.Button();
            this.b_Example2 = new System.Windows.Forms.Button();
            this.b_Example1 = new System.Windows.Forms.Button();
            this.tb_Code = new System.Windows.Forms.TextBox();
            this.rtb_Info = new System.Windows.Forms.RichTextBox();
            this.b_Execute = new System.Windows.Forms.Button();
            this.lb_Console = new System.Windows.Forms.ListBox();
            this.b_Terminate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.b_ConsoleClear = new System.Windows.Forms.Button();
            this.OutputTimer = new System.Windows.Forms.Timer(this.components);
            this.b_ResetVM = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(948, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_Example9);
            this.groupBox1.Controls.Add(this.b_Example8);
            this.groupBox1.Controls.Add(this.b_Example7);
            this.groupBox1.Controls.Add(this.b_Example_6);
            this.groupBox1.Controls.Add(this.b_Example5);
            this.groupBox1.Controls.Add(this.b_Example4);
            this.groupBox1.Controls.Add(this.b_Example3);
            this.groupBox1.Controls.Add(this.b_Example2);
            this.groupBox1.Controls.Add(this.b_Example1);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 558);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Examples";
            // 
            // b_Example9
            // 
            this.b_Example9.Location = new System.Drawing.Point(6, 294);
            this.b_Example9.Name = "b_Example9";
            this.b_Example9.Size = new System.Drawing.Size(152, 28);
            this.b_Example9.TabIndex = 8;
            this.b_Example9.Text = "Simple A* pathfinding";
            this.b_Example9.UseVisualStyleBackColor = true;
            this.b_Example9.Click += new System.EventHandler(this.b_Example9_Click);
            // 
            // b_Example8
            // 
            this.b_Example8.Location = new System.Drawing.Point(6, 158);
            this.b_Example8.Name = "b_Example8";
            this.b_Example8.Size = new System.Drawing.Size(152, 28);
            this.b_Example8.TabIndex = 7;
            this.b_Example8.Text = "Bubble sort";
            this.b_Example8.UseVisualStyleBackColor = true;
            this.b_Example8.Click += new System.EventHandler(this.b_Example8_Click);
            // 
            // b_Example7
            // 
            this.b_Example7.Location = new System.Drawing.Point(6, 56);
            this.b_Example7.Name = "b_Example7";
            this.b_Example7.Size = new System.Drawing.Size(152, 28);
            this.b_Example7.TabIndex = 6;
            this.b_Example7.Text = "Variable scopes";
            this.b_Example7.UseVisualStyleBackColor = true;
            this.b_Example7.Click += new System.EventHandler(this.b_Example7_Click);
            // 
            // b_Example_6
            // 
            this.b_Example_6.Location = new System.Drawing.Point(6, 124);
            this.b_Example_6.Name = "b_Example_6";
            this.b_Example_6.Size = new System.Drawing.Size(152, 28);
            this.b_Example_6.TabIndex = 5;
            this.b_Example_6.Text = "Switch falling through";
            this.b_Example_6.UseVisualStyleBackColor = true;
            this.b_Example_6.Click += new System.EventHandler(this.b_Example_6_Click);
            // 
            // b_Example5
            // 
            this.b_Example5.Location = new System.Drawing.Point(6, 90);
            this.b_Example5.Name = "b_Example5";
            this.b_Example5.Size = new System.Drawing.Size(152, 28);
            this.b_Example5.TabIndex = 4;
            this.b_Example5.Text = "Break as a function";
            this.b_Example5.UseVisualStyleBackColor = true;
            this.b_Example5.Click += new System.EventHandler(this.b_Example5_Click);
            // 
            // b_Example4
            // 
            this.b_Example4.Location = new System.Drawing.Point(6, 260);
            this.b_Example4.Name = "b_Example4";
            this.b_Example4.Size = new System.Drawing.Size(152, 28);
            this.b_Example4.TabIndex = 3;
            this.b_Example4.Text = "Form";
            this.b_Example4.UseVisualStyleBackColor = true;
            this.b_Example4.Click += new System.EventHandler(this.b_Example4_Click);
            // 
            // b_Example3
            // 
            this.b_Example3.Location = new System.Drawing.Point(6, 226);
            this.b_Example3.Name = "b_Example3";
            this.b_Example3.Size = new System.Drawing.Size(152, 28);
            this.b_Example3.TabIndex = 2;
            this.b_Example3.Text = "Quicksort";
            this.b_Example3.UseVisualStyleBackColor = true;
            this.b_Example3.Click += new System.EventHandler(this.b_Example3_Click);
            // 
            // b_Example2
            // 
            this.b_Example2.Location = new System.Drawing.Point(6, 192);
            this.b_Example2.Name = "b_Example2";
            this.b_Example2.Size = new System.Drawing.Size(152, 28);
            this.b_Example2.TabIndex = 1;
            this.b_Example2.Text = "File output";
            this.b_Example2.UseVisualStyleBackColor = true;
            this.b_Example2.Click += new System.EventHandler(this.b_Example2_Click);
            // 
            // b_Example1
            // 
            this.b_Example1.Location = new System.Drawing.Point(6, 22);
            this.b_Example1.Name = "b_Example1";
            this.b_Example1.Size = new System.Drawing.Size(152, 28);
            this.b_Example1.TabIndex = 0;
            this.b_Example1.Text = ".Net static functions";
            this.b_Example1.UseVisualStyleBackColor = true;
            this.b_Example1.Click += new System.EventHandler(this.b_Example1_Click);
            // 
            // tb_Code
            // 
            this.tb_Code.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Code.Location = new System.Drawing.Point(184, 31);
            this.tb_Code.Multiline = true;
            this.tb_Code.Name = "tb_Code";
            this.tb_Code.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Code.Size = new System.Drawing.Size(580, 280);
            this.tb_Code.TabIndex = 2;
            this.tb_Code.Text = "int j = 0;\r\nfor (int i = 0; i < 10; i++)\r\n    if (j == 0) print(0);\r\n    elseif (" +
    "j == 1) print(1);\r\n    elseif (j == 2) print(2);\r\n    else print(3);";
            this.tb_Code.WordWrap = false;
            this.tb_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Code_KeyDown);
            // 
            // rtb_Info
            // 
            this.rtb_Info.Location = new System.Drawing.Point(770, 31);
            this.rtb_Info.Name = "rtb_Info";
            this.rtb_Info.Size = new System.Drawing.Size(166, 96);
            this.rtb_Info.TabIndex = 3;
            this.rtb_Info.Text = "";
            // 
            // b_Execute
            // 
            this.b_Execute.Location = new System.Drawing.Point(770, 245);
            this.b_Execute.Name = "b_Execute";
            this.b_Execute.Size = new System.Drawing.Size(166, 64);
            this.b_Execute.TabIndex = 4;
            this.b_Execute.Text = "Execute";
            this.b_Execute.UseVisualStyleBackColor = true;
            this.b_Execute.Click += new System.EventHandler(this.b_Execute_Click);
            // 
            // lb_Console
            // 
            this.lb_Console.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Console.FormattingEnabled = true;
            this.lb_Console.HorizontalScrollbar = true;
            this.lb_Console.ItemHeight = 20;
            this.lb_Console.Location = new System.Drawing.Point(6, 21);
            this.lb_Console.Name = "lb_Console";
            this.lb_Console.Size = new System.Drawing.Size(740, 204);
            this.lb_Console.TabIndex = 5;
            this.lb_Console.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_Console_MouseDoubleClick);
            // 
            // b_Terminate
            // 
            this.b_Terminate.Location = new System.Drawing.Point(770, 211);
            this.b_Terminate.Name = "b_Terminate";
            this.b_Terminate.Size = new System.Drawing.Size(80, 28);
            this.b_Terminate.TabIndex = 6;
            this.b_Terminate.Text = "Terminate";
            this.b_Terminate.UseVisualStyleBackColor = true;
            this.b_Terminate.Click += new System.EventHandler(this.b_Terminate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(770, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 72);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Infinite loop control";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(149, 22);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max. iterations:";
            // 
            // b_ConsoleClear
            // 
            this.b_ConsoleClear.Location = new System.Drawing.Point(6, 232);
            this.b_ConsoleClear.Name = "b_ConsoleClear";
            this.b_ConsoleClear.Size = new System.Drawing.Size(740, 28);
            this.b_ConsoleClear.TabIndex = 8;
            this.b_ConsoleClear.Text = "Clear output";
            this.b_ConsoleClear.UseVisualStyleBackColor = true;
            this.b_ConsoleClear.Click += new System.EventHandler(this.b_ConsoleClear_Click);
            // 
            // OutputTimer
            // 
            this.OutputTimer.Enabled = true;
            this.OutputTimer.Tick += new System.EventHandler(this.OutputTimer_Tick);
            // 
            // b_ResetVM
            // 
            this.b_ResetVM.Location = new System.Drawing.Point(856, 211);
            this.b_ResetVM.Name = "b_ResetVM";
            this.b_ResetVM.Size = new System.Drawing.Size(80, 28);
            this.b_ResetVM.TabIndex = 9;
            this.b_ResetVM.Text = "Reset VM";
            this.b_ResetVM.UseVisualStyleBackColor = true;
            this.b_ResetVM.Click += new System.EventHandler(this.b_ResetVM_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lb_Console);
            this.groupBox3.Controls.Add(this.b_ConsoleClear);
            this.groupBox3.Location = new System.Drawing.Point(184, 318);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(752, 266);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 598);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.b_ResetVM);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.b_Terminate);
            this.Controls.Add(this.b_Execute);
            this.Controls.Add(this.rtb_Info);
            this.Controls.Add(this.tb_Code);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Scripter.Net Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_Code;
        private System.Windows.Forms.RichTextBox rtb_Info;
        private System.Windows.Forms.Button b_Execute;
        private System.Windows.Forms.Button b_Terminate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_ConsoleClear;
        private System.Windows.Forms.Timer OutputTimer;
        private System.Windows.Forms.ListBox lb_Console;
        private System.Windows.Forms.Button b_Example1;
        private System.Windows.Forms.Button b_Example2;
        private System.Windows.Forms.Button b_Example3;
        private System.Windows.Forms.Button b_ResetVM;
        private System.Windows.Forms.Button b_Example4;
        private System.Windows.Forms.Button b_Example5;
        private System.Windows.Forms.Button b_Example_6;
        private System.Windows.Forms.Button b_Example7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button b_Example8;
        private System.Windows.Forms.Button b_Example9;
    }
}

