using PasswordManager.WindowsApp.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.WindowsApp
{
    public partial class frmSettings : Form
    {

        dataSettings ds = new dataSettings();
        dataDelete dd = new dataDelete();
        dataLogin dl = new dataLogin();
        dataExport de = new dataExport();
        dataInsert da = new dataInsert();

        public frmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            //get username
            lblUsername.Text = ds.getUsername(Program.MyStaticValues.userID.ToString());

            //get password count
            lblPasswordCount.Text = ds.getEntriesToDelete(Program.MyStaticValues.userID.ToString()).Count().ToString();

            //get serveraddress
            string connString = dl.getConnectionString();
            string ip = connString.Split(':', ',')[1];
            lblServerAddress.Text = ip;
        }


        //when back button is pressed
        private void BtnBack_Click(object sender, EventArgs e)
        {
            frmPasswordRetrieval newForm = new frmPasswordRetrieval();
            newForm.Show();
            newForm.Location = this.Location;

            //close login form
            this.Close();
        }


        //when the logout button is pressed
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Program.MyStaticValues.userID = 0;

            frmLogin newForm = new frmLogin();
            newForm.Show();
            newForm.Location = this.Location;

            //close login form
            this.Close();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            //get list of entries
            List<string> entriesToDelete = ds.getEntriesToDelete(Program.MyStaticValues.userID.ToString());

            //for every entry call delete entry function
            for(int i = 0; i< entriesToDelete.Count; i++)
            {
                dd.deleteEntry(entriesToDelete[i]);
            }

            //reload count label
            lblPasswordCount.Text = ds.getEntriesToDelete(Program.MyStaticValues.userID.ToString()).Count().ToString();

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    tbExport.Text = fbd.SelectedPath;
                    tbExport.Enabled = true;
                    btnExportGo.Enabled = true;
                    

                }
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {

                ofd.Filter = "CSV files (*.csv)|*.csv";
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    
                    tbImport.Text = ofd.FileName;
                    tbImport.Enabled = true;
                    btnImportGo.Enabled = true;

                }
            }

        }

        private void BtnExportGo_Click(object sender, EventArgs e)
        {
            //set path of file
            string path = tbExport.Text + "\\Passwords.csv";

            try
            {

                if (File.Exists(path))
                {
                    //do nothing
                }

                //write to file values from database
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(de.getCSVData(Program.MyStaticValues.userID.ToString()));
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch(Exception ex)
            {
                lblAppVersion.Text = ex.ToString();
            }

            tbExport.Text = "";
            tbExport.Enabled = false;
            btnExportGo.Enabled = false;
            MessageBox.Show("Export Successful!");
        }








        private void BtnImportGo_Click(object sender, EventArgs e)
        {

            int counter = 1;

            string WebsiteDomain = "";
            string WebsiteUsername = "";
            string WebsitePassword = "";

            int WebsiteDomainID = 0;
            int WebsiteUsernameID = 0;
            int WebsitePasswordID = 0;

            //get path
            string path = tbImport.Text;

            try
            {
                //loop through file from path and add them to database
                using (StreamReader sr = File.OpenText(path))
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        if(counter == 1)
                        {
                            //do nothing for header
                        }
                        // for the rest
                        else
                        {
                            string[] values = line.Split(',');

                            WebsiteDomain = values[0];
                            WebsiteUsername = values[1];
                            WebsitePassword = values[2];

                            if (WebsiteDomain == "" || WebsiteUsername == "" || WebsitePassword == "")
                            {
                                //do not import
                            }

                            else
                            {
                                //insert into database and retrieve IDs
                                WebsiteDomainID = da.insertWebsiteDomain(WebsiteDomain);
                                WebsiteUsernameID = da.insertWebsiteUsername(WebsiteUsername);
                                WebsitePasswordID = da.insertWebsitePassword(WebsitePassword);

                                //insert entry
                                da.insertEntry(Program.MyStaticValues.userID, WebsiteDomainID, WebsiteUsernameID, WebsitePasswordID, 0);

                               
                            }

                        }

                        counter++;

                    }

                    tbImport.Enabled = false;
                    tbImport.Text = "";
                    btnImportGo.Enabled = false;
                    MessageBox.Show("Import Success!");

                    //refresh password count label
                    lblPasswordCount.Text = ds.getEntriesToDelete(Program.MyStaticValues.userID.ToString()).Count().ToString();

                }
            }

            catch(Exception ex)
            {
                lblAppVersion.Text = ex.ToString();
            }
        }
    }
}
