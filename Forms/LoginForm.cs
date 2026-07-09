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
                DashboardForm dashboard = new DashboardForm(user);
                // When dashboard closes, show login form again
                dashboard.FormClosed += (s, args) => this.Show();
                dashboard.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
