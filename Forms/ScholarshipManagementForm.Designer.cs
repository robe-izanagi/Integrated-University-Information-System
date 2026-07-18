namespace IntegratedUniversityInformationSystem.Forms
{
    partial class ScholarshipManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScholarshipManagementForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSelectInfo = new System.Windows.Forms.Label();
            this.dgvScholarships = new System.Windows.Forms.DataGridView();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblScholarshipName = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.txtScholarshipName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDateAwarded = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblFields = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtpDateAwarded = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.cmbSortColumn = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblPrivateSummary = new System.Windows.Forms.Label();
            this.lblPrivate = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblTotalScholarshipSummary = new System.Windows.Forms.Label();
            this.lblTotalScholarship = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblGovernmentSummary = new System.Windows.Forms.Label();
            this.lblGovernment = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblAthleticSummary = new System.Windows.Forms.Label();
            this.lblAthletic = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblAcademicSummary = new System.Windows.Forms.Label();
            this.lblAcademic = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTopContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholarships)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panelTopContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.White;
            this.cmbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Academic",
            "Athletic",
            "Government",
            "Private"});
            this.cmbType.Location = new System.Drawing.Point(14, 231);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(275, 28);
            this.cmbType.TabIndex = 80;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.White;
            this.lblAdd.Location = new System.Drawing.Point(129, 9);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(36, 18);
            this.lblAdd.TabIndex = 60;
            this.lblAdd.Text = "Add";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(254)))));
            this.lblUpdate.Location = new System.Drawing.Point(44, 9);
            this.lblUpdate.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(61, 18);
            this.lblUpdate.TabIndex = 60;
            this.lblUpdate.Text = "Update";
            this.lblUpdate.Click += new System.EventHandler(this.lblUpdate_Click);
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.ForeColor = System.Drawing.Color.Red;
            this.lblDelete.Location = new System.Drawing.Point(42, 8);
            this.lblDelete.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(56, 18);
            this.lblDelete.TabIndex = 60;
            this.lblDelete.Text = "Delete";
            this.lblDelete.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // pbRefresh
            // 
            this.pbRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pbRefresh.Image")));
            this.pbRefresh.Location = new System.Drawing.Point(932, 135);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(29, 22);
            this.pbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRefresh.TabIndex = 60;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(5, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(329, 19);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSelectInfo
            // 
            this.lblSelectInfo.AutoSize = true;
            this.lblSelectInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectInfo.ForeColor = System.Drawing.Color.Black;
            this.lblSelectInfo.Location = new System.Drawing.Point(347, 641);
            this.lblSelectInfo.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblSelectInfo.Name = "lblSelectInfo";
            this.lblSelectInfo.Size = new System.Drawing.Size(206, 18);
            this.lblSelectInfo.TabIndex = 57;
            this.lblSelectInfo.Text = "Select a row on the table first: ";
            // 
            // dgvScholarships
            // 
            this.dgvScholarships.BackgroundColor = System.Drawing.Color.White;
            this.dgvScholarships.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScholarships.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScholarships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScholarships.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScholarships.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvScholarships.Location = new System.Drawing.Point(332, 167);
            this.dgvScholarships.Name = "dgvScholarships";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScholarships.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScholarships.Size = new System.Drawing.Size(629, 472);
            this.dgvScholarships.TabIndex = 44;
            this.dgvScholarships.SelectionChanged += new System.EventHandler(this.dgvScholarships_SelectionChanged);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.ForeColor = System.Drawing.Color.Black;
            this.lblRemarks.Location = new System.Drawing.Point(140, 422);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(85, 20);
            this.lblRemarks.TabIndex = 75;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(147, 445);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(142, 26);
            this.txtRemarks.TabIndex = 74;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(12, 420);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 20);
            this.lblStatus.TabIndex = 73;
            this.lblStatus.Text = "Status:";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiryDate.ForeColor = System.Drawing.Color.Black;
            this.lblExpiryDate.Location = new System.Drawing.Point(12, 366);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(106, 20);
            this.lblExpiryDate.TabIndex = 71;
            this.lblExpiryDate.Text = "Expiry Date:";
            // 
            // lblScholarshipName
            // 
            this.lblScholarshipName.AutoSize = true;
            this.lblScholarshipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScholarshipName.ForeColor = System.Drawing.Color.Black;
            this.lblScholarshipName.Location = new System.Drawing.Point(12, 156);
            this.lblScholarshipName.Name = "lblScholarshipName";
            this.lblScholarshipName.Size = new System.Drawing.Size(159, 20);
            this.lblScholarshipName.TabIndex = 39;
            this.lblScholarshipName.Text = "Scholarship Name:";
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.ForeColor = System.Drawing.Color.Black;
            this.lblStudent.Location = new System.Drawing.Point(13, 102);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(78, 20);
            this.lblStudent.TabIndex = 31;
            this.lblStudent.Text = "Student:";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(15, 285);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(274, 26);
            this.txtAmount.TabIndex = 69;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Location = new System.Drawing.Point(12, 262);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(76, 20);
            this.lblAmount.TabIndex = 41;
            this.lblAmount.Text = "Amount:";
            // 
            // cmbStudent
            // 
            this.cmbStudent.BackColor = System.Drawing.Color.White;
            this.cmbStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbStudent.Location = new System.Drawing.Point(15, 125);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(274, 28);
            this.cmbStudent.TabIndex = 38;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(144, 76);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(145, 26);
            this.txtID.TabIndex = 28;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(12, 82);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(132, 20);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "Scholarship ID:";
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.ForeColor = System.Drawing.Color.Black;
            this.lblClear.Location = new System.Drawing.Point(126, 9);
            this.lblClear.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(48, 18);
            this.lblClear.TabIndex = 60;
            this.lblClear.Text = "Clear";
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // txtScholarshipName
            // 
            this.txtScholarshipName.BackColor = System.Drawing.Color.White;
            this.txtScholarshipName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScholarshipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScholarshipName.Location = new System.Drawing.Point(15, 179);
            this.txtScholarshipName.Name = "txtScholarshipName";
            this.txtScholarshipName.Size = new System.Drawing.Size(274, 26);
            this.txtScholarshipName.TabIndex = 79;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.Black;
            this.lblType.Location = new System.Drawing.Point(10, 208);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(52, 20);
            this.lblType.TabIndex = 63;
            this.lblType.Text = "Type:";
            // 
            // lblDateAwarded
            // 
            this.lblDateAwarded.AutoSize = true;
            this.lblDateAwarded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAwarded.ForeColor = System.Drawing.Color.Black;
            this.lblDateAwarded.Location = new System.Drawing.Point(12, 314);
            this.lblDateAwarded.Name = "lblDateAwarded";
            this.lblDateAwarded.Size = new System.Drawing.Size(128, 20);
            this.lblDateAwarded.TabIndex = 65;
            this.lblDateAwarded.Text = "Date Awarded:";
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.panel11);
            this.panelInput.Controls.Add(this.lblFields);
            this.panelInput.Controls.Add(this.panel3);
            this.panelInput.Controls.Add(this.dtpExpiryDate);
            this.panelInput.Controls.Add(this.panel2);
            this.panelInput.Controls.Add(this.dtpDateAwarded);
            this.panelInput.Controls.Add(this.panel5);
            this.panelInput.Controls.Add(this.panel4);
            this.panelInput.Controls.Add(this.cmbStatus);
            this.panelInput.Controls.Add(this.cmbType);
            this.panelInput.Controls.Add(this.txtScholarshipName);
            this.panelInput.Controls.Add(this.lblRemarks);
            this.panelInput.Controls.Add(this.txtRemarks);
            this.panelInput.Controls.Add(this.lblStatus);
            this.panelInput.Controls.Add(this.lblExpiryDate);
            this.panelInput.Controls.Add(this.txtAmount);
            this.panelInput.Controls.Add(this.lblDateAwarded);
            this.panelInput.Controls.Add(this.lblType);
            this.panelInput.Controls.Add(this.lblAmount);
            this.panelInput.Controls.Add(this.lblScholarshipName);
            this.panelInput.Controls.Add(this.cmbStudent);
            this.panelInput.Controls.Add(this.txtID);
            this.panelInput.Controls.Add(this.lblID);
            this.panelInput.Controls.Add(this.lblStudent);
            this.panelInput.Location = new System.Drawing.Point(10, 49);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(303, 619);
            this.panelInput.TabIndex = 61;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel11.Location = new System.Drawing.Point(3, 46);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(297, 1);
            this.panel11.TabIndex = 91;
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.lblFields.Font = new System.Drawing.Font("Noto Sans KR", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFields.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblFields.Location = new System.Drawing.Point(9, 8);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(163, 27);
            this.lblFields.TabIndex = 90;
            this.lblFields.Text = "Scholarship Info";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.lblUpdate);
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(254)))));
            this.panel3.Location = new System.Drawing.Point(14, 529);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 36);
            this.panel3.TabIndex = 88;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(30, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpiryDate.Location = new System.Drawing.Point(18, 391);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(271, 26);
            this.dtpExpiryDate.TabIndex = 85;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblDelete);
            this.panel2.Location = new System.Drawing.Point(156, 529);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 36);
            this.panel2.TabIndex = 86;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // dtpDateAwarded
            // 
            this.dtpDateAwarded.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateAwarded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateAwarded.Location = new System.Drawing.Point(18, 337);
            this.dtpDateAwarded.Name = "dtpDateAwarded";
            this.dtpDateAwarded.Size = new System.Drawing.Size(271, 26);
            this.dtpDateAwarded.TabIndex = 84;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Controls.Add(this.lblAdd);
            this.panel5.Location = new System.Drawing.Point(14, 485);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 36);
            this.panel5.TabIndex = 89;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(112, 10);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(17, 17);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 59;
            this.pictureBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.lblClear);
            this.panel4.Location = new System.Drawing.Point(14, 571);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 36);
            this.panel4.TabIndex = 87;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(108, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(17, 17);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 59;
            this.pictureBox3.TabStop = false;
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.White;
            this.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Expired",
            "Suspended"});
            this.cmbStatus.Location = new System.Drawing.Point(17, 443);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(123, 28);
            this.cmbStatus.TabIndex = 83;
            // 
            // cmbSortOrder
            // 
            this.cmbSortOrder.BackColor = System.Drawing.Color.White;
            this.cmbSortOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSortOrder.FormattingEnabled = true;
            this.cmbSortOrder.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cmbSortOrder.Location = new System.Drawing.Point(811, 134);
            this.cmbSortOrder.Name = "cmbSortOrder";
            this.cmbSortOrder.Size = new System.Drawing.Size(115, 24);
            this.cmbSortOrder.TabIndex = 73;
            this.cmbSortOrder.SelectedIndexChanged += new System.EventHandler(this.cmbSortOrder_SelectedIndexChanged);
            // 
            // cmbSortColumn
            // 
            this.cmbSortColumn.BackColor = System.Drawing.Color.White;
            this.cmbSortColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSortColumn.FormattingEnabled = true;
            this.cmbSortColumn.Location = new System.Drawing.Point(699, 134);
            this.cmbSortColumn.Name = "cmbSortColumn";
            this.cmbSortColumn.Size = new System.Drawing.Size(106, 24);
            this.cmbSortColumn.TabIndex = 72;
            this.cmbSortColumn.SelectedIndexChanged += new System.EventHandler(this.cmbSortColumn_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(332, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 28);
            this.panel1.TabIndex = 71;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(338, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(5, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(329, 19);
            this.textBox1.TabIndex = 36;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.lblPrivateSummary);
            this.panel10.Controls.Add(this.lblPrivate);
            this.panel10.Location = new System.Drawing.Point(711, 68);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(119, 57);
            this.panel10.TabIndex = 78;
            // 
            // lblPrivateSummary
            // 
            this.lblPrivateSummary.AutoSize = true;
            this.lblPrivateSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblPrivateSummary.Location = new System.Drawing.Point(4, 28);
            this.lblPrivateSummary.Name = "lblPrivateSummary";
            this.lblPrivateSummary.Size = new System.Drawing.Size(42, 24);
            this.lblPrivateSummary.TabIndex = 64;
            this.lblPrivateSummary.Text = "0.00";
            // 
            // lblPrivate
            // 
            this.lblPrivate.AutoSize = true;
            this.lblPrivate.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivate.Location = new System.Drawing.Point(3, 10);
            this.lblPrivate.Name = "lblPrivate";
            this.lblPrivate.Size = new System.Drawing.Size(55, 17);
            this.lblPrivate.TabIndex = 63;
            this.lblPrivate.Text = "Private:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblTotalScholarshipSummary);
            this.panel9.Controls.Add(this.lblTotalScholarship);
            this.panel9.Location = new System.Drawing.Point(836, 68);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(125, 57);
            this.panel9.TabIndex = 75;
            // 
            // lblTotalScholarshipSummary
            // 
            this.lblTotalScholarshipSummary.AutoSize = true;
            this.lblTotalScholarshipSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalScholarshipSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalScholarshipSummary.Location = new System.Drawing.Point(4, 28);
            this.lblTotalScholarshipSummary.Name = "lblTotalScholarshipSummary";
            this.lblTotalScholarshipSummary.Size = new System.Drawing.Size(42, 24);
            this.lblTotalScholarshipSummary.TabIndex = 64;
            this.lblTotalScholarshipSummary.Text = "0.00";
            // 
            // lblTotalScholarship
            // 
            this.lblTotalScholarship.AutoSize = true;
            this.lblTotalScholarship.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalScholarship.Location = new System.Drawing.Point(3, 10);
            this.lblTotalScholarship.Name = "lblTotalScholarship";
            this.lblTotalScholarship.Size = new System.Drawing.Size(112, 17);
            this.lblTotalScholarship.TabIndex = 63;
            this.lblTotalScholarship.Text = "Total Scholarship";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.lblGovernmentSummary);
            this.panel8.Controls.Add(this.lblGovernment);
            this.panel8.Location = new System.Drawing.Point(586, 68);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(119, 57);
            this.panel8.TabIndex = 76;
            // 
            // lblGovernmentSummary
            // 
            this.lblGovernmentSummary.AutoSize = true;
            this.lblGovernmentSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovernmentSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblGovernmentSummary.Location = new System.Drawing.Point(4, 28);
            this.lblGovernmentSummary.Name = "lblGovernmentSummary";
            this.lblGovernmentSummary.Size = new System.Drawing.Size(42, 24);
            this.lblGovernmentSummary.TabIndex = 64;
            this.lblGovernmentSummary.Text = "0.00";
            // 
            // lblGovernment
            // 
            this.lblGovernment.AutoSize = true;
            this.lblGovernment.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovernment.Location = new System.Drawing.Point(3, 10);
            this.lblGovernment.Name = "lblGovernment";
            this.lblGovernment.Size = new System.Drawing.Size(88, 17);
            this.lblGovernment.TabIndex = 63;
            this.lblGovernment.Text = "Government:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.lblAthleticSummary);
            this.panel7.Controls.Add(this.lblAthletic);
            this.panel7.Location = new System.Drawing.Point(457, 68);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(123, 57);
            this.panel7.TabIndex = 77;
            // 
            // lblAthleticSummary
            // 
            this.lblAthleticSummary.AutoSize = true;
            this.lblAthleticSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAthleticSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblAthleticSummary.Location = new System.Drawing.Point(4, 28);
            this.lblAthleticSummary.Name = "lblAthleticSummary";
            this.lblAthleticSummary.Size = new System.Drawing.Size(42, 24);
            this.lblAthleticSummary.TabIndex = 64;
            this.lblAthleticSummary.Text = "0.00";
            // 
            // lblAthletic
            // 
            this.lblAthletic.AutoSize = true;
            this.lblAthletic.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAthletic.Location = new System.Drawing.Point(3, 10);
            this.lblAthletic.Name = "lblAthletic";
            this.lblAthletic.Size = new System.Drawing.Size(59, 17);
            this.lblAthletic.TabIndex = 63;
            this.lblAthletic.Text = "Athletic:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.lblAcademicSummary);
            this.panel6.Controls.Add(this.lblAcademic);
            this.panel6.Location = new System.Drawing.Point(332, 68);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(119, 57);
            this.panel6.TabIndex = 74;
            // 
            // lblAcademicSummary
            // 
            this.lblAcademicSummary.AutoSize = true;
            this.lblAcademicSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcademicSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblAcademicSummary.Location = new System.Drawing.Point(4, 28);
            this.lblAcademicSummary.Name = "lblAcademicSummary";
            this.lblAcademicSummary.Size = new System.Drawing.Size(42, 24);
            this.lblAcademicSummary.TabIndex = 62;
            this.lblAcademicSummary.Text = "0.00";
            // 
            // lblAcademic
            // 
            this.lblAcademic.AutoSize = true;
            this.lblAcademic.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcademic.Location = new System.Drawing.Point(3, 10);
            this.lblAcademic.Name = "lblAcademic";
            this.lblAcademic.Size = new System.Drawing.Size(70, 17);
            this.lblAcademic.TabIndex = 0;
            this.lblAcademic.Text = "Academic:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(332, 643);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(15, 15);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 79;
            this.pictureBox6.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans KR", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "SCHOLARSHIP MANAGEMENT";
            // 
            // panelTopContent
            // 
            this.panelTopContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panelTopContent.Controls.Add(this.label3);
            this.panelTopContent.Location = new System.Drawing.Point(0, -6);
            this.panelTopContent.Name = "panelTopContent";
            this.panelTopContent.Size = new System.Drawing.Size(988, 57);
            this.panelTopContent.TabIndex = 65;
            // 
            // ScholarshipManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(988, 668);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.cmbSortOrder);
            this.Controls.Add(this.cmbSortColumn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTopContent);
            this.Controls.Add(this.pbRefresh);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.lblSelectInfo);
            this.Controls.Add(this.dgvScholarships);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScholarshipManagementForm";
            this.Text = "ScholarshipManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholarships)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panelTopContent.ResumeLayout(false);
            this.panelTopContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSelectInfo;
        private System.Windows.Forms.DataGridView dgvScholarships;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblScholarshipName;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.TextBox txtScholarshipName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDateAwarded;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpDateAwarded;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox cmbSortOrder;
        private System.Windows.Forms.ComboBox cmbSortColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblPrivateSummary;
        private System.Windows.Forms.Label lblPrivate;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblTotalScholarshipSummary;
        private System.Windows.Forms.Label lblTotalScholarship;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblGovernmentSummary;
        private System.Windows.Forms.Label lblGovernment;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblAthleticSummary;
        private System.Windows.Forms.Label lblAthletic;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblAcademicSummary;
        private System.Windows.Forms.Label lblAcademic;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTopContent;
    }
}