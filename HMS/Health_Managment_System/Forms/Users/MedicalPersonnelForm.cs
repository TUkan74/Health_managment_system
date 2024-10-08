﻿using Health_Managment_System.Services;
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

        private void PersonalInfoToolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var personalInfoForm = new PersonalInfoformationForm(_user, _userService, false);
            personalInfoForm.ShowDialog();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            var UserManagmentForm = new UserManagmentForm(_userService);
            UserManagmentForm.ShowDialog();

        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            var AppointmentForm = new AppointmentsForm(_user,_userService,true);
            AppointmentForm.ShowDialog();
        }

        private void btnAddPatients_Click(object sender, EventArgs e)
        {
            var RegistrationForm = new RegistrationForm(_userService, false);
            RegistrationForm.ShowDialog();
        }
    }
}
