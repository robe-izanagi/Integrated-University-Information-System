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
            switch (activeModule)
            {
                case "books":
                    p1.Visible = true;
                    p2.Visible = true;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc1.BackColor = Color.FromArgb(218, 160, 109);
                    pc2.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    break;
                case "borrowings":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = true;
                    p4.Visible = true;
                    p5.Visible = false;
                    p6.Visible = false;
                    pc2.BackColor = Color.FromArgb(218, 160, 109);
                    pc1.BackColor = Color.Transparent;
                    pc3.BackColor = Color.Transparent;
                    break;
                case "fines":
                    p1.Visible = false;
                    p2.Visible = false;
                    p3.Visible = false;
                    p4.Visible = false;
                    p5.Visible = true;
                    p6.Visible = true;
                    pc3.BackColor = Color.FromArgb(218, 160, 109);
                    pc1.BackColor = Color.Transparent;
                    pc2.BackColor = Color.Transparent;
                    break;
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
