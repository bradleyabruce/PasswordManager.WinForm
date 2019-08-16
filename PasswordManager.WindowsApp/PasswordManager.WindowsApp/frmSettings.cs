using PasswordManager.WindowsApp.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        DataUtilities dataUtility = new DataUtilities();

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
         string connString = dataUtility.getConnectionString();
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
         for (int i = 0; i < entriesToDelete.Count; i++)
         {
            dd.deleteEntry(entriesToDelete[i]);
         }

         //reload count label
         lblPasswordCount.Text = ds.getEntriesToDelete(Program.MyStaticValues.userID.ToString()).Count().ToString();

      }







      //when export button is pressed
      private void BtnExport_Click(object sender, EventArgs e)
      {

         //allow user to select folder to put file to
         using (var fbd = new FolderBrowserDialog())
         {
            DialogResult result = fbd.ShowDialog();

            //after selection export the data
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                    /*
               //set path of file
               string path = fbd.SelectedPath + "\\Passwords.csv";

               try
               {

                  if (File.Exists(path))
                  {
                     //
                  }


                  //write to file values from database
                  using (FileStream fs = File.Create(path))
                  {
                     Byte[] info = new UTF8Encoding(true).GetBytes(de.getCSVData(Program.MyStaticValues.userID.ToString()));
                     // Add some information to the file.
                     fs.Write(info, 0, info.Length);
                  }
               }
               catch (Exception ex)
               {
                  lblAppVersion.Text = ex.ToString();
               }

               MessageBox.Show("Export Successful!");
               */
            }
         }
      }




      //when import button is pressed
      private void BtnImport_Click(object sender, EventArgs e)
      {

         //show the user a prompt to allow the user to select a file
         using (var ofd = new OpenFileDialog())
         {

            ofd.Filter = "CSV files (*.csv)|*.csv";
            DialogResult result = ofd.ShowDialog();


            //when the file is selected import the file
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
            {

               int rowCounter = 1;
               int importCounter = 0;

               string WebsiteDomain = "";
               string WebsiteUsername = "";
               string WebsitePassword = "";

               int WebsiteDomainID = 0;
               int WebsiteUsernameID = 0;
               int WebsitePasswordID = 0;

               //get path
               string path = ofd.FileName;

               try
               {
                  //loop through file from path and add them to database
                  using (StreamReader sr = File.OpenText(path))
                  {
                     string line = "";

                     while ((line = sr.ReadLine()) != null)
                     {

                        if (rowCounter == 1)
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

                              //get base domain
                              string url = WebsiteDomain;

                              string pattern = @"([\da-z\.-]+)\.([a-z\.]{2,8})";

                              Regex regex = new Regex(pattern);
                              MatchCollection results = regex.Matches(url);

                              if (results.Count == 0)
                              {
                                 //do nothing
                              }
                              else
                              {
                                 
                                 WebsiteDomain = results[0].Value;
                              }



                              WebsiteDomainID = da.insertWebsiteDomain(WebsiteDomain);
                              WebsiteUsernameID = da.insertWebsiteUsername(WebsiteUsername);
                              WebsitePasswordID = da.insertWebsitePassword(WebsitePassword);

                              //insert entry
                              da.insertEntry(Program.MyStaticValues.userID, WebsiteDomainID, WebsiteUsernameID, WebsitePasswordID, 0);


                           }

                           importCounter++;

                        }

                        rowCounter++;

                     }


                     if (importCounter == 0)
                     {
                        MessageBox.Show("No passwords imported");
                     }
                     else if (importCounter == 1)
                     {
                        MessageBox.Show(importCounter + " password imported");
                     }
                     else
                     {
                        MessageBox.Show(importCounter + " passwords imported");
                     }

                     //refresh password count label
                     lblPasswordCount.Text = ds.getEntriesToDelete(Program.MyStaticValues.userID.ToString()).Count().ToString();

                  }
               }

               catch (Exception ex)
               {
                  lblAppVersion.Text = ex.ToString();
               }



            }
         }

      }




      private void BtnChangePassword_Click(object sender, EventArgs e)
      {
         MessageBox.Show("Coming Soon");
      }

      private void BtnDeleteAccount_Click(object sender, EventArgs e)
      {
         MessageBox.Show("Coming Soon");
      }
   }
}
