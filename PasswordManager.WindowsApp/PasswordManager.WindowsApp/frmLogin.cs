using PasswordManager.WindowsApp.DAO;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace PasswordManager.WindowsApp
{
    public partial class frmLogin : Form
    {

        dataLogin dl = new dataLogin();
        int loginHideCounter = 1;

        public frmLogin()
        {
            InitializeComponent();
        }


        //on start up of the application
        //set database status
        private void FrmLogin_Load(object sender, EventArgs e)
        {

            if (dl.databaseCheck() == true)
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
        private void BtnLogin_Click(object sender, EventArgs e)
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
                    string hashedPass = dl.EncodePassword(password);

                    //if the login is sucessful, close the login screen and open next form 
                    
                    if (dl.loginToDatabase(username, hashedPass) == true)
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
        private void BtnRegister_Click(object sender, EventArgs e)
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
                        string hashedPass = dl.EncodePassword(registerPassword1);
                        lblRegisterError.Text = hashedPass;

                        //enter into database
                        if (dl.Register(registerEmail, hashedPass) != 0)
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
