namespace Q1
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
            lbStudentIDText = new Label();
            lbStudentID = new Label();
            lbGet = new Label();
            txtNumber = new TextBox();
            label4 = new Label();
            btnGet = new Button();
            SuspendLayout();
            // 
            // lbStudentIDText
            // 
            lbStudentIDText.AutoSize = true;
            lbStudentIDText.Location = new Point(108, 56);
            lbStudentIDText.Name = "lbStudentIDText";
            lbStudentIDText.Size = new Size(62, 15);
            lbStudentIDText.TabIndex = 0;
            lbStudentIDText.Text = "StudentID:";
            // 
            // lbStudentID
            // 
            lbStudentID.AutoSize = true;
            lbStudentID.Location = new Point(176, 56);
            lbStudentID.Name = "lbStudentID";
            lbStudentID.Size = new Size(38, 15);
            lbStudentID.TabIndex = 1;
            lbStudentID.Text = "label2";
            // 
            // lbGet
            // 
            lbGet.AutoSize = true;
            lbGet.Location = new Point(65, 99);
            lbGet.Name = "lbGet";
            lbGet.Size = new Size(25, 15);
            lbGet.TabIndex = 2;
            lbGet.Text = "Get";
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(108, 96);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(100, 23);
            txtNumber.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(223, 99);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 4;
            label4.Text = "character(s)";
            // 
            // btnGet
            // 
            btnGet.Location = new Point(133, 148);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(75, 23);
            btnGet.TabIndex = 5;
            btnGet.Text = "Get";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 222);
            Controls.Add(btnGet);
            Controls.Add(label4);
            Controls.Add(txtNumber);
            Controls.Add(lbGet);
            Controls.Add(lbStudentID);
            Controls.Add(lbStudentIDText);
            Name = "Form1";
            Text = "DummyForm";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbStudentIDText;
        private Label lbStudentID;
        private Label lbGet;
        private TextBox txtNumber;
        private Label label4;
        private Button btnGet;
    }
}