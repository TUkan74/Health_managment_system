namespace Health_Managment_System.Forms
{
    partial class PersonalInfoformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalInfoformationForm));
            lblPhoneNumber = new Label();
            lblAdress = new Label();
            lblDateOfBirth = new Label();
            txtPhoneNumber = new TextBox();
            txtAddress = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblFullName = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            btnSave = new Button();
            lblPassword = new Label();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            btnEdit = new Button();
            btnBack = new Button();
            lblLogin = new Label();
            lblRole = new Label();
            Rolelbl = new Label();
            SuspendLayout();
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(233, 219);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(86, 15);
            lblPhoneNumber.TabIndex = 45;
            lblPhoneNumber.Text = "Phone number";
            // 
            // lblAdress
            // 
            lblAdress.AutoSize = true;
            lblAdress.Location = new Point(53, 219);
            lblAdress.Name = "lblAdress";
            lblAdress.Size = new Size(42, 15);
            lblAdress.TabIndex = 44;
            lblAdress.Text = "Adress";
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Location = new Point(53, 357);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(73, 15);
            lblDateOfBirth.TabIndex = 43;
            lblDateOfBirth.Text = "Date of birth";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPhoneNumber.Location = new Point(233, 191);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(165, 23);
            txtPhoneNumber.TabIndex = 42;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Location = new Point(53, 191);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(165, 23);
            txtAddress.TabIndex = 41;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.AllowDrop = true;
            dtpDateOfBirth.CustomFormat = "dd.MM  yyyy";
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.ImeMode = ImeMode.NoControl;
            dtpDateOfBirth.Location = new Point(53, 331);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(130, 23);
            dtpDateOfBirth.TabIndex = 40;
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Location = new Point(233, 51);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(165, 23);
            txtLastName.TabIndex = 39;
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Location = new Point(53, 51);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(165, 23);
            txtFirstName.TabIndex = 38;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(233, 79);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 37;
            lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(53, 77);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 36;
            lblFirstName.Text = "First Name";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 12F);
            lblFullName.ForeColor = SystemColors.ActiveCaptionText;
            lblFullName.Location = new Point(53, 27);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(81, 21);
            lblFullName.TabIndex = 35;
            lblFullName.Text = "Full Name";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(233, 121);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(165, 23);
            txtEmail.TabIndex = 32;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(233, 147);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 31;
            lblEmail.Text = "Email";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(53, 121);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(165, 23);
            txtUsername.TabIndex = 28;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(53, 147);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 26;
            lblUsername.Text = "Username";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.GradientInactiveCaption;
            btnSave.Location = new Point(53, 391);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(284, 33);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(53, 287);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(84, 15);
            lblPassword.TabIndex = 46;
            lblPassword.Text = "New Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(53, 261);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(165, 23);
            txtPassword.TabIndex = 47;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Location = new Point(233, 261);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(165, 23);
            txtConfirmPassword.TabIndex = 48;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(233, 287);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(104, 15);
            lblConfirmPassword.TabIndex = 49;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ActiveCaption;
            btnEdit.Location = new Point(364, 391);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 33);
            btnEdit.TabIndex = 50;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(1, 1);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(26, 25);
            btnBack.TabIndex = 51;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 7F);
            lblLogin.ForeColor = Color.Red;
            lblLogin.Location = new Point(53, 106);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(94, 12);
            lblLogin.TabIndex = 52;
            lblLogin.Text = "*Used for logging in";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(233, 357);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(30, 15);
            lblRole.TabIndex = 53;
            lblRole.Text = "Role";
            // 
            // Rolelbl
            // 
            Rolelbl.AutoSize = true;
            Rolelbl.BorderStyle = BorderStyle.FixedSingle;
            Rolelbl.Font = new Font("Segoe UI", 10F);
            Rolelbl.Location = new Point(233, 331);
            Rolelbl.Name = "Rolelbl";
            Rolelbl.Size = new Size(73, 21);
            Rolelbl.TabIndex = 54;
            Rolelbl.Text = "Role HERE";
            // 
            // PersonalInfoformationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 450);
            Controls.Add(Rolelbl);
            Controls.Add(lblRole);
            Controls.Add(lblLogin);
            Controls.Add(btnBack);
            Controls.Add(btnEdit);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblAdress);
            Controls.Add(lblDateOfBirth);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtAddress);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblFullName);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(btnSave);
            Location = new Point(100, 100);
            Name = "PersonalInfoformationForm";
            Text = "PersonalInfoformationForm";
            Load += PersonalInfoformationForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPhoneNumber;
        private Label lblAdress;
        private Label lblDateOfBirth;
        private TextBox txtPhoneNumber;
        private TextBox txtAddress;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblFullName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtUsername;
        private Label lblUsername;
        private Button btnSave;
        private Label lblPassword;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private Button btnEdit;
        private Button btnBack;
        private Label lblLogin;
        private Label lblRole;
        private Label Rolelbl;
    }
}