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
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsernameStatus = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblPasswordCount = new System.Windows.Forms.Label();
            this.lblPasswordCountStatus = new System.Windows.Forms.Label();
            this.ttSettings = new System.Windows.Forms.ToolTip(this.components);
            this.btnExportGo = new System.Windows.Forms.Button();
            this.btnImportGo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbExport = new System.Windows.Forms.TextBox();
            this.tbImport = new System.Windows.Forms.TextBox();
            this.lblTitleData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.Location = new System.Drawing.Point(45, 9);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(113, 31);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.lblUsernameStatus);
            this.panel1.Location = new System.Drawing.Point(11, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 35);
            this.panel1.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(44, 10);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(24, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "test";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(243, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 26);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Sign Out";
            this.ttSettings.SetToolTip(this.btnLogout, "Logout of Account");
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // lblUsernameStatus
            // 
            this.lblUsernameStatus.AutoSize = true;
            this.lblUsernameStatus.Location = new System.Drawing.Point(3, 10);
            this.lblUsernameStatus.Name = "lblUsernameStatus";
            this.lblUsernameStatus.Size = new System.Drawing.Size(35, 13);
            this.lblUsernameStatus.TabIndex = 0;
            this.lblUsernameStatus.Text = "Email:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(4, 37);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 26);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import Passwords";
            this.ttSettings.SetToolTip(this.btnImport, "Import passwords from CSV File");
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(4, 95);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 26);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export Passwords";
            this.ttSettings.SetToolTip(this.btnExport, "Export passwords to CSV File");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(4, 171);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 26);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete All Passwords";
            this.ttSettings.SetToolTip(this.btnDelete, "Delete all entries from account");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPasswordCount
            // 
            this.lblPasswordCount.AutoSize = true;
            this.lblPasswordCount.Location = new System.Drawing.Point(122, 8);
            this.lblPasswordCount.Name = "lblPasswordCount";
            this.lblPasswordCount.Size = new System.Drawing.Size(24, 13);
            this.lblPasswordCount.TabIndex = 4;
            this.lblPasswordCount.Text = "test";
            // 
            // lblPasswordCountStatus
            // 
            this.lblPasswordCountStatus.AutoSize = true;
            this.lblPasswordCountStatus.Location = new System.Drawing.Point(3, 8);
            this.lblPasswordCountStatus.Name = "lblPasswordCountStatus";
            this.lblPasswordCountStatus.Size = new System.Drawing.Size(113, 13);
            this.lblPasswordCountStatus.TabIndex = 3;
            this.lblPasswordCountStatus.Text = "Number of Passwords:";
            // 
            // btnExportGo
            // 
            this.btnExportGo.Enabled = false;
            this.btnExportGo.Image = global::PasswordManager.WindowsApp.Properties.Resources.enter;
            this.btnExportGo.Location = new System.Drawing.Point(307, 123);
            this.btnExportGo.Name = "btnExportGo";
            this.btnExportGo.Size = new System.Drawing.Size(26, 26);
            this.btnExportGo.TabIndex = 15;
            this.ttSettings.SetToolTip(this.btnExportGo, "Export Go");
            this.btnExportGo.UseVisualStyleBackColor = true;
            // 
            // btnImportGo
            // 
            this.btnImportGo.Enabled = false;
            this.btnImportGo.Image = global::PasswordManager.WindowsApp.Properties.Resources.enter;
            this.btnImportGo.Location = new System.Drawing.Point(307, 65);
            this.btnImportGo.Name = "btnImportGo";
            this.btnImportGo.Size = new System.Drawing.Size(26, 26);
            this.btnImportGo.TabIndex = 14;
            this.ttSettings.SetToolTip(this.btnImportGo, "Import Go");
            this.btnImportGo.UseVisualStyleBackColor = true;
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
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(3, 35);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(90, 26);
            this.btnDeleteAccount.TabIndex = 3;
            this.btnDeleteAccount.Text = "Delete Account";
            this.ttSettings.SetToolTip(this.btnDeleteAccount, "Delete Account");
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(3, 3);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(148, 26);
            this.btnChangePassword.TabIndex = 5;
            this.btnChangePassword.Text = "Change Account Password";
            this.ttSettings.SetToolTip(this.btnChangePassword, "Change Account Password");
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(8, 56);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 13);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "User Info:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnChangePassword);
            this.panel3.Controls.Add(this.lblWarning);
            this.panel3.Controls.Add(this.btnDeleteAccount);
            this.panel3.Location = new System.Drawing.Point(12, 386);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 66);
            this.panel3.TabIndex = 11;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(122, 42);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(198, 13);
            this.lblWarning.TabIndex = 4;
            this.lblWarning.Text = "Warning! This action can not be undone";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnExportGo);
            this.panel4.Controls.Add(this.btnImportGo);
            this.panel4.Controls.Add(this.tbExport);
            this.panel4.Controls.Add(this.tbImport);
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Controls.Add(this.btnImport);
            this.panel4.Controls.Add(this.lblPasswordCount);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.lblPasswordCountStatus);
            this.panel4.Location = new System.Drawing.Point(11, 143);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(338, 202);
            this.panel4.TabIndex = 13;
            // 
            // tbExport
            // 
            this.tbExport.Enabled = false;
            this.tbExport.Location = new System.Drawing.Point(4, 127);
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(297, 20);
            this.tbExport.TabIndex = 9;
            // 
            // tbImport
            // 
            this.tbImport.Enabled = false;
            this.tbImport.Location = new System.Drawing.Point(4, 69);
            this.tbImport.Name = "tbImport";
            this.tbImport.Size = new System.Drawing.Size(297, 20);
            this.tbImport.TabIndex = 8;
            // 
            // lblTitleData
            // 
            this.lblTitleData.AutoSize = true;
            this.lblTitleData.Location = new System.Drawing.Point(7, 127);
            this.lblTitleData.Name = "lblTitleData";
            this.lblTitleData.Size = new System.Drawing.Size(74, 13);
            this.lblTitleData.TabIndex = 10;
            this.lblTitleData.Text = "Data Settings:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Address:";
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(96, 464);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(24, 13);
            this.lblServerAddress.TabIndex = 4;
            this.lblServerAddress.Text = "test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Admin:";
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.Location = new System.Drawing.Point(81, 486);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(24, 13);
            this.lblAppVersion.TabIndex = 14;
            this.lblAppVersion.Text = "test";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "App Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Select File to Import From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select Folder to export file to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Warning! This action can not be undone";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 508);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAppVersion);
            this.Controls.Add(this.lblServerAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTitleData);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSettings);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExportGo;
        private System.Windows.Forms.Button btnImportGo;
        private System.Windows.Forms.TextBox tbExport;
        private System.Windows.Forms.TextBox tbImport;
        private System.Windows.Forms.Label lblTitleData;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}