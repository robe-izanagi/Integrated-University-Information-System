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
    public partial class AccountingOfficeForm : Form
    {
        private readonly User _currentUser;
        private Form _activeForm = null;
        public AccountingOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Accounting Office";
            OpenChildForm(new PaymentManagementForm());
        }

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

        private void lblPayment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PaymentManagementForm());
        }

        private void lblScholarship_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ScholarshipManagementForm());
        }

        private void lblTuition_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TuitionManagementForm());
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
