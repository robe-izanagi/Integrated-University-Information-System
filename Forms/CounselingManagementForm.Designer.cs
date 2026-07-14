namespace IntegratedUniversityInformationSystem.Forms
{
    partial class CounselingManagementForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounselingManagementForm));
            this.panelInput = new System.Windows.Forms.Panel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtRecommendation = new System.Windows.Forms.TextBox();
            this.lblRecommendation = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtConcern = new System.Windows.Forms.TextBox();
            this.lblConcern = new System.Windows.Forms.Label();
            this.lblSessionType = new System.Windows.Forms.Label();
            this.txtCounselor = new System.Windows.Forms.TextBox();
            this.dtpSessionDate = new System.Windows.Forms.DateTimePicker();
            this.lblFields = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.cmbSessionType = new System.Windows.Forms.ComboBox();
            this.lblCounselor = new System.Windows.Forms.Label();
            this.lblSessionDate = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.panelTable = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvCounseling = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panelTopContent = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelInput.SuspendLayout();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounseling)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panelTopContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.panel6);
            this.panelInput.Controls.Add(this.panel7);
            this.panelInput.Controls.Add(this.panel8);
            this.panelInput.Controls.Add(this.panel9);
            this.panelInput.Controls.Add(this.lblStatus);
            this.panelInput.Controls.Add(this.cmbStatus);
            this.panelInput.Controls.Add(this.txtRecommendation);
            this.panelInput.Controls.Add(this.lblRecommendation);
            this.panelInput.Controls.Add(this.txtNotes);
            this.panelInput.Controls.Add(this.lblNotes);
            this.panelInput.Controls.Add(this.txtConcern);
            this.panelInput.Controls.Add(this.lblConcern);
            this.panelInput.Controls.Add(this.lblSessionType);
            this.panelInput.Controls.Add(this.txtCounselor);
            this.panelInput.Controls.Add(this.dtpSessionDate);
            this.panelInput.Controls.Add(this.lblFields);
            this.panelInput.Controls.Add(this.cmbSessionType);
            this.panelInput.Controls.Add(this.lblCounselor);
            this.panelInput.Controls.Add(this.lblSessionDate);
            this.panelInput.Controls.Add(this.cmbStudent);
            this.panelInput.Controls.Add(this.txtID);
            this.panelInput.Controls.Add(this.lblID);
            this.panelInput.Controls.Add(this.lblStudent);
            this.panelInput.Location = new System.Drawing.Point(16, 49);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(303, 688);
            this.panelInput.TabIndex = 60;
            this.panelInput.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInput_Paint);
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.White;
            this.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Scheduled",
            "Completed",
            "Cancelled",
            "Ongoing"});
            this.cmbStatus.Location = new System.Drawing.Point(13, 508);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(275, 28);
            this.cmbStatus.TabIndex = 96;
            // 
            // txtRecommendation
            // 
            this.txtRecommendation.BackColor = System.Drawing.Color.White;
            this.txtRecommendation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecommendation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecommendation.Location = new System.Drawing.Point(11, 456);
            this.txtRecommendation.Name = "txtRecommendation";
            this.txtRecommendation.Size = new System.Drawing.Size(277, 26);
            this.txtRecommendation.TabIndex = 95;
            // 
            // lblRecommendation
            // 
            this.lblRecommendation.AutoSize = true;
            this.lblRecommendation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendation.ForeColor = System.Drawing.Color.Black;
            this.lblRecommendation.Location = new System.Drawing.Point(8, 433);
            this.lblRecommendation.Name = "lblRecommendation";
            this.lblRecommendation.Size = new System.Drawing.Size(154, 20);
            this.lblRecommendation.TabIndex = 94;
            this.lblRecommendation.Text = "Recommendation:";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(12, 404);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(276, 26);
            this.txtNotes.TabIndex = 93;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.Black;
            this.lblNotes.Location = new System.Drawing.Point(9, 381);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(61, 20);
            this.lblNotes.TabIndex = 92;
            this.lblNotes.Text = "Notes:";
            // 
            // txtConcern
            // 
            this.txtConcern.BackColor = System.Drawing.Color.White;
            this.txtConcern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConcern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcern.Location = new System.Drawing.Point(14, 352);
            this.txtConcern.Name = "txtConcern";
            this.txtConcern.Size = new System.Drawing.Size(274, 26);
            this.txtConcern.TabIndex = 91;
            // 
            // lblConcern
            // 
            this.lblConcern.AutoSize = true;
            this.lblConcern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcern.ForeColor = System.Drawing.Color.Black;
            this.lblConcern.Location = new System.Drawing.Point(10, 329);
            this.lblConcern.Name = "lblConcern";
            this.lblConcern.Size = new System.Drawing.Size(81, 20);
            this.lblConcern.TabIndex = 90;
            this.lblConcern.Text = "Concern:";
            // 
            // lblSessionType
            // 
            this.lblSessionType.AutoSize = true;
            this.lblSessionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionType.ForeColor = System.Drawing.Color.Black;
            this.lblSessionType.Location = new System.Drawing.Point(10, 275);
            this.lblSessionType.Name = "lblSessionType";
            this.lblSessionType.Size = new System.Drawing.Size(121, 20);
            this.lblSessionType.TabIndex = 89;
            this.lblSessionType.Text = "Session Type:";
            // 
            // txtCounselor
            // 
            this.txtCounselor.BackColor = System.Drawing.Color.White;
            this.txtCounselor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCounselor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounselor.Location = new System.Drawing.Point(13, 191);
            this.txtCounselor.Name = "txtCounselor";
            this.txtCounselor.Size = new System.Drawing.Size(276, 26);
            this.txtCounselor.TabIndex = 88;
            // 
            // dtpSessionDate
            // 
            this.dtpSessionDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSessionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSessionDate.Location = new System.Drawing.Point(13, 246);
            this.dtpSessionDate.Name = "dtpSessionDate";
            this.dtpSessionDate.Size = new System.Drawing.Size(276, 26);
            this.dtpSessionDate.TabIndex = 87;
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.lblFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFields.ForeColor = System.Drawing.Color.Black;
            this.lblFields.Location = new System.Drawing.Point(12, 16);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(176, 25);
            this.lblFields.TabIndex = 66;
            this.lblFields.Text = "Counseling Info";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.Black;
            this.lblAdd.Location = new System.Drawing.Point(132, 9);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(36, 18);
            this.lblAdd.TabIndex = 60;
            this.lblAdd.Text = "Add";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.ForeColor = System.Drawing.Color.Black;
            this.lblClear.Location = new System.Drawing.Point(125, 9);
            this.lblClear.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(48, 18);
            this.lblClear.TabIndex = 60;
            this.lblClear.Text = "Clear";
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // cmbSessionType
            // 
            this.cmbSessionType.BackColor = System.Drawing.Color.White;
            this.cmbSessionType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSessionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSessionType.FormattingEnabled = true;
            this.cmbSessionType.Items.AddRange(new object[] {
            "Individual",
            "Group",
            "Career",
            "Academic",
            "Personal"});
            this.cmbSessionType.Location = new System.Drawing.Point(13, 298);
            this.cmbSessionType.Name = "cmbSessionType";
            this.cmbSessionType.Size = new System.Drawing.Size(275, 28);
            this.cmbSessionType.TabIndex = 60;
            this.cmbSessionType.SelectedIndexChanged += new System.EventHandler(this.cmbSessionType_SelectedIndexChanged);
            // 
            // lblCounselor
            // 
            this.lblCounselor.AutoSize = true;
            this.lblCounselor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounselor.ForeColor = System.Drawing.Color.Black;
            this.lblCounselor.Location = new System.Drawing.Point(10, 168);
            this.lblCounselor.Name = "lblCounselor";
            this.lblCounselor.Size = new System.Drawing.Size(95, 20);
            this.lblCounselor.TabIndex = 41;
            this.lblCounselor.Text = "Counselor:";
            // 
            // lblSessionDate
            // 
            this.lblSessionDate.AutoSize = true;
            this.lblSessionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionDate.ForeColor = System.Drawing.Color.Black;
            this.lblSessionDate.Location = new System.Drawing.Point(9, 222);
            this.lblSessionDate.Name = "lblSessionDate";
            this.lblSessionDate.Size = new System.Drawing.Size(122, 20);
            this.lblSessionDate.TabIndex = 39;
            this.lblSessionDate.Text = "Session Date:";
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
            this.cmbStudent.Location = new System.Drawing.Point(14, 137);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(275, 28);
            this.cmbStudent.TabIndex = 38;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(143, 80);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(146, 26);
            this.txtID.TabIndex = 28;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(10, 86);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(127, 20);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "Counseling ID:";
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.ForeColor = System.Drawing.Color.Black;
            this.lblStudent.Location = new System.Drawing.Point(9, 114);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(78, 20);
            this.lblStudent.TabIndex = 31;
            this.lblStudent.Text = "Student:";
            // 
            // panelTable
            // 
            this.panelTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelTable.Controls.Add(this.lblRecords);
            this.panelTable.Controls.Add(this.pbRefresh);
            this.panelTable.Controls.Add(this.panel1);
            this.panelTable.Location = new System.Drawing.Point(340, 79);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(629, 121);
            this.panelTable.TabIndex = 61;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.Black;
            this.lblRecords.Location = new System.Drawing.Point(18, 16);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(224, 25);
            this.lblRecords.TabIndex = 67;
            this.lblRecords.Text = "Counseling Records";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(254)))));
            this.lblUpdate.Location = new System.Drawing.Point(50, 10);
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
            this.lblDelete.Location = new System.Drawing.Point(44, 9);
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
            this.pbRefresh.Location = new System.Drawing.Point(575, 80);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(29, 26);
            this.pbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRefresh.TabIndex = 60;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(23, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 36);
            this.panel1.TabIndex = 58;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(296, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(29, 26);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(9, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(281, 19);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvCounseling
            // 
            this.dgvCounseling.BackgroundColor = System.Drawing.Color.White;
            this.dgvCounseling.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCounseling.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCounseling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCounseling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCounseling.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCounseling.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvCounseling.Location = new System.Drawing.Point(337, 307);
            this.dgvCounseling.Name = "dgvCounseling";
            this.dgvCounseling.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCounseling.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCounseling.Size = new System.Drawing.Size(632, 247);
            this.dgvCounseling.TabIndex = 44;
            this.dgvCounseling.SelectionChanged += new System.EventHandler(this.dgvCounseling_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 715);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 62;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(7, 485);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 20);
            this.lblStatus.TabIndex = 97;
            this.lblStatus.Text = "Status:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.pictureBox7);
            this.panel7.Controls.Add(this.lblDelete);
            this.panel7.Location = new System.Drawing.Point(156, 596);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(133, 36);
            this.panel7.TabIndex = 101;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(27, 9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(17, 17);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 59;
            this.pictureBox7.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(197)))), ((int)(((byte)(19)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.pictureBox8);
            this.panel8.Controls.Add(this.lblAdd);
            this.panel8.Location = new System.Drawing.Point(14, 552);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(275, 36);
            this.panel8.TabIndex = 104;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(112, 10);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(17, 17);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 59;
            this.pictureBox8.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.pictureBox9);
            this.panel9.Controls.Add(this.lblClear);
            this.panel9.Location = new System.Drawing.Point(14, 638);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(275, 36);
            this.panel9.TabIndex = 102;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(108, 10);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(17, 17);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 59;
            this.pictureBox9.TabStop = false;
            // 
            // panelTopContent
            // 
            this.panelTopContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(197)))), ((int)(((byte)(19)))));
            this.panelTopContent.Controls.Add(this.label6);
            this.panelTopContent.Location = new System.Drawing.Point(0, 0);
            this.panelTopContent.Name = "panelTopContent";
            this.panelTopContent.Size = new System.Drawing.Size(988, 52);
            this.panelTopContent.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Noto Sans KR", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "APPOINTMENT MANAGEMENT";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(30, 10);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(17, 17);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 59;
            this.pictureBox6.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.pictureBox6);
            this.panel6.Controls.Add(this.lblUpdate);
            this.panel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(254)))));
            this.panel6.Location = new System.Drawing.Point(14, 596);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(136, 36);
            this.panel6.TabIndex = 103;
            // 
            // CounselingManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(988, 737);
            this.Controls.Add(this.panelTopContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.dgvCounseling);
            this.Controls.Add(this.panelTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CounselingManagementForm";
            this.Text = "CounselingManagementForm";
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelTable.ResumeLayout(false);
            this.panelTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounseling)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panelTopContent.ResumeLayout(false);
            this.panelTopContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.DateTimePicker dtpSessionDate;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.ComboBox cmbSessionType;
        private System.Windows.Forms.Label lblCounselor;
        private System.Windows.Forms.Label lblSessionDate;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvCounseling;
        private System.Windows.Forms.TextBox txtCounselor;
        private System.Windows.Forms.Label lblSessionType;
        private System.Windows.Forms.TextBox txtConcern;
        private System.Windows.Forms.Label lblConcern;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtRecommendation;
        private System.Windows.Forms.Label lblRecommendation;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Panel panelTopContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}