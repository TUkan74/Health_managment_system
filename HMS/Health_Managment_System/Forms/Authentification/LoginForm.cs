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
            // DEBUG: Create an admin user
            CreateAdminButton();
            InitializeComponent();

        }

        private void CreateAdminButton()
        {
            Button btnUsers = new Button();
            btnUsers.Text = "Admin";
            btnUsers.Location = new Point(0, 0);
            btnUsers.Click += (s, e) =>
            {
                var adminForm = new AdminForm(_userService);
                adminForm.ShowDialog();
            };
            this.Controls.Add(btnUsers);
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
                Form nextForm;

                // Determine which form to open based on the user's role
                if (user.Role == "Admin")
                {
                    nextForm = new AdminForm(_userService);
                }
                if (user.Role == "Doctor" || user.Role == "Nurse")
                {
                    nextForm = new MedicalPersonnelForm(user, _userService,user.Role);
                }
                else // (user.Role == "Patient")
                {
                    nextForm = new PatientForm(user, _userService);
                }
                

                // Hide the login form and show the next form
                this.Hide();
                nextForm.ShowDialog();

                // Check the dialog result of the next form
                if (nextForm.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
                else if (nextForm.DialogResult == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
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
            registrationForm.RegistrationForm_Loader(this, e);
            registrationForm.ShowDialog();
            
            if (registrationForm.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else if (registrationForm.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
            
        }

    }

}
