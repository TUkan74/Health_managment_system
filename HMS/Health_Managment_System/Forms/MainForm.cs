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
    public partial class MainForm : Form
    {
        private User _user;
        private readonly LoginForm _loginForm;
        public MainForm(User user, LoginForm loginForm)
        {
            _loginForm = loginForm;
            _user = user;
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Close();
        }

        private void PersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var personalInfoForm = new PersonalInfoformationForm(_user);
            personalInfoForm.ShowDialog();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
