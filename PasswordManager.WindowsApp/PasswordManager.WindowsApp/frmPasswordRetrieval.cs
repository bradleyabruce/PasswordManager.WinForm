using PasswordManager.WindowsApp.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        int favoriteCounter = 1;
        bool comboCategoryChange = false;

        //this variable will determine whether the user is making a selection, or text is changing programatically
        bool userTextChange = true;


        //when the form is loaded, check status and load categories and entries
        public frmPasswordRetrieval()
        {
            InitializeComponent();
        }




        private void FrmPasswordRetrieval_Load(object sender, EventArgs e)
        {

            userTextChange = false;

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


            //set datagrid for all values
            dataGridEntries.DataSource = dr.getEntries(0).Tables[0];
            dataGridEntries.Refresh();

            //hide ID column
            dataGridEntries.Columns[2].Visible = false;
            dataGridEntries.EnableHeadersVisualStyles = false;

            //load categories
            comboCategorySort.DataSource = dr.getCategories();


            //if there are no results, disable user options until they add more

            if (dataGridEntries.Rows.Count == 0)
            {
                pnlResults.Enabled = false;
            }
            else
            {
                //load result categories
                comboCategoryResult.DataSource = dr.getCategories();
                List<string> reloadValues = new List<string>();

                for (int j = 0; j < dataGridEntries.Rows[0].Cells.Count; j++)
                {
                    reloadValues.Add(dataGridEntries.SelectedRows[0].Cells[j].Value.ToString());
                }

                string entryID = reloadValues[2];
                string websiteUsername = reloadValues[1];

                tbResultPassword.Text = dr.getWebsitePassword(entryID);
                tbResultUsername.Text = websiteUsername;
                comboCategoryResult.SelectedIndex = dr.getEntryCategory(entryID);

            }

            userTextChange = true;

        }




        //when sort combo box is selected, query the database with that selected option
        public void ComboCategorySort_SelectedIndexChanged(object sender, EventArgs e)
        {

            //on first combo select (on page load) do nothing
            if (comboCategoryChange == false)
            {
                //do nothing
            }
            else
            {
                //get ID of option selected and reload list from ID
                int index = comboCategorySort.SelectedIndex;

                //load data based on selection of category
                dataGridEntries.DataSource = dr.getEntries(index).Tables[0];
                dataGridEntries.Refresh();

            }
            comboCategoryChange = true;
        }






        //update results when the user selects an entry
        private void DataGridEntries_SelectionChanged(object sender, EventArgs e)
        {

            if (userTextChange == false)
            {
                //do nothing if the program changes selection
            }

            //if the user makes a selection..
            else
            {
                //get website and WebsiteUsernameID
                string websiteDomain = "";
                string websiteUsername = "";
                string entryID = "";

                List<string> cellValues = new List<string>();


                //if there are no selected row (in the case of a delete event), reload the first entry
                if (dataGridEntries.SelectedRows.Count == 0)
                {
                    //do nothing as the selected row changed event will fire again when the new row is selected after the delete
                }
                //if there are selected rows, display data from that row
                else
                {

                    for (int i = 0; i < dataGridEntries.SelectedRows.Count; i++)
                    {

                        for (int j = 0; j < dataGridEntries.SelectedRows[i].Cells.Count; j++)
                        {
                            cellValues.Add(dataGridEntries.SelectedRows[i].Cells[j].Value.ToString());
                        }

                    }

                    websiteDomain = cellValues[0];
                    websiteUsername = cellValues[1];
                    entryID = cellValues[2];

                    //pass those values to retrieve username and password
                    string userID = Program.MyStaticValues.userID.ToString();

                    //set username and password text boxes
                    tbResultPassword.Text = dr.getWebsitePassword(entryID);
                    tbResultUsername.Text = websiteUsername;

                    //set current category combo box
                    comboCategoryResult.DataSource = dr.getCategories();
                    comboCategoryResult.SelectedIndex = dr.getEntryCategory(entryID);

                }
                
                //clean up of UI
                pbUsernameSave.Visible = false;
                pbPasswordSave.Visible = false;
                pbCategorySave.Visible = false;

                userTextChange = true;
                
            }
        }


    




        //when the copy button is click, copy result to clipboard
        private void BtnCopyEmail_Click(object sender, EventArgs e)
        {
            if (tbResultUsername.Text == "" || tbResultUsername.Text == null)
            {
                //if value is blank do nothing
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
                //if value is blank do nothing
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
            string websiteUsername = "";

            List<string> cellValues = new List<string>();
            List<string> reloadValues = new List<string>();

            //loop through all selected rows
            for (int i = 0; i < dataGridEntries.SelectedRows.Count; i++)
            {

                for (int j = 0; j < dataGridEntries.SelectedRows[i].Cells.Count; j++)
                {
                    cellValues.Add(dataGridEntries.SelectedRows[i].Cells[j].Value.ToString());
                }

            }

            //delete from database
            entryID = cellValues[2];
            dd.deleteEntry(entryID);

            //reload list
            int index = comboCategorySort.SelectedIndex;
            dataGridEntries.DataSource = dr.getEntries(index).Tables[0];
            dataGridEntries.Refresh();
            

            //if list is now empty, disable forms
            if (dataGridEntries.Rows.Count == 0)
            {
                pnlResults.Enabled = false;
                tbResultPassword.Text = "";
                tbResultUsername.Text = "";
                comboCategoryResult.DataSource = null;
                //userTextChange = false;
            }
            //if list is not empty, load the result of the first entry
            else
            {
                 
                //get values of first in list
                 for (int j = 0; j < dataGridEntries.Rows[0].Cells.Count; j++)
                 {
                        reloadValues.Add(dataGridEntries.SelectedRows[0].Cells[j].Value.ToString());
                 }      

                 //get data from entry and set it to form
                 entryID = reloadValues[2];
                 websiteUsername = reloadValues[1];

                 tbResultPassword.Text = dr.getWebsitePassword(entryID);
                 tbResultUsername.Text = websiteUsername;
                 comboCategoryResult.SelectedIndex = dr.getEntryCategory(entryID);
            }

            //hide text changed icons
            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;

        }




        //when the update button is pressed
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //get values of current entry from database
            string entryID = "";

            string databasePassword = "";
            string databaseUsername = "";
            string databaseCategoryID = "";

            string databasePasswordID = "";
            string databaseUsernameID = "";

            //get current values from user input
            string currentPassword = tbResultPassword.Text;
            string currentUsername = tbResultUsername.Text;
            string currentCategoryID = comboCategoryResult.SelectedIndex.ToString();

            //get entryID from database
            List<string> cellValues = new List<string>();

            //loop through all selected rows
            for (int i = 0; i < dataGridEntries.SelectedRows.Count; i++)
            {

                for (int j = 0; j < dataGridEntries.SelectedRows[i].Cells.Count; j++)
                {
                    cellValues.Add(dataGridEntries.SelectedRows[i].Cells[j].Value.ToString());
                }

            }

            entryID = cellValues[2];

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

            //if passwords are different update database
            if (databasePassword != currentPassword)
            {
                du.updatePassword(databasePasswordID, currentPassword);
            }

            //if usernames are different update database
            if (databaseUsername != currentUsername)
            {
                du.updateUsername(databaseUsernameID, currentUsername);
            }

            //if categoryIDs are different update database
            if (databaseCategoryID != currentCategoryID)
            {
                du.updateCategoryID(entryID, currentCategoryID);
            }

            //get index of currently selected entry
            int entryIndex = dataGridEntries.SelectedRows[0].Index;

            //reload datasource
            userTextChange = false;
            int categoryIndex = comboCategorySort.SelectedIndex;
            dataGridEntries.DataSource = dr.getEntries(categoryIndex).Tables[0];
            dataGridEntries.Refresh();


            //set selected item the same as before
            //lbWebsiteList.SelectedIndex = entryIndex;
            dataGridEntries.Rows[entryIndex].Selected = true;

            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;

            userTextChange = true;
        }





        //when user makes changes to text boxes text and combo box selection
        private void TbResultUsername_TextChanged(object sender, EventArgs e)
        {

            if (userTextChange == true)
            {
                pbUsernameSave.Visible = true;
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
            }
            
        }



        //let user know that changes have not been saved yet
        private void TbResultPassword_TextChanged(object sender, EventArgs e)
        {
            if (userTextChange == true)
            {
                pbPasswordSave.Visible = true;
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
            }
        }




        //let user know that changes have not been saved yet
        private void ComboCategoryResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userTextChange == true)
            {
                pbCategorySave.Visible = true;
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
            }
        }




        //generate new random password for user
        private void btnGeneratePassword_Click(object sender, EventArgs e)
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

            List<string> cellValues = new List<string>();

            //loop through all selected rows
            for (int i = 0; i < dataGridEntries.SelectedRows.Count; i++)
            {

                for (int j = 0; j < dataGridEntries.SelectedRows[i].Cells.Count; j++)
                {
                    cellValues.Add(dataGridEntries.SelectedRows[i].Cells[j].Value.ToString());
                }

            }

            websiteDomain = cellValues[0];
            websiteUsername = cellValues[1];
            entryID = cellValues[2];

            //pass those values to retrieve username and password
            string userID = Program.MyStaticValues.userID.ToString();

            //set username and password text boxes
            tbResultPassword.Text = dr.getWebsitePassword(entryID);
            tbResultUsername.Text = websiteUsername;
            comboCategoryResult.SelectedIndex = dr.getEntryCategory(entryID);

            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
        }
 




        //when favorite button is clicked
        private void BtnFavorite_Click(object sender, EventArgs e)
        {

            //increase hide counter every time the button is pressed
            favoriteCounter++;

            if (favoriteCounter % 2 == 0)
            {
                //set image
                String path = "..\\..\\Resources\\starFilled.png";
                btnFavorite.Image = Image.FromFile(path);
            }
            else
            {
                //set image
                String path = "..\\..\\Resources\\star.png";
                btnFavorite.Image = Image.FromFile(path);
            }

        }


        //launch settings pane
        private void BtnSettings_Click(object sender, EventArgs e)
        {

            //create new form to open
            frmSettings newForm = new frmSettings();
            newForm.Show();
            newForm.Location = this.Location;

            //close login form
            this.Close();

        }
    }//end class
}//end namespace
