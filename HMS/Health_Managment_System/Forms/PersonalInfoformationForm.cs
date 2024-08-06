using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Windows.Forms;

namespace Health_Managment_System.Forms
{
    public partial class PersonalInfoformationForm : Form
    {
        private User _user;
        private readonly IUserService _userService;
        private bool _isEditing = false;

        public PersonalInfoformationForm(User user, IUserService userService)
        {
            _user = user;
            _userService = userService;
            InitializeComponent();
            this.Load += PersonalInfoformationForm_Load;
        }

        private void PersonalInfoformationForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
            ToggleEditMode(false); // Start in view mode
        }

        private void LoadUserData()
        {
            txtUsername.Text = _user.Username;
            txtEmail.Text = _user.Email;

            if (_user.PatientRecord != null)
            {
                PatientRecord patientRecord = _user.PatientRecord;
                txtFirstName.Text = patientRecord.FirstName;
                txtLastName.Text = patientRecord.LastName;
                dtpDateOfBirth.Value = patientRecord.DateOfBirth;
                txtAddress.Text = patientRecord.Address;
                txtPhoneNumber.Text = patientRecord.PhoneNumber;
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                dtpDateOfBirth.Value = DateTime.Today;
                txtAddress.Text = "";
                txtPhoneNumber.Text = "";
            }

            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] { "Doctor", "Patient", "Nurse" });
            cmbRole.Text = _user.Role;
        }

        private void ToggleEditMode(bool isEditing)
        {
            _isEditing = isEditing;

            txtUsername.ReadOnly = !isEditing;
            txtEmail.ReadOnly = !isEditing;
            txtFirstName.ReadOnly = !isEditing;
            txtLastName.ReadOnly = !isEditing;
            dtpDateOfBirth.Enabled = isEditing;
            txtAddress.ReadOnly = !isEditing;
            txtPhoneNumber.ReadOnly = !isEditing;
            cmbRole.Enabled = isEditing;
            txtPassword.Visible = isEditing;
            txtConfirmPassword.Visible = isEditing;
            lblPassword.Visible = isEditing;
            lblConfirmPassword.Visible = isEditing;
            btnSave.Enabled = isEditing;
            btnEdit.Enabled = !isEditing;

            if (!isEditing)
            {
                // Hide passwords in view mode
                txtPassword.Text = "********";
                txtConfirmPassword.Text = "********";
            }
            else
            {
                // Clear passwords in edit mode
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
        }



        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Update user and patient record details
            _user.Username = txtUsername.Text;
            _user.Email = txtEmail.Text;
            _user.Role = cmbRole.Text;

            if (_user.PatientRecord != null)
            {
                _user.PatientRecord.FirstName = txtFirstName.Text;
                _user.PatientRecord.LastName = txtLastName.Text;
                _user.PatientRecord.DateOfBirth = dtpDateOfBirth.Value;
                _user.PatientRecord.Address = txtAddress.Text;
                _user.PatientRecord.PhoneNumber = txtPhoneNumber.Text;
            }
            else
            {
                _user.PatientRecord = new PatientRecord
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Email = txtEmail.Text
                };
            }

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
            }

            try
            {
                await _userService.UpdateUserAsync(_user);
                MessageBox.Show("Personal information updated successfully.");
                ToggleEditMode(false);
                LoadUserData(); // Refresh data to reflect any changes
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the information: {ex.Message}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ToggleEditMode(true);
        }
    }
}
