namespace PasswordManager.WindowsApp
{
    partial class frmPasswordRetrieval
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lbWebsiteList = new System.Windows.Forms.ListBox();
            this.comboCategorySort = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.pbCategorySave = new System.Windows.Forms.PictureBox();
            this.pbPasswordSave = new System.Windows.Forms.PictureBox();
            this.pbUsernameSave = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbPassword = new System.Windows.Forms.CheckBox();
            this.tbResultPassword = new System.Windows.Forms.TextBox();
            this.lblResultPassword = new System.Windows.Forms.Label();
            this.tbResultUsername = new System.Windows.Forms.TextBox();
            this.lblResultUsername = new System.Windows.Forms.Label();
            this.comboCategoryResult = new System.Windows.Forms.ComboBox();
            this.lblResultCategory = new System.Windows.Forms.Label();
            this.btnCopyPassword = new System.Windows.Forms.Button();
            this.btnCopyEmail = new System.Windows.Forms.Button();
            this.ttNotYetSaved = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategorySave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernameSave)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnSettings);
            this.pnlMain.Controls.Add(this.btnAdd);
            this.pnlMain.Controls.Add(this.pnlList);
            this.pnlMain.Controls.Add(this.lblServerStatus);
            this.pnlMain.Controls.Add(this.lblServer);
            this.pnlMain.Controls.Add(this.pnlResults);
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(685, 561);
            this.pnlMain.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(586, 7);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(96, 23);
            this.btnSettings.TabIndex = 13;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(484, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add Password";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // pnlList
            // 
            this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlList.Controls.Add(this.lbWebsiteList);
            this.pnlList.Controls.Add(this.comboCategorySort);
            this.pnlList.Controls.Add(this.lblCategory);
            this.pnlList.Location = new System.Drawing.Point(0, 36);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(335, 500);
            this.pnlList.TabIndex = 0;
            // 
            // lbWebsiteList
            // 
            this.lbWebsiteList.FormattingEnabled = true;
            this.lbWebsiteList.Location = new System.Drawing.Point(-1, 33);
            this.lbWebsiteList.Name = "lbWebsiteList";
            this.lbWebsiteList.Size = new System.Drawing.Size(335, 472);
            this.lbWebsiteList.TabIndex = 2;
            this.lbWebsiteList.SelectedIndexChanged += new System.EventHandler(this.LbWebsiteList_SelectedIndexChanged);
            // 
            // comboCategorySort
            // 
            this.comboCategorySort.FormattingEnabled = true;
            this.comboCategorySort.Location = new System.Drawing.Point(94, 6);
            this.comboCategorySort.Name = "comboCategorySort";
            this.comboCategorySort.Size = new System.Drawing.Size(237, 21);
            this.comboCategorySort.TabIndex = 1;
            this.comboCategorySort.SelectedIndexChanged += new System.EventHandler(this.ComboCategorySort_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(3, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(85, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Select Category:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(98, 11);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(37, 13);
            this.lblServerStatus.TabIndex = 3;
            this.lblServerStatus.Text = "Status";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(3, 11);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(89, 13);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Database Status:";
            // 
            // pnlResults
            // 
            this.pnlResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResults.Controls.Add(this.pbCategorySave);
            this.pnlResults.Controls.Add(this.pbPasswordSave);
            this.pnlResults.Controls.Add(this.pbUsernameSave);
            this.pnlResults.Controls.Add(this.btnDelete);
            this.pnlResults.Controls.Add(this.btnUpdate);
            this.pnlResults.Controls.Add(this.cbPassword);
            this.pnlResults.Controls.Add(this.tbResultPassword);
            this.pnlResults.Controls.Add(this.lblResultPassword);
            this.pnlResults.Controls.Add(this.tbResultUsername);
            this.pnlResults.Controls.Add(this.lblResultUsername);
            this.pnlResults.Controls.Add(this.comboCategoryResult);
            this.pnlResults.Controls.Add(this.lblResultCategory);
            this.pnlResults.Controls.Add(this.btnCopyPassword);
            this.pnlResults.Controls.Add(this.btnCopyEmail);
            this.pnlResults.Location = new System.Drawing.Point(341, 36);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(338, 500);
            this.pnlResults.TabIndex = 1;
            // 
            // pbCategorySave
            // 
            this.pbCategorySave.Image = global::PasswordManager.WindowsApp.Properties.Resources.warning;
            this.pbCategorySave.Location = new System.Drawing.Point(299, 125);
            this.pbCategorySave.Name = "pbCategorySave";
            this.pbCategorySave.Size = new System.Drawing.Size(16, 16);
            this.pbCategorySave.TabIndex = 17;
            this.pbCategorySave.TabStop = false;
            this.ttNotYetSaved.SetToolTip(this.pbCategorySave, "Change is not yet saved!");
            this.pbCategorySave.Visible = false;
            // 
            // pbPasswordSave
            // 
            this.pbPasswordSave.Image = global::PasswordManager.WindowsApp.Properties.Resources.warning;
            this.pbPasswordSave.Location = new System.Drawing.Point(71, 75);
            this.pbPasswordSave.Name = "pbPasswordSave";
            this.pbPasswordSave.Size = new System.Drawing.Size(16, 16);
            this.pbPasswordSave.TabIndex = 16;
            this.pbPasswordSave.TabStop = false;
            this.ttNotYetSaved.SetToolTip(this.pbPasswordSave, "Change is not yet saved!");
            this.pbPasswordSave.Visible = false;
            // 
            // pbUsernameSave
            // 
            this.pbUsernameSave.Image = global::PasswordManager.WindowsApp.Properties.Resources.warning;
            this.pbUsernameSave.Location = new System.Drawing.Point(71, 30);
            this.pbUsernameSave.Name = "pbUsernameSave";
            this.pbUsernameSave.Size = new System.Drawing.Size(16, 16);
            this.pbUsernameSave.TabIndex = 15;
            this.pbUsernameSave.TabStop = false;
            this.ttNotYetSaved.SetToolTip(this.pbUsernameSave, "Change is not yet saved!");
            this.pbUsernameSave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(88, 210);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(88, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(165, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // cbPassword
            // 
            this.cbPassword.AutoSize = true;
            this.cbPassword.Location = new System.Drawing.Point(230, 75);
            this.cbPassword.Name = "cbPassword";
            this.cbPassword.Size = new System.Drawing.Size(102, 17);
            this.cbPassword.TabIndex = 9;
            this.cbPassword.Text = "Show Password";
            this.cbPassword.UseVisualStyleBackColor = true;
            this.cbPassword.CheckedChanged += new System.EventHandler(this.CbPassword_CheckedChanged);
            // 
            // tbResultPassword
            // 
            this.tbResultPassword.Location = new System.Drawing.Point(3, 92);
            this.tbResultPassword.Name = "tbResultPassword";
            this.tbResultPassword.PasswordChar = '*';
            this.tbResultPassword.Size = new System.Drawing.Size(330, 20);
            this.tbResultPassword.TabIndex = 8;
            this.tbResultPassword.TextChanged += new System.EventHandler(this.TbResultPassword_TextChanged);
            // 
            // lblResultPassword
            // 
            this.lblResultPassword.AutoSize = true;
            this.lblResultPassword.Location = new System.Drawing.Point(7, 76);
            this.lblResultPassword.Name = "lblResultPassword";
            this.lblResultPassword.Size = new System.Drawing.Size(56, 13);
            this.lblResultPassword.TabIndex = 7;
            this.lblResultPassword.Text = "Password:";
            // 
            // tbResultUsername
            // 
            this.tbResultUsername.Location = new System.Drawing.Point(3, 49);
            this.tbResultUsername.Name = "tbResultUsername";
            this.tbResultUsername.Size = new System.Drawing.Size(330, 20);
            this.tbResultUsername.TabIndex = 6;
            this.tbResultUsername.TextChanged += new System.EventHandler(this.TbResultUsername_TextChanged);
            // 
            // lblResultUsername
            // 
            this.lblResultUsername.AutoSize = true;
            this.lblResultUsername.Location = new System.Drawing.Point(7, 33);
            this.lblResultUsername.Name = "lblResultUsername";
            this.lblResultUsername.Size = new System.Drawing.Size(58, 13);
            this.lblResultUsername.TabIndex = 5;
            this.lblResultUsername.Text = "Username:";
            // 
            // comboCategoryResult
            // 
            this.comboCategoryResult.FormattingEnabled = true;
            this.comboCategoryResult.Location = new System.Drawing.Point(98, 122);
            this.comboCategoryResult.Name = "comboCategoryResult";
            this.comboCategoryResult.Size = new System.Drawing.Size(195, 21);
            this.comboCategoryResult.TabIndex = 4;
            this.comboCategoryResult.SelectedIndexChanged += new System.EventHandler(this.ComboCategoryResult_SelectedIndexChanged);
            // 
            // lblResultCategory
            // 
            this.lblResultCategory.AutoSize = true;
            this.lblResultCategory.Location = new System.Drawing.Point(3, 125);
            this.lblResultCategory.Name = "lblResultCategory";
            this.lblResultCategory.Size = new System.Drawing.Size(89, 13);
            this.lblResultCategory.TabIndex = 3;
            this.lblResultCategory.Text = "Current Category:";
            // 
            // btnCopyPassword
            // 
            this.btnCopyPassword.Location = new System.Drawing.Point(168, 149);
            this.btnCopyPassword.Name = "btnCopyPassword";
            this.btnCopyPassword.Size = new System.Drawing.Size(165, 23);
            this.btnCopyPassword.TabIndex = 2;
            this.btnCopyPassword.Text = "Copy Password";
            this.btnCopyPassword.UseVisualStyleBackColor = true;
            this.btnCopyPassword.Click += new System.EventHandler(this.BtnCopyPassword_Click);
            // 
            // btnCopyEmail
            // 
            this.btnCopyEmail.Location = new System.Drawing.Point(3, 149);
            this.btnCopyEmail.Name = "btnCopyEmail";
            this.btnCopyEmail.Size = new System.Drawing.Size(165, 23);
            this.btnCopyEmail.TabIndex = 1;
            this.btnCopyEmail.Text = "Copy Username";
            this.btnCopyEmail.UseVisualStyleBackColor = true;
            this.btnCopyEmail.Click += new System.EventHandler(this.BtnCopyEmail_Click);
            // 
            // frmPasswordRetrieval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 585);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmPasswordRetrieval";
            this.Text = "frmPasswordRetrieval";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategorySave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernameSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.ListBox lbWebsiteList;
        private System.Windows.Forms.ComboBox comboCategorySort;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.CheckBox cbPassword;
        private System.Windows.Forms.TextBox tbResultPassword;
        private System.Windows.Forms.Label lblResultPassword;
        private System.Windows.Forms.TextBox tbResultUsername;
        private System.Windows.Forms.Label lblResultUsername;
        private System.Windows.Forms.ComboBox comboCategoryResult;
        private System.Windows.Forms.Label lblResultCategory;
        private System.Windows.Forms.Button btnCopyPassword;
        private System.Windows.Forms.Button btnCopyEmail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.PictureBox pbUsernameSave;
        private System.Windows.Forms.PictureBox pbCategorySave;
        private System.Windows.Forms.PictureBox pbPasswordSave;
        private System.Windows.Forms.ToolTip ttNotYetSaved;
    }
}