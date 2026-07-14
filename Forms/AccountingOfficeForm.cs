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

            handleModule(activeSidebar);
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

        private void handleModule (string activeModule)
        {
            switch (activeModule)
            {
                case "payment":
                    p1.Visible = true;
                    p2.Visible = true;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc1.BackColor = Color.LightSkyBlue;
                    pc2.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                break;
                case "scholarship":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = true;
                    p4.Visible = true;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc2.BackColor = Color.LightSkyBlue;
                    pc1.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    break;
                case "tuition":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = true;
                    p6.Visible = true;
                    pc3.BackColor = Color.LightSkyBlue;
                    pc1.BackColor = Color.Transparent;
                    pc2.BackColor = Color.Transparent;
                    break;
            }
        }

        // logout and go back to login
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
