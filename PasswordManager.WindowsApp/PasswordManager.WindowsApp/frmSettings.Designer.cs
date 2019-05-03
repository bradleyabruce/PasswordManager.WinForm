namespace PasswordManager.WindowsApp
{
    partial class frmSettings
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
            this.components = new System.ComponentModel.Container();
            this.lblSettings = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblPasswordCount = new System.Windows.Forms.Label();
            this.lblPasswordCountStatus = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsernameStatus = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.ttSettings = new System.Windows.Forms.ToolTip(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.Location = new System.Drawing.Point(12, 40);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(153, 42);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lblPasswordCount);
            this.panel1.Controls.Add(this.lblPasswordCountStatus);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.lblUsernameStatus);
            this.panel1.Location = new System.Drawing.Point(11, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 124);
            this.panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(258, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete All";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPasswordCount
            // 
            this.lblPasswordCount.AutoSize = true;
            this.lblPasswordCount.Location = new System.Drawing.Point(123, 28);
            this.lblPasswordCount.Name = "lblPasswordCount";
            this.lblPasswordCount.Size = new System.Drawing.Size(24, 13);
            this.lblPasswordCount.TabIndex = 4;
            this.lblPasswordCount.Text = "test";
            // 
            // lblPasswordCountStatus
            // 
            this.lblPasswordCountStatus.AutoSize = true;
            this.lblPasswordCountStatus.Location = new System.Drawing.Point(4, 28);
            this.lblPasswordCountStatus.Name = "lblPasswordCountStatus";
            this.lblPasswordCountStatus.Size = new System.Drawing.Size(113, 13);
            this.lblPasswordCountStatus.TabIndex = 3;
            this.lblPasswordCountStatus.Text = "Number of Passwords:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(45, 11);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(24, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "test";
            // 
            // lblUsernameStatus
            // 
            this.lblUsernameStatus.AutoSize = true;
            this.lblUsernameStatus.Location = new System.Drawing.Point(4, 11);
            this.lblUsernameStatus.Name = "lblUsernameStatus";
            this.lblUsernameStatus.Size = new System.Drawing.Size(35, 13);
            this.lblUsernameStatus.TabIndex = 0;
            this.lblUsernameStatus.Text = "Email:";
            // 
            // btnLogout
            // 
            this.btnLogout.Image = global::PasswordManager.WindowsApp.Properties.Resources.shutdown;
            this.btnLogout.Location = new System.Drawing.Point(323, 57);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(26, 26);
            this.btnLogout.TabIndex = 2;
            this.ttSettings.SetToolTip(this.btnLogout, "Logout of Account");
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::PasswordManager.WindowsApp.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(13, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(26, 26);
            this.btnBack.TabIndex = 2;
            this.ttSettings.SetToolTip(this.btnBack, "Back");
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(3, 96);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export Passwords";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(3, 67);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import Passwords";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 479);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblSettings);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUsernameStatus;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolTip ttSettings;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblPasswordCount;
        private System.Windows.Forms.Label lblPasswordCountStatus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
    }
}