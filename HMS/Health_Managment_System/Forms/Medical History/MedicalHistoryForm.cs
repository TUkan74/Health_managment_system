using Health_Managment_System.Forms.Medical_History;
using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Managment_System.Forms
{
    public partial class MedicalHistoryForm : Form
    {
        private User _user;
        private IUserService _userService;
        private bool _adminPermissions;
        private DataGridView dgvMedicalHistory;
        private BindingSource _bindingSource;



        public MedicalHistoryForm(User user, IUserService userService,bool AdminPermissions = false)
        {
            _user = user;
            _userService = userService;
            _adminPermissions = AdminPermissions;
            InitializeComponent();
            InitializeMedicalHistoryGrid();
            LoadMedicalHistory();
        }

        private void InitializeMedicalHistoryGrid()
        {
            dgvMedicalHistory = new DataGridView
            {
                Location = new Point(30, 30),
                Size = new Size(700, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            _bindingSource = new BindingSource();
            dgvMedicalHistory.DataSource = _bindingSource;

            Button btnAdd = new Button
            {
                Text = "Add",
                Location = new Point(30, 350),
                Size = new Size(100, 30)
            };
            btnAdd.Click += BtnAdd_Click;

            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(150, 350),
                Size = new Size(100, 30)
            };
            btnEdit.Click += BtnEdit_Click;

            Button btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(270, 350),
                Size = new Size(100, 30)
            };
            btnDelete.Click += BtnDelete_Click;

            this.Controls.Add(dgvMedicalHistory);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
        }

        private async void LoadMedicalHistory()
        {
            try
            {
                // Assuming the _user has access to PatientRecord
                var patientRecord = _user.PatientRecord;
                if (patientRecord == null)
                {
                    MessageBox.Show("No patient record found.");
                    return;
                }

                // Load medical histories for the patient
                var medicalHistories = await _userService.GetMedicalHistoriesByPatientIdAsync(patientRecord.Id);
                _bindingSource.DataSource = medicalHistories;
                dgvMedicalHistory.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medical history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addEditMedicalHistoryForm = new AddEditMedicalHistoryForm(_user, _userService);
            if (addEditMedicalHistoryForm.ShowDialog() == DialogResult.OK)
            {
                LoadMedicalHistory(); // Refresh the list after adding
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMedicalHistory.SelectedRows.Count > 0)
            {
                var selectedHistory = (MedicalHistory)dgvMedicalHistory.SelectedRows[0].DataBoundItem;
                var editMedicalHistoryForm = new AddEditMedicalHistoryForm(_user, _userService, selectedHistory);
                if (editMedicalHistoryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMedicalHistory(); // Refresh the list after editing
                }
            }
            else
            {
                MessageBox.Show("Please select a medical history record to edit.");
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMedicalHistory.SelectedRows.Count > 0)
            {
                var selectedHistory = (MedicalHistory)dgvMedicalHistory.SelectedRows[0].DataBoundItem;
                var confirmation = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    await _userService.DeleteMedicalHistoryAsync(selectedHistory.Id);
                    LoadMedicalHistory(); // Refresh the list after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a medical history record to delete.");
            }
        }
    }
}
