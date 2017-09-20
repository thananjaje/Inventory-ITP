using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EwingInventory
{
    public partial class Homepage : Form
    {
        public string currentUser = string.Empty;
        public string connString = "datasource=localhost; port=3306; initial Catalog='inventory'; username=root; password=;convert zero datetime=True";

        public Homepage()
        {
            InitializeComponent();
        }
        public Homepage(string u)
        {
            InitializeComponent();
            currentUser = u;
        }


        private void Homepage_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            TopMost = false;
            groupBox1.Width = Screen.FromControl(this).WorkingArea.Width + 10;
            this.Text = currentUser + " Logged in at "+ DateTime.Now.ToString("hh:mm:ss tt");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var opt = MessageBox.Show("Are you sure you want to logoff?\nAll open forms will be closed", "Confirm Logoff", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (opt == DialogResult.OK)
            {
                //Collect all open forms
                List<Form> openforms = new List<Form>();
                foreach (Form f in Application.OpenForms)
                    openforms.Add(f);

                //close all open forms
                foreach (Form f in openforms)
                    if (f.Name != "frm_login")
                        f.Close();
                
                //Open login form
                frm_login login = new frm_login();
                login.Show();
            }
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            bool b = false;
            
            foreach (Form f in Application.OpenForms)
                if (f.Name == "frm_users")
                    b = true;
            if (!b)
            {
                frm_users userform = new frm_users(currentUser);
                userform.TopLevel = false;
                this.Controls.Add(userform);
                userform.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool b = false;

            foreach (Form f in Application.OpenForms)
                if (f.Name == "form_ManufactMgt")
                    b = true;
            if (!b)
            {
                form_ManufactMgt manufactform = new form_ManufactMgt(currentUser);
                manufactform.TopLevel = false;
                this.Controls.Add(manufactform);
                manufactform.Show();
            }
        }

    }
}
