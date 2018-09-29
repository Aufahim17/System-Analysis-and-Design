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
    public partial class Form9 : Form
    {
        SystemMenuManager menuManager;
         
        OleDbConnection conn = new OleDbConnection();
        public Form9()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";

            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select * from Client", conn);

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

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form8 f6 = new Form8();
            f6.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Form4 f6 = new Form4();
            f6.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Client_ID"].Value);
               



                //MessageBox.Show(a);
                conn.Open();
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        OleDbCommand cmd = new OleDbCommand("Delete * from Client  where Client_ID= " + a, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Recorde remove successfully");
                        Form9 f6 = new Form9();
                        f6.Show();
                        this.Close();

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occur: " + ex);
                }
                conn.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Client_ID"].Value);
                string b = Convert.ToString(selectedRow.Cells["Client_Name"].Value);
                string c = Convert.ToString(selectedRow.Cells["Company"].Value);
                string d = Convert.ToString(selectedRow.Cells["Address"].Value);
                string ee = Convert.ToString(selectedRow.Cells["Phone"].Value);
                string f = Convert.ToString(selectedRow.Cells["Email"].Value);
                



                //MessageBox.Show(a);
                conn.Open();
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure? Data will be changed!", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        OleDbCommand cmd = new OleDbCommand("update Client set Client_Name='" + b + "', Company='" + c + "',Address= '" + d + "',Phone = '" + ee + "', Email= '" + f + "' where Client_ID=" + a, conn);
                     
                        int n = cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Updated");
                        Form9 fa = new Form9();
                        fa.Show();
                        this.Close();

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }

                 

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occur: " + ex);
                }
                conn.Close();


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("select * from Client where Client_ID like '" + textBox1.Text + "%' OR Client_Name like '%" + textBox1.Text + "%'", conn);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f6 = new Form9();
            f6.Show();
            this.Close();
        }
    }
}
