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
    public partial class BookManagementForm : Form
    {
        // repository for saving and loading books
        private readonly BookRepository _bookRepo;
        private List<Book> _books;
        public BookManagementForm()
        {
            InitializeComponent();
            // setup the repository
            _bookRepo = new BookRepository();

            // load books from json
            LoadBooks();
        }

        // loads all books from the json file
        private void LoadBooks()
        {
            try
            {
                // get all books from the repository
                _books = _bookRepo.GetAll();

                // clear the datagridview
                dgvBooks.DataSource = null;

                // show only the important columns
                dgvBooks.DataSource = _books.Select(b => new
                {
                    b.Id,
                    b.ISBN,
                    b.Title,
                    b.Author,
                    b.Publisher,
                    b.YearPublished,
                    b.Category,
                    b.Location,
                    b.Quantity,
                    b.AvailableCopies,
                    b.IsActive
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears all textboxes and comboboxes
        private void ClearFields()
        {
            txtID.Clear();
            txtISBN.Clear();
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            numYearPublished.Value = DateTime.Now.Year;
            cmbCategory.SelectedIndex = -1;
            txtLocation.Clear();
            numQuantity.Value = 1;
            numAvailable.Value = 1;
            chkIsActive.Checked = true;
            txtID.Focus();
        }

        // add button - creates a new book
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate required fields
                if (string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    MessageBox.Show("Please enter ISBN.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtISBN.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
                {
                    MessageBox.Show("Please enter Book Title.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookTitle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    MessageBox.Show("Please enter Author.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAuthor.Focus();
                    return;
                }

                if (cmbCategory.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Category.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCategory.Focus();
                    return;
                }

                // check if ISBN already exists
                if (_bookRepo.GetById(b => b.ISBN == txtISBN.Text) != null)
                {
                    MessageBox.Show("ISBN already exists.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtISBN.Focus();
                    return;
                }

                // make sure available copies is not more than total quantity
                int quantity = (int)numQuantity.Value;
                int available = (int)numAvailable.Value;

                if (available > quantity)
                {
                    MessageBox.Show("Available copies cannot be more than total quantity.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numAvailable.Focus();
                    return;
                }

                // create new book object
                var book = new Book
                {
                    Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1,
                    ISBN = txtISBN.Text,
                    Title = txtBookTitle.Text,
                    Author = txtAuthor.Text,
                    Publisher = txtPublisher.Text,
                    YearPublished = (int)numYearPublished.Value,
                    Category = cmbCategory.Text,
                    Location = txtLocation.Text,
                    Quantity = quantity,
                    AvailableCopies = available,
                    IsActive = chkIsActive.Checked
                };

                // save to json
                _bookRepo.Add(book);

                // reload the list
                LoadBooks();

                // clear the form
                ClearFields();

                MessageBox.Show("Book added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // on clicks a row, load the book details
        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedRow = dgvBooks.SelectedRows[0];
                var book = _bookRepo.GetById(b => b.Id == (int)selectedRow.Cells["Id"].Value);

                if (book != null)
                {
                    txtID.Text = book.Id.ToString();
                    txtISBN.Text = book.ISBN;
                    txtBookTitle.Text = book.Title;
                    txtAuthor.Text = book.Author;
                    txtPublisher.Text = book.Publisher;
                    numYearPublished.Value = book.YearPublished;
                    cmbCategory.Text = book.Category;
                    txtLocation.Text = book.Location;
                    numQuantity.Value = book.Quantity;
                    numAvailable.Value = book.AvailableCopies;
                    chkIsActive.Checked = book.IsActive;
                }
            }
        }

        // update button - saves changes to existing book
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a book to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var book = _bookRepo.GetById(b => b.Id == id);

                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // validate fields
                if (string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    MessageBox.Show("Please enter ISBN.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtISBN.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
                {
                    MessageBox.Show("Please enter Book Title.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookTitle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    MessageBox.Show("Please enter Author.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAuthor.Focus();
                    return;
                }

                if (cmbCategory.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Category.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCategory.Focus();
                    return;
                }

                int quantity = (int)numQuantity.Value;
                int available = (int)numAvailable.Value;

                if (available > quantity)
                {
                    MessageBox.Show("Available copies cannot be more than total quantity.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numAvailable.Focus();
                    return;
                }

                // update the book object
                book.ISBN = txtISBN.Text;
                book.Title = txtBookTitle.Text;
                book.Author = txtAuthor.Text;
                book.Publisher = txtPublisher.Text;
                book.YearPublished = (int)numYearPublished.Value;
                book.Category = cmbCategory.Text;
                book.Location = txtLocation.Text;
                book.Quantity = quantity;
                book.AvailableCopies = available;
                book.IsActive = chkIsActive.Checked;

                // save changes
                _bookRepo.Update(b => b.Id == id, book);
                LoadBooks();
                ClearFields();

                MessageBox.Show("Book updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // delete button - marks book as damaged/lost
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select a book to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var book = _bookRepo.GetById(b => b.Id == id);

                if (book == null)
                {
                    MessageBox.Show("Book not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Mark this book as damaged/lost? This will set it to inactive.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // soft delete - set to inactive
                    book.IsActive = false;
                    _bookRepo.Update(b => b.Id == id, book);

                    LoadBooks();
                    ClearFields();

                    MessageBox.Show("Book marked as damaged/lost.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // search - filters books by title, author, isbn, or category
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
            ClearFields();
        }

        private void SearchBooks()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _books.Where(b =>
                    b.ISBN.ToLower().Contains(keyword) ||
                    b.Title.ToLower().Contains(keyword) ||
                    b.Author.ToLower().Contains(keyword) ||
                    b.Category.ToLower().Contains(keyword)
                ).ToList();

                dgvBooks.DataSource = null;
                dgvBooks.DataSource = filtered.Select(b => new
                {
                    b.Id,
                    b.ISBN,
                    b.Title,
                    b.Author,
                    b.Publisher,
                    b.YearPublished,
                    b.Category,
                    b.Location,
                    b.Quantity,
                    b.AvailableCopies,
                    b.IsActive
                }).ToList();
            }
            catch (Exception)
            {
                // ignore search errors
            }
        }
    }
}
