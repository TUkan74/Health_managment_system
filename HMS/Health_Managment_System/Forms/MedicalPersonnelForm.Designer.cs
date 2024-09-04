namespace Health_Managment_System.Forms
{
    partial class MedicalPersonnelForm
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
            btnPatients = new Button();
            btnAppointments = new Button();
            btnAddPatients = new Button();
            menuStrip1 = new MenuStrip();
            profileToolStripMenuItem = new ToolStripMenuItem();
            PersonalInfoToolStrip = new ToolStripMenuItem();
            loToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPatients
            // 
            btnPatients.Location = new Point(137, 151);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(136, 92);
            btnPatients.TabIndex = 0;
            btnPatients.Text = "Patients";
            btnPatients.UseVisualStyleBackColor = true;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.Location = new Point(279, 151);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(136, 92);
            btnAppointments.TabIndex = 2;
            btnAppointments.Text = "Appointments";
            btnAppointments.UseVisualStyleBackColor = true;
            // 
            // btnAddPatients
            // 
            btnAddPatients.Location = new Point(421, 151);
            btnAddPatients.Name = "btnAddPatients";
            btnAddPatients.Size = new Size(136, 92);
            btnAddPatients.TabIndex = 3;
            btnAddPatients.Text = "Add Patients";
            btnAddPatients.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PersonalInfoToolStrip, loToolStripMenuItem, exitToolStripMenuItem });
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(53, 20);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // PersonalInfoToolStrip
            // 
            PersonalInfoToolStrip.Name = "PersonalInfoToolStrip";
            PersonalInfoToolStrip.Size = new Size(176, 22);
            PersonalInfoToolStrip.Text = "\"Name\" \"Surname\"";
            PersonalInfoToolStrip.Click += PersonalInfoToolStripToolStripMenuItem_Click;
            // 
            // loToolStripMenuItem
            // 
            loToolStripMenuItem.Name = "loToolStripMenuItem";
            loToolStripMenuItem.Size = new Size(176, 22);
            loToolStripMenuItem.Text = "Logout";
            loToolStripMenuItem.Click += LogoutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(176, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // MedicalPersonnelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddPatients);
            Controls.Add(btnAppointments);
            Controls.Add(btnPatients);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MedicalPersonnelForm";
            Text = "MedicalPersonnel";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPatients;
        private Button btnAppointments;
        private Button btnAddPatients;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem PersonalInfoToolStrip;
        private ToolStripMenuItem loToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}