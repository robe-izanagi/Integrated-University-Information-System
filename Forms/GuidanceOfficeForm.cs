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
        // stores the logged-in user info
        private readonly User _currentUser;

        // holds the currently open child form inside the panel
        private Form _activeForm = null;

        // tracks which sidebar menu item is currently selected
        // default Counseling page loads first
        private string activeSidebar = "counseling"; // counseling - violation - appointment

        public GuidanceOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Guidance Office";

            // highlight the default menu item (counseling)
            handleModule(activeSidebar);

            // automatically load Counseling management when form opens
            OpenChildForm(new CounselingManagementForm());
        }

        // opens a form inside the panelContent container
        private void OpenChildForm(Form childForm)
        {
            // close existing form if there's one open
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            // set up the new form to be embedded inside the panel
            _activeForm = childForm;
            childForm.TopLevel = false; // not a standalone window
            childForm.FormBorderStyle = FormBorderStyle.None;  // remove borders
            childForm.Dock = DockStyle.Fill; // fill the entire panel

            // add to panel and show
            panelContent.Controls.Add(childForm); 
            childForm.BringToFront();
            childForm.Show();
        }

        // when user clicks Counseling menu
        private void lblCounseling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CounselingManagementForm());
            activeSidebar = "counseling";
            handleModule(activeSidebar);
        }

        // when user clicks Violation menu
        private void lblViolation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViolationManagementForm());
            activeSidebar = "violation";
            handleModule(activeSidebar);
        }

        // when user clicks Appointment menu
        private void lblAppointment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AppointmentManagementForm());
            activeSidebar = "appointment";
            handleModule(activeSidebar);
        }

        // highlights the selected sidebar menu item
        // shows/hides panels and changes background color
        private void handleModule(string activeModule)
        {
            // reset everything
            p1.Visible = p2.Visible = p3.Visible = p4.Visible = p5.Visible = p6.Visible = false;
            pc1.BackColor = pc2.BackColor = pc3.BackColor = Color.Transparent;

            // set only the ones for the active module
            switch (activeModule)
            {
                case "counseling":
                    p1.Visible = p2.Visible = true;
                    pc1.BackColor = Color.FromArgb(255, 250, 0);
                    break;
                case "violation":
                    p3.Visible = p4.Visible = true;
                    pc2.BackColor = Color.FromArgb(255, 250, 0);
                    break;
                case "appointment":
                    p5.Visible = p6.Visible = true;
                    pc3.BackColor = Color.FromArgb(255, 250, 0);
                    break;
            }
        }

        // logout - closes current form and shows login form
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
