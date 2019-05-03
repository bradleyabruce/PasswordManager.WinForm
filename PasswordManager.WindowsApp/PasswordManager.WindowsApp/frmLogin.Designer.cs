namespace PasswordManager.WindowsApp
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.ttLogin = new System.Windows.Forms.ToolTip(this.components);
            this.btnShowLoginPassword = new System.Windows.Forms.Button();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.tabControlLogin = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.lblLoginError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbLoginPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLoginEmail = new System.Windows.Forms.TextBox();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.btnRegisterPassword2Show = new System.Windows.Forms.Button();
            this.btnRegisterPassword1Show = new System.Windows.Forms.Button();
            this.lblRegisterError = new System.Windows.Forms.Label();
            this.tbRegisterPassword_2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tbRegisterPassword_1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRegisterEmail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.tabControlLogin.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowLoginPassword
            // 
            this.btnShowLoginPassword.Image = global::PasswordManager.WindowsApp.Properties.Resources.hide;
            this.btnShowLoginPassword.Location = new System.Drawing.Point(254, 92);
            this.btnShowLoginPassword.Name = "btnShowLoginPassword";
            this.btnShowLoginPassword.Size = new System.Drawing.Size(26, 26);
            this.btnShowLoginPassword.TabIndex = 20;
            this.ttLogin.SetToolTip(this.btnShowLoginPassword, "Toggle show/hide password");
            this.btnShowLoginPassword.UseVisualStyleBackColor = true;
            this.btnShowLoginPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnShowLoginPassword_MouseDown);
            this.btnShowLoginPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnShowLoginPassword_MouseUp);
            // 
            // pbStatus
            // 
            this.pbStatus.Image = global::PasswordManager.WindowsApp.Properties.Resources.notConnected;
            this.pbStatus.Location = new System.Drawing.Point(12, 4);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(32, 32);
            this.pbStatus.TabIndex = 2;
            this.pbStatus.TabStop = false;
            // 
            // tabControlLogin
            // 
            this.tabControlLogin.Controls.Add(this.tabLogin);
            this.tabControlLogin.Controls.Add(this.tabRegister);
            this.tabControlLogin.Location = new System.Drawing.Point(12, 43);
            this.tabControlLogin.Name = "tabControlLogin";
            this.tabControlLogin.SelectedIndex = 0;
            this.tabControlLogin.Size = new System.Drawing.Size(318, 254);
            this.tabControlLogin.TabIndex = 3;
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.btnShowLoginPassword);
            this.tabLogin.Controls.Add(this.lblLoginError);
            this.tabLogin.Controls.Add(this.label6);
            this.tabLogin.Controls.Add(this.btnLogin);
            this.tabLogin.Controls.Add(this.tbLoginPassword);
            this.tabLogin.Controls.Add(this.label7);
            this.tabLogin.Controls.Add(this.label8);
            this.tabLogin.Controls.Add(this.tbLoginEmail);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(310, 228);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // lblLoginError
            // 
            this.lblLoginError.AutoSize = true;
            this.lblLoginError.Location = new System.Drawing.Point(105, 173);
            this.lblLoginError.Name = "lblLoginError";
            this.lblLoginError.Size = new System.Drawing.Size(0, 13);
            this.lblLoginError.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Login With Existing Account";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(108, 193);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "Login >";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // tbLoginPassword
            // 
            this.tbLoginPassword.Location = new System.Drawing.Point(33, 96);
            this.tbLoginPassword.Name = "tbLoginPassword";
            this.tbLoginPassword.PasswordChar = '*';
            this.tbLoginPassword.Size = new System.Drawing.Size(215, 20);
            this.tbLoginPassword.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Email:";
            // 
            // tbLoginEmail
            // 
            this.tbLoginEmail.Location = new System.Drawing.Point(33, 48);
            this.tbLoginEmail.Name = "tbLoginEmail";
            this.tbLoginEmail.Size = new System.Drawing.Size(247, 20);
            this.tbLoginEmail.TabIndex = 0;
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.btnRegisterPassword2Show);
            this.tabRegister.Controls.Add(this.btnRegisterPassword1Show);
            this.tabRegister.Controls.Add(this.lblRegisterError);
            this.tabRegister.Controls.Add(this.tbRegisterPassword_2);
            this.tabRegister.Controls.Add(this.label5);
            this.tabRegister.Controls.Add(this.label1);
            this.tabRegister.Controls.Add(this.btnRegister);
            this.tabRegister.Controls.Add(this.tbRegisterPassword_1);
            this.tabRegister.Controls.Add(this.label3);
            this.tabRegister.Controls.Add(this.label4);
            this.tabRegister.Controls.Add(this.tbRegisterEmail);
            this.tabRegister.Location = new System.Drawing.Point(4, 22);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegister.Size = new System.Drawing.Size(310, 228);
            this.tabRegister.TabIndex = 1;
            this.tabRegister.Text = "Register";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // btnRegisterPassword2Show
            // 
            this.btnRegisterPassword2Show.Image = global::PasswordManager.WindowsApp.Properties.Resources.hide;
            this.btnRegisterPassword2Show.Location = new System.Drawing.Point(254, 144);
            this.btnRegisterPassword2Show.Name = "btnRegisterPassword2Show";
            this.btnRegisterPassword2Show.Size = new System.Drawing.Size(26, 26);
            this.btnRegisterPassword2Show.TabIndex = 18;
            this.btnRegisterPassword2Show.UseVisualStyleBackColor = true;
            this.btnRegisterPassword2Show.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRegisterPassword2Show_MouseDown);
            this.btnRegisterPassword2Show.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRegisterPassword2Show_MouseUp);
            // 
            // btnRegisterPassword1Show
            // 
            this.btnRegisterPassword1Show.Image = global::PasswordManager.WindowsApp.Properties.Resources.hide;
            this.btnRegisterPassword1Show.Location = new System.Drawing.Point(254, 92);
            this.btnRegisterPassword1Show.Name = "btnRegisterPassword1Show";
            this.btnRegisterPassword1Show.Size = new System.Drawing.Size(26, 26);
            this.btnRegisterPassword1Show.TabIndex = 17;
            this.btnRegisterPassword1Show.UseVisualStyleBackColor = true;
            this.btnRegisterPassword1Show.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRegisterPassword1Show_MouseDown);
            this.btnRegisterPassword1Show.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRegisterPassword1Show_MouseUp);
            // 
            // lblRegisterError
            // 
            this.lblRegisterError.AutoSize = true;
            this.lblRegisterError.Location = new System.Drawing.Point(105, 171);
            this.lblRegisterError.Name = "lblRegisterError";
            this.lblRegisterError.Size = new System.Drawing.Size(0, 13);
            this.lblRegisterError.TabIndex = 16;
            // 
            // tbRegisterPassword_2
            // 
            this.tbRegisterPassword_2.Location = new System.Drawing.Point(33, 148);
            this.tbRegisterPassword_2.Name = "tbRegisterPassword_2";
            this.tbRegisterPassword_2.PasswordChar = '*';
            this.tbRegisterPassword_2.Size = new System.Drawing.Size(215, 20);
            this.tbRegisterPassword_2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Reenter Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Register New Account";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(108, 193);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Register >";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // tbRegisterPassword_1
            // 
            this.tbRegisterPassword_1.Location = new System.Drawing.Point(33, 96);
            this.tbRegisterPassword_1.Name = "tbRegisterPassword_1";
            this.tbRegisterPassword_1.PasswordChar = '*';
            this.tbRegisterPassword_1.Size = new System.Drawing.Size(215, 20);
            this.tbRegisterPassword_1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Email:";
            // 
            // tbRegisterEmail
            // 
            this.tbRegisterEmail.Location = new System.Drawing.Point(33, 48);
            this.tbRegisterEmail.Name = "tbRegisterEmail";
            this.tbRegisterEmail.Size = new System.Drawing.Size(247, 20);
            this.tbRegisterEmail.TabIndex = 7;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 300);
            this.Controls.Add(this.tabControlLogin);
            this.Controls.Add(this.pbStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.Text = "Password Manager";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.tabControlLogin.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttLogin;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.TabControl tabControlLogin;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox tbRegisterPassword_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRegisterEmail;
        private System.Windows.Forms.TextBox tbRegisterPassword_2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbLoginPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLoginEmail;
        private System.Windows.Forms.Label lblLoginError;
        private System.Windows.Forms.Label lblRegisterError;
        private System.Windows.Forms.Button btnShowLoginPassword;
        private System.Windows.Forms.Button btnRegisterPassword2Show;
        private System.Windows.Forms.Button btnRegisterPassword1Show;
    }
}

