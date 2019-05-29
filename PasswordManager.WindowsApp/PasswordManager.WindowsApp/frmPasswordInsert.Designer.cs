namespace PasswordManager.WindowsApp
{
    partial class frmPasswordInsert
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPasswordPasteFromClip = new System.Windows.Forms.Button();
            this.btnUsernamePasteFromClip = new System.Windows.Forms.Button();
            this.btnDomainPasteFromClip = new System.Windows.Forms.Button();
            this.btnChangeDomain = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopyUsername = new System.Windows.Forms.Button();
            this.btnPasswordHide = new System.Windows.Forms.Button();
            this.btnCopyPassword = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.tbWebsitePassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbWebsiteUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbWebsiteDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.ttInsert = new System.Windows.Forms.ToolTip(this.components);
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPasswordPasteFromClip);
            this.panel1.Controls.Add(this.btnUsernamePasteFromClip);
            this.panel1.Controls.Add(this.btnDomainPasteFromClip);
            this.panel1.Controls.Add(this.btnChangeDomain);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnCopyUsername);
            this.panel1.Controls.Add(this.btnPasswordHide);
            this.panel1.Controls.Add(this.btnCopyPassword);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.tbWebsitePassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.tbWebsiteUsername);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.tbWebsiteDomain);
            this.panel1.Controls.Add(this.lblDomain);
            this.panel1.Location = new System.Drawing.Point(13, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 304);
            this.panel1.TabIndex = 0;
            // 
            // btnPasswordPasteFromClip
            // 
            this.btnPasswordPasteFromClip.Image = global::PasswordManager.WindowsApp.Properties.Resources.pasteFromClipboard;
            this.btnPasswordPasteFromClip.Location = new System.Drawing.Point(355, 146);
            this.btnPasswordPasteFromClip.Name = "btnPasswordPasteFromClip";
            this.btnPasswordPasteFromClip.Size = new System.Drawing.Size(26, 26);
            this.btnPasswordPasteFromClip.TabIndex = 19;
            this.ttInsert.SetToolTip(this.btnPasswordPasteFromClip, "Paste from clipboard");
            this.btnPasswordPasteFromClip.UseVisualStyleBackColor = true;
            this.btnPasswordPasteFromClip.Click += new System.EventHandler(this.BtnPasswordPasteFromClip_Click);
            // 
            // btnUsernamePasteFromClip
            // 
            this.btnUsernamePasteFromClip.Image = global::PasswordManager.WindowsApp.Properties.Resources.pasteFromClipboard;
            this.btnUsernamePasteFromClip.Location = new System.Drawing.Point(355, 85);
            this.btnUsernamePasteFromClip.Name = "btnUsernamePasteFromClip";
            this.btnUsernamePasteFromClip.Size = new System.Drawing.Size(26, 26);
            this.btnUsernamePasteFromClip.TabIndex = 18;
            this.ttInsert.SetToolTip(this.btnUsernamePasteFromClip, "Paste from clipboard");
            this.btnUsernamePasteFromClip.UseVisualStyleBackColor = true;
            this.btnUsernamePasteFromClip.Click += new System.EventHandler(this.BtnUsernamePasteFromClip_Click);
            // 
            // btnDomainPasteFromClip
            // 
            this.btnDomainPasteFromClip.Image = global::PasswordManager.WindowsApp.Properties.Resources.pasteFromClipboard;
            this.btnDomainPasteFromClip.Location = new System.Drawing.Point(355, 27);
            this.btnDomainPasteFromClip.Name = "btnDomainPasteFromClip";
            this.btnDomainPasteFromClip.Size = new System.Drawing.Size(26, 26);
            this.btnDomainPasteFromClip.TabIndex = 17;
            this.ttInsert.SetToolTip(this.btnDomainPasteFromClip, "Paste from clipboard");
            this.btnDomainPasteFromClip.UseVisualStyleBackColor = true;
            this.btnDomainPasteFromClip.Click += new System.EventHandler(this.BtnDomainPasteFromClip_Click);
            // 
            // btnChangeDomain
            // 
            this.btnChangeDomain.Image = global::PasswordManager.WindowsApp.Properties.Resources.change;
            this.btnChangeDomain.Location = new System.Drawing.Point(323, 27);
            this.btnChangeDomain.Name = "btnChangeDomain";
            this.btnChangeDomain.Size = new System.Drawing.Size(26, 26);
            this.btnChangeDomain.TabIndex = 16;
            this.ttInsert.SetToolTip(this.btnChangeDomain, "Get base domain from URL");
            this.btnChangeDomain.UseVisualStyleBackColor = true;
            this.btnChangeDomain.Click += new System.EventHandler(this.BtnChangeDomain_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::PasswordManager.WindowsApp.Properties.Resources.cancel;
            this.btnClear.Location = new System.Drawing.Point(196, 265);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(26, 26);
            this.btnClear.TabIndex = 15;
            this.ttInsert.SetToolTip(this.btnClear, "Clear Data");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnCopyUsername
            // 
            this.btnCopyUsername.Image = global::PasswordManager.WindowsApp.Properties.Resources.clipboard;
            this.btnCopyUsername.Location = new System.Drawing.Point(323, 85);
            this.btnCopyUsername.Name = "btnCopyUsername";
            this.btnCopyUsername.Size = new System.Drawing.Size(26, 26);
            this.btnCopyUsername.TabIndex = 14;
            this.ttInsert.SetToolTip(this.btnCopyUsername, "Copy username to clipboard");
            this.btnCopyUsername.UseVisualStyleBackColor = true;
            this.btnCopyUsername.Click += new System.EventHandler(this.BtnCopyUsername_Click);
            // 
            // btnPasswordHide
            // 
            this.btnPasswordHide.Image = global::PasswordManager.WindowsApp.Properties.Resources.hide;
            this.btnPasswordHide.Location = new System.Drawing.Point(261, 146);
            this.btnPasswordHide.Name = "btnPasswordHide";
            this.btnPasswordHide.Size = new System.Drawing.Size(26, 26);
            this.btnPasswordHide.TabIndex = 13;
            this.ttInsert.SetToolTip(this.btnPasswordHide, "Toggle show/hide of password");
            this.btnPasswordHide.UseVisualStyleBackColor = true;
            this.btnPasswordHide.Click += new System.EventHandler(this.BtnPasswordHide_Click);
            // 
            // btnCopyPassword
            // 
            this.btnCopyPassword.Image = global::PasswordManager.WindowsApp.Properties.Resources.clipboard;
            this.btnCopyPassword.Location = new System.Drawing.Point(325, 146);
            this.btnCopyPassword.Name = "btnCopyPassword";
            this.btnCopyPassword.Size = new System.Drawing.Size(26, 26);
            this.btnCopyPassword.TabIndex = 12;
            this.ttInsert.SetToolTip(this.btnCopyPassword, "Copy password to clipboard");
            this.btnCopyPassword.UseVisualStyleBackColor = true;
            this.btnCopyPassword.Click += new System.EventHandler(this.BtnCopyPassword_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Image = global::PasswordManager.WindowsApp.Properties.Resources.refresh;
            this.btnGenerate.Location = new System.Drawing.Point(293, 146);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(26, 26);
            this.btnGenerate.TabIndex = 11;
            this.ttInsert.SetToolTip(this.btnGenerate, "Generate new random password!");
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(83, 240);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(242, 13);
            this.lblError.TabIndex = 10;
            this.lblError.Text = "Domain, Username, and Password are all required";
            this.lblError.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::PasswordManager.WindowsApp.Properties.Resources.save;
            this.btnAdd.Location = new System.Drawing.Point(164, 265);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 26);
            this.btnAdd.TabIndex = 9;
            this.ttInsert.SetToolTip(this.btnAdd, "Save Entry");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(3, 207);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(252, 21);
            this.cbCategory.TabIndex = 8;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(3, 190);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(97, 13);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Category (Optional)";
            // 
            // tbWebsitePassword
            // 
            this.tbWebsitePassword.Location = new System.Drawing.Point(4, 150);
            this.tbWebsitePassword.Name = "tbWebsitePassword";
            this.tbWebsitePassword.PasswordChar = '*';
            this.tbWebsitePassword.Size = new System.Drawing.Size(251, 20);
            this.tbWebsitePassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(3, 134);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(95, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "WebsitePassword:";
            // 
            // tbWebsiteUsername
            // 
            this.tbWebsiteUsername.Location = new System.Drawing.Point(4, 89);
            this.tbWebsiteUsername.Name = "tbWebsiteUsername";
            this.tbWebsiteUsername.Size = new System.Drawing.Size(313, 20);
            this.tbWebsiteUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(2, 73);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Website Username:";
            // 
            // tbWebsiteDomain
            // 
            this.tbWebsiteDomain.Location = new System.Drawing.Point(3, 31);
            this.tbWebsiteDomain.Name = "tbWebsiteDomain";
            this.tbWebsiteDomain.Size = new System.Drawing.Size(314, 20);
            this.tbWebsiteDomain.TabIndex = 1;
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(2, 14);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(88, 13);
            this.lblDomain.TabIndex = 0;
            this.lblDomain.Text = "Website Domain:";
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(368, 12);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(32, 32);
            this.pbStatus.TabIndex = 2;
            this.pbStatus.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Image = global::PasswordManager.WindowsApp.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(12, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(26, 26);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // frmPasswordInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 358);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Name = "frmPasswordInsert";
            this.Text = "frmPasswordInsert";
            this.Load += new System.EventHandler(this.frmPasswordInsert_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox tbWebsitePassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbWebsiteUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbWebsiteDomain;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ToolTip ttInsert;
        private System.Windows.Forms.Button btnCopyUsername;
        private System.Windows.Forms.Button btnPasswordHide;
        private System.Windows.Forms.Button btnCopyPassword;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.Button btnChangeDomain;
        private System.Windows.Forms.Button btnDomainPasteFromClip;
        private System.Windows.Forms.Button btnPasswordPasteFromClip;
        private System.Windows.Forms.Button btnUsernamePasteFromClip;
    }
}