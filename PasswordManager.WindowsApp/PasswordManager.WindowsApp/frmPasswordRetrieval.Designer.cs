﻿namespace PasswordManager.WindowsApp
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lbWebsiteList = new System.Windows.Forms.ListBox();
            this.comboCategorySort = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbPassword = new System.Windows.Forms.CheckBox();
            this.tbResultPassword = new System.Windows.Forms.TextBox();
            this.lblResultPassword = new System.Windows.Forms.Label();
            this.tbResultUsername = new System.Windows.Forms.TextBox();
            this.lblResultUsername = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblResultCategory = new System.Windows.Forms.Label();
            this.btnCopyPassword = new System.Windows.Forms.Button();
            this.btnCopyEmail = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(509, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(165, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
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
            this.pnlResults.Controls.Add(this.btnDelete);
            this.pnlResults.Controls.Add(this.btnUpdate);
            this.pnlResults.Controls.Add(this.cbPassword);
            this.pnlResults.Controls.Add(this.tbResultPassword);
            this.pnlResults.Controls.Add(this.lblResultPassword);
            this.pnlResults.Controls.Add(this.tbResultUsername);
            this.pnlResults.Controls.Add(this.lblResultUsername);
            this.pnlResults.Controls.Add(this.comboBox1);
            this.pnlResults.Controls.Add(this.lblResultCategory);
            this.pnlResults.Controls.Add(this.btnCopyPassword);
            this.pnlResults.Controls.Add(this.btnCopyEmail);
            this.pnlResults.Location = new System.Drawing.Point(341, 36);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(338, 500);
            this.pnlResults.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(88, 210);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(88, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(165, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
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
            // 
            // tbResultPassword
            // 
            this.tbResultPassword.Location = new System.Drawing.Point(3, 92);
            this.tbResultPassword.Name = "tbResultPassword";
            this.tbResultPassword.PasswordChar = '*';
            this.tbResultPassword.Size = new System.Drawing.Size(330, 20);
            this.tbResultPassword.TabIndex = 8;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(98, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 21);
            this.comboBox1.TabIndex = 4;
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
            // 
            // btnCopyEmail
            // 
            this.btnCopyEmail.Location = new System.Drawing.Point(3, 149);
            this.btnCopyEmail.Name = "btnCopyEmail";
            this.btnCopyEmail.Size = new System.Drawing.Size(165, 23);
            this.btnCopyEmail.TabIndex = 1;
            this.btnCopyEmail.Text = "Copy Username";
            this.btnCopyEmail.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblResultCategory;
        private System.Windows.Forms.Button btnCopyPassword;
        private System.Windows.Forms.Button btnCopyEmail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
    }
}