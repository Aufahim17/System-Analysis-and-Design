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
    
    public partial class Form5 : Form
    {
        SystemMenuManager menuManager;
        
        OleDbConnection conn = new OleDbConnection();
        OleDbCommand cmd;
        MemoryStream ms;
        byte[] photo_aray;
        public Form5()
        {
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            string text = ControlID.TextData;

            conn.Open();
            try
            {
                OleDbDataReader dr = null;
                OleDbCommand cmd = new OleDbCommand("Select * from Product where Product_ID=" + text, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    label8.Text = text;
                    textBox2.Text = (dr["P_Name"].ToString());
                    textBox3.Text = (dr["Size"].ToString());
                    textBox4.Text = (dr["Color"].ToString());
                    textBox5.Text = (dr["Weight"].ToString());
                    textBox6.Text = (dr["Cost"].ToString());
                    textBox7.Text = (dr["Type"].ToString());


                    if (dr["Photo"] != System.DBNull.Value)
                    {
                        photo_aray = (byte[])dr["Photo"];
                        MemoryStream ms = new MemoryStream(photo_aray);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                      
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occur: " + ex);
            }
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Form4 f6 = new Form4();
            f6.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Form7 f6 = new Form7();
            f6.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }

           
        }
        void conv_photo()
        {
            //converting photo to binary data
            if (pictureBox1.Image != null)
            {
                //using FileStream:(will not work while updating, if image is not changed)
                //FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                //byte[] photo_aray = new byte[fs.Length];
                //fs.Read(photo_aray, 0, photo_aray.Length);  

                //using MemoryStream:
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@photo", photo_aray);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        { 

            conn.Open();
            try
            {
                string text = ControlID.TextData;

                cmd = new OleDbCommand("update Product set P_Name='" + textBox2.Text + "', [Size]='" + textBox3.Text + "',Color= '" + textBox4.Text + "',Weight = '" + textBox5.Text + "', Cost= '" + textBox6.Text + "', Type= '" + textBox7.Text + "', photo=@photo where Product_ID=" + text, conn);
                conv_photo();
               
                int n = cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occur: " + ex);
            }
            conn.Close();

            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string text = ControlID.TextData;
                OleDbCommand cmd = new OleDbCommand("Delete * from Product  where Product_ID= " + text, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occur: " + ex);
            }
            conn.Close();

            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
