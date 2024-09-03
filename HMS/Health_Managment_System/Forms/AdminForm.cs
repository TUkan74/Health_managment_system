﻿using Health_Managment_System.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Managment_System.Forms
{
    public partial class AdminForm : Form
    {
        private readonly IUserService _userService;
        private DataGridView dgvUsers;

        public AdminForm(IUserService userService)
        {
            _userService = userService;
            InitializeUserGrid();
            LoadUsersAsync();
            InitializeComponent();
        }

        
        private void InitializeUserGrid()
        {
            dgvUsers = new DataGridView
            {
                Location = new Point(50, 50),
                Size = new Size(700, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

            dgvUsers.Columns.Add("Username", "Username");
            dgvUsers.Columns.Add("Email", "Email");
            dgvUsers.Columns.Add("Role", "Role");
            dgvUsers.Columns.Add("PasswordHash", "Password Hash");

            // Edit user information button
            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(50, 370)
            };
            btnEdit.Click += BtnEdit_Click;

            // Delete user button
            Button btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(150, 370)
            };
            btnDelete.Click += BtnDelete_Click;

            //Appointments button
            Button btnAppointments = new Button
            {
                Text = "Appointments",
                Location = new Point(250, 370)
            };

            // Prescriptions button
            Button btnPrescriptions = new Button
            {
                Text = "Prescriptions",
                Location = new Point(350, 370)
            };

            // Medical Records button
            Button btnMedicalRecords = new Button
            {
                Text = "Medical Records",
                Location = new Point(450, 370)
            };

            this.Controls.Add(dgvUsers);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
        }

        private async void LoadUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            dgvUsers.Rows.Clear();

            foreach (var user in users)
            {
                dgvUsers.Rows.Add(user.Username, user.Email, user.Role, user.PasswordHash);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedUser = dgvUsers.SelectedRows[0];
                // Open an edit form here (implementation of the form will be done later)
                MessageBox.Show($"Edit user: {selectedUser.Cells["Username"].Value}");
                var username = selectedUser.Cells["Username"].Value.ToString();
                var user = await _userService.GetUserByNameAsync(username);

                // Check if the user was found
                if (user != null)
                {
                    // Open the PersonalInformationForm with the selected user
                    var personalInfoForm = new PersonalInfoformationForm(user, _userService,true);
                    personalInfoForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }

                
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedUser = dgvUsers.SelectedRows[0];
                var username = selectedUser.Cells["Username"].Value.ToString();
                var user = await _userService.GetUserByNameAsync(username);

                // Check if the user was found
                if (user != null)
                {
                    // Confirm before deleting the user
                    var confirmation = MessageBox.Show($"Are you sure you want to delete the user '{username}'?",
                                                       "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Yes)
                    {
                        try
                        {
                            // Await the deletion to ensure it completes
                            await _userService.DeleteUserAsync(user.Id);
                            MessageBox.Show("User deleted successfully.");

                            // Refresh the DataGridView or update the user list as needed
                            // You may need to call a method to reload the data
                            LoadUsersAsync(); // Assuming LoadUsers() is a method that refreshes the user list
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the user: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
    }
}
