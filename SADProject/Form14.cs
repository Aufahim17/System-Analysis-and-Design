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
namespace SADProject
{
    public partial class Form14 : Form
    {
        SystemMenuManager menuManager;
         
        OleDbConnection conn = new OleDbConnection();
        MemoryStream ms;
        byte[] photo_aray;
        OleDbCommand cmd;
        public Form14()
        {
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            string text1 = ControlID.TextData;

            conn.Open();
            try
            {
                OleDbDataReader dr = null;
                OleDbCommand cmd = new OleDbCommand("Select * from Sales_record where Sales_ID=" + text1, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    label8.Text = (text1);
                    label14.Text = (dr["Order_ID"].ToString());
                    cid.Text = (dr["Client_ID"].ToString());
                    pcode.Text = (dr["Product_ID"].ToString());
                    odate.Text = (dr["Order_date"].ToString());
                    ddate.Text = (dr["Delivery_date"].ToString());
                    pcs.Text = (dr["Quantity"].ToString());
                    totalprice.Text = (dr["Selling_price"].ToString());
                    pcolor.Text = (dr["Color"].ToString());
                    psize.Text = (dr["Size"].ToString());
                   // price.Text = (dr["Single_price"].ToString());
                    pname.Text = (dr["Pname"].ToString());
                    cname.Text = (dr["Cname"].ToString());
                    pcost.Text = (dr["Profit"].ToString());

                    OleDbCommand cmd1 = new OleDbCommand("Select * from Product where Product_ID=" + pcode.Text, conn);
                    dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {

                        if (dr["Photo"] != System.DBNull.Value)
                        {
                            photo_aray = (byte[])dr["Photo"];
                            MemoryStream ms = new MemoryStream(photo_aray);
                            pictureBox1.Image = Image.FromStream(ms);
                        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            Form13 f6 = new Form13();
            f6.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
