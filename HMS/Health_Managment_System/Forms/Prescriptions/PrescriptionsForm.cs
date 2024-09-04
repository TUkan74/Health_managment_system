using Health_Managment_System.Forms.Prescriptions;
using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Health_Managment_System.Forms
{
    public partial class PrescriptionsForm : Form
    {
        private User _user;
        private IUserService _userService;
        private DataGridView dgvPrescriptions;
        private BindingSource _bindingSource;
        bool _adminPermissions;

        public PrescriptionsForm(User user, IUserService userService,bool AdminPermissions = false)
        {
            _user = user;
            _userService = userService;
            _adminPermissions = AdminPermissions;
            InitializeComponent();
            InitializeFormComponents(); // Set up the grid and buttons
            LoadPrescriptions();        // Load the prescriptions data
            if (_adminPermissions == true)
            {
                addButtons();
            }
                           
        }

        private void addButtons()
        {
            // Add button
            Button btnAdd = new Button
            {
                Text = "Add",
                Location = new Point(20, 400),
                Size = new Size(100, 30)
            };
            btnAdd.Click += BtnAdd_Click;

            // Edit button
            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(130, 400),
                Size = new Size(100, 30)
            };
            btnEdit.Click += BtnEdit_Click;

            // Delete button
            Button btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(240, 400),
                Size = new Size(100, 30)
            };
            btnDelete.Click += BtnDelete_Click;

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
        }

        private void InitializeFormComponents()
        {
            this.Text = "Manage Prescriptions";
            this.Size = new Size(800, 500);

            // Initialize the DataGridView
            dgvPrescriptions = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(740, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Create a binding source to manage data binding
            _bindingSource = new BindingSource();
            dgvPrescriptions.DataSource = _bindingSource;

            // Adding columns for displaying prescription details
            dgvPrescriptions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DrugName", HeaderText = "Drug Name" });
            dgvPrescriptions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dosage", HeaderText = "Dosage" });
            dgvPrescriptions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UsageInstructions", HeaderText = "Usage Instructions" });
            dgvPrescriptions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DatePrescribed", HeaderText = "Date Prescribed" });
            dgvPrescriptions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Doctor.PatientRecord.FullName", HeaderText = "Prescribed By" });

            

            // Add components to the form
            this.Controls.Add(dgvPrescriptions);
            
        }

        // Load prescriptions data into the DataGridView
        private async void LoadPrescriptions()
        {
            try
            {
                var prescriptions = await _userService.GetPrescriptionsByPatientIdAsync(_user.PatientRecord.Id);
                _bindingSource.DataSource = prescriptions;
                dgvPrescriptions.ClearSelection(); // Clear any pre-existing selections
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading prescriptions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle the Add button click event
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addPrescriptionForm = new AddEditPrescriptionForm(_user, _userService);
            if (addPrescriptionForm.ShowDialog() == DialogResult.OK)
            {
                LoadPrescriptions(); // Refresh the prescriptions after adding
            }
        }

        // Handle the Edit button click event
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count > 0)
            {
                var selectedPrescription = (Prescription)dgvPrescriptions.SelectedRows[0].DataBoundItem;
                if (selectedPrescription != null)
                {
                    // Open the form to edit the selected prescription
                    var editPrescriptionForm = new AddEditPrescriptionForm(_user, _userService, selectedPrescription);
                    if (editPrescriptionForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadPrescriptions(); // Refresh the prescriptions after editing
                    }
                }
                else
                {
                    MessageBox.Show("The selected item is not a valid prescription.");
                }
            }
            else
            {
                MessageBox.Show("Please select a prescription to edit.");
            }
        }

        // Handle the Delete button click event
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count > 0)
            {
                var selectedPrescription = (Prescription)dgvPrescriptions.SelectedRows[0].DataBoundItem;

                if (selectedPrescription != null)
                {
                    var confirmation = MessageBox.Show("Are you sure you want to delete this prescription?",
                                                       "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmation == DialogResult.Yes)
                    {
                        try
                        {
                            await _userService.DeletePrescriptionAsync(selectedPrescription.Id);
                            LoadPrescriptions(); // Refresh the list of prescriptions
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting prescription: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The selected item is not a valid prescription.");
                }
            }
            else
            {
                MessageBox.Show("Please select a prescription to delete.");
            }
        }
    }
}
