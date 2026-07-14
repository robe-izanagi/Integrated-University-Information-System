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
    public partial class AppointmentManagementForm : Form
    {
        private readonly AppointmentRepository _appointmentRepo;
        private readonly StudentRepository _studentRepo;
        private List<Appointment> _appointments;
        public AppointmentManagementForm()
        {
            InitializeComponent();
            _appointmentRepo = new AppointmentRepository();
            _studentRepo = new StudentRepository();

            LoadAppointments();
            LoadStudents();
        }

        private void LoadAppointments()
        {
            try
            {
                _appointments = _appointmentRepo.GetAll();

                dgvAppointments.DataSource = null;

                dgvAppointments.DataSource = _appointments.Select(a => new
                {
                    a.Id,
                    Student = GetStudentName(a.StudentId),
                    a.AppointmentDate,
                    a.AppointmentTime,
                    a.Purpose,
                    a.Status,
                    a.Remarks
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStudentName(int studentId)
        {
            var student = _studentRepo.GetById(s => s.Id == studentId);
            return student != null ? $"{student.FirstName} {student.LastName}" : "N/A";
        }

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

        private void ClearFields()
        {
            txtID.Clear();
            cmbStudent.SelectedIndex = -1;
            dtpAppointmentDate.Value = DateTime.Now;
            dtpAppointmentTime.Value = DateTime.Now;
            txtPurpose.Clear();
            cmbStatus.SelectedIndex = -1;
            txtRemarks.Clear();
            txtID.Focus();
        }
        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate fields
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPurpose.Text))
                {
                    MessageBox.Show("Please enter Purpose.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurpose.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // combine date and time
                DateTime appointmentDateTime = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;

                // create new appointment
                var appointment = new Appointment
                {
                    Id = _appointments.Count > 0 ? _appointments.Max(a => a.Id) + 1 : 1,
                    StudentId = (int)cmbStudent.SelectedValue,
                    AppointmentDate = appointmentDateTime,
                    AppointmentTime = appointmentDateTime,
                    Purpose = txtPurpose.Text,
                    Status = cmbStatus.Text,
                    Remarks = txtRemarks.Text
                };

                _appointmentRepo.Add(appointment);
                LoadAppointments();
                ClearFields();

                MessageBox.Show("Appointment added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding appointment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                var selectedRow = dgvAppointments.SelectedRows[0];
                var appointment = _appointmentRepo.GetById(a => a.Id == (int)selectedRow.Cells["Id"].Value);

                if (appointment != null)
                {
                    txtID.Text = appointment.Id.ToString();
                    cmbStudent.SelectedValue = appointment.StudentId;
                    dtpAppointmentDate.Value = appointment.AppointmentDate;
                    dtpAppointmentTime.Value = appointment.AppointmentTime;
                    txtPurpose.Text = appointment.Purpose;
                    cmbStatus.Text = appointment.Status;
                    txtRemarks.Text = appointment.Remarks;
                }
            }
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an appointment to update.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var appointment = _appointmentRepo.GetById(a => a.Id == id);

                if (appointment == null)
                {
                    MessageBox.Show("Appointment not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // validate fields
                if (cmbStudent.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a Student.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPurpose.Text))
                {
                    MessageBox.Show("Please enter Purpose.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurpose.Focus();
                    return;
                }

                if (cmbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Focus();
                    return;
                }

                // combine date and time
                DateTime appointmentDateTime = dtpAppointmentDate.Value.Date + dtpAppointmentTime.Value.TimeOfDay;

                // update appointment
                appointment.StudentId = (int)cmbStudent.SelectedValue;
                appointment.AppointmentDate = appointmentDateTime;
                appointment.AppointmentTime = appointmentDateTime;
                appointment.Purpose = txtPurpose.Text;
                appointment.Status = cmbStatus.Text;
                appointment.Remarks = txtRemarks.Text;

                _appointmentRepo.Update(a => a.Id == id, appointment);
                LoadAppointments();
                ClearFields();

                MessageBox.Show("Appointment updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating appointment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select an appointment to delete.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtID.Text);
                var appointment = _appointmentRepo.GetById(a => a.Id == id);

                if (appointment == null)
                {
                    MessageBox.Show("Appointment not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Cancel this appointment?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // soft delete - set status to cancelled
                    appointment.Status = "Cancelled";
                    _appointmentRepo.Update(a => a.Id == id, appointment);

                    LoadAppointments();
                    ClearFields();

                    MessageBox.Show("Appointment cancelled.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling appointment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
            LoadStudents();
            ClearFields();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchAppointments();
        }
        private void SearchAppointments()
        {
            try
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = _appointments.Where(a =>
                    GetStudentName(a.StudentId).ToLower().Contains(keyword) ||
                    a.Purpose.ToLower().Contains(keyword) ||
                    a.Status.ToLower().Contains(keyword)
                ).ToList();

                dgvAppointments.DataSource = null;
                dgvAppointments.DataSource = filtered.Select(a => new
                {
                    a.Id,
                    Student = GetStudentName(a.StudentId),
                    a.AppointmentDate,
                    a.AppointmentTime,
                    a.Purpose,
                    a.Status,
                    a.Remarks
                }).ToList();
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private void AppointmentManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
