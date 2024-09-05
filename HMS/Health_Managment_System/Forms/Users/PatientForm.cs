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
        public PatientForm(User user, IUserService userService)
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

        // OLD ToolStripMenuItem
        private void PersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var personalInfoForm = new PersonalInfoformationForm(_user, _userService, false);
            personalInfoForm.ShowDialog();

        }
        // OLD ToolStripMenuItems

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnMedicalHistory_Click(object sender, EventArgs e)
        {
            var medicalHistoryForm = new MedicalHistoryForm(_user, _userService);
            medicalHistoryForm.ShowDialog();
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            var prescriptionForm = new PrescriptionsForm(_user, _userService);
            prescriptionForm.ShowDialog();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            var appointmentForm = new AppointmentsForm(_user, _userService);
            appointmentForm.ShowDialog();
        }


        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var personalInfoForm = new PersonalInfoformationForm(_user, _userService, false);
            personalInfoForm.ShowDialog();
        }

    }

    internal class PrescriptionForm
    {
        private User user;
        private IUserService userService;

        public PrescriptionForm(User user, IUserService userService)
        {
            this.user = user;
            this.userService = userService;
        }
    }
}
