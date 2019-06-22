using PasswordManager.WindowsApp.DAO;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PasswordManager.WindowsApp
{
    public partial class frmLogin : Form
    {
        #region Variables

        dataLogin dataLogin = new dataLogin();
        DataUtilities dataUtility = new DataUtilities();
        
        string registerEmail = "";
        string registerPassword1 = "";
        string registerPassword2 = "";

        #endregion

        #region Constructors

        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            bool databaseCheck = dataUtility.databaseCheck();

            if (databaseCheck == true)
            {
                String path = "..\\..\\Resources\\Connected.png";
                pbStatus.Image = Image.FromFile(path);
                ttLogin.SetToolTip(pbStatus, "You are connected!");
            }

            else
            {
                String path = "..\\..\\Resources\\notConnected.png";
                pbStatus.Image = Image.FromFile(path);
                ttLogin.SetToolTip(pbStatus, "You are not connected!");
                btnLogin.Enabled = false;
            }

            tbLoginEmail.Focus();
        }

        #endregion

        #region Events

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = tbLoginEmail.Text;
            string password = tbLoginPassword.Text;

            if (username == "")
            {
                lblLoginError.ForeColor = System.Drawing.Color.Red;
                lblLoginError.Text = "Email is required";
                tbRegisterEmail.Focus();
                tbRegisterEmail.SelectAll();
            }

            else
            {
                if (password == "")
                {
                    lblLoginError.ForeColor = System.Drawing.Color.Red;
                    lblLoginError.Text = "Password is required";
                    tbLoginPassword.Focus();
                    tbLoginPassword.SelectAll();
                }

                else
                {
                    string hashedPass = dataUtility.EncodePassword(password);

                    Task<bool> loginAsync = dataLogin.loginToDatabase(username, hashedPass);

                    progressBarLogin.Visible = true;
                    progressBarLogin.MarqueeAnimationSpeed = 10;

                    bool loginSuccess = await loginAsync;
                                        
                    if (loginSuccess)
                    {
                        frmPasswordRetrieval newForm = new frmPasswordRetrieval();
                        newForm.Show();
                        newForm.Location = this.Location;

                        //close login form
                        this.Close();
                    }

                    else
                    {
                        lblLoginError.ForeColor = System.Drawing.Color.Red;
                        lblLoginError.Text = "Incorrect Password";

                        tbLoginPassword.Focus();
                        tbLoginPassword.SelectAll();
                    }

                    progressBarLogin.Visible = false;
                } 
            }
        }

        private void BtnShowLoginPassword_MouseDown(object sender, EventArgs e)
        {
                tbLoginPassword.PasswordChar = '\0';
                String path = "..\\..\\Resources\\unhide.png";
                btnShowLoginPassword.Image = Image.FromFile(path);            
        }

        private void BtnShowLoginPassword_MouseUp(object sender, EventArgs e)
        {
            tbLoginPassword.PasswordChar = '*';
            String path = "..\\..\\Resources\\hide.png";
            btnShowLoginPassword.Image = Image.FromFile(path);
        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            registerEmail = tbRegisterEmail.Text;
            registerPassword1 = tbRegisterPassword_1.Text;
            registerPassword2 = tbRegisterPassword_2.Text;

            if (registerEmail == "")
            {
                lblRegisterError.ForeColor = System.Drawing.Color.Red;
                lblRegisterError.Text = "Email is required";
            }
            else
            {
                if (registerPassword1 == "" || registerPassword2 == "")
                {
                    lblRegisterError.ForeColor = System.Drawing.Color.Red;
                    lblRegisterError.Text = "Password is required";
                }
                else
                {
                    if(registerPassword1 != registerPassword2)
                    {
                        lblRegisterError.ForeColor = System.Drawing.Color.Red;
                        lblRegisterError.Text = "Passwords must match";
                    }
                    else
                    {
                        string hashedPass = dataUtility.EncodePassword(registerPassword1);

                        Task<int> SignUpAsync = dataLogin.signUp(registerEmail, hashedPass);

                        progressBarLogin.Visible = true;
                        progressBarLogin.MarqueeAnimationSpeed = 10;

                        int SignUpSuccess = await SignUpAsync;
                        
                        if (SignUpSuccess != -1)
                        {
                            tabControlLogin.SelectedIndex = 0;
                            lblLoginError.ForeColor = System.Drawing.Color.Green;
                            lblLoginError.Text = "Registration Success!";
                            tbLoginEmail.Text = "";
                            tbLoginPassword.Text = "";
                            tbRegisterEmail.Text = "";
                            tbRegisterPassword_1.Text = "";
                            tbRegisterPassword_2.Text = "";
                            lblRegisterError.Text = "";
                        }
                        else
                        {
                            tabControlLogin.SelectedIndex = 0;
                            lblLoginError.ForeColor = System.Drawing.Color.Red;
                            lblLoginError.Text = "Registration Failed!";
                            tbLoginEmail.Text = "";
                            tbLoginPassword.Text = "";
                            tbRegisterEmail.Text = "";
                            tbRegisterPassword_1.Text = "";
                            tbRegisterPassword_2.Text = "";
                            lblRegisterError.Text = "";
                        }
                    }
                }
            }
            progressBarLogin.Visible = false;
        }

        private void btnRegisterPassword1Show_MouseDown(object sender, EventArgs e)
        {
            tbRegisterPassword_1.PasswordChar = '\0';
            String path = "..\\..\\Resources\\unhide.png";
            btnRegisterPassword1Show.Image = Image.FromFile(path);
        }

        private void btnRegisterPassword1Show_MouseUp(object sender, EventArgs e)
        {
            tbRegisterPassword_1.PasswordChar = '*';
            String path = "..\\..\\Resources\\hide.png";
            btnRegisterPassword1Show.Image = Image.FromFile(path);
        }

        private void btnRegisterPassword2Show_MouseDown(object sender, EventArgs e)
        {
            tbRegisterPassword_2.PasswordChar = '\0';
            String path = "..\\..\\Resources\\unhide.png";
            btnRegisterPassword2Show.Image = Image.FromFile(path);
        }

        private void btnRegisterPassword2Show_MouseUp(object sender, EventArgs e)
        {
            tbRegisterPassword_2.PasswordChar = '*';
            String path = "..\\..\\Resources\\hide.png";
            btnRegisterPassword2Show.Image = Image.FromFile(path);
        }

        #endregion
    }
}
