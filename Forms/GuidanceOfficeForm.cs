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
    public partial class GuidanceOfficeForm : Form
    {
        private readonly User _currentUser;
        private Form _activeForm = null;
        public GuidanceOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Guidance Office";
            OpenChildForm(new CounselingManagementForm());
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

        private void lblCounseling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CounselingManagementForm());
        }

        private void lblViolation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViolationManagementForm());
        }

        private void lblAppointment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AppointmentManagementForm());
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
