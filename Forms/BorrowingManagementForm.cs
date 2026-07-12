using IntegratedUniversityInformationSystem.Models;
using IntegratedUniversityInformationSystem.Repositories;
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
   
    public partial class BorrowingManagementForm : Form
    {
        // repositories for data
        private readonly BorrowingRepository _borrowingRepo;
        private readonly StudentRepository _studentRepo;
        private readonly BookRepository _bookRepo;
        private List<Borrowing> _borrowings;
        public BorrowingManagementForm()
        {
            InitializeComponent();
            // setup repositories
            _borrowingRepo = new BorrowingRepository();
            _studentRepo = new StudentRepository();
            _bookRepo = new BookRepository();

            // load data
            LoadBorrowings();
            LoadStudents();
            LoadBooks();
        }

        // loads all borrowing records
        private void LoadBorrowings()
        {
            try
            {
                _borrowings = _borrowingRepo.GetAll();

                dgvBorrowings.DataSource = null;

                dgvBorrowings.DataSource = _borrowings.Select(b => new
                {
                    b.Id,
                    Student = GetStudentName(b.StudentId),
                    Book = GetBookTitle(b.BookId),
                    b.BorrowDate,
                    b.DueDate,
                    b.ReturnDate,
                    b.Status,
                    b.Remarks
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrowings: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // helper - gets student name
        private string GetStudentName(int studentId)
        {
            var student = _studentRepo.GetById(s => s.Id == studentId);
            return student != null ? $"{student.FirstName} {student.LastName}" : "N/A";
        }

        // helper - gets book title
        private string GetBookTitle(int bookId)
        {
            var book = _bookRepo.GetById(b => b.Id == bookId);
            return book != null ? book.Title : "N/A";
        }

        // loads students for dropdown - read only from students.json
        private void LoadStudents()
        {
            try
            {
                var students = _studentRepo.GetAll().Where(s => s.IsActive).ToList();

                cmbStudent.DataSource = students;
                cmbStudent.DisplayMember = "FullName";
                cmbStudent.ValueMember = "Id";
                cmbStudent.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // loads books for dropdown - only show books with available copies
        private void LoadBooks()
        {
            try
            {
                var books = _bookRepo.GetAll().Where(b => b.IsActive && b.AvailableCopies > 0).ToList();

                cmbBook.DataSource = books;
                cmbBook.DisplayMember = "Title";
                cmbBook.ValueMember = "Id";
                cmbBook.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears fields
        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            cmbBook.SelectedIndex = -1;
            dtpBorrowDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(7);
            dtpReturnDate.Value = DateTime.Now;
            cmbStatus.SelectedIndex = -1;
            txtRemarks.Clear();
            txtID.Focus();
        }

        // borrow button - creates a new borrowing transaction
        private void lblBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                // validate
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbBook.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Book.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBook.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // check if student already has an active borrowing for this book
                int studentId = (int)cmbStudent.SelectedValue;
                int bookId = (int)cmbBook.SelectedValue;

                var existing = _borrowingRepo.GetById(b =>
                    b.StudentId == studentId &&
                    b.BookId == bookId &&
                    b.Status != "Returned" &&
                    b.Status != "Cancelled");

                if (existing != null)
                {
                    MessageBox.Show("Student already has an active borrowing for this book.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // get the book to update available copies
                var book = _bookRepo.GetById(b => b.Id == bookId);
                if (book == null || book.AvailableCopies <= 0)
                {
                    MessageBox.Show("No available copies for this book.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // create new borrowing record
                var borrowing = new Borrowing
                {
                    Id = _borrowings.Count > 0 ? _borrowings.Max(b => b.Id) + 1 : 1,
                    StudentId = studentId,
                    BookId = bookId,
                    BorrowDate = dtpBorrowDate.Value,
                    DueDate = dtpDueDate.Value,
                    Status = cmbStatus.Text,
                    Remarks = txtRemarks.Text
                };

                _borrowingRepo.Add(borrowing);

                // decrease available copies of the book
                book.AvailableCopies -= 1;
                _bookRepo.Update(b => b.Id == bookId, book);

                // reload
                LoadBorrowings();
                LoadBooks();
                ClearFields();

                MessageBox.Show("Book borrowed successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error borrowing book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // return button - marks book as returned
        private void lblReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a borrowing record to return.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var borrowing = _borrowingRepo.GetById(b => b.Id == id);

                if (borrowing == null)
                {
                    MessageBox.Show("Borrowing record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // check if already returned
                if (borrowing.Status == "Returned")
                {
                    MessageBox.Show("This book is already returned.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // confirm return
                DialogResult result = MessageBox.Show("Confirm return of this book?",
                    "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // update borrowing record
                    borrowing.ReturnDate = DateTime.Now;
                    borrowing.Status = "Returned";
                    _borrowingRepo.Update(b => b.Id == id, borrowing);

                    // increase available copies of the book
                    var book = _bookRepo.GetById(b => b.Id == borrowing.BookId);
                    if (book != null)
                    {
                        book.AvailableCopies += 1;
                        _bookRepo.Update(b => b.Id == book.Id, book);
                    }

                    LoadBorrowings();
                    LoadBooks();
                    ClearFields();

                    MessageBox.Show("Book returned successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // load selected record
        private void dgvBorrowings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBorrowings.SelectedRows.Count > 0)
            {
                var selectedRow = dgvBorrowings.SelectedRows[0];
                var borrowing = _borrowingRepo.GetById(b => b.Id == (int)selectedRow.Cells["Id"].Value);

                if (borrowing != null)
                {
                    txtID.Text = borrowing.Id.ToString();
                    cmbStudent.SelectedValue = borrowing.StudentId;
                    cmbBook.SelectedValue = borrowing.BookId;
                    dtpBorrowDate.Value = borrowing.BorrowDate;
                    dtpDueDate.Value = borrowing.DueDate;
                    dtpReturnDate.Value = borrowing.ReturnDate ?? DateTime.Now;
                    cmbStatus.Text = borrowing.Status;
                    txtRemarks.Text = borrowing.Remarks;
                }
            }
        }

        // update button - updates status and other details
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a borrowing record to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var borrowing = _borrowingRepo.GetById(b => b.Id == id);

                if (borrowing == null)
                {
                    MessageBox.Show("Borrowing record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (cmbBook.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Book.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBook.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                borrowing.StudentId = (int)cmbStudent.SelectedValue;
                borrowing.BookId = (int)cmbBook.SelectedValue;
                borrowing.BorrowDate = dtpBorrowDate.Value;
                borrowing.DueDate = dtpDueDate.Value;
                borrowing.Status = cmbStatus.Text;
                borrowing.Remarks = txtRemarks.Text;

                _borrowingRepo.Update(b => b.Id == id, borrowing);
                LoadBorrowings();
                ClearFields();

                MessageBox.Show("Borrowing record updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating borrowing: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // cancel button - cancels the transaction
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a borrowing record to cancel.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var borrowing = _borrowingRepo.GetById(b => b.Id == id);

                if (borrowing == null)
                {
                    MessageBox.Show("Borrowing record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to cancel this borrowing transaction?",
                    "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // set status to cancelled
                    borrowing.Status = "Cancelled";
                    _borrowingRepo.Update(b => b.Id == id, borrowing);

                    // return the book copy if it was borrowed
                    if (borrowing.Status != "Returned" && borrowing.Status != "Cancelled")
                    {
                        var book = _bookRepo.GetById(b => b.Id == borrowing.BookId);
                        if (book != null)
                        {
                            book.AvailableCopies += 1;
                            _bookRepo.Update(b => b.Id == book.Id, book);
                        }
                    }

                    LoadBorrowings();
                    LoadBooks();
                    ClearFields();

                    MessageBox.Show("Borrowing transaction cancelled.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling borrowing: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadBorrowings();
            LoadStudents();
            LoadBooks();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchBorrowings();
        }

        private void SearchBorrowings()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _borrowings.Where(b =>
                    GetStudentName(b.StudentId).ToLower().Contains(keyword) ||
                    GetBookTitle(b.BookId).ToLower().Contains(keyword) ||
                    b.Status.ToLower().Contains(keyword)
                ).ToList();

                dgvBorrowings.DataSource = null;
                dgvBorrowings.DataSource = filtered.Select(b => new
                {
                    b.Id,
                    Student = GetStudentName(b.StudentId),
                    Book = GetBookTitle(b.BookId),
                    b.BorrowDate,
                    b.DueDate,
                    b.ReturnDate,
                    b.Status,
                    b.Remarks
                }).ToList();
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}
