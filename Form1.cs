using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IntegratedUniversityInformationSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtLoginUsername.Text) || string.IsNullOrWhiteSpace(txtLoginPassword.Text))
            {
                MessageBox.Show("Please fill up all fields to proceed.", "Missing fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string loginUsername = txtLoginUsername.Text;
            string loginPassword= txtLoginPassword.Text;

            bool validAuth = LoginAuthentication(loginUsername, loginPassword);
            if (validAuth)
            {
                // go to dashboard
                MessageBox.Show("Login Successfully");
            }
        }

        private bool LoginAuthentication(string username, string password)
        {
            if (!username.Equals("json"))
            {
                MessageBox.Show("Invalid username input! Try again.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!password.Equals("michael"))
            {
                MessageBox.Show("Wrong password input! Try again.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                MessageBox.Show("Login Successfully! Redirecting to admin dashboard.", "Success Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }
    }
}
