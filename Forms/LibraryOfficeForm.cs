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
    public partial class LibraryOfficeForm : Form
    {
        private readonly User _currentUser;
        private Form _activeForm = null;
        // current active sidebar 
        private string activeSidebar = "books"; // books - borrowings - fines

        public LibraryOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Library Office";

            handleModule(activeSidebar);
            OpenChildForm(new BookManagementForm());
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

        private void lblBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BookManagementForm());
            activeSidebar = "books";
            handleModule(activeSidebar);
        }

        private void lblBorrowings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BorrowingManagementForm());
            activeSidebar = "borrowings";
            handleModule(activeSidebar);
        }

        private void lblFines_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FineManagementForm());
            activeSidebar = "fines";
            handleModule(activeSidebar);
        }

        private void handleModule(string activeModule)
        {
            // reset everything first
            p1.Visible = p2.Visible = p3.Visible = p4.Visible = p5.Visible = p6.Visible = false;
            pc1.BackColor = pc2.BackColor = pc3.BackColor = Color.Transparent;

            // set only the ones for the active module
            switch (activeModule)
            {
                case "books":
                    p1.Visible = p2.Visible = true;
                    pc1.BackColor = Color.FromArgb(218, 160, 109);
                    break;
                case "borrowings":
                    p3.Visible = p4.Visible = true;
                    pc2.BackColor = Color.FromArgb(218, 160, 109);
                    break;
                case "fines":
                    p5.Visible = p6.Visible = true;
                    pc3.BackColor = Color.FromArgb(218, 160, 109);
                    break;
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
