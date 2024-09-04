using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Managment_System.Forms.Appointments
{
    public partial class AddEditAppointmentForm : Form
    {
        private readonly IUserService _userService;
        private readonly User _user;
        private Appointment _appointment;
        private bool _isEditMode;
        private List<User> _doctors;

        private DateTimePicker dtpDate;
        private TextBox txtDescription;
        private ComboBox cmbStatus;
        private ComboBox cmbDoctors; // ComboBox for selecting doctors
        private Button btnSave;
        private Button btnCancel;

        // Constructor for creating a new appointment
        public AddEditAppointmentForm(User user, IUserService userService)
        {
            _userService = userService;
            _user = user;
            _isEditMode = false;
            InitializeComponent();
            InitializeFormComponents();
            LoadDoctorsAsync(); // Load doctors when creating a new appointment
        }

        // Constructor for editing an existing appointment
        public AddEditAppointmentForm(User user, IUserService userService, Appointment appointment)
        {
            _userService = userService;
            _user = user;
            _appointment = appointment;
            _isEditMode = true;
            InitializeComponent();
            InitializeFormComponents();
            PopulateFields();
            LoadDoctorsAsync(); // Load doctors when editing an existing appointment
        }

        // Initialize the form components
        private void InitializeFormComponents()
        {
            this.Text = _isEditMode ? "Edit Appointment" : "Add Appointment";
            this.Size = new Size(400, 350);

            // Date picker for the appointment date
            dtpDate = new DateTimePicker
            {
                Location = new Point(30, 30),
                Size = new Size(300, 30)
            };

            // Text box for the appointment description
            txtDescription = new TextBox
            {
                Location = new Point(30, 80),
                Size = new Size(300, 30),
                PlaceholderText = "Enter description"
            };

            // Combo box for the appointment status
            cmbStatus = new ComboBox
            {
                Location = new Point(30, 130),
                Size = new Size(300, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new string[] { "Scheduled", "Completed", "Canceled" });

            // Combo box for selecting doctors
            cmbDoctors = new ComboBox
            {
                Location = new Point(30, 180),
                Size = new Size(300, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Save button
            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(50, 240),
                Size = new Size(100, 30)
            };
            btnSave.Click += BtnSave_Click;

            // Cancel button
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(200, 240),
                Size = new Size(100, 30)
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Add controls to the form
            this.Controls.Add(dtpDate);
            this.Controls.Add(txtDescription);
            this.Controls.Add(cmbStatus);
            this.Controls.Add(cmbDoctors);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        // Populate the fields when editing an existing appointment
        private void PopulateFields()
        {
            if (_appointment != null)
            {
                dtpDate.Value = _appointment.Date;
                txtDescription.Text = _appointment.Description;
                cmbStatus.SelectedItem = _appointment.Status;
                cmbDoctors.SelectedValue = _appointment.DoctorId; // Pre-select the assigned doctor
            }
        }

        // Load the list of doctors into the ComboBox
        private async void LoadDoctorsAsync()
        {
            try
            {
                _doctors = await _userService.GetAllUsersAsync();
                var doctorList = _doctors.Where(d => d.Role == "Doctor").ToList(); // Filter only doctors

                cmbDoctors.DataSource = doctorList;
                cmbDoctors.DisplayMember = "FullName"; 
                cmbDoctors.ValueMember = "Id"; // Assign the doctor's ID as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save the appointment
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description.");
                return;
            }

            if (cmbDoctors.SelectedItem == null)
            {
                MessageBox.Show("Please select a doctor.");
                return;
            }

            var selectedDoctorId = (int)cmbDoctors.SelectedValue; // Get the selected doctor's ID

            if (_isEditMode)
            {
                // Update existing appointment
                _appointment.Date = dtpDate.Value;
                _appointment.Description = txtDescription.Text;
                _appointment.Status = cmbStatus.SelectedItem?.ToString() ?? "Scheduled";
                _appointment.DoctorId = selectedDoctorId; // Set the selected doctor ID

                await _userService.UpdateAppointmentAsync(_appointment);
            }
            else
            {
                // Create new appointment
                var newAppointment = new Appointment
                {
                    UserId = _user.Id,
                    DoctorId = selectedDoctorId, // Assign the selected doctor ID
                    Date = dtpDate.Value,
                    Description = txtDescription.Text,
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Scheduled"
                };

                await _userService.AddAppointmentAsync(newAppointment);
            }

            MessageBox.Show("Appointment saved successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
