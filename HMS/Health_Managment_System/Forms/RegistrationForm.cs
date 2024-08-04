// Forms/RegistrationForm.cs
using System;
using System.Linq;
using System.Windows.Forms;
using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;

namespace Health_Managment_System.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly IUserService _userService;

        public RegistrationForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void lnkBackLgn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            bool hasError = false;

            // Check each field and change the background color if empty
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtUsername.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtPassword.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                txtConfirmPassword.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtConfirmPassword.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtEmail.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtFirstName.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                txtLastName.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtLastName.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtAddress.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                txtPhoneNumber.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                txtPhoneNumber.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                cmbRole.BackColor = Color.Red;
                hasError = true;
            }
            else
            {
                cmbRole.BackColor = Color.White;
            }

            // Show message box if there is an error
            if (hasError)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;
            var email = txtEmail.Text;
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var dateOfBirth = dtpDateOfBirth.Value;
            var address = txtAddress.Text;
            var phoneNumber = txtPhoneNumber.Text;
            var role = cmbRole.Text;

            if (username.Length < 4 || password.Length < 4)
            {
                MessageBox.Show("Username and password must be at least 4 characters long.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (!(role == "Doctor" || role == "Patient" || role == "Nurse"))
            {
                MessageBox.Show("Please select a valid role.");
                return;
            }

            var user = new User
            {
                Username = username,
                PasswordHash = password,  // Hashing will be done in the UserService
                Role = role,
                Email = email,
                PatientRecord = new PatientRecord
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Email = email
                }
            };

            try
            {
                await _userService.RegisterAsync(user);
                MessageBox.Show("User registered successfully.");

                var users = await _userService.GetAllUsersAsync();
                string userList = string.Join(Environment.NewLine, users.Select(u => u.Username));
                MessageBox.Show("Current users in the database:\n" + userList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}");
            }

            this.Close();
        }


        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
                
        }
    }
}
