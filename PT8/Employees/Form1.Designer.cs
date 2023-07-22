namespace Employees
{
    partial class Employees
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
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.gboCurrentEmployee = new System.Windows.Forms.GroupBox();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.optFemale = new System.Windows.Forms.RadioButton();
            this.optMale = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbPosition = new System.Windows.Forms.Label();
            this.lbDOB = new System.Windows.Forms.Label();
            this.lbSex = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.gboCurrentEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 12);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowTemplate.Height = 25;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(688, 611);
            this.dgvEmployees.TabIndex = 0;
            // 
            // gboCurrentEmployee
            // 
            this.gboCurrentEmployee.Controls.Add(this.cboPosition);
            this.gboCurrentEmployee.Controls.Add(this.dtDOB);
            this.gboCurrentEmployee.Controls.Add(this.optFemale);
            this.gboCurrentEmployee.Controls.Add(this.optMale);
            this.gboCurrentEmployee.Controls.Add(this.txtName);
            this.gboCurrentEmployee.Controls.Add(this.txtID);
            this.gboCurrentEmployee.Controls.Add(this.btnEdit);
            this.gboCurrentEmployee.Controls.Add(this.btnAdd);
            this.gboCurrentEmployee.Controls.Add(this.btnRefresh);
            this.gboCurrentEmployee.Controls.Add(this.lbPosition);
            this.gboCurrentEmployee.Controls.Add(this.lbDOB);
            this.gboCurrentEmployee.Controls.Add(this.lbSex);
            this.gboCurrentEmployee.Controls.Add(this.lbName);
            this.gboCurrentEmployee.Controls.Add(this.lbID);
            this.gboCurrentEmployee.Location = new System.Drawing.Point(731, 12);
            this.gboCurrentEmployee.Name = "gboCurrentEmployee";
            this.gboCurrentEmployee.Size = new System.Drawing.Size(477, 611);
            this.gboCurrentEmployee.TabIndex = 1;
            this.gboCurrentEmployee.TabStop = false;
            this.gboCurrentEmployee.Text = "Current Employee";
            // 
            // cboPosition
            // 
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(131, 344);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(121, 23);
            this.cboPosition.TabIndex = 13;
            // 
            // dtDOB
            // 
            this.dtDOB.Location = new System.Drawing.Point(131, 261);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.Size = new System.Drawing.Size(200, 23);
            this.dtDOB.TabIndex = 12;
            // 
            // optFemale
            // 
            this.optFemale.AutoSize = true;
            this.optFemale.Location = new System.Drawing.Point(254, 188);
            this.optFemale.Name = "optFemale";
            this.optFemale.Size = new System.Drawing.Size(63, 19);
            this.optFemale.TabIndex = 11;
            this.optFemale.TabStop = true;
            this.optFemale.Text = "Female";
            this.optFemale.UseVisualStyleBackColor = true;
            // 
            // optMale
            // 
            this.optMale.AutoSize = true;
            this.optMale.Location = new System.Drawing.Point(131, 188);
            this.optMale.Name = "optMale";
            this.optMale.Size = new System.Drawing.Size(51, 19);
            this.optMale.TabIndex = 10;
            this.optMale.TabStop = true;
            this.optMale.Text = "Male";
            this.optMale.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 120);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(285, 23);
            this.txtName.TabIndex = 9;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(131, 56);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 23);
            this.txtID.TabIndex = 8;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(368, 456);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(211, 456);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(46, 456);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.Location = new System.Drawing.Point(46, 347);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(50, 15);
            this.lbPosition.TabIndex = 4;
            this.lbPosition.Text = "Position";
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Location = new System.Drawing.Point(46, 267);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(31, 15);
            this.lbDOB.TabIndex = 3;
            this.lbDOB.Text = "DOB";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Location = new System.Drawing.Point(46, 190);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(25, 15);
            this.lbSex.TabIndex = 2;
            this.lbSex.Text = "Sex";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(46, 123);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 15);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Name";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(46, 59);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 15);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 635);
            this.Controls.Add(this.gboCurrentEmployee);
            this.Controls.Add(this.dgvEmployees);
            this.Name = "Employees";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Employees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.gboCurrentEmployee.ResumeLayout(false);
            this.gboCurrentEmployee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvEmployees;
        private GroupBox gboCurrentEmployee;
        private ComboBox cboPosition;
        private DateTimePicker dtDOB;
        private RadioButton optFemale;
        private RadioButton optMale;
        private TextBox txtName;
        private TextBox txtID;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnRefresh;
        private Label lbPosition;
        private Label lbDOB;
        private Label lbSex;
        private Label lbName;
        private Label lbID;
    }
}