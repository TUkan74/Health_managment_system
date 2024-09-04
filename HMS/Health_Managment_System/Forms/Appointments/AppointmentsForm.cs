using Health_Managment_System.Forms.Appointments;
using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Managment_System.Forms
{
    public partial class AppointmentsForm : Form
    {
        private User _user;
        private IUserService _userService;
        private DataGridView dgvAppointments;
        private BindingSource _bindingSource;
        bool _adminPermissions;

        public AppointmentsForm(User user, IUserService userService,bool AdminPermissions = false)
        {
            _adminPermissions = AdminPermissions;
            _user = user;
            _userService = userService;
            InitializeComponent();
            InitializeUserGrid(); // Call this to set up the grid and buttons
            LoadAppointments();   // Load the appointments data
            
            if (_user.Role != "Patient" || _adminPermissions == true)
            {
                addButtons();         // Add the buttons to the form
            }
            
        }

        private void InitializeUserGrid()
        {
            dgvAppointments = new DataGridView
            {
                Location = new Point(50, 50),
                Size = new Size(700, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Create a binding source to manage data binding
            _bindingSource = new BindingSource();
            dgvAppointments.DataSource = _bindingSource;

            

            // Add components to the form
            this.Controls.Add(dgvAppointments);
            
        }

        private void addButtons()
        {
            // Add button
            Button btnAdd = new Button
            {
                Text = "Add",
                Location = new Point(50, 370),
                Size = new Size(100, 30)
            };
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            // Edit button
            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(150, 370),
                Size = new Size(100, 30)
            };
            btnEdit.Click += BtnEdit_Click;
            this.Controls.Add(btnEdit);
            // Delete button
            Button btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(250, 370),
                Size = new Size(100, 30)
            };
            btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(btnDelete);
        }

        private async void LoadAppointments()
        {
            try
            {
                var appointments = await _userService.GetAppointmentsByUserAsync(_user.Id,_user.Role);
                _bindingSource.DataSource = appointments; // Set the data source of the binding source
                dgvAppointments.ClearSelection(); // Clear any pre-existing selections
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addAppointmentForm = new AddEditAppointmentForm(_user, _userService);
            addAppointmentForm.ShowDialog();
            LoadAppointments(); // Refresh the appointments after adding
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                var selectedAppointment = (Appointment)dgvAppointments.SelectedRows[0].DataBoundItem;
                if (selectedAppointment != null)
                {
                    // Open the form to edit the selected appointment
                    var editAppointmentForm = new AddEditAppointmentForm(_user, _userService,selectedAppointment);
                    editAppointmentForm.ShowDialog();
                    LoadAppointments(); // Refresh the appointments after editing
                }
                else
                {
                    MessageBox.Show("The selected item is not a valid appointment.");
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to edit.");
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                var selectedAppointment = (Appointment)dgvAppointments.SelectedRows[0].DataBoundItem;

                if (selectedAppointment != null)
                {
                    var confirmation = MessageBox.Show("Are you sure you want to delete this appointment?",
                                                       "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Yes)
                    {
                        try
                        {
                            await _userService.DeleteAppointmentAsync(selectedAppointment.Id);
                            LoadAppointments(); // Refresh the list of appointments
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The selected item is not a valid appointment.");
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.");
            }
        }
    }
}
