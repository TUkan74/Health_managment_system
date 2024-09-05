using Health_Managment_System.Services;
using HealthcareManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Managment_System.Forms.Templates
{
    public class BaseForm<T> : Form where T : class
    {
        protected User _user;
        protected IUserService _userService;
        protected bool _adminPermissions;
        protected DataGridView _dataGridView;
        protected BindingSource _bindingSource;

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

        protected virtual async Task LoadDataAsync()
        {
            // Implemented in derived classes
        }

        // Add, Edit, Delete button handlers
        protected void AddButtons(Action addAction, Action editAction)
        {
            Button btnAdd = new Button
            {
                Text = "Add",
                Location = new Point(20, 400),
                Size = new Size(100, 30)
            };
            btnAdd.Click += (s, e) => addAction();

            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(130, 400),
                Size = new Size(100, 30)
            };
            btnEdit.Click += (s, e) => editAction();

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
        }

        // Generic method for handling add operations
        protected void HandleAdd(Action openFormAction)
        {
            openFormAction?.Invoke();
            LoadDataAsync(); // Refresh the data after adding
        }

        // Generic method for handling edit operations
        protected void HandleEdit(Func<T, bool> openFormAction)
        {
            if (_dataGridView.SelectedRows.Count > 0)
            {
                var selectedItem = (T)_dataGridView.SelectedRows[0].DataBoundItem;
                if (selectedItem != null)
                {
                    if (openFormAction(selectedItem))
                    {
                        LoadDataAsync(); // Refresh the data after editing
                    }
                }
                else
                {
                    MessageBox.Show("The selected item is not valid.");
                }
            }
            else
            {
                MessageBox.Show("Please select an item to edit.");
            }
        }
    }

}
