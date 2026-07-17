namespace IntegratedUniversityInformationSystem.Forms
{
    partial class FineManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FineManagementForm));
            this.dgvFines = new System.Windows.Forms.DataGridView();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.dtpFineDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblFineDate = new System.Windows.Forms.Label();
            this.cmbBorrowing = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblBorrowing = new System.Windows.Forms.Label();
            this.panelTopContent = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.cmbSortColumn = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblTotalFinesSummary = new System.Windows.Forms.Label();
            this.lblTotalFinesText = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWaivedSummary = new System.Windows.Forms.Label();
            this.lblWaivedText = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPaidSummary = new System.Windows.Forms.Label();
            this.lblPaidText = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblPendingSummary = new System.Windows.Forms.Label();
            this.lblPendingText = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSelectInfo = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblFields = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelTopContent.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFines
            // 
            this.dgvFines.BackgroundColor = System.Drawing.Color.White;
            this.dgvFines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFines.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvFines.Location = new System.Drawing.Point(341, 165);
            this.dgvFines.Name = "dgvFines";
            this.dgvFines.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFines.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFines.Size = new System.Drawing.Size(629, 463);
            this.dgvFines.TabIndex = 44;
            this.dgvFines.SelectionChanged += new System.EventHandler(this.dgvFines_SelectionChanged);
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(254)))));
            this.lblUpdate.Location = new System.Drawing.Point(48, 9);
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
            this.lblDelete.Location = new System.Drawing.Point(43, 8);
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
            this.pbRefresh.Location = new System.Drawing.Point(950, 135);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(20, 20);
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
            this.txtSearch.Location = new System.Drawing.Point(4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(338, 19);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.ForeColor = System.Drawing.Color.Black;
            this.lblClear.Location = new System.Drawing.Point(123, 10);
            this.lblClear.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(48, 18);
            this.lblClear.TabIndex = 60;
            this.lblClear.Text = "Clear";
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.White;
            this.lblAdd.Location = new System.Drawing.Point(128, 8);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(36, 18);
            this.lblAdd.TabIndex = 60;
            this.lblAdd.Text = "Add";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.panel11);
            this.panelInput.Controls.Add(this.lblFields);
            this.panelInput.Controls.Add(this.panel6);
            this.panelInput.Controls.Add(this.panel7);
            this.panelInput.Controls.Add(this.panel8);
            this.panelInput.Controls.Add(this.panel9);
            this.panelInput.Controls.Add(this.lblReason);
            this.panelInput.Controls.Add(this.txtReason);
            this.panelInput.Controls.Add(this.lblAmount);
            this.panelInput.Controls.Add(this.dtpFineDate);
            this.panelInput.Controls.Add(this.lblStatus);
            this.panelInput.Controls.Add(this.cmbStatus);
            this.panelInput.Controls.Add(this.txtAmount);
            this.panelInput.Controls.Add(this.lblFineDate);
            this.panelInput.Controls.Add(this.cmbBorrowing);
            this.panelInput.Controls.Add(this.txtID);
            this.panelInput.Controls.Add(this.lblID);
            this.panelInput.Controls.Add(this.lblBorrowing);
            this.panelInput.Location = new System.Drawing.Point(19, 51);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(303, 615);
            this.panelInput.TabIndex = 63;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.ForeColor = System.Drawing.Color.Black;
            this.lblReason.Location = new System.Drawing.Point(12, 268);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(76, 20);
            this.lblReason.TabIndex = 92;
            this.lblReason.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(16, 291);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(270, 26);
            this.txtReason.TabIndex = 91;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Location = new System.Drawing.Point(12, 163);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(76, 20);
            this.lblAmount.TabIndex = 88;
            this.lblAmount.Text = "Amount:";
            // 
            // dtpFineDate
            // 
            this.dtpFineDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFineDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFineDate.Location = new System.Drawing.Point(16, 239);
            this.dtpFineDate.Name = "dtpFineDate";
            this.dtpFineDate.Size = new System.Drawing.Size(270, 26);
            this.dtpFineDate.TabIndex = 86;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(12, 319);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(141, 20);
            this.lblStatus.TabIndex = 41;
            this.lblStatus.Text = "Payment Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.White;
            this.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Paid",
            "Waived"});
            this.cmbStatus.Location = new System.Drawing.Point(16, 342);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(270, 28);
            this.cmbStatus.TabIndex = 60;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(16, 186);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(270, 26);
            this.txtAmount.TabIndex = 61;
            // 
            // lblFineDate
            // 
            this.lblFineDate.AutoSize = true;
            this.lblFineDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFineDate.ForeColor = System.Drawing.Color.Black;
            this.lblFineDate.Location = new System.Drawing.Point(12, 216);
            this.lblFineDate.Name = "lblFineDate";
            this.lblFineDate.Size = new System.Drawing.Size(93, 20);
            this.lblFineDate.TabIndex = 63;
            this.lblFineDate.Text = "Fine Date:";
            // 
            // cmbBorrowing
            // 
            this.cmbBorrowing.BackColor = System.Drawing.Color.White;
            this.cmbBorrowing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBorrowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBorrowing.FormattingEnabled = true;
            this.cmbBorrowing.Location = new System.Drawing.Point(16, 132);
            this.cmbBorrowing.Name = "cmbBorrowing";
            this.cmbBorrowing.Size = new System.Drawing.Size(270, 28);
            this.cmbBorrowing.TabIndex = 38;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(116, 75);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(170, 26);
            this.txtID.TabIndex = 28;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(12, 81);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(73, 20);
            this.lblID.TabIndex = 26;
            this.lblID.Text = "Fine ID:";
            // 
            // lblBorrowing
            // 
            this.lblBorrowing.AutoSize = true;
            this.lblBorrowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowing.ForeColor = System.Drawing.Color.Black;
            this.lblBorrowing.Location = new System.Drawing.Point(11, 109);
            this.lblBorrowing.Name = "lblBorrowing";
            this.lblBorrowing.Size = new System.Drawing.Size(157, 20);
            this.lblBorrowing.TabIndex = 31;
            this.lblBorrowing.Text = "Borrowing Record:";
            // 
            // panelTopContent
            // 
            this.panelTopContent.BackColor = System.Drawing.Color.Brown;
            this.panelTopContent.Controls.Add(this.label2);
            this.panelTopContent.Location = new System.Drawing.Point(0, -1);
            this.panelTopContent.Name = "panelTopContent";
            this.panelTopContent.Size = new System.Drawing.Size(988, 52);
            this.panelTopContent.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans KR", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "FINE MANAGEMENT";
            this.label2.UseMnemonic = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblUpdate);
            this.panel6.Controls.Add(this.pictureBox6);
            this.panel6.Location = new System.Drawing.Point(15, 522);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(136, 36);
            this.panel6.TabIndex = 95;
            this.panel6.Click += new System.EventHandler(this.lblUpdate_Click);
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
            this.pictureBox6.Click += new System.EventHandler(this.lblUpdate_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblDelete);
            this.panel7.Controls.Add(this.pictureBox7);
            this.panel7.Location = new System.Drawing.Point(157, 522);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(128, 36);
            this.panel7.TabIndex = 93;
            this.panel7.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(24, 9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(17, 17);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 59;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Brown;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblAdd);
            this.panel8.Controls.Add(this.pictureBox8);
            this.panel8.Location = new System.Drawing.Point(15, 478);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(271, 36);
            this.panel8.TabIndex = 96;
            this.panel8.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(110, 9);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(17, 17);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 59;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblClear);
            this.panel9.Controls.Add(this.pictureBox9);
            this.panel9.Location = new System.Drawing.Point(15, 564);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(270, 36);
            this.panel9.TabIndex = 94;
            this.panel9.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(100, 10);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(17, 17);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 59;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.lblClear_Click);
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
            this.cmbSortOrder.Location = new System.Drawing.Point(832, 132);
            this.cmbSortOrder.Name = "cmbSortOrder";
            this.cmbSortOrder.Size = new System.Drawing.Size(115, 24);
            this.cmbSortOrder.TabIndex = 89;
            this.cmbSortOrder.SelectedIndexChanged += new System.EventHandler(this.cmbSortOrder_SelectedIndexChanged);
            // 
            // cmbSortColumn
            // 
            this.cmbSortColumn.BackColor = System.Drawing.Color.White;
            this.cmbSortColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSortColumn.FormattingEnabled = true;
            this.cmbSortColumn.Location = new System.Drawing.Point(720, 132);
            this.cmbSortColumn.Name = "cmbSortColumn";
            this.cmbSortColumn.Size = new System.Drawing.Size(106, 24);
            this.cmbSortColumn.TabIndex = 88;
            this.cmbSortColumn.SelectedIndexChanged += new System.EventHandler(this.cmbSortColumn_SelectedIndexChanged);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.lblTotalFinesSummary);
            this.panel10.Controls.Add(this.lblTotalFinesText);
            this.panel10.Location = new System.Drawing.Point(814, 66);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(156, 57);
            this.panel10.TabIndex = 87;
            // 
            // lblTotalFinesSummary
            // 
            this.lblTotalFinesSummary.AutoSize = true;
            this.lblTotalFinesSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFinesSummary.ForeColor = System.Drawing.Color.Brown;
            this.lblTotalFinesSummary.Location = new System.Drawing.Point(4, 28);
            this.lblTotalFinesSummary.Name = "lblTotalFinesSummary";
            this.lblTotalFinesSummary.Size = new System.Drawing.Size(42, 24);
            this.lblTotalFinesSummary.TabIndex = 64;
            this.lblTotalFinesSummary.Text = "0.00";
            // 
            // lblTotalFinesText
            // 
            this.lblTotalFinesText.AutoSize = true;
            this.lblTotalFinesText.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFinesText.Location = new System.Drawing.Point(3, 10);
            this.lblTotalFinesText.Name = "lblTotalFinesText";
            this.lblTotalFinesText.Size = new System.Drawing.Size(77, 17);
            this.lblTotalFinesText.TabIndex = 63;
            this.lblTotalFinesText.Text = "Total Fines:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblWaivedSummary);
            this.panel2.Controls.Add(this.lblWaivedText);
            this.panel2.Location = new System.Drawing.Point(659, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(149, 57);
            this.panel2.TabIndex = 85;
            // 
            // lblWaivedSummary
            // 
            this.lblWaivedSummary.AutoSize = true;
            this.lblWaivedSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaivedSummary.ForeColor = System.Drawing.Color.Brown;
            this.lblWaivedSummary.Location = new System.Drawing.Point(4, 28);
            this.lblWaivedSummary.Name = "lblWaivedSummary";
            this.lblWaivedSummary.Size = new System.Drawing.Size(42, 24);
            this.lblWaivedSummary.TabIndex = 64;
            this.lblWaivedSummary.Text = "0.00";
            // 
            // lblWaivedText
            // 
            this.lblWaivedText.AutoSize = true;
            this.lblWaivedText.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaivedText.Location = new System.Drawing.Point(3, 10);
            this.lblWaivedText.Name = "lblWaivedText";
            this.lblWaivedText.Size = new System.Drawing.Size(56, 17);
            this.lblWaivedText.TabIndex = 63;
            this.lblWaivedText.Text = "Waived:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblPaidSummary);
            this.panel3.Controls.Add(this.lblPaidText);
            this.panel3.Location = new System.Drawing.Point(498, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 57);
            this.panel3.TabIndex = 86;
            // 
            // lblPaidSummary
            // 
            this.lblPaidSummary.AutoSize = true;
            this.lblPaidSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidSummary.ForeColor = System.Drawing.Color.Brown;
            this.lblPaidSummary.Location = new System.Drawing.Point(4, 28);
            this.lblPaidSummary.Name = "lblPaidSummary";
            this.lblPaidSummary.Size = new System.Drawing.Size(42, 24);
            this.lblPaidSummary.TabIndex = 64;
            this.lblPaidSummary.Text = "0.00";
            // 
            // lblPaidText
            // 
            this.lblPaidText.AutoSize = true;
            this.lblPaidText.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidText.Location = new System.Drawing.Point(3, 10);
            this.lblPaidText.Name = "lblPaidText";
            this.lblPaidText.Size = new System.Drawing.Size(38, 17);
            this.lblPaidText.TabIndex = 63;
            this.lblPaidText.Text = "Paid:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblPendingSummary);
            this.panel4.Controls.Add(this.lblPendingText);
            this.panel4.Location = new System.Drawing.Point(341, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(151, 57);
            this.panel4.TabIndex = 83;
            // 
            // lblPendingSummary
            // 
            this.lblPendingSummary.AutoSize = true;
            this.lblPendingSummary.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingSummary.ForeColor = System.Drawing.Color.Brown;
            this.lblPendingSummary.Location = new System.Drawing.Point(4, 28);
            this.lblPendingSummary.Name = "lblPendingSummary";
            this.lblPendingSummary.Size = new System.Drawing.Size(42, 24);
            this.lblPendingSummary.TabIndex = 62;
            this.lblPendingSummary.Text = "0.00";
            // 
            // lblPendingText
            // 
            this.lblPendingText.AutoSize = true;
            this.lblPendingText.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingText.Location = new System.Drawing.Point(3, 10);
            this.lblPendingText.Name = "lblPendingText";
            this.lblPendingText.Size = new System.Drawing.Size(62, 17);
            this.lblPendingText.TabIndex = 0;
            this.lblPendingText.Text = "Pending:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.txtSearch);
            this.panel5.Location = new System.Drawing.Point(341, 130);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(373, 29);
            this.panel5.TabIndex = 81;
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(342, 634);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 91;
            this.pictureBox1.TabStop = false;
            // 
            // lblSelectInfo
            // 
            this.lblSelectInfo.AutoSize = true;
            this.lblSelectInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectInfo.ForeColor = System.Drawing.Color.Black;
            this.lblSelectInfo.Location = new System.Drawing.Point(357, 633);
            this.lblSelectInfo.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblSelectInfo.Name = "lblSelectInfo";
            this.lblSelectInfo.Size = new System.Drawing.Size(206, 18);
            this.lblSelectInfo.TabIndex = 90;
            this.lblSelectInfo.Text = "Select a row on the table first: ";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(160)))), ((int)(((byte)(109)))));
            this.panel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(160)))), ((int)(((byte)(109)))));
            this.panel11.Location = new System.Drawing.Point(2, 50);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(303, 1);
            this.panel11.TabIndex = 103;
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.lblFields.BackColor = System.Drawing.Color.Transparent;
            this.lblFields.Font = new System.Drawing.Font("Noto Sans KR", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFields.ForeColor = System.Drawing.Color.Brown;
            this.lblFields.Location = new System.Drawing.Point(14, 11);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(93, 27);
            this.lblFields.TabIndex = 102;
            this.lblFields.Text = "Fine Info";
            // 
            // FineManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(988, 665);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSelectInfo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cmbSortOrder);
            this.Controls.Add(this.cmbSortColumn);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panelTopContent);
            this.Controls.Add(this.pbRefresh);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.dgvFines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FineManagementForm";
            this.Text = "FineManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelTopContent.ResumeLayout(false);
            this.panelTopContent.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFines;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DateTimePicker dtpFineDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblFineDate;
        private System.Windows.Forms.ComboBox cmbBorrowing;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblBorrowing;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Panel panelTopContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.ComboBox cmbSortOrder;
        private System.Windows.Forms.ComboBox cmbSortColumn;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblTotalFinesSummary;
        private System.Windows.Forms.Label lblTotalFinesText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWaivedSummary;
        private System.Windows.Forms.Label lblWaivedText;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPaidSummary;
        private System.Windows.Forms.Label lblPaidText;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblPendingSummary;
        private System.Windows.Forms.Label lblPendingText;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSelectInfo;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblFields;
    }
}