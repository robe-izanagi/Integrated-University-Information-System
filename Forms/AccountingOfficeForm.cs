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

        // current active sidebar 
        private string activeSidebar = "payment"; // payment - scholarship - tuition

        // holds forms that will open inside the panel
        private Form _activeForm = null;

        // constructor - runs when form is created
        public AccountingOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Accounting Office";

            // highlight the default menu item (payment)
            handleModule(activeSidebar);

            // auto-load Payment Management when form opens
            OpenChildForm(new PaymentManagementForm());
        }

        // opens forms inside panelContent
        private void OpenChildForm(Form childForm)
        {
            // close existing form if one open
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            // set up new form to be embedded inside the panel
            _activeForm = childForm;
            childForm.TopLevel = false;     // not a standalone window
            childForm.FormBorderStyle = FormBorderStyle.None;      // remove borders
            childForm.Dock = DockStyle.Fill;   // fill the entire panel

            // add to panel and show
            panelContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        // opens Payment Management
        private void lblPayment_Click(object sender, EventArgs e)
        {
            activeSidebar = "payment";
            OpenChildForm(new PaymentManagementForm());
            handleModule(activeSidebar);
        }

        // opens Scholarship Management
        private void lblScholarship_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ScholarshipManagementForm());
            activeSidebar = "scholarship";
            handleModule(activeSidebar);
            
        }

        // opens Tuition Management
        private void lblTuition_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TuitionManagementForm());
            activeSidebar = "tuition";
            handleModule(activeSidebar);
            
        }

        // Handle UI design changes on Sidebar modules
        private void handleModule (string activeModule)
        {
            // reset everything first
            p1.Visible = p2.Visible = p3.Visible = p4.Visible = p5.Visible = p6.Visible = false;
            pc1.BackColor = pc2.BackColor = pc3.BackColor = Color.Transparent;

            // set only the ones for the active module
            switch (activeModule)
            {
                case "payment":
                    p1.Visible = p2.Visible = true;
                    pc1.BackColor = Color.LightSkyBlue;
                    break;
                case "scholarship":
                    p3.Visible = p4.Visible = true;
                    pc2.BackColor = Color.LightSkyBlue;
                    break;
                case "tuition":
                    p5.Visible = p6.Visible = true;
                    pc3.BackColor = Color.LightSkyBlue;
                    break;
            }
        }

        // logout and go back to login
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
