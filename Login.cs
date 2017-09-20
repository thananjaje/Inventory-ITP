using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace EwingInventory
{
    public partial class frm_login : Form
    {
        string connString = "Server=localhost;Database=inventory;Uid=root;Password=;";
        public frm_login()
        {
            InitializeComponent();
        }
        private void frm_login_Load(object sender, EventArgs e)
        {
            LoadUser();
            FormBorderStyle = FormBorderStyle.None;
            this.CenterToScreen();
        }
        private void btn_login_MouseHover(object sender, EventArgs e)
        {
            btn_login.BackColor = Color.LightGray;
        }

        private void btn_login_MouseLeave(object sender, EventArgs e)
        {
            btn_login.BackColor = Color.LightBlue;
        }

        private void btn_exit_MouseHover(object sender, EventArgs e)
        {
            btn_exit.BackColor = Color.LightGray;
        }

        private void btn_exit_MouseLeave(object sender, EventArgs e)
        {
            btn_exit.BackColor = Color.LightBlue;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            if (userCombo.SelectedIndex < 0){
                MessageBox.Show("Invalid Username!", "Error");
            }
            else{

                string uname = userCombo.SelectedItem.ToString();
                string password = passField.Text;
                var conn = new MySqlConnection(connString);
                string query = "SELECT password from staff where username ='" + uname + "';";

                try{
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    var read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        if (read.GetString("password") == password)
                        {
                            MessageBox.Show(uname + " logged in successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Homepage home = new Homepage(uname);
                            home.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("username and/or password is incorrect");
                        }
                    }


                }
                catch (Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void LoadUser()
        {
            
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

            string query = "select * from staff";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
            try
            {
                var read = cmd.ExecuteReader();
                while (read.Read())
                    userCombo.Items.Add(read.GetString("username"));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                
            }
            

            
        }

    }

}
