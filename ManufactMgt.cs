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
    public partial class form_ManufactMgt : Form
    {
        public Homepage home = new Homepage();
        private string currentUser;
        
        public form_ManufactMgt()
        {
            InitializeComponent();

        }

        public form_ManufactMgt(string currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; initial Catalog='inventory'; username=root; password=;convert zero datetime=True");

        MySqlCommand command;

        private void Loadtable(DataGridView dgv, string q)
        {
            DataTable dt = new DataTable();
            //MySqlConnection conn = new MySqlConnection(home.connString);
            MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; initial Catalog='inventory'; username=root; password=;convert zero datetime=True");
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

        public void executeMyQuery(string q)
        {
            try
            {
                conn.Open();
                command = new MySqlCommand(q, conn);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Query Executed");
                else
                    MessageBox.Show("Query Not Executed");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ManufactMgt_Load(object sender, EventArgs e)
        {
            if (currentUser != "JAJE")
            {
                //tab_manufact.TabPages.Remove(tabPage1_RawMaterial);
                //tab_manufact.TabPages.Remove(tabPage2_Production);
                //tab_manufact.TabPages.Remove(tabPage3_JobSchedule);
            }
            //else
            //    tab_manufact.TabPages.Remove(tabPage4_Monitor);

            //this.RowHeadersVisible = false;
            //this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            //this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.AllowUserToResizeRows = false;
            //this.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //this.BackgroundColor = Color.White;
            //this.AllowUserToAddRows = false;

            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Loadtable(mdgv_manufactraw, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME', availableNow 'In Stock', reorderLevel 'Reorder Level', orderAmount 'Order QTY', toOrder 'To Order' FROM `manufactraw`");
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME' FROM `manufactraw`");

            Loadtable(mdgv_manufactraw5, "SELECT jobId 'ID', jobName 'NAME', description 'Description', duration 'Duration', noOfEmp 'No Of Emp', startingDate  'Starting Date', status 'Status' FROM `jobs`");
            Loadtable(mdgv_manufactraw6, "SELECT empId 'ID', type 'Job Type',noOfEmp 'No Of Emp' FROM `manemp`");

            Loadtable(mdgv_production2, "SELECT batchNo 'Barch No', currentJob 'Job', noOfEmp 'No Of Employees', workingHrs 'Working Hrs', costPerUnit 'Cost Per Unit', units 'No Of Units', total 'Total Costs' FROM `batch`");
            Loadtable(mdgv_production1, "SELECT batchNo 'Barch No', currentJob 'Job' FROM `batch`");

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!textBoxbatchno.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBoxjobid.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (!text_ID.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var opt = MessageBox.Show("Are you sure you want to Make Order?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
             this.Close();

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!comboBox2.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
        }

        private void mdgv_manufactraw_MouseClick(object sender, MouseEventArgs e)
        {
            text_ID.Text = mdgv_manufactraw.CurrentRow.Cells[0].Value.ToString();
            text_name.Text = mdgv_manufactraw.CurrentRow.Cells[1].Value.ToString();
            text_stock.Text = mdgv_manufactraw.CurrentRow.Cells[2].Value.ToString();
            text_ROL.Text = mdgv_manufactraw.CurrentRow.Cells[3].Value.ToString();
            text_OA.Text = mdgv_manufactraw.CurrentRow.Cells[4].Value.ToString();
            comboBoxtoorder.Text = mdgv_manufactraw.CurrentRow.Cells[5].Value.ToString();

            //string id = mdgv_manufactraw1.SelectedCells[0].Value.ToString();
            ////btn_clear.Enabled = true;
            ////btn_save.Enabled = true;

            //MySqlConnection conn = new MySqlConnection(home.connString);

            //try
            //{
            //    conn.Open();
            //    MySqlDataReader dr = null;
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM manufactraw WHERE rawMaterialID = " + id + ";", conn);

            //    dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        text_ID.Text = dr["rawMaterialID"].ToString();
            //        text_name.Text = dr["rawMaterialName"].ToString();
            //        text_stock.Text = dr["availableNow"].ToString();
            //        text_ROL.Text = dr["reorderLevel"].ToString();
            //        text_OA.Text = dr["orderAmount"].ToString();
            //        comboBoxtoorder.Text = dr["toOrder"].ToString();

            //        //cmb_access.SelectedItem = cmb_access.Items.IndexOf(dr["access"].ToString());

            //    }
            //    conn.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void mdgv_manufactraw1_MouseClick(object sender, MouseEventArgs e)
        {
            text_ID.Text = mdgv_manufactraw1.CurrentRow.Cells[0].Value.ToString();
            text_name.Text = mdgv_manufactraw1.CurrentRow.Cells[1].Value.ToString();
            text_stock.Text = "";
            text_ROL.Text = "";
            text_OA.Text = "";
            comboBoxtoorder.Text = "";
        }

        private void mdgv_production2_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxbatchno.Text = mdgv_production2.CurrentRow.Cells[0].Value.ToString();
            textBoxjob.Text = mdgv_production2.CurrentRow.Cells[1].Value.ToString();
            textBoxnoofemp.Text = mdgv_production2.CurrentRow.Cells[2].Value.ToString();
            textBoxworkinghrs.Text = mdgv_production2.CurrentRow.Cells[3].Value.ToString();
            textBoxcostperunit.Text = mdgv_production2.CurrentRow.Cells[4].Value.ToString();
            textBoxnoofunits.Text = mdgv_production2.CurrentRow.Cells[5].Value.ToString();
            textBoxtotcost.Text = mdgv_production2.CurrentRow.Cells[6].Value.ToString();
        }

        private void mdgv_production1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxbatchno.Text = mdgv_production1.CurrentRow.Cells[0].Value.ToString();
            textBoxjob.Text = mdgv_production1.CurrentRow.Cells[1].Value.ToString();
            textBoxnoofemp.Text = "";
            textBoxworkinghrs.Text = "";
            textBoxcostperunit.Text = "";
            textBoxnoofunits.Text ="";
            textBoxtotcost.Text = "";
        }

        private void mdgv_manufactraw5_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxjobid.Text = mdgv_manufactraw5.CurrentRow.Cells[0].Value.ToString();


            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jobs WHERE jobid =" + textBoxjobid.Text + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string year = dr["startingDate"].ToString().Substring(0, 4);
                    string month = dr["startingDate"].ToString().Substring(5, 2);
                    string day = dr["startingDate"].ToString().Substring(8, 2);

                    textBoxjobtitle.Text = dr["jobName"].ToString();
                    textBoxdesc.Text = dr["description"].ToString();
                    textBoxdura.Text = dr["duration"].ToString();
                    textBoxempass.Text = dr["noOfEmp"].ToString();
                    dateTimePickersdate.Value = new DateTime(Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(year));

                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //string year = dr["startingDate "].ToString().Substring(0, 4);
            //string month = dr["startingDate "].ToString().Substring(5, 2);
            //string day = dr["startingDate "].ToString().Substring(8, 2);

            //textBoxjobid.Text = mdgv_manufactraw5.CurrentRow.Cells[0].Value.ToString();
            //textBoxjobtitle.Text = mdgv_manufactraw5.CurrentRow.Cells[1].Value.ToString();
            //textBoxdesc.Text = mdgv_manufactraw5.CurrentRow.Cells[2].Value.ToString();
            //textBoxdura.Text = mdgv_manufactraw5.CurrentRow.Cells[3].Value.ToString();
            //textBoxempass.Text = mdgv_manufactraw5.CurrentRow.Cells[4].Value.ToString();
            //dateTimePickersdate.Value = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));

            ////dateTimePickersdate.Text = mdgv_manufactraw5.CurrentRow.Cells[5].Value.ToString();
            ////radioButtonen.Text = mdgv_manufactraw5.CurrentRow.Cells[6].Value.ToString();
            ////radioButtondis.Text = mdgv_manufactraw5.CurrentRow.Cells[6].Value.ToString();
        }


        private void mdgv_manufactraw6_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxempid.Text = mdgv_manufactraw6.CurrentRow.Cells[0].Value.ToString();
            textBoxtype.Text = mdgv_manufactraw6.CurrentRow.Cells[1].Value.ToString();
            textBoxempno.Text = mdgv_manufactraw6.CurrentRow.Cells[2].Value.ToString();
        }
        public void clearTxts()
        {
            text_ID.Text = "";
            text_name.Text = "";
            text_stock.Text = "";
            text_ROL.Text = "";
            text_OA.Text = "";
            comboBoxtoorder.Text = "";
            
        }
        private void add(string id, string nam, string an, string ro, string oa, string to)
        {
            if (text_ID.Text != "" && text_name.Text != "")
            {
                //SQL STMT
                string sql = "INSERT INTO manufactraw(rawMaterialID, rawMaterialName, availableNow, reorderLevel, orderAmount, toOrder) VALUES(@RawMaterialID,@RawMaterialName,@AvailableNow,@ReorderLevel,@OrderAmount,@ToOrder)";
                command = new MySqlCommand(sql, conn);
                //ADD PARAMETERS
                command.Parameters.AddWithValue("@RawMaterialID", id);
                command.Parameters.AddWithValue("@RawMaterialName", nam);
                command.Parameters.AddWithValue("@AvailableNow", an);
                command.Parameters.AddWithValue("@ReorderLevel", ro);
                command.Parameters.AddWithValue("@OrderAmount", oa);
                command.Parameters.AddWithValue("@ToOrder", to);
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
            //OPEN CON AND EXEC insert
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");
                }
                conn.Close();
                //retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void buttonadd_Click(object sender, EventArgs e)
        {
            add(text_ID.Text, text_name.Text, text_stock.Text, text_ROL.Text, text_OA.Text, comboBoxtoorder.Text);            //string insertQuery = "INSERT INTO manufactraw (rawMaterialID, rawMaterialName, availableNow, reorderLevel, orderAmount, toOrder) VALUES('" + text_ID + "','"+ text_name + "','" + text_stock + "','" + text_ROL + "','" + text_OA + "','" + comboBoxtoorder + "',)";
            //executeMyQuery(insertQuery);
            Loadtable(mdgv_manufactraw, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME', availableNow 'In Stock', reorderLevel 'Reorder Level', orderAmount 'Order QTY', toOrder 'To Order' FROM `manufactraw`");
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID 'ID', rawMaterialName 'NAME' FROM `manufactraw`");
        }

        private void buttonpadd_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO batch (batchNo, currentJob, noOfEmp, workingHrs, costPerUnit, units, total) VALUES('" + textBoxbatchno + "','" + textBoxjob + "','" + textBoxnoofemp + "','" + textBoxworkinghrs + "','" + textBoxcostperunit + "', '"+ textBoxnoofunits + "','" + textBoxtotcost + "',)";

            executeMyQuery(insertQuery);

            Loadtable(mdgv_production2, "SELECT batchNo 'Barch No', currentJob 'Job', noOfEmp 'No Of Employees', workingHrs 'Working Hrs', costPerUnit 'Cost Per Unit', units 'No Of Units', total 'Total Costs' FROM `batch`");
            Loadtable(mdgv_production1, "SELECT batchNo 'Barch No', currentJob 'Job' FROM `batch`");

        }

        private void buttonjobadd_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO jobs (jobId, jobName, description , duration , noOfEmp , startingDate, status) VALUES('" + textBoxjobid + "','" + textBoxjobtitle + "','" + textBoxdesc + "','" + textBoxdura + "','" + textBoxempass + "','" + dateTimePickersdate + "','" + radioButtonen + "')";

            executeMyQuery(insertQuery);

            Loadtable(mdgv_manufactraw5, "SELECT jobId 'ID', jobName 'NAME', description 'Description', duration 'Duration', noOfEmp 'No Of Emp', startingDate  'Starting Date', status 'Status' FROM `jobs`");
        }

        private void buttonempadd_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO manemp (empId , type ,noOfEmp) VALUES('" + textBoxempid + "','"+textBoxtype+ "','" + textBoxempno + "')";

            executeMyQuery(insertQuery);

            Loadtable(mdgv_manufactraw6, "SELECT empId 'ID', type 'Job Type',noOfEmp 'No Of Emp' FROM `manemp`");

        }

        private void textBox_Msearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Msearch.Text;
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID,rawMaterialName FROM `manufactraw` WHERE rawMaterialName like '" + filter + "%'");
            Loadtable(mdgv_manufactraw1, "SELECT rawMaterialID,rawMaterialName FROM `manufactraw` WHERE rawMaterialID like '" + filter + "%'");
        }

        private void textBox_Psearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Psearch.Text;
            Loadtable(mdgv_production1, "SELECT batchNo,currentJob FROM `batch` WHERE batchNo like '" + filter + "'");
            Loadtable(mdgv_production1, "SELECT batchNo,currentJob FROM `batch` WHERE currentJob like '" + filter + "%'");
            //Loadtable(mdgv_production2, "SELECT batchNo,currentJob FROM `batch` WHERE currentJob like '" + filter + "%'");

        }

        private void textBox_Jsearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Jsearch.Text;
            Loadtable(mdgv_manufactraw5, "SELECT jobId, jobName, description, duration, noOfEmp, startingDate, status FROM `jobs` WHERE jobId like '" + filter + "%'");
            Loadtable(mdgv_manufactraw5, "SELECT jobId, jobName, description, duration, noOfEmp, startingDate, status FROM `jobs` WHERE jobName like '" + filter + "%'");
        }

        private void textBox_Esearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox_Esearch.Text;
            Loadtable(mdgv_manufactraw6, "SELECT empId, type,noOfEmp FROM `manemp` WHERE empId like '" + filter + "%'");
            Loadtable(mdgv_manufactraw6, "SELECT empId, type,noOfEmp FROM `manemp` WHERE type like '" + filter + "%'");
        }

    }
}
