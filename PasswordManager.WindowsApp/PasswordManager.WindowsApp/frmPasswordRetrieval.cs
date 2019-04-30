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
    }
}
