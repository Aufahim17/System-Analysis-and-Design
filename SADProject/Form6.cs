using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace SADProject
{
    public partial class Form6 : Form
    {
        SystemMenuManager menuManager;
         
        OleDbConnection conn = new OleDbConnection();
        OleDbCommand cmd;
        public Form6()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
        }

        MemoryStream ms;
        private void button5_Click(object sender, EventArgs e)
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
                
                cmd = new OleDbCommand("insert into Product(P_Name,Color,[Size],Weight,Cost,Type,Photo) values('" + textBox2.Text + "','" + textBox1.Text + "','" + str + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox3.Text +  "',@photo)", conn);
                conv_photo();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("record inserted");
                }
                else
                    MessageBox.Show("insertion failed");
                
                Form7 f7 = new Form7();
                f7.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fillup all the Fields!! ");

            }
            conn.Close();
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
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form5 f6 = new Form5();
            f6.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form7 f6 = new Form7();
            f6.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Form4 f6 = new Form4();
            f6.Show();
            this.Close();
        }
    }
}
