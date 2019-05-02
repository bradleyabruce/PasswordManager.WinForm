﻿using PasswordManager.WindowsApp.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.WindowsApp
{
    public partial class frmPasswordRetrieval : Form
    {

        dataLogin dl = new dataLogin();
        dataRetrieval dr = new dataRetrieval();
        dataDelete dd = new dataDelete();
        dataUpdate du = new dataUpdate();
        generatePassword gp = new generatePassword();

        int hideCounter = 1;

        //when the form is loaded, check status and load categories and entries
        public frmPasswordRetrieval()
        {

            InitializeComponent();

            //check database status
            if (dl.databaseCheck() == true)
            {
                String path = "..\\..\\Resources\\Connected.png";
                pbStatus.Image = Image.FromFile(path);
                ttRetrieve.SetToolTip(pbStatus, "You are connected!");

            }
            else
            {
                String path = "..\\..\\Resources\\notConnected.png";
                pbStatus.Image = Image.FromFile(path);
                ttRetrieve.SetToolTip(pbStatus, "You are not connected!");

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

            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;

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
            comboCategoryResult.DataSource = dr.getCategories();
            comboCategoryResult.SelectedIndex = dr.getEntryCategory(entryID);

            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
        }



        //when the copy button is click, copy result to clipboard
        private void BtnCopyEmail_Click(object sender, EventArgs e)
        {
            if (tbResultUsername.Text == "" || tbResultUsername.Text == null)
            {

            }
            else
            {
                Clipboard.SetText(tbResultUsername.Text);
            }
        }


        //when the copy button is click, copy result to clipboard
        private void BtnCopyPassword_Click(object sender, EventArgs e)
        {
            if (tbResultPassword.Text == "" || tbResultPassword.Text == null)
            {

            }
            else
            {
                Clipboard.SetText(tbResultPassword.Text);
            }
            
        }


        //when add button is pressed, open the add form
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            //create new form to open
            frmPasswordInsert newForm = new frmPasswordInsert();
            newForm.Show();
            newForm.Location = this.Location;

            //close login form
            this.Close();
        }

        //when the delete button is pressed
        private void BtnDelete_Click(object sender, EventArgs e)
        {

            //get entry ID from selected text box

            string entryID = "";

            //get listbox entry data
            String selectedEntry = lbWebsiteList.SelectedItem.ToString();

            //split string to get entry ID
            List<String> websiteArray = selectedEntry.Split(',').ToList<string>();

            entryID = websiteArray[2].Substring(1);


            dd.deleteEntry(entryID);

            int index = comboCategorySort.SelectedIndex;
            lbWebsiteList.DataSource = dr.getEntries(index);


            if(lbWebsiteList.Items.Count == 0)
            {
                pnlList.Enabled = false;
                pnlResults.Enabled = false;
                tbResultPassword.Text = "";
                tbResultUsername.Text = "";
                comboCategoryResult.DataSource = null;
                pbUsernameSave.Visible = false;
                pbPasswordSave.Visible = false;
                pbCategorySave.Visible = false;
                
            }


        }


        //when the update button is pressed
        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            string entryID = "";

            string databasePassword = "";
            string databaseUsername = "";
            string databaseCategoryID = "";

            string databasePasswordID = "";
            string databaseUsernameID = "";

            //get current values
            string currentPassword = tbResultPassword.Text;
            string currentUsername = tbResultUsername.Text;
            string currentCategoryID = comboCategoryResult.SelectedIndex.ToString();



            //get listbox entry data
            String selectedEntry = lbWebsiteList.SelectedItem.ToString();

            //split string to get entry ID
            List<String> websiteArray = selectedEntry.Split(',').ToList<string>();

            entryID = websiteArray[2].Substring(1);


            //compare existing values in database with values from app to see what needs to be changed
            List<string> valuesToDelete = du.getValuesToUpdate(entryID);
            for (int i = 0; i < valuesToDelete.Count; i++)
            {
                if (i == 0)
                {
                    databasePassword = valuesToDelete.ElementAt(i);
                }
                if (i == 1)
                {
                    databaseUsername = valuesToDelete.ElementAt(i);
                }
                if (i == 2)
                {
                    databasePasswordID = valuesToDelete.ElementAt(i);
                }
                if (i == 3)
                {
                    databaseUsernameID = valuesToDelete.ElementAt(i);
                }
                if (i == 4)
                {
                    databaseCategoryID = valuesToDelete.ElementAt(i);
                }
            }

            
            //if passwords are different
            if(databasePassword != currentPassword)
            {
                du.updatePassword(databasePasswordID, currentPassword);
            }

                //if usernames are different
            if(databaseUsername != currentUsername)
            {
                du.updateUsername(databaseUsernameID, currentUsername);
            }
            
            //if categoryIDs are different
            if(databaseCategoryID != currentCategoryID)
            {
                du.updateCategoryID(entryID, currentCategoryID);
            }


            //get index of currently selected entry
            int entryIndex = lbWebsiteList.SelectedIndex;

            //reload datasource
            int categoryIndex = comboCategorySort.SelectedIndex;
            lbWebsiteList.DataSource = dr.getEntries(categoryIndex);

            //set selected item the same as before
            lbWebsiteList.SelectedIndex = entryIndex;

            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
        }

        //when user makes changes to text boxes text and combo box selection
        private void TbResultUsername_TextChanged(object sender, EventArgs e)
        {
            pbUsernameSave.Visible = true;
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void TbResultPassword_TextChanged(object sender, EventArgs e)
        {
            pbPasswordSave.Visible = true;
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void ComboCategoryResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbCategorySave.Visible = true;
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }


        //generate new random password for user
        private void Button1_Click(object sender, EventArgs e)
        {
            tbResultPassword.Text = gp.GenerateToken(50) + "-" + gp.GenerateToken(50) + "-" + gp.GenerateToken(50);
        }


        //toggle hiding and showing password
        private void BtnHidePassword_Click(object sender, EventArgs e)
        {
            //increase hide counter every time the button is pressed
            hideCounter++;

            if (hideCounter % 2 == 0)
            {
                //unhide text box, set image
                tbResultPassword.PasswordChar = '\0';
                String path = "..\\..\\Resources\\unhide.png";
                btnHidePassword.Image = Image.FromFile(path);
            }
            else
            {
                //unhide text box, set image
                tbResultPassword.PasswordChar = '*';
                String path = "..\\..\\Resources\\hide.png";
                btnHidePassword.Image = Image.FromFile(path);
            }

        }


        //when cancel button is pressed
        private void BtnCancel_Click(object sender, EventArgs e)
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
            comboCategoryResult.DataSource = dr.getCategories();
            comboCategoryResult.SelectedIndex = dr.getEntryCategory(entryID);

            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;


        }
    }
}
