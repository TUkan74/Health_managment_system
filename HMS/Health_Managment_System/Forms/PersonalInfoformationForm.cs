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
    public partial class PersonalInfoformationForm : Form
    {
        private User _user;
        private bool _isEditing = false;
        public PersonalInfoformationForm(User user)
        {
            _user = user;
            InitializeComponent();
            this.Load += PersonalInfoformationForm_Load;
        }

        private void PersonalInfoformationForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = _user.Username;
            txtEmail.Text = _user.Email;

            if (_user.PatientRecord != null)
            {
                PatientRecord patientRecord = _user.PatientRecord;
                txtFirstName.Text = patientRecord.FirstName;
                txtLastName.Text = patientRecord.LastName;
                dtpDateOfBirth.Value = patientRecord.DateOfBirth;
                txtAddress.Text = patientRecord.Address;
                txtPhoneNumber.Text = patientRecord.PhoneNumber;
            }
            else
            {
                // Handle the case where PatientRecord is null
                txtFirstName.Text = "";
                txtLastName.Text = "";
                dtpDateOfBirth.Value = DateTime.Today;
                txtAddress.Text = "";
                txtPhoneNumber.Text = "";
            }

            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] { "Doctor", "Patient", "Nurse" });
            cmbRole.Text = _user.Role;
        }
    }
}
