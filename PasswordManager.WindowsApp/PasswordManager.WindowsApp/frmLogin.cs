using PasswordManager.WindowsApp.DAO;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace PasswordManager.WindowsApp
{
    public partial class frmLogin : Form
    {


        dataLogin utilClass = new dataLogin();



        //on start up of the application
        public frmLogin()
        {

            //set database status for database
            InitializeComponent();
            if (utilClass.databaseCheck() == true)
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


  
        //on login button press
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            //get username and password from textbox
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            //check to see if username is blank
            if (username == "")
            {
                lblPassword.ForeColor = System.Drawing.Color.Black;
                lblUsername.ForeColor = System.Drawing.Color.Red;
                tbUsername.Focus();

            }

            else
            {

                //if passsword is blank, let the user know
                if (password == "")
                {
                    lblUsername.ForeColor = System.Drawing.Color.Black;
                    lblPassword.ForeColor = System.Drawing.Color.Red;
                    tbPassword.Focus();
                }

                else
                {

                    //if the login is sucessful, close the login screen and open next form 
                    if (utilClass.loginToDatabase(username, password) == true)
                    {
                        lblUsername.ForeColor = System.Drawing.Color.Black;
                        lblPassword.ForeColor = System.Drawing.Color.Black;
                        


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
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblUsername.ForeColor = System.Drawing.Color.Black;
                        lblPassword.ForeColor = System.Drawing.Color.Black;
                        lblError.Text = "  Login Failed!";

                        tbPassword.Focus();
                        tbPassword.SelectAll();

                    }

                }//end password blank   

            }//end username blank

        }//end button click

    }//end form

}//end namespace
