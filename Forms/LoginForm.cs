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
        //data access for users - reads/writes users.json
        private readonly UserRepository _userRepo;
        public LoginForm()
        {
            InitializeComponent();

            // setup the repository so we can check user credentials
            _userRepo = new UserRepository();
        }

        // runs when user clicks the Login button
        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                // get user typed and remove extra spaces
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // check if both fields have text
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // find a matching user in the json file
                var user = _userRepo.GetById(u => u.Username == username && u.IsActive);

                // if no user found, show error
                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // check if password matches
                if (user.PasswordHash != password)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hide login form, show dashboard
                this.Hide();

                // open the correct office form based on user's role
                Form officeForm = GetOfficeForm(user);

                // when office form closes, show login form again
                officeForm.FormClosed += (s, args) => this.Show();

                // show the office form
                officeForm.Show();
            }
            catch (Exception ex)
            {
                // show error message if something unexpected happens
                MessageBox.Show($"An error occurred during login: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // return office form to open based on user role
        private Form GetOfficeForm(User user)
        {
            switch (user.Role.ToLower())
            {
                case "registrar":
                    return new RegistrarOfficeForm(user);
                case "accounting":
                    return new AccountingOfficeForm(user);
                case "librarian":
                case "library":
                    return new LibraryOfficeForm(user);
                case "guidance":
                    return new GuidanceOfficeForm(user);
                //case "clinic":
                //    return new ClinicOfficeForm(user);
                case "hr":
                    return new HROfficeForm(user);
                default:
                    MessageBox.Show("Unknown role. Please contact administrator.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return null;
            }
        }

        // when login form loads, put cursor on username field
        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        // hides the password (shows dots)
        private void hidePassword_Click(object sender, EventArgs e)
        {
            showPassword.Visible = true;
            hidePassword.Visible = false;
            txtPassword.PasswordChar = '•';
        }

        // shows the password as plain text
        private void showPassword_Click(object sender, EventArgs e)
        {
            showPassword.Visible = false;
            hidePassword.Visible = true;
            txtPassword.PasswordChar = '\0';
        }
    }
}
