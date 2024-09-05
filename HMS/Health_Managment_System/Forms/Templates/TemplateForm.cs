using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Managment_System.Forms
{
    public enum FormTypeEnum
    {
        MedicalHistory,
        Prescriptions,
        Appointments
    }
    
    public class BaseForm : Form
    {
        protected User _user;
        protected IUserService _userService;
        protected bool _adminPermissions;
        protected DataGridView _dataGridView;
        protected BindingSource _bindingSource;
        protected FormTypeEnum _formType;


        public BaseForm(User user, IUserService userService, bool adminPermissions = false)
        {
            _user = user;
            _userService = userService;
            _adminPermissions = adminPermissions;
            _bindingSource = new BindingSource();
        }

        // Initialize the DataGridView
        protected void InitializeGrid(string[] columns)
        {
            _dataGridView = new DataGridView
            {
                Location = new Point(20, 20),
                Size = new Size(740, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            foreach (var column in columns)
            {
                _dataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = column });
            }

            _dataGridView.DataSource = _bindingSource;
            this.Controls.Add(_dataGridView);
        }

        // Load data method to be implemented by derived classes
        protected async Task LoadDataAsync<T>()
        {
            try
            {
                // Assuming the _user has access to PatientRecord
                var patientData = _user.PatientRecord;
                if (patientData == null)
                {
                    MessageBox.Show("No patient data found.");
                    return;
                }

                List<T> data = null;

                switch (_formType)
                {
                    case FormTypeEnum.Appointments:
                        data = (await _userService.GetAppointmentsByUserAsync(patientData.Id,_user.Role)) as List<T>;
                        break;
                    case FormTypeEnum.Prescriptions:
                        data = (await _userService.GetPrescriptionsByPatientIdAsync(patientData.Id)) as List<T>;
                        break;
                    case FormTypeEnum.MedicalHistory:
                        data = (await _userService.GetMedicalHistoriesByPatientIdAsync(patientData.Id)) as List<T>;
                        break;
                }

                if (data == null)
                {
                    MessageBox.Show("Failed to load data");
                    return;
                }
                _bindingSource.DataSource = data;
                _dataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {_formType.ToString()}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        // Add buttons based on permissions
        protected void AddButtons()
        {
            Button btnAdd = new Button
            {
                Text = "Add",
                Location = new Point(20, 400),
                Size = new Size(100, 30)
            };
            btnAdd.Click += BtnAdd_Click;

            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(130, 400),
                Size = new Size(100, 30)
            };
            btnEdit.Click += BtnEdit_Click;

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

        // Add button click event handler (implemented in derived classes)
        protected virtual void BtnAdd_Click(object sender, EventArgs e)
        {
            // Implemented in derived classes
        }

        // Edit button click event handler (implemented in derived classes)
        protected virtual void BtnEdit_Click(object sender, EventArgs e)
        {
            // Implemented in derived classes
        }

        // Delete button click event handler (implemented in derived classes)
        protected virtual void BtnDelete_Click(object sender, EventArgs e)
        {
            // Implemented in derived classes
        }
    }
}
