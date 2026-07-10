namespace IntegratedUniversityInformationSystem.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelLoginForm = new System.Windows.Forms.Panel();
            this.panelUsername = new System.Windows.Forms.Panel();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.pbLock = new System.Windows.Forms.PictureBox();
            this.lblTitleSub = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.showPassword = new System.Windows.Forms.Label();
            this.hidePassword = new System.Windows.Forms.Label();
            this.panelLoginForm.SuspendLayout();
            this.panelUsername.SuspendLayout();
            this.panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(8, 11);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(341, 19);
            this.txtUsername.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(25, 516);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(394, 49);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelLoginForm
            // 
            this.panelLoginForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelLoginForm.Controls.Add(this.hidePassword);
            this.panelLoginForm.Controls.Add(this.showPassword);
            this.panelLoginForm.Controls.Add(this.lblCopyright);
            this.panelLoginForm.Controls.Add(this.label5);
            this.panelLoginForm.Controls.Add(this.lblTitle);
            this.panelLoginForm.Controls.Add(this.lblTitleSub);
            this.panelLoginForm.Controls.Add(this.pbLogo);
            this.panelLoginForm.Controls.Add(this.label3);
            this.panelLoginForm.Controls.Add(this.btnLogin);
            this.panelLoginForm.Controls.Add(this.panelPassword);
            this.panelLoginForm.Controls.Add(this.panelUsername);
            this.panelLoginForm.Controls.Add(this.label1);
            this.panelLoginForm.Location = new System.Drawing.Point(350, 0);
            this.panelLoginForm.Name = "panelLoginForm";
            this.panelLoginForm.Size = new System.Drawing.Size(450, 700);
            this.panelLoginForm.TabIndex = 6;
            // 
            // panelUsername
            // 
            this.panelUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelUsername.Controls.Add(this.panel6);
            this.panelUsername.Controls.Add(this.pbUser);
            this.panelUsername.Controls.Add(this.txtUsername);
            this.panelUsername.Location = new System.Drawing.Point(25, 319);
            this.panelUsername.Name = "panelUsername";
            this.panelUsername.Size = new System.Drawing.Size(394, 43);
            this.panelUsername.TabIndex = 7;
            // 
            // panelPassword
            // 
            this.panelPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelPassword.Controls.Add(this.pbLock);
            this.panelPassword.Controls.Add(this.panel5);
            this.panelPassword.Controls.Add(this.txtPassword);
            this.panelPassword.Location = new System.Drawing.Point(25, 416);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(394, 43);
            this.panelPassword.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "PASSWORD:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(8, 11);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(341, 19);
            this.txtPassword.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(394, 12);
            this.panel5.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel6.Location = new System.Drawing.Point(0, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(394, 12);
            this.panel6.TabIndex = 11;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(34, 67);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(122, 100);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 10;
            this.pbLogo.TabStop = false;
            // 
            // pbUser
            // 
            this.pbUser.Image = ((System.Drawing.Image)(resources.GetObject("pbUser.Image")));
            this.pbUser.Location = new System.Drawing.Point(355, 7);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(34, 27);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUser.TabIndex = 13;
            this.pbUser.TabStop = false;
            // 
            // pbLock
            // 
            this.pbLock.Image = ((System.Drawing.Image)(resources.GetObject("pbLock.Image")));
            this.pbLock.Location = new System.Drawing.Point(355, 7);
            this.pbLock.Name = "pbLock";
            this.pbLock.Size = new System.Drawing.Size(34, 27);
            this.pbLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLock.TabIndex = 14;
            this.pbLock.TabStop = false;
            // 
            // lblTitleSub
            // 
            this.lblTitleSub.AutoSize = true;
            this.lblTitleSub.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleSub.Location = new System.Drawing.Point(162, 149);
            this.lblTitleSub.Name = "lblTitleSub";
            this.lblTitleSub.Size = new System.Drawing.Size(244, 17);
            this.lblTitleSub.TabIndex = 11;
            this.lblTitleSub.Text = "Integrated University Information System";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Noto Sans KR", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(155, 96);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(94, 51);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "IUIS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Perpetua Titling MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 32);
            this.label5.TabIndex = 13;
            this.label5.Text = "Welcome Back!";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("PMingLiU-ExtB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(138, 676);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(167, 15);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "Copyright © 2025 BA-3303";
            // 
            // showPassword
            // 
            this.showPassword.AutoSize = true;
            this.showPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword.Location = new System.Drawing.Point(288, 471);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(131, 20);
            this.showPassword.TabIndex = 3;
            this.showPassword.Text = "Show Password?";
            this.showPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showPassword.Click += new System.EventHandler(this.showPassword_Click);
            // 
            // hidePassword
            // 
            this.hidePassword.AutoSize = true;
            this.hidePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hidePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hidePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hidePassword.Location = new System.Drawing.Point(295, 471);
            this.hidePassword.Name = "hidePassword";
            this.hidePassword.Size = new System.Drawing.Size(124, 20);
            this.hidePassword.TabIndex = 3;
            this.hidePassword.Text = "Hide Password?";
            this.hidePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hidePassword.Visible = false;
            this.hidePassword.Click += new System.EventHandler(this.hidePassword_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelLoginForm);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load_1);
            this.panelLoginForm.ResumeLayout(false);
            this.panelLoginForm.PerformLayout();
            this.panelUsername.ResumeLayout(false);
            this.panelUsername.PerformLayout();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panelLoginForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.Panel panelUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pbLock;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label lblTitleSub;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label showPassword;
        private System.Windows.Forms.Label hidePassword;
    }
}