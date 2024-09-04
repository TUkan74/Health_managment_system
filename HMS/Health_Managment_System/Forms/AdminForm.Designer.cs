namespace Health_Managment_System.Forms
{
    partial class AdminForm
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
            btnManageUsers = new Button();
            btnAddUsers = new Button();
            btnManagePersonnel = new Button();
            SuspendLayout();
            // 
            // btnManageUsers
            // 
            btnManageUsers.Location = new Point(190, 155);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(145, 87);
            btnManageUsers.TabIndex = 0;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.UseVisualStyleBackColor = true;
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnAddUsers
            // 
            btnAddUsers.Location = new Point(400, 155);
            btnAddUsers.Name = "btnAddUsers";
            btnAddUsers.Size = new Size(143, 87);
            btnAddUsers.TabIndex = 1;
            btnAddUsers.Text = "Add Users";
            btnAddUsers.UseVisualStyleBackColor = true;
            btnAddUsers.Click += btnAddUsers_Click;
            // 
            // btnManagePersonnel
            // 
            btnManagePersonnel.Location = new Point(561, 162);
            btnManagePersonnel.Name = "btnManagePersonnel";
            btnManagePersonnel.Size = new Size(143, 80);
            btnManagePersonnel.TabIndex = 2;
            btnManagePersonnel.Text = "Manage Personnel";
            btnManagePersonnel.UseVisualStyleBackColor = true;
            btnManagePersonnel.Click += btnManagePersonnel_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnManagePersonnel);
            Controls.Add(btnAddUsers);
            Controls.Add(btnManageUsers);
            Name = "AdminForm";
            Text = "AdminForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageUsers;
        private Button btnAddUsers;
        private Button btnManagePersonnel;
    }
}