using Health_Managment_System.Services;
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

            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(50, 370)
            };
            btnEdit.Click += BtnEdit_Click;

            Button btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(150, 370)
            };
            btnDelete.Click += BtnDelete_Click;

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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedUser = dgvUsers.SelectedRows[0];
                // Open an edit form here (implementation of the form will be done later)
                MessageBox.Show($"Edit user: {selectedUser.Cells["Username"].Value}");
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedUser = dgvUsers.SelectedRows[0];
                var username = selectedUser.Cells["Username"].Value.ToString();
                // Delete user logic here (implementation will be done later)
                MessageBox.Show($"Delete user: {username}");
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
    }
}
