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
    public partial class Form2 : Form
    {
        SystemMenuManager menuManager;
       

        OleDbConnection conn = new OleDbConnection();
        public Form2()
        {
            InitializeComponent();
            //this.MaximizeBox = false;
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                OleDbDataReader dr = null;
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [User] where U_name ='" + textBox1.Text + "' AND [Password]='" + textBox2.Text + "'" + ";", conn);
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    MessageBox.Show("Successfully login completed");
                    Dispose();
                    Form4 f4 = new Form4();
                    f4.ShowDialog();
                    



                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occur: " + ex);
            }
            conn.Close();
        }

        private void hOmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            
            obj.Show();
            this.Close();
        }

        private void manageLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            
            
            obj.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        
               if (e.KeyCode == Keys.Enter)
                {
                    textBox2.Focus();
                    e.Handled = true;
                }
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
                e.Handled = true;
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void webmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 obj = new AboutBox1();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
