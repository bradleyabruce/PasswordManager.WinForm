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
        #region Variables

        string userID = Program.MyStaticValues.userID.ToString();
        dataRetrieval dataRetrieval = new dataRetrieval();
        dataDelete dd = new dataDelete();
        dataUpdate du = new dataUpdate();
        generatePassword gp = new generatePassword();
        int hideCounter = 1;
        int favoriteCounter = 1;

        //this variable will determine whether the user is making a selection, or text is changing programatically
        bool userTextChange = true;

        #endregion

        #region Methods

        public async void RefreshDataGrid(string userID, string categoryID)
        {
            Task<List<PasswordObject>> entriesAsync = dataRetrieval.getEntries(userID, categoryID);

            //show loading icon...

            List<PasswordObject> entries = await entriesAsync;

            if (entries[0].Status == "No Results")
            {
                pnlResults.Enabled = false;
                MessageBox.Show("No Results");
            }

            //if there are results
            else
            {
                if (entries[0].Status == "Failure")
                {
                    comboCategorySort.Enabled = false;
                    pnlResults.Enabled = false;
                    MessageBox.Show("Unable to retrieve results");
                }

                //if there are no failures
                else
                {
                    dataGridEntries.Columns.Add("EntryID", "EntryID");
                    dataGridEntries.Columns.Add("Website", "Website");
                    dataGridEntries.Columns.Add("Username", "Username");
                    dataGridEntries.Columns.Add("Password", "Password");
                    dataGridEntries.Columns.Add("CategoryID", "CategoryID");
                    dataGridEntries.Columns[0].Visible = false;
                    dataGridEntries.Columns[3].Visible = false;
                    dataGridEntries.Columns[4].Visible = false;

                    foreach (PasswordObject passwordObject in entries)
                    {
                        string[] rows = new string[] { passwordObject.EntryID, passwordObject.WebsiteDomain, passwordObject.WebsiteUsername, passwordObject.WebsitePassword, passwordObject.CategoryID };
                        dataGridEntries.Rows.Add(rows);
                    }
                }
            }
        }

        public bool RefreshResultsPanel()
        {
            try
            {
                DataGridViewRow currentRow = dataGridEntries.SelectedRows[0];
                comboCategoryResult.DataSource = dataRetrieval.getCategories();

                string currentUsername = currentRow.Cells[2].Value.ToString();
                string currentPassword = currentRow.Cells[3].Value.ToString();
                string currentCategoryID = currentRow.Cells[4].Value.ToString();
                tbResultPassword.Text = currentPassword;
                tbResultUsername.Text = currentUsername;
                comboCategoryResult.SelectedIndex = int.Parse(currentCategoryID);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region Constructors

        //when the form is loaded, check status and load categories and entries
        public frmPasswordRetrieval()
        {
            InitializeComponent();
        }

        private async void FrmPasswordRetrieval_Load(object sender, EventArgs e)
        {
            userTextChange = false;

            //load categories
            comboCategorySort.DataSource = dataRetrieval.getCategories();

            RefreshDataGrid(userID, comboCategorySort.SelectedIndex.ToString());

            RefreshResultsPanel();

            userTextChange = true;
        }

        #endregion

        #region Events


        public void ComboCategorySort_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridEntries.Rows.Clear();
            dataGridEntries.Columns.Clear();

            //get ID of option selected and reload list from ID
            string index = comboCategorySort.SelectedIndex.ToString();

            RefreshDataGrid(userID, index);
            RefreshResultsPanel();
        }

        private void DataGridEntries_SelectionChanged(object sender, EventArgs e)
        {
            RefreshResultsPanel();
        }
                                 
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
            dataGridEntries.DataSource = dataRetrieval.getEntries(index).Tables[0];
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

                tbResultPassword.Text = dataRetrieval.getWebsitePassword(entryID);
                tbResultUsername.Text = websiteUsername;
                comboCategoryResult.SelectedIndex = dataRetrieval.getEntryCategory(entryID);
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
            dataGridEntries.DataSource = dataRetrieval.getEntries(categoryIndex).Tables[0];
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
            tbResultPassword.Text = dataRetrieval.getWebsitePassword(entryID);
            tbResultUsername.Text = websiteUsername;
            comboCategoryResult.SelectedIndex = dataRetrieval.getEntryCategory(entryID);

            pbUsernameSave.Visible = false;
            pbPasswordSave.Visible = false;
            pbCategorySave.Visible = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
        }

        //when favorite button is clicked
        private void BtnFavorite_Click(object sender, EventArgs e)
        {
            /*
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

            MessageBox.Show("Coming Soon");
            */
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

        #endregion
    }
}
