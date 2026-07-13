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
    // Accounting Office form
    public partial class AccountingOfficeForm : Form
    {
        // stores logged-in user info
        private readonly User _currentUser;

        // holds forms that will open inside the panel
        private Form _activeForm = null;

        // constructor - runs when form is created
        public AccountingOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Accounting Office";

            // auto-load Payment Management when form opens
            OpenChildForm(new PaymentManagementForm());
        }

        // opens forms inside panelContent
        private void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        // opens Payment Management
        private void lblPayment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PaymentManagementForm());
        }

        // opens Scholarship Management
        private void lblScholarship_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ScholarshipManagementForm());
        }

        // opens Tuition Management
        private void lblTuition_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TuitionManagementForm());
        }

        // logout and go back to login
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
