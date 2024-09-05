namespace Health_Managment_System.Forms
{
    partial class PatientForm
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            btnMedicalHistory = new Button();
            btnPrescriptions = new Button();
            btnAppointments = new Button();
            PersonalInfoToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PersonalInfoToolStripMenuItem, logoutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(53, 20);
            fileToolStripMenuItem.Text = "Profile";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(185, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(185, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // btnMedicalHistory
            // 
            btnMedicalHistory.Location = new Point(114, 152);
            btnMedicalHistory.Name = "btnMedicalHistory";
            btnMedicalHistory.Size = new Size(136, 92);
            btnMedicalHistory.TabIndex = 1;
            btnMedicalHistory.Text = "Medical History";
            btnMedicalHistory.UseVisualStyleBackColor = true;
            btnMedicalHistory.Click += btnMedicalHistory_Click;
            // 
            // btnPrescriptions
            // 
            btnPrescriptions.Location = new Point(283, 152);
            btnPrescriptions.Name = "btnPrescriptions";
            btnPrescriptions.Size = new Size(136, 93);
            btnPrescriptions.TabIndex = 2;
            btnPrescriptions.Text = "Prescription";
            btnPrescriptions.UseVisualStyleBackColor = true;
            btnPrescriptions.Click += btnPrescriptions_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.Location = new Point(462, 152);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(136, 93);
            btnAppointments.TabIndex = 4;
            btnAppointments.Text = "Appointments";
            btnAppointments.UseVisualStyleBackColor = true;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // PersonalInfoToolStripMenuItem
            // 
            PersonalInfoToolStripMenuItem.Name = "PersonalInfoToolStripMenuItem";
            PersonalInfoToolStripMenuItem.Size = new Size(185, 22);
            PersonalInfoToolStripMenuItem.Text = "Personal Information";
            PersonalInfoToolStripMenuItem.Click += PersonalInfoToolStripMenuItem_Click;
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAppointments);
            Controls.Add(btnPrescriptions);
            Controls.Add(btnMedicalHistory);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "PatientForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button btnMedicalHistory;
        private Button btnPrescriptions;
        private Button btnAppointments;
        private ToolStripMenuItem PersonalInfoToolStripMenuItem;
    }
}