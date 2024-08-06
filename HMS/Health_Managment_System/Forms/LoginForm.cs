using Health_Managment_System.Services;
using Microsoft.Extensions.DependencyInjection;
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
    // Forms/LoginForm.cs
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private int _loginAttempts = 0;
        private int _forgottenAttempts = 0;
        private readonly IServiceProvider _serviceProvider;

        public LoginForm(IUserService userService, IServiceProvider serviceProvider)
        {
            _userService = userService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }


        /// <summary>
        /// For the login button TO BE IMPLEMENTED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Invalid username or password.");
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            //MessageBox.Show($"{username} \n {password}");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            var user = await _userService.AuthenticateAsync(username, password);
            if (user != null)
            {
                // Open main form and close login form
                var mainForm = new MainForm(user,this,_userService);
                this.Hide();
                mainForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

            /*this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Show();*/
        }

        /// <summary>
        /// For the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// For the forgotten password link FOR FUN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkForgoten_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_forgottenAttempts < 3)
            {
                MessageBox.Show("Too bad then.");

            }
            else if (_forgottenAttempts == 3)
            {
                MessageBox.Show("STOP THAT!!!");
            }
            else if (_forgottenAttempts == 4)
            {
                MessageBox.Show("I SAID STOP!!!");
            }
            else if (_forgottenAttempts == 5)
            {
                MessageBox.Show("I WILL END YOU!!!");
            }
            else if (_forgottenAttempts == 6)
            {
                MessageBox.Show("The application will self destruct now");

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                int countdown = 5;

                Label lblTimer = new Label();


                lblTimer.Location = new Point(10, 10);
                lblTimer.AutoSize = true;
                lblTimer.Font = new Font(lblTimer.Font.FontFamily, 32);
                lblTimer.ForeColor = Color.Red;
                this.Controls.Add(lblTimer);

                lblTimer.Text = countdown.ToString();

                timer.Tick += (s, args) =>
                {
                    countdown--;
                    if (countdown <= 0)
                    {
                        timer.Stop();
                        Application.Exit();
                    }
                    else
                    {
                        lblTimer.Text = countdown.ToString();
                    }
                };

                timer.Start();
            }
            else
            {
                MessageBox.Show("You are done");
            }
            _forgottenAttempts++;
            
            

        }

        // NEEDS TO BE FIXED
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var registrationForm = _serviceProvider.GetRequiredService<RegistrationForm>();
            registrationForm.ShowDialog();
            this.Show();
            
        }

    }

}
