using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;

namespace SADProject
{
    public partial class Form11 : Form
    {
        SystemMenuManager menuManager;
         
        MemoryStream ms;
        OleDbCommand cmd;
        byte[] photo_aray;
        OleDbConnection conn = new OleDbConnection();
        public Form11()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form10 f6 = new Form10();
            f6.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Form4 f6 = new Form4();
            f6.Show();
            this.Close();
        }
        private bool button4WasClicked = false;
        private bool button5WasClicked = false;
        private void button4_Click(object sender, EventArgs e)
        {
            button4WasClicked = true;
            button5WasClicked = false;
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select Product_ID,P_Name from Product", conn);

                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable scores = new DataTable();
                da.Fill(scores);
                dataGridView1.DataSource = scores;



                // cmd.ExecuteNonQuery();
                // MessageBox.Show("Data Showed");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occur: " + ex);

            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5WasClicked = true;
            button4WasClicked = false;
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select Client_ID,Client_Name from Client", conn);

                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable scores = new DataTable();
                da.Fill(scores);
                dataGridView1.DataSource = scores;



                // cmd.ExecuteNonQuery();
                // MessageBox.Show("Data Showed");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occur: " + ex);

            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int na = 0;
            foreach (Control child in panel2.Controls)
            {
                if (child is TextBox)
                {

                    TextBox tb = child as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        na++;
                    }

                }
            }
            if (na > 0)
            {
                MessageBox.Show("Fillup all the field. " + na + " field missing!!");
            }
            else
            {
                conn.Open();
                try
                {
                    string str = "";
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (checkedListBox1.GetItemChecked(i))
                        {
                            str += (string)checkedListBox1.Items[i] + ",";

                        }
                    }
                    str = str.TrimEnd(',');
                    textBox6.Text += "$";


                    DialogResult dialogResult = MessageBox.Show("Are you sure all information are correct? ", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        OleDbCommand cmd = new OleDbCommand("insert into Order_list(Client_ID,Product_ID,Order_date,Delivery_date,Quantity,Selling_Price,Color,[Size],Single_price,Pname,Cname,Pcost) values('" + label17.Text + "','" + label15.Text + "','" + dateTimePicker2.Value + "','" + dateTimePicker1.Value + "','" + textBox5.Text + "','" + label8.Text + "','" + textBox3.Text + "','" + str + "','" + textBox6.Text + "','" + label16.Text + "','" + label18.Text + "','" + label14.Text + "')", conn);
                       // cmd.Parameters.Add("@Date", OleDbType.Date).Value = dateTimePicker1.Value;
                        //conv_photo();
                        int n = cmd.ExecuteNonQuery();
                        if (n > 0)
                        {
                            MessageBox.Show("record inserted");
                        }
                        else
                            MessageBox.Show("insertion failed");

                        Form10 f7 = new Form10();
                        f7.Show();
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }


                }
                catch (Exception ea)
                {
                    MessageBox.Show("Uncertain Error Occur :( !! " + ea);

                }
                conn.Close();

            }
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            conn.Open();
            try
            {

                if (e.RowIndex >= 0 && button4WasClicked == true)
                {
                    button5WasClicked = false;
                    string id;

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    id = row.Cells["Product_ID"].Value.ToString();

                    OleDbDataReader dr = null;
                    OleDbCommand cmd = new OleDbCommand("Select * from Product where Product_ID=" + id, conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        label15.Text = id;
                        label16.Text = (dr["P_Name"].ToString());
                        textBox3.Text = (dr["Color"].ToString());

                        label14.Text = (dr["Cost"].ToString());



                        if (dr["Photo"] != System.DBNull.Value)
                        {
                            photo_aray = (byte[])dr["Photo"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                       
                    }
                    

                }
                else if (e.RowIndex >= 0 && button5WasClicked == true)
                {
                    button4WasClicked = false;
                    string id;
                   
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    id = row.Cells["Client_ID"].Value.ToString();

                    OleDbDataReader dr = null;
                    OleDbCommand cmd = new OleDbCommand("Select * from Client where Client_ID=" + id, conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        label17.Text = id;
                        label18.Text = (dr["Client_Name"].ToString());

                    }

                    

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occur: " + ex);
            }
            conn.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int m = Int32.Parse(textBox5.Text);
                int n = Int32.Parse(textBox6.Text);
                int rslt = m * n;
                
                label8.Text = rslt.ToString()+"$";
            }
            catch (FormatException eb)
            {
                //MessageBox.Show(eb.Message);
                label8.Text = "0$";
            }
        }
    }
}
