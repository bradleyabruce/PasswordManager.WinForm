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
    public partial class frmSettings : Form
    {

        dataSettings ds = new dataSettings();
        dataDelete dd = new dataDelete();

        public frmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {

            lblUsername.Text = ds.getUsername(Program.MyStaticValues.userID.ToString());
            lblPasswordCount.Text = ds.getEntriesToDelete(Program.MyStaticValues.userID.ToString()).Count().ToString();
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
    }
}
