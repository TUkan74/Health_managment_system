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
    public partial class MedicalHistoryForm : Form
    {
        private User _user;
        private IUserService _userService;



        public MedicalHistoryForm(User user, IUserService userService)
        {
            _user = user;
            _userService = userService;
            InitializeComponent();

        }
    }
}
