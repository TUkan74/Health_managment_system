using System.Windows.Forms;

namespace Health_Managment_System.Forms
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lnkBackLgn = new LinkLabel();
            cmbRole = new ComboBox();
            btnRegister = new Button();
            Username = new Label();
            Password = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblRole = new Label();
            label1 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtConfirmPassword = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            txtAddress = new TextBox();
            txtPhoneNumber = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblLogin = new Label();
            SuspendLayout();
            // 
            // lnkBackLgn
            // 
            lnkBackLgn.AutoSize = true;
            lnkBackLgn.Location = new Point(325, 387);
            lnkBackLgn.Name = "lnkBackLgn";
            lnkBackLgn.Size = new Size(76, 15);
            lnkBackLgn.TabIndex = 0;
            lnkBackLgn.TabStop = true;
            lnkBackLgn.Text = "Back to login";
            lnkBackLgn.LinkClicked += lnkBackLgn_LinkClicked;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Doctor", "Patient", "Nurse" });
            cmbRole.Location = new Point(236, 345);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(100, 23);
            cmbRole.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(56, 405);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(345, 33);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Location = new Point(56, 161);
            Username.Name = "Username";
            Username.Size = new Size(60, 15);
            Username.TabIndex = 3;
            Username.Text = "Username";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(56, 301);
            Password.Name = "Password";
            Password.Size = new Size(57, 15);
            Password.TabIndex = 4;
            Password.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(56, 135);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(165, 23);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(56, 275);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(165, 23);
            txtPassword.TabIndex = 6;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(236, 371);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(30, 15);
            lblRole.TabIndex = 7;
            lblRole.Text = "Role";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 161);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 8;
            label1.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(236, 135);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(165, 23);
            txtEmail.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 301);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 10;
            label2.Text = "Confirm password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Location = new Point(236, 275);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(165, 23);
            txtConfirmPassword.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(56, 41);
            label3.Name = "label3";
            label3.Size = new Size(81, 21);
            label3.TabIndex = 12;
            label3.Text = "Full Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 91);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 13;
            label4.Text = "First Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(236, 93);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 14;
            label5.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Location = new Point(56, 65);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(165, 23);
            txtFirstName.TabIndex = 15;
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Location = new Point(236, 65);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(165, 23);
            txtLastName.TabIndex = 16;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.AllowDrop = true;
            dtpDateOfBirth.CustomFormat = "dd.MM  yyyy";
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.ImeMode = ImeMode.NoControl;
            dtpDateOfBirth.Location = new Point(56, 345);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(130, 23);
            dtpDateOfBirth.TabIndex = 17;
            dtpDateOfBirth.ValueChanged += dtpDateOfBirth_ValueChanged;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Location = new Point(56, 205);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(165, 23);
            txtAddress.TabIndex = 18;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPhoneNumber.Location = new Point(236, 205);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(165, 23);
            txtPhoneNumber.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(56, 371);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 20;
            label6.Text = "Date of birth";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 233);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 21;
            label7.Text = "Adress";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(236, 233);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 22;
            label8.Text = "Phone number";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 7F);
            lblLogin.ForeColor = SystemColors.ActiveCaptionText;
            lblLogin.Location = new Point(56, 120);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(94, 12);
            lblLogin.TabIndex = 23;
            lblLogin.Text = "*Used for logging in";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 450);
            Controls.Add(lblLogin);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtAddress);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(lblRole);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(btnRegister);
            Controls.Add(cmbRole);
            Controls.Add(lnkBackLgn);
            Location = new Point(100, 100);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel lnkBackLgn;
        private ComboBox cmbRole;
        private Button btnRegister;
        private Label Username;
        private Label Password;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblRole;
        private Label label1;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtConfirmPassword;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtAddress;
        private TextBox txtPhoneNumber;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblLogin;
    }
}