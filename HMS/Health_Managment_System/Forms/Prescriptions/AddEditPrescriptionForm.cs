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

namespace Health_Managment_System.Forms.Prescriptions
{
    public partial class AddEditPrescriptionForm : Form
    {
        public AddEditPrescriptionForm(User user,IUserService userService,Prescription prescription)
        {
            InitializeComponent();
        }
        public AddEditPrescriptionForm(User user, IUserService userService)
        {
            InitializeComponent();
        }
    }
}
