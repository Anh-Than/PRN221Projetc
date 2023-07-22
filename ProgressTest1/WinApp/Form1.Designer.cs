namespace WinApp
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
            this.gboFilter = new System.Windows.Forms.GroupBox();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.lbPosition = new System.Windows.Forms.Label();
            this.optFemale = new System.Windows.Forms.RadioButton();
            this.optMale = new System.Windows.Forms.RadioButton();
            this.optMaleFemale = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.gboFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // gboFilter
            // 
            this.gboFilter.Controls.Add(this.cboPosition);
            this.gboFilter.Controls.Add(this.lbPosition);
            this.gboFilter.Controls.Add(this.optFemale);
            this.gboFilter.Controls.Add(this.optMale);
            this.gboFilter.Controls.Add(this.optMaleFemale);
            this.gboFilter.Controls.Add(this.txtName);
            this.gboFilter.Controls.Add(this.lbName);
            this.gboFilter.Location = new System.Drawing.Point(32, 37);
            this.gboFilter.Name = "gboFilter";
            this.gboFilter.Size = new System.Drawing.Size(273, 353);
            this.gboFilter.TabIndex = 0;
            this.gboFilter.TabStop = false;
            this.gboFilter.Text = "Filter";
            // 
            // cboPosition
            // 
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(69, 139);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(121, 23);
            this.cboPosition.TabIndex = 6;
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.Location = new System.Drawing.Point(16, 142);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(50, 15);
            this.lbPosition.TabIndex = 5;
            this.lbPosition.Text = "Position";
            // 
            // optFemale
            // 
            this.optFemale.AutoSize = true;
            this.optFemale.Location = new System.Drawing.Point(179, 96);
            this.optFemale.Name = "optFemale";
            this.optFemale.Size = new System.Drawing.Size(63, 19);
            this.optFemale.TabIndex = 4;
            this.optFemale.TabStop = true;
            this.optFemale.Text = "Female";
            this.optFemale.UseVisualStyleBackColor = true;
            // 
            // optMale
            // 
            this.optMale.AutoSize = true;
            this.optMale.Location = new System.Drawing.Point(116, 96);
            this.optMale.Name = "optMale";
            this.optMale.Size = new System.Drawing.Size(51, 19);
            this.optMale.TabIndex = 3;
            this.optMale.TabStop = true;
            this.optMale.Text = "Male";
            this.optMale.UseVisualStyleBackColor = true;
            // 
            // optMaleFemale
            // 
            this.optMaleFemale.AutoSize = true;
            this.optMaleFemale.Location = new System.Drawing.Point(16, 96);
            this.optMaleFemale.Name = "optMaleFemale";
            this.optMaleFemale.Size = new System.Drawing.Size(94, 19);
            this.optMaleFemale.TabIndex = 2;
            this.optMaleFemale.TabStop = true;
            this.optMaleFemale.Text = "Male/Female";
            this.optMaleFemale.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(69, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 23);
            this.txtName.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(16, 37);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 15);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(333, 37);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowTemplate.Height = 25;
            this.dgvEmployee.Size = new System.Drawing.Size(446, 353);
            this.dgvEmployee.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.gboFilter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gboFilter.ResumeLayout(false);
            this.gboFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gboFilter;
        private ComboBox cboPosition;
        private Label lbPosition;
        private RadioButton optFemale;
        private RadioButton optMale;
        private RadioButton optMaleFemale;
        private TextBox txtName;
        private Label lbName;
        private DataGridView dgvEmployee;
    }
}