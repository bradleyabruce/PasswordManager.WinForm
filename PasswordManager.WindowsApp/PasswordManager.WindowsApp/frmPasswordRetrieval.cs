using PasswordManager.WindowsApp.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.WindowsApp
{
    public partial class frmPasswordRetrieval : Form
    {

        dataLogin dl = new dataLogin();
        dataRetrieval dr = new dataRetrieval();


        public frmPasswordRetrieval()
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


            //load categories
            comboCategorySort.DataSource = dr.getCategories();

            //load entries 
            lbWebsiteList.DataSource = dr.getEntries(0);


        }


        public void ComboCategorySort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboCategorySort.SelectedIndex;
            lbWebsiteList.DataSource = dr.getEntries(index);
        }


        private void LbWebsiteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get website and WebsiteUsernameID

            string websiteDomain = "";
            string websiteUsernameID = "";

            //get input from textbox
            String selectedWebsite = lbWebsiteList.SelectedItem.ToString();

            //split string
            List<String> websiteArray = selectedWebsite.Split(',').ToList<string>();

            websiteDomain = websiteArray[0];
            websiteUsernameID = websiteArray[1].Substring(1);

            //pass those values to retrieve username and password

            string userID = Program.MyStaticValues.userID.ToString();
            string websiteUserName = dr.getWebsiteUsername(websiteUsernameID);

            tbResultUsername.Text = websiteUserName;
            tbResultPassword.Text = dr.getWebsitePassword(Program.MyStaticValues.userID.ToString(), websiteDomain, websiteUserName);
            
        }

        private void CbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPassword.Checked == true)
            {
                tbResultPassword.PasswordChar = '\0';
            }
            else
            {
                tbResultPassword.PasswordChar = '*';
            }

            
        }

        private void BtnCopyEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbResultUsername.Text);
        }

        private void BtnCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbResultPassword.Text);
        }
    }
}
