using PasswordManager.WindowsApp.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.WindowsApp
{
    public partial class frmPasswordRetrieval : Form
    {
        #region Variables

        string userID = Program.MyStaticValues.userID.ToString();
        int DataGridIndex = 0;
        dataRetrieval dataRetrieval = new dataRetrieval();
        dataDelete dd = new dataDelete();
        dataUpdate du = new dataUpdate();
        generatePassword gp = new generatePassword();
        int hideCounter = 1;
        int favoriteCounter = 1;

        //this variable will determine whether the user is making a selection, or text is changing programatically
        bool userTextChange = false;

        #endregion

        #region Methods

        public async void RefreshDataGrid(string userID, string categoryID)
        {
            Task<List<PasswordObject>> entriesAsync = dataRetrieval.getEntries(userID, categoryID);

            //show loading icon...
            pnlList.Enabled = false;
            progressBar.Visible = true;
            progressBar.MarqueeAnimationSpeed = 10;

            List<PasswordObject> entries = await entriesAsync;

            if (entries[0].Status == "No Results")
            {
                pnlResults.Enabled = false;
                lblNoResults.Text = "No Results";
                lblNoResults.Visible = true;
                lblNoResults.ForeColor = Color.Red;
            }

            //if there are results
            else
            {
                if (entries[0].Status == "Failure")
                {
                    comboCategorySort.Enabled = false;
                    pnlResults.Enabled = false;
                    lblNoResults.Text = "Unable to Retrieve Entries";
                    lblNoResults.Visible = true;
                    lblNoResults.ForeColor = Color.Red;
                }

                //if there are no failures
                else
                {
                    pnlResults.Enabled = true;
                    comboCategorySort.Enabled = true;
                    lblNoResults.Visible = false;

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

                    //sort columns
                    DataGridViewColumn sortColumn = dataGridEntries.Columns[1];
                    dataGridEntries.Sort(sortColumn, ListSortDirection.Ascending);

                    //set selected row (will be different during deletes)
                    try
                    {
                        dataGridEntries.Rows[DataGridIndex - 1].Selected = true;
                    }
                    catch (Exception e)
                    {
                        dataGridEntries.Rows[0].Selected = true;
                    }

                    DataGridIndex = 0;
                }
            }

            //hiding loading icon
            pnlList.Enabled = true;
            progressBar.Visible = false;
        }

        public bool RefreshResultsPanel()
        {
            try
            {
                DataGridViewRow currentRow = dataGridEntries.SelectedRows[0];

                string currentUsername = currentRow.Cells[2].Value.ToString();
                string currentPassword = currentRow.Cells[3].Value.ToString();
                string currentCategoryID = currentRow.Cells[4].Value.ToString();
                tbResultPassword.Text = currentPassword;
                tbResultUsername.Text = currentUsername;
                comboCategoryResult.SelectedIndex = int.Parse(currentCategoryID);

                btnUpdate.Enabled = false;
                btnCancel.Enabled = false;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async void LoadCategories()
        {
            try
            {
                comboCategorySort.Items.Clear();
                comboCategoryResult.Items.Clear();

                Task<List<CategoryObject>> categoriesAsync = dataRetrieval.getCategories(userID);

                //loading bar...

                List<CategoryObject> categories = await categoriesAsync;

                if (categories.Count > 0)
                {
                    foreach (CategoryObject category in categories)
                    {
                        comboCategorySort.Items.Add(category.CategoryName);
                        comboCategoryResult.Items.Add(category.CategoryName);
                    }
                }
            }
            catch(Exception e)
            {
                comboCategorySort.Items.Clear();
                comboCategoryResult.Items.Clear();
            }
        }

        #endregion

        #region Constructors

        public frmPasswordRetrieval()
        {
            InitializeComponent();
        }

        private void FrmPasswordRetrieval_Load(object sender, EventArgs e)
        {
            LoadCategories();
            RefreshDataGrid(userID, "0");
            RefreshResultsPanel();
            userTextChange = true;

        }

        #endregion

        #region Events

        public void ComboCategorySort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userTextChange == true)
            {
                dataGridEntries.Rows.Clear();
                dataGridEntries.Columns.Clear();

                //get ID of option selected and reload list from ID
                string index = comboCategorySort.SelectedIndex.ToString();

                RefreshDataGrid(userID, index);
                RefreshResultsPanel();
            }
            else
            {
                //do nothing
            }
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //get selected data
            DataGridViewRow currentRow = dataGridEntries.SelectedRows[0];
            string currentEntryID = currentRow.Cells[0].Value.ToString();

            int currentIndex = dataGridEntries.Rows.IndexOf(currentRow);
            string currentCategoryID = comboCategorySort.SelectedIndex.ToString();
            DataGridIndex = currentIndex;

            dd.deleteEntry(currentEntryID);

            //reload list
            dataGridEntries.Rows.Clear();
            dataGridEntries.Columns.Clear();

            RefreshDataGrid(userID, currentCategoryID);
            RefreshResultsPanel();
        }

        //needs modification
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //get current values
            DataGridViewRow currentRow = dataGridEntries.SelectedRows[0];
            string currentEntryID = currentRow.Cells[0].Value.ToString();
            string currentUsername = currentRow.Cells[2].Value.ToString();
            string currentPassword = currentRow.Cells[3].Value.ToString();
            string currentCategoryID = currentRow.Cells[4].Value.ToString();

            //get current values from user input
            string newPassword = tbResultPassword.Text;
            string newUsername = tbResultUsername.Text;
            string newCategoryID = comboCategoryResult.SelectedIndex.ToString();

            //dont compare with existing, just push all new data

            //reload datasource
                       
            //set selected item the same as before

        }

        private void TbResult_TextChanged(object sender, EventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender as TextBox;
            string senderName = currentTextBox.Name;
            bool usernameChange = false;
            bool passwordChange = false;

            DataGridViewRow currentRow = dataGridEntries.SelectedRows[0];
            string currentUserName = currentRow.Cells[2].Value.ToString();
            string currentPassword = currentRow.Cells[3].Value.ToString();

            if (senderName == "tbResultUsername")
            {
                if (currentTextBox.Text != currentUserName)
                {
                    usernameChange = true;
                }
                else
                {
                    usernameChange = false;
                }
            }

            if (senderName == "tbResultPassword")
            {
                if (currentTextBox.Text != currentPassword)
                {
                    passwordChange = true;
                }
                else
                {
                    passwordChange = false;
                }
            }

            if (usernameChange == true) pbUsernameSave.Visible = true;
            else pbUsernameSave.Visible = false;

            if (passwordChange == true) pbPasswordSave.Visible = true;
            else pbPasswordSave.Visible = false;

            if (usernameChange == true || passwordChange == true || pbCategorySave.Visible == true)
            {
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void ComboCategoryResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridEntries.SelectedRows[0];
            string currentCategoryID = currentRow.Cells[4].Value.ToString();

            string newCategoryID = comboCategoryResult.SelectedIndex.ToString();
            bool categoryChange = false;

            if (currentCategoryID != newCategoryID)
            {
                categoryChange = true;
            }
            else
            {
                categoryChange = false;
            }

            if (categoryChange == true) pbCategorySave.Visible = true;
            else pbCategorySave.Visible = false;

            if (categoryChange == true || pbUsernameSave.Visible == true || pbPasswordSave.Visible == true)
            {
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

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
            DataGridViewRow currentRow = dataGridEntries.SelectedRows[0];
            string currentUserName = currentRow.Cells[2].Value.ToString();
            string currentPassword = currentRow.Cells[3].Value.ToString();
            string currentCategoryID = currentRow.Cells[4].Value.ToString();

            tbResultUsername.Text = currentUserName;
            tbResultPassword.Text = currentPassword;
            comboCategoryResult.SelectedIndex = int.Parse(currentCategoryID);

            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void BtnFavorite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
        }

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
