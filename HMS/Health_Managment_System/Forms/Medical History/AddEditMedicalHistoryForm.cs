using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Health_Managment_System.Forms.Medical_History
{
    public partial class AddEditMedicalHistoryForm : Form
    {
        private readonly IUserService _userService;
        private readonly User _user;
        private MedicalHistory _medicalHistory;
        private bool _isEditMode;

        // Text fields for input
        private TextBox txtCondition;
        private TextBox txtTreatment;
        private DateTimePicker dtpDateDiagnosed;
        private Button btnSave;
        private Button btnCancel;

        // Constructor for editing an existing medical history record
        public AddEditMedicalHistoryForm(User user, IUserService userService, MedicalHistory medicalHistory)
        {
            _userService = userService;
            _user = user;
            _medicalHistory = medicalHistory;
            _isEditMode = true;
            InitializeComponent();
            InitializeFormComponents();
            PopulateFields();
        }

        // Constructor for adding a new medical history record
        public AddEditMedicalHistoryForm(User user, IUserService userService)
        {
            _userService = userService;
            _user = user;
            _isEditMode = false;
            InitializeComponent();
            InitializeFormComponents();
        }

        // Initialize the form components
        private void InitializeFormComponents()
        {
            this.Text = _isEditMode ? "Edit Medical History" : "Add Medical History";
            this.Size = new Size(400, 300);

            // Condition text box
            txtCondition = new TextBox
            {
                Location = new Point(30, 30),
                Size = new Size(300, 30),
                PlaceholderText = "Enter condition"
            };

            // Treatment text box
            txtTreatment = new TextBox
            {
                Location = new Point(30, 80),
                Size = new Size(300, 30),
                PlaceholderText = "Enter treatment"
            };

            // Date diagnosed date picker
            dtpDateDiagnosed = new DateTimePicker
            {
                Location = new Point(30, 130),
                Size = new Size(300, 30)
            };

            // Save button
            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(50, 200),
                Size = new Size(100, 30)
            };
            btnSave.Click += BtnSave_Click;

            // Cancel button
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(200, 200),
                Size = new Size(100, 30)
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Add controls to the form
            this.Controls.Add(txtCondition);
            this.Controls.Add(txtTreatment);
            this.Controls.Add(dtpDateDiagnosed);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        // Populate fields when editing an existing medical history record
        private void PopulateFields()
        {
            if (_medicalHistory != null)
            {
                txtCondition.Text = _medicalHistory.Condition;
                txtTreatment.Text = _medicalHistory.Treatment;
                dtpDateDiagnosed.Value = _medicalHistory.DateDiagnosed;
            }
        }

        // Save the medical history record
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCondition.Text) || string.IsNullOrWhiteSpace(txtTreatment.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (_isEditMode)
            {
                // Update existing medical history
                _medicalHistory.Condition = txtCondition.Text;
                _medicalHistory.Treatment = txtTreatment.Text;
                _medicalHistory.DateDiagnosed = dtpDateDiagnosed.Value;

                await _userService.UpdateMedicalHistoryAsync(_medicalHistory);
            }
            else
            {
                // Create new medical history
                var newMedicalHistory = new MedicalHistory
                {
                    PatientRecordId = _user.PatientRecord.Id,
                    Condition = txtCondition.Text,
                    Treatment = txtTreatment.Text,
                    DateDiagnosed = dtpDateDiagnosed.Value
                };

                await _userService.AddMedicalHistoryAsync(newMedicalHistory);
            }

            MessageBox.Show("Medical history saved successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
