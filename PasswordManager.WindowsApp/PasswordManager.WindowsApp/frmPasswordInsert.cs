using PasswordManager.WindowsApp.DAO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PasswordManager.WindowsApp
{
    public partial class frmPasswordInsert : Form
    {

        dataLogin dl = new dataLogin();
        dataRetrieval dr = new dataRetrieval();
        dataInsert di = new dataInsert();


        //on page load
        public frmPasswordInsert()
        {
            InitializeComponent();

            //check database status
            if (dl.databaseCheck() == true)
            {
                lblServerStatus.Text = " Online";
                lblServerStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblServerStatus.Text = " Offline";
                lblServerStatus.ForeColor = System.Drawing.Color.Red;
            }

            cbCategory.DataSource = dr.getCategories();


        }




        //when back button is pressed
        private void BtnBack_Click(object sender, EventArgs e)
        {
            //create new form to open
            frmPasswordRetrieval newForm = new frmPasswordRetrieval();
            newForm.Show();

            //close login form
            this.Close();
        }


        //when password check box is affected
        private void ChPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chPassword.Checked == true)
            {
                tbWebsitePassword.PasswordChar = '\0';
            }
            else
            {
                tbWebsitePassword.PasswordChar = '*';
            }
        }



        private void BtnAdd_Click(object sender, EventArgs e)
        {

            string domain = tbWebsiteDomain.Text;
            string username = tbWebsiteUsername.Text;
            string password = tbWebsitePassword.Text;

            int domainID;
            int usernameID;
            int passwordID;
            int categoryID;
            int userID = Program.MyStaticValues.userID;

            //if domain is null do not proceed
            if (domain == "")
            {
                lblDomain.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                //if username is null do not proceed
                if(username == "")
                {
                    lblDomain.ForeColor = System.Drawing.Color.Black;
                    lblUsername.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //if password is null do not proceed
                    if(password == "")
                    {
                        lblUsername.ForeColor = System.Drawing.Color.Black;
                        lblPassword.ForeColor = System.Drawing.Color.Red;
                    }
                    
                    //if all entries are filled in, continue with insert
                    else
                    {
                        lblPassword.ForeColor = System.Drawing.Color.Black;               

                        //get IDs from inserted data
                        domainID = di.insertWebsiteDomain(domain);
                        usernameID = di.insertWebsiteUsername(username);
                        passwordID = di.insertWebsitePassword(password);
                        categoryID = Convert.ToInt32(cbCategory.SelectedIndex);

                        lblError.Visible = true;

                        //insert into entry table
                        lblError.Text = di.insertEntry(userID, domainID, usernameID, passwordID, categoryID).ToString();

                        //reset form
                        tbWebsiteDomain.Text = null;
                        tbWebsitePassword.Text = null;
                        tbWebsiteUsername.Text = null;
                        cbCategory.SelectedIndex = 0;

                    }
                }
            }
                
            




        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            tbWebsitePassword.Text = GenerateToken(50) + "-" + GenerateToken(50) + "-" + GenerateToken(50);
        }




        //generates a random string consisting of 5 characters
        public string GenerateToken(int length)
        {
            RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider();
            byte[] tokenBuffer = new byte[length];
            cryptRNG.GetBytes(tokenBuffer);
            string randomString =  Convert.ToBase64String(tokenBuffer);

            char[] characters = randomString.ToCharArray();
            List<char> finalChars = new List<char>();
            string password = "";
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                
                int index = rand.Next(0, characters.Length);
                

                finalChars.Add(characters[index]);
            }
            
            for(int i = 0; i<finalChars.Count; i++)
            {
                password += finalChars[i];
            }
            return password;

        }
    }
}
