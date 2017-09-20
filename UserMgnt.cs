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
using System.IO;

namespace EwingInventory
{
    public partial class frm_users : Form
    {
        public Homepage home = new Homepage();
        public string currentUser = String.Empty;
        public string imagepath = null;
        public frm_users()
        {
            InitializeComponent();
        }

        public frm_users(string u)
        {
            InitializeComponent();
            currentUser = u;
        }

        public void clearFields()
        {
            lbl_id.Text = "-please select staff";
            txt_fName.Text = "";
            txt_lName.Text = "";
            txt_nic.Text = "";
            txt_addr1.Text = "";
            txt_addr2.Text = "";
            txt_email.Text = "";
            txt_mob.Text = "";
            txt_bSal.Text = "";
            pictureBox1.Image = null;
            lbl_age.Text = "--";
        }

        public void disableFields()
        {
            //Disable Fields
            txt_fName.Enabled = false;
            txt_lName.Enabled = false;
            txt_addr1.Enabled = false;
            txt_addr2.Enabled = false;
            datePic.Enabled = false;
            txt_nic.Enabled = false;
            txt_bSal.Enabled = false;
            txt_mob.Enabled = false;
            txt_email.Enabled = false;
            btn_browsImage.Enabled = false;
            btn_save.Enabled = false;
            btn_clear.Enabled = false;
        }

        public void enableFields()
        {
            txt_fName.Enabled = true;
            txt_lName.Enabled = true;
            txt_addr1.Enabled = true;
            txt_addr2.Enabled = true;
            datePic.Enabled = true;
            txt_nic.Enabled = true;
            txt_bSal.Enabled = true;
            txt_mob.Enabled = true;
            txt_email.Enabled = true;
            btn_browsImage.Enabled = true;
            btn_save.Enabled = true;
            btn_clear.Enabled = true;
        }

        private void frm_users_Load(object sender, EventArgs e)
        {
            if (currentUser != "ADMIN")
                tab_user.TabPages.Remove(tabPage1);
            else
                tab_user.TabPages.Remove(tabPage2);
                        
            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w)-this.Width)/2,120);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            LoadToDatagridview(dgvStaff, "SELECT id 'ID',fName 'NAME' FROM `staff` WHERE id > 1");
                       
        }

        private void LoadToDatagridview(DataGridView dgv, string q)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            MySqlCommand cmd = new MySqlCommand(q, conn);

            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                BindingSource bs = new BindingSource();

                bs.DataSource = dt;
                dgv.DataSource = bs;
                da.Update(dt);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!lbl_id.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
            
        }
        
        //Search Staff
        private void txt_serach_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_serach.Text;
            LoadToDatagridview(dgvStaff, "SELECT id,fName FROM staff WHERE fName like '%" + filter + "%'");
        }

       
        private void btn_browsImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files | *.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    //imagepath = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(lbl_id.Text == "-please select staff")
                enableFields();

            string id = dgvStaff.SelectedCells[0].Value.ToString();
            btn_clear.Enabled = true;
            btn_save.Enabled = true;
            btn_browsImage.Enabled = true;

            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM staff WHERE id =" + id + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string year = dr["dob"].ToString().Substring(0, 4);
                    string month = dr["dob"].ToString().Substring(5, 2);
                    string day = dr["dob"].ToString().Substring(8, 2);
                        
                    lbl_id.Text = dr["id"].ToString();
                    lbl_age.Text = (DateTime.Now.Year - Convert.ToInt32(year)).ToString();
                    txt_fName.Text = dr["fName"].ToString();
                    txt_lName.Text = dr["lName"].ToString();
                    txt_nic.Text = dr["nic"].ToString();
                    txt_bSal.Text = dr["bSal"].ToString();
                    txt_addr1.Text = dr["address1"].ToString();
                    txt_addr2.Text = dr["address2"].ToString();
                    txt_mob.Text = dr["mobile"].ToString();
                    txt_email.Text = dr["email"].ToString();
                    datePic.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                    var data = (byte[])dr["image"];
                    var stream = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(stream);
                    //MessageBox.Show(pictureBox1.ImageLocation);
                        
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(home.connString))
            {

                try
                {

                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();


                    //FileStream fs;
                    //BinaryReader br;
                    //byte[] ImageData;

                    //fs = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                    //br = new BinaryReader(fs);
                    //ImageData = br.ReadBytes((int)fs.Length);
                    //br.Close();
                    //fs.Close();

                    string q = null;

                    if (lbl_id.Text != "-please select staff")
                        q = "UPDATE staff SET fName=@fName,lName=@lName,address1=@add1,address2=@add2,email=@email,dob=@dob,mobile=@mob,bSal=@bSal,image=@image WHERE id=@id";
                    else
                        q = "INSERT INTO staff(fname,lname,address1,address2,email,dob,nic,mobile,joined,bSal,image)" +
                            "VALUES(@fName,@lName,@add1,@add2,@email,@dob,@nic,@mob,@joined,@bSal,@image)";
                    
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = lbl_id.Text;
                        cmd.Parameters.Add("@fName", MySqlDbType.VarChar).Value = txt_fName.Text;
                        cmd.Parameters.Add("@lName", MySqlDbType.VarChar).Value = txt_lName.Text;
                        cmd.Parameters.Add("@add1", MySqlDbType.VarChar).Value = txt_addr1.Text;
                        cmd.Parameters.Add("@add2", MySqlDbType.VarChar).Value = txt_addr2.Text;
                        cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = txt_email.Text;
                        cmd.Parameters.Add("@dob", MySqlDbType.Date).Value = datePic.Value;
                        cmd.Parameters.Add("@mob", MySqlDbType.Int32).Value = txt_mob.Text;
                        cmd.Parameters.Add("@joined", MySqlDbType.Date).Value = System.DateTime.Now;
                        cmd.Parameters.Add("@bSal", MySqlDbType.Double).Value = Convert.ToDouble(txt_bSal.Text);
                        cmd.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = img;

                        int rows = 0;

                        try{
                            conn.Open();

                            if (lbl_id.Text == "-please select staff")
                            {
                                cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = txt_nic.Text;
                                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                                DataSet ds = new DataSet();

                                try
                                {
                                    da.Fill(ds).ToString();
                                    MessageBox.Show("Staff Added Successfully");
                                    clearFields();
                                    LoadToDatagridview(dgvStaff, "SELECT id 'ID',fName 'NAME' FROM `staff` WHERE id > 1");
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Details Updated Successfully");
                                    clearFields();
                                    LoadToDatagridview(dgvStaff, "SELECT id 'ID',fName 'NAME' FROM `staff` WHERE id > 1");
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            
                        }catch (Exception exp){
                            MessageBox.Show(exp.Message,"Try Inside");
                        }finally{
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Try 1");
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
