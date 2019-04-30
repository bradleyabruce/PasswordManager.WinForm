using PasswordManager.WindowsApp.DAO;
using System;
using System.Windows.Forms;


namespace PasswordManager.WindowsApp
{
    public partial class Form1 : Form
    {

        Utils utilClass = new Utils();

        public Form1()
        {

            //set database status for user

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
            }

        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {

            string username = tbUsername.Text;
            string password = tbPassword.Text;

           



        }
    }
}
