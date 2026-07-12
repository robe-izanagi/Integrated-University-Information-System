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
    public partial class EmployeeManagementForm : Form
    {
        // repositories for reading and saving data
        private readonly EmployeeRepository _employeeRepo;
        private List<Employee> _employees;
        public EmployeeManagementForm()
        {
            InitializeComponent();
            // set up the repository for employee data
            _employeeRepo = new EmployeeRepository();

            // load employees from json file
            LoadEmployees();
        }

        // loads all employees from the json file and displays them in the datagridview
        private void LoadEmployees()
        {
            try
            {
                // get all employees from the repository
                _employees = _employeeRepo.GetAll();

                // clear the datagridview before adding new data
                dgvEmployees.DataSource = null;

                // show employee list in the datagridview with only the important columns
                dgvEmployees.DataSource = _employees.Select(e => new
                {
                    e.Id,
                    e.EmployeeNumber,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.BirthDate,
                    e.Gender,
                    e.ContactNumber,
                    e.Email,
                    e.Address,
                    e.Position,
                    e.Department,
                    e.HireDate,
                    e.EmploymentType,
                    e.IsActive
                }).ToList();
            }
            catch (Exception ex)
            {
                // show error message if something goes wrong
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clears all the textboxes and comboboxes so we can add a new employee
        private void ClearFields()
        {
            txtID.Clear();
            txtEmployeeNo.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPosition.Clear();
            txtDepartment.Clear();
            dtpBirthDate.Value = DateTime.Now.AddYears(-25); // default to 25 years old
            dtpHireDate.Value = DateTime.Now;
            cmbGender.SelectedIndex = -1;
            cmbEmploymentType.SelectedIndex = -1;
            chkIsActive.Checked = true;
            txtID.Focus();
        }

        // add button - creates a new employee
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // check if all required fields are filled
                if (string.IsNullOrWhiteSpace(txtEmployeeNo.Text))
                {
                    MessageBox.Show("Please enter Employee Number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmployeeNo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("Please enter First Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Please enter Last Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPosition.Text))
                {
                    MessageBox.Show("Please enter Position.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPosition.Focus();
                    return;
                }

                if (cmbEmploymentType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Employment Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEmploymentType.Focus();
                    return;
                }

                // check if employee number already exists to avoid duplicate
                if (_employeeRepo.GetById(em => em.EmployeeNumber == txtEmployeeNo.Text) != null)
                {
                    MessageBox.Show("Employee Number already exists.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmployeeNo.Focus();
                    return;
                }

                // create a new employee object
                var employee = new Employee
                {
                    Id = _employees.Count > 0 ? _employees.Max(em => em.Id) + 1 : 1, // auto-increment ID
                    EmployeeNumber = txtEmployeeNo.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    MiddleName = txtMiddleName.Text,
                    BirthDate = dtpBirthDate.Value,
                    Gender = cmbGender.Text,
                    ContactNumber = txtContact.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    Position = txtPosition.Text,
                    Department = txtDepartment.Text,
                    HireDate = dtpHireDate.Value,
                    EmploymentType = cmbEmploymentType.Text,
                    IsActive = chkIsActive.Checked
                };

                // save the new employee to json
                _employeeRepo.Add(employee);

                // reload the employee list
                LoadEmployees();

                // clear the form for the next entry
                ClearFields();

                MessageBox.Show("Employee added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // when user clicks on a row in the datagridview, load that employee's details into the textboxes
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                // get the selected row
                var selectedRow = dgvEmployees.SelectedRows[0];

                // find the employee by ID
                var employee = _employeeRepo.GetById(emp => emp.Id == (int)selectedRow.Cells["Id"].Value);

                if (employee != null)
                {
                    // fill the textboxes with the employee's data
                    txtID.Text = employee.Id.ToString();
                    txtEmployeeNo.Text = employee.EmployeeNumber;
                    txtFirstName.Text = employee.FirstName;
                    txtLastName.Text = employee.LastName;
                    txtMiddleName.Text = employee.MiddleName;
                    dtpBirthDate.Value = employee.BirthDate;
                    cmbGender.Text = employee.Gender;
                    txtContact.Text = employee.ContactNumber;
                    txtEmail.Text = employee.Email;
                    txtAddress.Text = employee.Address;
                    txtPosition.Text = employee.Position;
                    txtDepartment.Text = employee.Department;
                    dtpHireDate.Value = employee.HireDate;
                    cmbEmploymentType.Text = employee.EmploymentType;
                    chkIsActive.Checked = employee.IsActive;
                }
            }
        }

        // update button - saves changes to an existing employee
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // must have an ID (User must selected an employee first)
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an employee to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var employee = _employeeRepo.GetById(emp => emp.Id == id);

                if (employee == null)
                {
                    MessageBox.Show("Employee not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // validate required fields
                if (string.IsNullOrWhiteSpace(txtEmployeeNo.Text))
                {
                    MessageBox.Show("Please enter Employee Number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmployeeNo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("Please enter First Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Please enter Last Name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPosition.Text))
                {
                    MessageBox.Show("Please enter Position.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPosition.Focus();
                    return;
                }

                if (cmbEmploymentType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Employment Type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEmploymentType.Focus();
                    return;
                }

                // update the employee object with new values
                employee.EmployeeNumber = txtEmployeeNo.Text;
                employee.FirstName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.MiddleName = txtMiddleName.Text;
                employee.BirthDate = dtpBirthDate.Value;
                employee.Gender = cmbGender.Text;
                employee.ContactNumber = txtContact.Text;
                employee.Email = txtEmail.Text;
                employee.Address = txtAddress.Text;
                employee.Position = txtPosition.Text;
                employee.Department = txtDepartment.Text;
                employee.HireDate = dtpHireDate.Value;
                employee.EmploymentType = cmbEmploymentType.Text;
                employee.IsActive = chkIsActive.Checked;

                // save the changes
                _employeeRepo.Update(emp => emp.Id == id, employee);

                // reload the list
                LoadEmployees();
                ClearFields();

                MessageBox.Show("Employee updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // delete button - marks employee as resigned (soft delete)
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an employee to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var employee = _employeeRepo.GetById(emp => emp.Id == id);

                if (employee == null)
                {
                    MessageBox.Show("Employee not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // confirmation before deleting
                DialogResult result = MessageBox.Show("Are you sure you want to mark this employee as resigned?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // soft delete - set to inactive
                    employee.IsActive = false;
                    _employeeRepo.Update(emp => emp.Id == id, employee);

                    LoadEmployees();
                    ClearFields();

                    MessageBox.Show("Employee marked as resigned.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // refresh button - reloads data from json
        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
            ClearFields();
        }

        // clear button - clears all fields
        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // search - filters the employee list
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchEmployees();
        }

        private void SearchEmployees()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                // filter employees by name, number, position, or department
                var filtered = _employees.Where(emp =>
                    emp.EmployeeNumber.ToLower().Contains(keyword) ||
                    emp.FirstName.ToLower().Contains(keyword) ||
                    emp.LastName.ToLower().Contains(keyword) ||
                    emp.Position.ToLower().Contains(keyword) ||
                    emp.Department.ToLower().Contains(keyword)
                ).ToList();

                // show filtered results
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = filtered.Select(emp => new
                {
                    emp.Id,
                    emp.EmployeeNumber,
                    emp.FirstName,
                    emp.LastName,
                    emp.MiddleName,
                    emp.BirthDate,
                    emp.Gender,
                    emp.ContactNumber,
                    emp.Email,
                    emp.Address,
                    emp.Position,
                    emp.Department,
                    emp.HireDate,
                    emp.EmploymentType,
                    emp.IsActive
                }).ToList();
            }
            catch (Exception)
            {
                // ignore error
            }
        }
    }
}
