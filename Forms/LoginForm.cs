using IntegratedUniversityInformationSystem.Repositories;
using IntegratedUniversityInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedUniversityInformationSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _userRepo;
        public LoginForm()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = _userRepo.GetById(u => u.Username == username && u.IsActive);

                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user.PasswordHash != password)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hide login form, show dashboard
                this.Hide();
                // Login successful - open appropriate office form based on role
                Form officeForm = GetOfficeForm(user);
                officeForm.FormClosed += (s, args) => this.Show();
                officeForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form GetOfficeForm(User user)
        {
            switch (user.Role.ToLower())
            {
                case "registrar":
                    return new RegistrarOfficeForm(user);
                case "accounting":
                    return new AccountingOfficeForm(user);
                //case "librarian":
                //case "library":
                //    return new LibraryOfficeForm(user);
                //case "guidance":
                //    return new GuidanceOfficeForm(user);
                //case "clinic":
                //    return new ClinicOfficeForm(user);
                //case "hr":
                //    return new HROfficeForm(user);
                //case "admin":
                //    return new AdminOfficeForm(user);
                default:
                    MessageBox.Show("Unknown role. Please contact administrator.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return null;
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void togglePassword_Click(object sender, EventArgs e)
        {
            showPassword.Text = "Hide Password?";
        }

        private void hidePassword_Click(object sender, EventArgs e)
        {
            showPassword.Visible = true;
            hidePassword.Visible = false;
            txtPassword.PasswordChar = '•';
        }

        private void showPassword_Click(object sender, EventArgs e)
        {
            showPassword.Visible = false;
            hidePassword.Visible = true;
            txtPassword.PasswordChar = '\0';
        }
    }
}
