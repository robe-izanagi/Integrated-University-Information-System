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
        private string activeSidebar = "counseling"; // counseling - violation - appointment
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
            activeSidebar = "counseling";
            handleModule(activeSidebar);
        }

        private void lblViolation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViolationManagementForm());
            activeSidebar = "violation";
            handleModule(activeSidebar);
        }

        private void lblAppointment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AppointmentManagementForm());
            activeSidebar = "appointment";
            handleModule(activeSidebar);
        }

        private void handleModule(string activeModule)
        {
            switch (activeModule)
            {
                case "counseling":
                    p1.Visible = true;
                    p2.Visible = true;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc1.BackColor = Color.FromArgb(255, 250, 0);
                    pc2.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    break;
                case "violation":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = true;
                    p4.Visible = true;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc2.BackColor = Color.FromArgb(255, 250, 0);
                    pc1.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    break;
                case "appointment":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = true;
                    p6.Visible = true;
                    pc3.BackColor = Color.FromArgb(255, 250, 0);
                    pc1.BackColor = Color.Transparent;
                    pc2.BackColor = Color.Transparent;
                    break;
            }
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

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
