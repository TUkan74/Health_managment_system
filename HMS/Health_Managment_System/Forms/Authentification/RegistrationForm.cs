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
        private bool _adminPermission;


        public RegistrationForm(IUserService userService,bool AdminPermission = false)
        {
            _userService = userService;
            _adminPermission = AdminPermission;
            InitializeComponent();
        }

        public void RegistrationForm_Loader(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpDateOfBirth.Value = DateTime.Today;
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
            if (_adminPermission == false)
            {
                cmbRole.Visible = false;
                cmbRole.Enabled = false;
                lblRole.Visible = false;
            }
             
            
            
        }

        private void lnkBackLgn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
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

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

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

            /*if (!(role == "Doctor" || role == "Patient" || role == "Nurse"))
            {
                MessageBox.Show("Please select a valid role.");
                return;
            }*/

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
                

                var users = await _userService.GetAllUsersAsync();
                string userList = string.Join(Environment.NewLine, users.Select(u => u.Username));
                MessageBox.Show($"User registered successfully. Username: {user.Username}");
                this.DialogResult = DialogResult.OK;

                // DEBUG: Show all users in the database
                //MessageBox.Show("Current users in the database:\n" + userList);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Username is already taken"))
                {
                    MessageBox.Show("Username is already taken. Please choose a different username.");
                }
                else if (ex.Message.Contains("Email is already registered"))
                {
                    MessageBox.Show("Email is already registered. Please use a different email.");
                }
                else
                {
                    MessageBox.Show($"Registration failed: {ex.Message}\n\n{ex.InnerException?.Message}");
                }
            }

            
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            // Any specific logic when the date of birth changes
        }
    }
}
