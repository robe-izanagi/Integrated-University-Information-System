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
        // stores the logged-in user info
        private readonly User _currentUser;

        // holds the currently open child form inside the panel
        private Form _activeForm = null;

        // tracks which sidebar menu item is currently selected
        // default is "books" so Books page loads first
        private string activeSidebar = "books"; // books - borrowings - fines

        public LibraryOfficeForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = "Library Office";

            // highlight the default menu item (books)
            handleModule(activeSidebar);

            // automatically load Books management when form opens
            OpenChildForm(new BookManagementForm());
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
            childForm.TopLevel = false;  // not a standalone window
            childForm.FormBorderStyle = FormBorderStyle.None;  // remove borders
            childForm.Dock = DockStyle.Fill; // fill the entire panel

            panelContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        // when user clicks Books menu
        private void lblBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BookManagementForm());
            activeSidebar = "books";
            handleModule(activeSidebar);
        }

        // when user clicks Borrowings menu
        private void lblBorrowings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BorrowingManagementForm());
            activeSidebar = "borrowings";
            handleModule(activeSidebar);
        }

        // when user clicks Fines menu
        private void lblFines_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FineManagementForm());
            activeSidebar = "fines";
            handleModule(activeSidebar);
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

        // logout - closes current form and shows login form
        private void lblLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
