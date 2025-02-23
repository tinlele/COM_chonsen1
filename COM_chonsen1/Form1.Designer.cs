namespace COM_chonsen1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            comboBox3 = new ComboBox();
            progressBar1 = new ProgressBar();
            sent = new GroupBox();
            button1 = new Button();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            button2 = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            sent.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 85);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(225, 23);
            comboBox1.TabIndex = 0;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "9600", "115200" });
            comboBox3.Location = new Point(270, 85);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(225, 23);
            comboBox3.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(533, 85);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(270, 23);
            progressBar1.TabIndex = 3;
            // 
            // sent
            // 
            sent.Controls.Add(button1);
            sent.Controls.Add(textBox1);
            sent.Location = new Point(83, 197);
            sent.Name = "sent";
            sent.Size = new Size(200, 124);
            sent.TabIndex = 4;
            sent.TabStop = false;
            sent.Text = "Sent here";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(119, 100);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(6, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 72);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Location = new Point(385, 197);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 124);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Received here";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(119, 100);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Read";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(6, 22);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(188, 72);
            textBox2.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new Point(665, 147);
            button3.Name = "button3";
            button3.Size = new Size(75, 49);
            button3.TabIndex = 7;
            button3.Text = "Open port";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(665, 230);
            button4.Name = "button4";
            button4.Size = new Size(75, 50);
            button4.TabIndex = 8;
            button4.Text = "Close port";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 9;
            label1.Text = "Port names";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 67);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 10;
            label2.Text = "Baud Rate";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 67);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 11;
            label3.Text = "Status";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 349);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(groupBox1);
            Controls.Add(sent);
            Controls.Add(progressBar1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Serial communication";
            Load += Form1_Load;
            sent.ResumeLayout(false);
            sent.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private ProgressBar progressBar1;
        private GroupBox sent;
        private TextBox textBox1;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private TextBox textBox2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
