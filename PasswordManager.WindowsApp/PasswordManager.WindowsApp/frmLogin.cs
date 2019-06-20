using PasswordManager.WindowsApp.DAO;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PasswordManager.WindowsApp
{
    public partial class frmLogin : Form
    {

        dataLogin dataLogin = new dataLogin();

        public frmLogin()
        {
            InitializeComponent();
        }


        //on start up of the application
        //set database status
        private async void FrmLogin_Load(object sender, EventArgs e)
        {

            bool databaseCheck = dataLogin.databaseCheck();

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

        }

/********************** Login *****************************/
  
        //on login button press
        private async void BtnLogin_Click(object sender, EventArgs e)
        {

            //get username and password from textbox
            string username = tbLoginEmail.Text;
            string password = tbLoginPassword.Text;

            //check to see if username is blank
            if (username == "")
            {
                lblLoginError.ForeColor = System.Drawing.Color.Red;
                lblLoginError.Text = "Email is required";
                tbRegisterEmail.Focus();
                tbRegisterEmail.SelectAll();

            }

            else
            {

                //if passsword is blank, let the user know
                if (password == "")
                {
                    lblLoginError.ForeColor = System.Drawing.Color.Red;
                    lblLoginError.Text = "Password is required";
                    tbLoginPassword.Focus();
                    tbLoginPassword.SelectAll();
                }

                else
                {

                    //hash password
                    string hashedPass = dataLogin.EncodePassword(password);

                    Task<bool> loginAsync = dataLogin.loginToDatabase(username, hashedPass);

                    //show loading icon...

                    bool loginSuccess = await loginAsync;
                    
                    
                    if (loginSuccess)
                    {
              
                        //create new form to open
                        frmPasswordRetrieval newForm = new frmPasswordRetrieval();
                        newForm.Show();
                        newForm.Location = this.Location;

                        //close login form
                        this.Close();
                    }

                    //if the login returns false alert the user 
                    else
                    {
                        lblLoginError.ForeColor = System.Drawing.Color.Red;
                        lblLoginError.Text = "Incorrect Password";

                        tbLoginPassword.Focus();
                        tbLoginPassword.SelectAll();

                    }
                    
                    //hide loading bar...

                }//end password blank   

            }//end username blank

        }//end button click



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


        /************************ Registation *******************************/

        string registerEmail = "";
        string registerPassword1 = "";
        string registerPassword2 = "";

        //when register button is clicked
        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            registerEmail = tbRegisterEmail.Text;
            registerPassword1 = tbRegisterPassword_1.Text;
            registerPassword2 = tbRegisterPassword_2.Text;

            //check blanks
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

                        //encrypt password 
                        string hashedPass = dataLogin.EncodePassword(registerPassword1);

                        Task<int> SignUpAsync = dataLogin.signUp(registerEmail, hashedPass);

                        //show loading icon...

                        int SignUpSuccess = await SignUpAsync;


                        //enter into database
                        if (SignUpSuccess != -1)
                        {

                            //allow user to sign in with new account
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

                    }
                }
            }


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

    }//end form

}//end namespace
