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
    public partial class MedicalPersonnelForm : Form
    {
        private readonly IUserService _userService;
        private User _user;
        private string _role;
        public MedicalPersonnelForm(User user, IUserService userService, string role)
        {
            _userService = userService;
            _user = user;
            _role = role;
            InitializeComponent();
        }

        private void nameSurnameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
