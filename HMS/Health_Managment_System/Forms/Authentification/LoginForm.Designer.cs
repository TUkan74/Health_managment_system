namespace Health_Managment_System.Forms
{
    partial class LoginForm
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
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnExit = new Button();
            lnkForgoten = new LinkLabel();
            label3 = new Label();
            lnkRegister = new LinkLabel();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(170, 207);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(159, 25);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 97);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 150);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(172, 115);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(157, 23);
            txtUsername.TabIndex = 3;
            txtUsername.Text = "klecak";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(171, 168);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(158, 23);
            txtPassword.TabIndex = 4;
            txtPassword.Text = "asdd";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(316, 361);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(79, 33);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lnkForgoten
            // 
            lnkForgoten.AutoSize = true;
            lnkForgoten.Location = new Point(269, 150);
            lnkForgoten.Name = "lnkForgoten";
            lnkForgoten.Size = new Size(100, 15);
            lnkForgoten.TabIndex = 6;
            lnkForgoten.TabStop = true;
            lnkForgoten.Text = "Forgot password?";
            lnkForgoten.LinkClicked += lnkForgoten_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 256);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 7;
            label3.Text = "Not yet registered?";
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.Location = new Point(282, 256);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(49, 15);
            lnkRegister.TabIndex = 8;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Register";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 442);
            Controls.Add(lnkRegister);
            Controls.Add(label3);
            Controls.Add(lnkForgoten);
            Controls.Add(btnExit);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnExit;
        private LinkLabel lnkForgoten;
        private Label label3;
        private LinkLabel lnkRegister;
    }
}