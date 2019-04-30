using PasswordManager.WindowsApp.DAO;
using System;
using System.Windows.Forms;


namespace PasswordManager.WindowsApp
{
    public partial class Form1 : Form
    {

        Utils utilClass = new Utils();


        //on start up of the application
        public Form1()
        {

            //set database status for database

            InitializeComponent();
            if (utilClass.databaseCheck() == true)
            {
                lblStatus.Text = " Online";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = " Offline";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                btnLogin.Enabled = false;
            }

        }


        //on login button press
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            //get username and password from textbox
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            //check to see if username or password is null and let user know
            if (username == "" || password == "")
            {
                MessageBox.Show("Username and Password Required");
            }

            else
            {

                //if the login returns true alert the user
                if (utilClass.loginToDatabase(username, password) == true)
                {
                    MessageBox.Show("Correct");
                }

                //if the login returns false alert the user 
                else
                {
                    MessageBox.Show("Incorrect Login");
                }
            }

        }
    }
}
