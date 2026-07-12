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
        public LibraryOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Library Office";
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
        }

        private void lblBorrowings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BorrowingManagementForm());
        }

        private void lblFines_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FineManagementForm());
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
