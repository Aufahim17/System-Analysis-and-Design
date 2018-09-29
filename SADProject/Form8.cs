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
    public partial class Form8 : Form
    {
        SystemMenuManager menuManager;
        
        OleDbConnection conn = new OleDbConnection();
        OleDbCommand cmd;
        public Form8()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form9 f6 = new Form9();
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 f6 = new Form4();
            f6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = 0;
            foreach (Control child in panel2.Controls)
            {
                if (child is TextBox)
                {

                    TextBox tb = child as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        k++;
                    }

                }
            }
            if (k > 0)
            {
                MessageBox.Show("Fillup all the field. " + k + " field missing!!");
            }
            else
            {
                conn.Open();
                try
                {


                    cmd = new OleDbCommand("insert into Client(Client_Name,Phone,Email,Company,Address) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", conn);

                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("record inserted");
                    }
                    else
                        MessageBox.Show("insertion failed");

                    Form9 f9 = new Form9();
                    f9.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fillup all the Fields!! ");

                }
                conn.Close();
            }
        }
    }
}
