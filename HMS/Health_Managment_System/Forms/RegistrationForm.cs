using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using Microsoft.VisualBasic.ApplicationServices;


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
            //TODO: Implement registration check if the username is already taken and stuff

            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var role = cmbRole.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (username.Length < 4 || password.Length < 4)
            {
                MessageBox.Show("Username and password must be at least 4 characters long.");
                return;
            }
            if (!(role == "Doctor" || role == "Patient" || role == "Nurse"))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            var user = new HealthcareManagementSystem.Models.User
            {
                Username = username,
                PasswordHash = password,  // Hashing will be done in the UserService
                Role = role
            };

            await _userService.RegisterAsync(user);
            MessageBox.Show("User registered successfully.");
            this.Close();

            MessageBox.Show("Successfully registered!");

            this.Close();

        }
    }
}
