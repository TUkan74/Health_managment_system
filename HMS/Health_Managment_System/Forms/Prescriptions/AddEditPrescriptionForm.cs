using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Managment_System.Forms.Prescriptions
{
    public partial class AddEditPrescriptionForm : Form
    {
        private readonly IUserService _userService;
        private readonly User _user;
        private Prescription _prescription;
        private bool _isEditMode;
        private List<User> _doctors;

        private TextBox txtDrugName;
        private TextBox txtDosage;
        private TextBox txtUsageInstructions;
        private DateTimePicker dtpDatePrescribed;
        private ComboBox cmbDoctors; // ComboBox for selecting doctors
        private Button btnSave;
        private Button btnCancel;

        // Constructor for adding a new prescription
        public AddEditPrescriptionForm(User user, IUserService userService)
        {
            _userService = userService;
            _user = user;
            _isEditMode = false;
            InitializeComponent();
            InitializeFormComponents();
            LoadDoctorsAsync(); // Load doctors when creating a new prescription
        }

        // Constructor for editing an existing prescription
        public AddEditPrescriptionForm(User user, IUserService userService, Prescription prescription)
        {
            _userService = userService;
            _user = user;
            _prescription = prescription;
            _isEditMode = true;
            InitializeComponent();
            InitializeFormComponents();
            PopulateFields();
            LoadDoctorsAsync(); // Load doctors when editing an existing prescription
        }

        // Initialize the form components
        private void InitializeFormComponents()
        {
            this.Text = _isEditMode ? "Edit Prescription" : "Add Prescription";
            this.Size = new Size(400, 350);

            // Text box for drug name
            txtDrugName = new TextBox
            {
                Location = new Point(30, 30),
                Size = new Size(300, 30),
                PlaceholderText = "Enter drug name"
            };

            // Text box for dosage
            txtDosage = new TextBox
            {
                Location = new Point(30, 80),
                Size = new Size(300, 30),
                PlaceholderText = "Enter dosage"
            };

            // Text box for usage instructions
            txtUsageInstructions = new TextBox
            {
                Location = new Point(30, 130),
                Size = new Size(300, 30),
                PlaceholderText = "Enter usage instructions"
            };

            // Date picker for the prescription date
            dtpDatePrescribed = new DateTimePicker
            {
                Location = new Point(30, 180),
                Size = new Size(300, 30)
            };

            // Combo box for selecting doctors
            cmbDoctors = new ComboBox
            {
                Location = new Point(30, 230),
                Size = new Size(300, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Save button
            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(50, 280),
                Size = new Size(100, 30)
            };
            btnSave.Click += BtnSave_Click;

            // Cancel button
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(200, 280),
                Size = new Size(100, 30)
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Add controls to the form
            this.Controls.Add(txtDrugName);
            this.Controls.Add(txtDosage);
            this.Controls.Add(txtUsageInstructions);
            this.Controls.Add(dtpDatePrescribed);
            this.Controls.Add(cmbDoctors);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        // Populate the fields when editing an existing prescription
        private void PopulateFields()
        {
            if (_prescription != null)
            {
                txtDrugName.Text = _prescription.DrugName;
                txtDosage.Text = _prescription.Dosage;
                txtUsageInstructions.Text = _prescription.UsageInstructions;
                dtpDatePrescribed.Value = _prescription.DatePrescribed;
                cmbDoctors.SelectedValue = _prescription.DoctorId; // Pre-select the assigned doctor
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
                cmbDoctors.DisplayMember = "FullName"; // Assuming FullName combines first and last name
                cmbDoctors.ValueMember = "Id"; // Assign the doctor's ID as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save the prescription
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDrugName.Text) || string.IsNullOrWhiteSpace(txtDosage.Text) || string.IsNullOrWhiteSpace(txtUsageInstructions.Text))
            {
                MessageBox.Show("Please fill in all fields.");
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
                // Update existing prescription
                _prescription.DrugName = txtDrugName.Text;
                _prescription.Dosage = txtDosage.Text;
                _prescription.UsageInstructions = txtUsageInstructions.Text;
                _prescription.DatePrescribed = dtpDatePrescribed.Value;
                _prescription.DoctorId = selectedDoctorId; // Set the selected doctor ID

                await _userService.UpdatePrescriptionAsync(_prescription);
            }
            else
            {
                // Create new prescription
                var newPrescription = new Prescription
                {
                    PatientRecordId = _user.PatientRecordId ?? 0, // Ensure PatientRecordId is set
                    DrugName = txtDrugName.Text,
                    Dosage = txtDosage.Text,
                    UsageInstructions = txtUsageInstructions.Text,
                    DatePrescribed = dtpDatePrescribed.Value,
                    DoctorId = selectedDoctorId // Assign the selected doctor ID
                };

                await _userService.AddPrescriptionAsync(newPrescription);
            }

            MessageBox.Show("Prescription saved successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
