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
        //private DataGridView dgvUsers;

        public AdminForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            var userManagmentForm = new UserManagmentForm(_userService, true);
            userManagmentForm.ShowDialog();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            var RegistrationForm = new RegistrationForm(_userService, true);
            RegistrationForm.ShowDialog();
        }

        private void btnManagePersonnel_Click(object sender, EventArgs e)
        {
            var PersonnelManagmentForm = new UserManagmentForm(_userService, AdminPermissions: true, OnlyPersonnel: true);
            PersonnelManagmentForm.ShowDialog();
        }
    }
}
