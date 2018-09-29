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
namespace SADProject
{
    public partial class Form3 : Form
    {
        SystemMenuManager menuManager;
         
        OleDbConnection conn = new OleDbConnection();
        public Form3()
        {
            //this.MaximizeBox = false;
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
        }

        private void hOmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            
            obj.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (Control child in panel2.Controls)
            {
                if (child is TextBox)
                {
                    
                    TextBox tb = child as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        n++;
                    }
                    
                }
            }
            if(n>0)
            {
                MessageBox.Show("Fillup all the field. " + n + " field missing!!");
            }
            else
            {

                if (textBox2.Text == textBox3.Text && textBox4.Text == "222")
                {

                    conn.Open();
                    try
                    {

                        //OleDbCommand cmd = new OleDbCommand("update User set [U_Name]='" + textBox1.Text + "', [Password]='" + textBox3.Text + "' where [ID]='"+n+"'", conn);

                        OleDbCommand cmd1 = new OleDbCommand("Update [User] Set [U_Name]=@uname, [Password]=@pass WHERE id=" + 1, conn);
                        cmd1.Parameters.AddWithValue("@uname", textBox1.Text);
                        cmd1.Parameters.AddWithValue("@pass", textBox3.Text);


                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Username and Password Updated");

                        Form1 f6 = new Form1();
                        f6.Show();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Occur: " + ex);
                    }
                    conn.Close();

                }
                else
                {
                    MessageBox.Show("Password or Key doesn't Match");
                }
            }
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AboutBox1 obj = new AboutBox1();
            obj.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();

            obj.Show();
            this.Close();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj2 = new Form2();
            obj2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
