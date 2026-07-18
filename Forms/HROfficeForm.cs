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
    public partial class HROfficeForm : Form
    {
        // stores the logged-in user info
        private readonly User _currentUser;

        // holds the currently open child form inside the panel
        private Form _activeForm = null;

        // current active sidebar 
        private string activeSidebar = "employee"; // employee - faculty - attendance

        public HROfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "HR Office";

            // highlight the default menu item (books)  
            handleModule(activeSidebar);

            // automatically load Books management when form opens
            OpenChildForm(new EmployeeManagementForm());
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
            childForm.FormBorderStyle = FormBorderStyle.None; // remove borders
            childForm.Dock = DockStyle.Fill; // fill the entire panel

            // add to panel and show it
            panelContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        // when user clicks Employee menu
        private void lblEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeManagementForm());
            activeSidebar = "employee";
            handleModule(activeSidebar);
        }

        // when user clicks Faculty menu
        private void lblFaculty_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FacultyManagementForm());
            activeSidebar = "faculty";
            handleModule(activeSidebar);
        }

        // when user clicks Attendance menu
        private void lblAttendace_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AttendanceManagementForm());
            activeSidebar = "attendance";
            handleModule(activeSidebar);
        }

        // logout - closes this form and shows login again
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // highlights the selected sidebar menu item
        // shows/hides panels and changes background color
        private void handleModule(string activeModule)
        {
            // reset everything first
            p1.Visible = p2.Visible = p3.Visible = p4.Visible = p5.Visible = p6.Visible = false;
            pc1.BackColor = pc2.BackColor = pc3.BackColor = Color.Transparent;

            // set only the ones for the active module
            switch (activeModule)
            {
                case "employee":
                    p1.Visible = p2.Visible = true;
                    pc1.BackColor = Color.Orange;
                    break;
                case "faculty":
                    p3.Visible = p4.Visible = true;
                    pc2.BackColor = Color.Orange;
                    break;
                case "attendance":
                    p5.Visible = p6.Visible = true;
                    pc3.BackColor = Color.Orange;
                    break;
            }
        }
    }
}
