using PasswordManager.WindowsApp.DAO;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PasswordManager.WindowsApp
{
    public partial class frmPasswordInsert : Form
    {

        dataLogin dl = new dataLogin();
        dataRetrieval dr = new dataRetrieval();
        dataInsert di = new dataInsert();
        generatePassword gp = new generatePassword();

        int hideCounter = 1;

        //on page load
        public frmPasswordInsert()
        {
            InitializeComponent();

            //check database status
            if (dl.databaseCheck() == true)
            {
                String path = "..\\..\\Resources\\Connected.png";
                pbStatus.Image = Image.FromFile(path);
                ttInsert.SetToolTip(pbStatus, "You are connected!");

            }
            else
            {
                String path = "..\\..\\Resources\\notConnected.png";
                pbStatus.Image = Image.FromFile(path);
                ttInsert.SetToolTip(pbStatus, "You are not connected!");
                
            }

            cbCategory.DataSource = dr.getCategories();

        }




        //when back button is pressed
        private void BtnBack_Click(object sender, EventArgs e)
        {
            //create new form to open
            frmPasswordRetrieval newForm = new frmPasswordRetrieval();
            newForm.Show();
            newForm.Location = this.Location;

            //close login form
            this.Close();
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //get values from user
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

                        
                        //insert into entry table
                        di.insertEntry(userID, domainID, usernameID, passwordID, categoryID).ToString();

                        //reset form
                        tbWebsiteDomain.Text = null;
                        tbWebsitePassword.Text = null;
                        tbWebsiteUsername.Text = null;
                        cbCategory.SelectedIndex = 0;

                    }
                }
            }
 
        }



        //generate new password
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            tbWebsitePassword.Text = gp.GenerateToken(50) + "-" + gp.GenerateToken(50) + "-" + gp.GenerateToken(50);
        }

        private void BtnPasswordHide_Click(object sender, EventArgs e)
        {

            //increase hide counter every time the button is pressed
            hideCounter++;

            if (hideCounter % 2 == 0)
            {
                //unhide text box, set image
                tbWebsitePassword.PasswordChar = '\0';
                String path = "..\\..\\Resources\\unhide.png";
                btnPasswordHide.Image = Image.FromFile(path);
            }
            else
            {
                //unhide text box, set image
                tbWebsitePassword.PasswordChar = '*';
                String path = "..\\..\\Resources\\hide.png";
                btnPasswordHide.Image = Image.FromFile(path);
            }
        }

        private void BtnCopyUsername_Click(object sender, EventArgs e)
        {
            if (tbWebsiteUsername.Text == "" || tbWebsiteUsername.Text == null)
            {

            }
            else
            {
                Clipboard.SetText(tbWebsiteUsername.Text);
            }
        }

        private void BtnCopyPassword_Click(object sender, EventArgs e)
        {
            if (tbWebsitePassword.Text == "" || tbWebsitePassword.Text == null)
            {

            }
            else
            {
                Clipboard.SetText(tbWebsitePassword.Text);
            }
            
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            tbWebsiteDomain.Text = "";
            tbWebsiteUsername.Text = "";
            tbWebsitePassword.Text = "";
            cbCategory.SelectedIndex = 0;
        }

        private void BtnChangeDomain_Click(object sender, EventArgs e)
        {
           
            string url = tbWebsiteDomain.Text;

            string pattern = @"([\da-z\.-]+)\.([a-z\.]{2,8})";

            Regex regex = new Regex(pattern);
            MatchCollection results = regex.Matches(url);

            if (results.Count == 0)
            {
                //do nothing
            }
            else
            {
                string result = results[0].Value;
                tbWebsiteDomain.Text = result;
            }

        }
    }
}
