﻿using PasswordManager.WindowsApp.DAO;
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


        //when the form is loaded, check status and load categories and entries
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
            //lbWebsiteList.Focus();


            //if there are no results, disable user options until they add more
            if(lbWebsiteList.Items.Count == 0)
            {
                pnlResults.Enabled = false;
                pnlList.Enabled = false;
            }

        }


        //when sort combo box is selected, query the database with that selected option
        public void ComboCategorySort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get ID of option selected and reload list from ID
            int index = comboCategorySort.SelectedIndex;
            lbWebsiteList.DataSource = dr.getEntries(index);
        }



        //when the user selects an entry from the list, load the results panel options
        private void LbWebsiteList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //get website and WebsiteUsernameID
            string websiteDomain = "";
            string websiteUsername = "";
            string entryID = "";

            //get input from textbox
            String selectedEntry = lbWebsiteList.SelectedItem.ToString();

            //split string
            List<String> websiteArray = selectedEntry.Split(',').ToList<string>();

            websiteDomain = websiteArray[0];
            websiteUsername = websiteArray[1].Substring(1);
            entryID = websiteArray[2].Substring(1);

            //pass those values to retrieve username and password
            string userID = Program.MyStaticValues.userID.ToString();

            //set username and password text boxes
            tbResultPassword.Text = dr.getWebsitePassword(entryID);
            tbResultUsername.Text = websiteUsername;

            //set current category combo box
            comboCategoryResult.DataSource = comboCategorySort;
            comboCategoryResult.SelectedIndex = dr.getEntryCategory(entryID);

        }



        //when the password checkbox is changed hide or unhide the password
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


        //when the copy button is click, copy result to clipboard
        private void BtnCopyEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbResultUsername.Text);
        }


        //when the copy button is click, copy result to clipboard
        private void BtnCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbResultPassword.Text);
        }


        //when add button is pressed, open the add form
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            //create new form to open
            frmPasswordInsert newForm = new frmPasswordInsert();
            newForm.Show();

            //close login form
            this.Close();
        }
    }
}