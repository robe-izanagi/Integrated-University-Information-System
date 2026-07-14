namespace IntegratedUniversityInformationSystem.Forms
{
    partial class PaymentManagementForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentManagementForm));
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panelTopContent = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblCheckSummary = new System.Windows.Forms.Label();
            this.lblCheck = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblTotalPaymentsSummary = new System.Windows.Forms.Label();
            this.lblTotalPayments = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblCreditCardSummary = new System.Windows.Forms.Label();
            this.lblCreditCard = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblBankTransferSummary = new System.Windows.Forms.Label();
            this.lblBankTransfer = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCashSummary = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.cmbSortColumn = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblFields = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblSelectInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panelTopContent.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.White;
            this.cmbPaymentMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Bank Transfer",
            "Credit Card",
            "Check"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(16, 243);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(270, 28);
            this.cmbPaymentMethod.TabIndex = 60;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(107, 381);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(178, 26);
            this.txtRemarks.TabIndex = 58;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentMethod.Location = new System.Drawing.Point(13, 220);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(148, 20);
            this.lblPaymentMethod.TabIndex = 41;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Location = new System.Drawing.Point(12, 168);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(76, 20);
            this.lblAmount.TabIndex = 39;
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
            this.cmbStudent.Location = new System.Drawing.Point(16, 137);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(269, 28);
            this.cmbStudent.TabIndex = 38;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.ForeColor = System.Drawing.Color.Black;
            this.lblRemarks.Location = new System.Drawing.Point(11, 387);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(90, 20);
            this.lblRemarks.TabIndex = 59;
            this.lblRemarks.Text = "Remarks: ";
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.ForeColor = System.Drawing.Color.Black;
            this.lblStudent.Location = new System.Drawing.Point(11, 114);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(78, 20);
            this.lblStudent.TabIndex = 31;
            this.lblStudent.Text = "Student:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(338, 19);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvPayments
            // 
            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPayments.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPayments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvPayments.Location = new System.Drawing.Point(339, 166);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayments.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPayments.Size = new System.Drawing.Size(630, 469);
            this.dgvPayments.TabIndex = 44;
            this.dgvPayments.SelectionChanged += new System.EventHandler(this.dgvPayments_SelectionChanged);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(138, 80);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(147, 26);
            this.txtID.TabIndex = 28;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(12, 86);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(107, 20);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "Payment ID:";
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.panel11);
            this.panelInput.Controls.Add(this.lblFields);
            this.panelInput.Controls.Add(this.panel3);
            this.panelInput.Controls.Add(this.panel2);
            this.panelInput.Controls.Add(this.panel5);
            this.panelInput.Controls.Add(this.panel4);
            this.panelInput.Controls.Add(this.dtpPaymentDate);
            this.panelInput.Controls.Add(this.lblReferenceNo);
            this.panelInput.Controls.Add(this.lblPaymentDate);
            this.panelInput.Controls.Add(this.txtReferenceNo);
            this.panelInput.Controls.Add(this.txtAmount);
            this.panelInput.Controls.Add(this.cmbPaymentMethod);
            this.panelInput.Controls.Add(this.lblRemarks);
            this.panelInput.Controls.Add(this.txtRemarks);
            this.panelInput.Controls.Add(this.lblPaymentMethod);
            this.panelInput.Controls.Add(this.lblAmount);
            this.panelInput.Controls.Add(this.cmbStudent);
            this.panelInput.Controls.Add(this.txtID);
            this.panelInput.Controls.Add(this.lblID);
            this.panelInput.Controls.Add(this.lblStudent);
            this.panelInput.Location = new System.Drawing.Point(17, 51);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(303, 617);
            this.panelInput.TabIndex = 54;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Location = new System.Drawing.Point(17, 349);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(269, 26);
            this.dtpPaymentDate.TabIndex = 86;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.White;
            this.lblAdd.Location = new System.Drawing.Point(100, 8);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(106, 18);
            this.lblAdd.TabIndex = 60;
            this.lblAdd.Text = "Add Payment";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNo.ForeColor = System.Drawing.Color.Black;
            this.lblReferenceNo.Location = new System.Drawing.Point(12, 274);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(130, 20);
            this.lblReferenceNo.TabIndex = 65;
            this.lblReferenceNo.Text = "Reference No.:";
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.ForeColor = System.Drawing.Color.Black;
            this.lblClear.Location = new System.Drawing.Point(127, 9);
            this.lblClear.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(48, 18);
            this.lblClear.TabIndex = 60;
            this.lblClear.Text = "Clear";
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.BackColor = System.Drawing.Color.White;
            this.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceNo.Location = new System.Drawing.Point(16, 297);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(270, 26);
            this.txtReferenceNo.TabIndex = 64;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentDate.Location = new System.Drawing.Point(12, 326);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(127, 20);
            this.lblPaymentDate.TabIndex = 63;
            this.lblPaymentDate.Text = "Payment Date:";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(15, 191);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(270, 26);
            this.txtAmount.TabIndex = 61;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(254)))));
            this.lblUpdate.Location = new System.Drawing.Point(45, 9);
            this.lblUpdate.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(68, 20);
            this.lblUpdate.TabIndex = 60;
            this.lblUpdate.Text = "Update";
            this.lblUpdate.Click += new System.EventHandler(this.lblUpdate_Click);
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.ForeColor = System.Drawing.Color.Red;
            this.lblDelete.Location = new System.Drawing.Point(41, 9);
            this.lblDelete.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(62, 20);
            this.lblDelete.TabIndex = 60;
            this.lblDelete.Text = "Delete";
            this.lblDelete.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // pbRefresh
            // 
            this.pbRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pbRefresh.Image")));
            this.pbRefresh.Location = new System.Drawing.Point(949, 135);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(20, 20);
            this.pbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRefresh.TabIndex = 60;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(340, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 29);
            this.panel1.TabIndex = 58;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(348, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // panelTopContent
            // 
            this.panelTopContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panelTopContent.Controls.Add(this.label2);
            this.panelTopContent.Location = new System.Drawing.Point(0, -1);
            this.panelTopContent.Name = "panelTopContent";
            this.panelTopContent.Size = new System.Drawing.Size(988, 52);
            this.panelTopContent.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans KR", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "PAYMENT MANAGEMENT";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.lblUpdate);
            this.panel3.Location = new System.Drawing.Point(15, 527);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 36);
            this.panel3.TabIndex = 89;
            this.panel3.Click += new System.EventHandler(this.lblUpdate_Click);
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
            this.pictureBox2.Click += new System.EventHandler(this.lblUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblDelete);
            this.panel2.Location = new System.Drawing.Point(157, 527);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 36);
            this.panel2.TabIndex = 87;
            this.panel2.Click += new System.EventHandler(this.lblDelete_Click);
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
            this.pictureBox1.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Controls.Add(this.lblAdd);
            this.panel5.Location = new System.Drawing.Point(15, 483);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(271, 36);
            this.panel5.TabIndex = 90;
            this.panel5.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(80, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(17, 17);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 59;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblClear);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(15, 569);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(270, 36);
            this.panel4.TabIndex = 88;
            this.panel4.Click += new System.EventHandler(this.lblClear_Click);
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
            this.pictureBox3.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.lblCheckSummary);
            this.panel10.Controls.Add(this.lblCheck);
            this.panel10.Location = new System.Drawing.Point(719, 67);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(119, 57);
            this.panel10.TabIndex = 78;
            // 
            // lblCheckSummary
            // 
            this.lblCheckSummary.AutoSize = true;
            this.lblCheckSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblCheckSummary.Location = new System.Drawing.Point(4, 28);
            this.lblCheckSummary.Name = "lblCheckSummary";
            this.lblCheckSummary.Size = new System.Drawing.Size(42, 24);
            this.lblCheckSummary.TabIndex = 64;
            this.lblCheckSummary.Text = "0.00";
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck.Location = new System.Drawing.Point(3, 10);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(48, 17);
            this.lblCheck.TabIndex = 63;
            this.lblCheck.Text = "Check:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblTotalPaymentsSummary);
            this.panel9.Controls.Add(this.lblTotalPayments);
            this.panel9.Location = new System.Drawing.Point(844, 67);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(125, 57);
            this.panel9.TabIndex = 75;
            // 
            // lblTotalPaymentsSummary
            // 
            this.lblTotalPaymentsSummary.AutoSize = true;
            this.lblTotalPaymentsSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaymentsSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPaymentsSummary.Location = new System.Drawing.Point(4, 28);
            this.lblTotalPaymentsSummary.Name = "lblTotalPaymentsSummary";
            this.lblTotalPaymentsSummary.Size = new System.Drawing.Size(42, 24);
            this.lblTotalPaymentsSummary.TabIndex = 64;
            this.lblTotalPaymentsSummary.Text = "0.00";
            // 
            // lblTotalPayments
            // 
            this.lblTotalPayments.AutoSize = true;
            this.lblTotalPayments.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayments.Location = new System.Drawing.Point(3, 10);
            this.lblTotalPayments.Name = "lblTotalPayments";
            this.lblTotalPayments.Size = new System.Drawing.Size(104, 17);
            this.lblTotalPayments.TabIndex = 63;
            this.lblTotalPayments.Text = "Total Payments:";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.lblCreditCardSummary);
            this.panel8.Controls.Add(this.lblCreditCard);
            this.panel8.Location = new System.Drawing.Point(594, 67);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(119, 57);
            this.panel8.TabIndex = 76;
            // 
            // lblCreditCardSummary
            // 
            this.lblCreditCardSummary.AutoSize = true;
            this.lblCreditCardSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCardSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblCreditCardSummary.Location = new System.Drawing.Point(4, 28);
            this.lblCreditCardSummary.Name = "lblCreditCardSummary";
            this.lblCreditCardSummary.Size = new System.Drawing.Size(42, 24);
            this.lblCreditCardSummary.TabIndex = 64;
            this.lblCreditCardSummary.Text = "0.00";
            // 
            // lblCreditCard
            // 
            this.lblCreditCard.AutoSize = true;
            this.lblCreditCard.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCard.Location = new System.Drawing.Point(3, 10);
            this.lblCreditCard.Name = "lblCreditCard";
            this.lblCreditCard.Size = new System.Drawing.Size(80, 17);
            this.lblCreditCard.TabIndex = 63;
            this.lblCreditCard.Text = "Credit Card:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.lblBankTransferSummary);
            this.panel7.Controls.Add(this.lblBankTransfer);
            this.panel7.Location = new System.Drawing.Point(465, 67);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(123, 57);
            this.panel7.TabIndex = 77;
            // 
            // lblBankTransferSummary
            // 
            this.lblBankTransferSummary.AutoSize = true;
            this.lblBankTransferSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankTransferSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblBankTransferSummary.Location = new System.Drawing.Point(4, 28);
            this.lblBankTransferSummary.Name = "lblBankTransferSummary";
            this.lblBankTransferSummary.Size = new System.Drawing.Size(42, 24);
            this.lblBankTransferSummary.TabIndex = 64;
            this.lblBankTransferSummary.Text = "0.00";
            // 
            // lblBankTransfer
            // 
            this.lblBankTransfer.AutoSize = true;
            this.lblBankTransfer.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankTransfer.Location = new System.Drawing.Point(3, 10);
            this.lblBankTransfer.Name = "lblBankTransfer";
            this.lblBankTransfer.Size = new System.Drawing.Size(94, 17);
            this.lblBankTransfer.TabIndex = 63;
            this.lblBankTransfer.Text = "Bank Transfer:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.lblCashSummary);
            this.panel6.Controls.Add(this.lblCash);
            this.panel6.Location = new System.Drawing.Point(340, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(119, 57);
            this.panel6.TabIndex = 74;
            // 
            // lblCashSummary
            // 
            this.lblCashSummary.AutoSize = true;
            this.lblCashSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashSummary.ForeColor = System.Drawing.Color.Blue;
            this.lblCashSummary.Location = new System.Drawing.Point(4, 28);
            this.lblCashSummary.Name = "lblCashSummary";
            this.lblCashSummary.Size = new System.Drawing.Size(42, 24);
            this.lblCashSummary.TabIndex = 62;
            this.lblCashSummary.Text = "0.00";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(3, 10);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(41, 17);
            this.lblCash.TabIndex = 0;
            this.lblCash.Text = "Cash:";
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
            this.cmbSortOrder.Location = new System.Drawing.Point(831, 133);
            this.cmbSortOrder.Name = "cmbSortOrder";
            this.cmbSortOrder.Size = new System.Drawing.Size(115, 24);
            this.cmbSortOrder.TabIndex = 80;
            this.cmbSortOrder.SelectedIndexChanged += new System.EventHandler(this.cmbSortOrder_SelectedIndexChanged);
            // 
            // cmbSortColumn
            // 
            this.cmbSortColumn.BackColor = System.Drawing.Color.White;
            this.cmbSortColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSortColumn.FormattingEnabled = true;
            this.cmbSortColumn.Location = new System.Drawing.Point(719, 133);
            this.cmbSortColumn.Name = "cmbSortColumn";
            this.cmbSortColumn.Size = new System.Drawing.Size(106, 24);
            this.cmbSortColumn.TabIndex = 79;
            this.cmbSortColumn.SelectedIndexChanged += new System.EventHandler(this.cmbSortColumn_SelectedIndexChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel11.Location = new System.Drawing.Point(0, 46);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(297, 1);
            this.panel11.TabIndex = 92;
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.lblFields.Font = new System.Drawing.Font("Noto Sans KR", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFields.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblFields.Location = new System.Drawing.Point(6, 8);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(136, 27);
            this.lblFields.TabIndex = 91;
            this.lblFields.Text = "Payment Info";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(339, 639);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(15, 15);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 82;
            this.pictureBox6.TabStop = false;
            // 
            // lblSelectInfo
            // 
            this.lblSelectInfo.AutoSize = true;
            this.lblSelectInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectInfo.ForeColor = System.Drawing.Color.Black;
            this.lblSelectInfo.Location = new System.Drawing.Point(354, 638);
            this.lblSelectInfo.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblSelectInfo.Name = "lblSelectInfo";
            this.lblSelectInfo.Size = new System.Drawing.Size(206, 18);
            this.lblSelectInfo.TabIndex = 81;
            this.lblSelectInfo.Text = "Select a row on the table first: ";
            // 
            // PaymentManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 668);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.lblSelectInfo);
            this.Controls.Add(this.cmbSortOrder);
            this.Controls.Add(this.cmbSortColumn);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pbRefresh);
            this.Controls.Add(this.panelTopContent);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentManagementForm";
            this.Text = "PaymentManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panelTopContent.ResumeLayout(false);
            this.panelTopContent.PerformLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.TextBox txtReferenceNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Panel panelTopContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblCheckSummary;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblTotalPaymentsSummary;
        private System.Windows.Forms.Label lblTotalPayments;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblCreditCardSummary;
        private System.Windows.Forms.Label lblCreditCard;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblBankTransferSummary;
        private System.Windows.Forms.Label lblBankTransfer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCashSummary;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.ComboBox cmbSortOrder;
        private System.Windows.Forms.ComboBox cmbSortColumn;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblSelectInfo;
    }
}