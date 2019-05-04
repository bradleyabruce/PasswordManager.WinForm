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
    }
}
