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
    public partial class PatientForm : Form
    {
        private User _user;
        private readonly IUserService _userService;
        public PatientForm(User user,IUserService userService)
        {
            _userService = userService;
            _user = user;
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void PersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var personalInfoForm = new PersonalInfoformationForm(_user,_userService,false);
            personalInfoForm.ShowDialog();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
