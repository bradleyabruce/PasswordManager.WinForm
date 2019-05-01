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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.chPassword = new System.Windows.Forms.CheckBox();
            this.tbWebsitePassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbWebsiteUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbWebsiteDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.chPassword);
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(125, 267);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 34);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Save!";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(4, 211);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(210, 21);
            this.cbCategory.TabIndex = 8;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(4, 194);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(97, 13);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Category (Optional)";
            // 
            // chPassword
            // 
            this.chPassword.AutoSize = true;
            this.chPassword.Location = new System.Drawing.Point(281, 130);
            this.chPassword.Name = "chPassword";
            this.chPassword.Size = new System.Drawing.Size(102, 17);
            this.chPassword.TabIndex = 6;
            this.chPassword.Text = "Show Password";
            this.chPassword.UseVisualStyleBackColor = true;
            this.chPassword.CheckedChanged += new System.EventHandler(this.ChPassword_CheckedChanged);
            // 
            // tbWebsitePassword
            // 
            this.tbWebsitePassword.Location = new System.Drawing.Point(4, 150);
            this.tbWebsitePassword.Name = "tbWebsitePassword";
            this.tbWebsitePassword.PasswordChar = '*';
            this.tbWebsitePassword.Size = new System.Drawing.Size(380, 20);
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
            this.tbWebsiteUsername.Size = new System.Drawing.Size(380, 20);
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
            this.tbWebsiteDomain.Size = new System.Drawing.Size(380, 20);
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
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<---";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(249, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Database Status:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(344, 13);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(0, 13);
            this.lblServerStatus.TabIndex = 3;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(73, 251);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(242, 13);
            this.lblError.TabIndex = 10;
            this.lblError.Text = "Domain, Username, and Password are all required";
            this.lblError.Visible = false;
            // 
            // frmPasswordInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 358);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Name = "frmPasswordInsert";
            this.Text = "frmPasswordInsert";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.CheckBox chPassword;
        private System.Windows.Forms.TextBox tbWebsitePassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbWebsiteUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbWebsiteDomain;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblError;
    }
}