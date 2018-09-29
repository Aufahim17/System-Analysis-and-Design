using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;

using System.Reflection;


namespace SADProject
{
    public partial class Form12 : Form
    {
        SystemMenuManager menuManager;
        
        OleDbConnection conn = new OleDbConnection();
        MemoryStream ms;
        byte[] photo_aray;
        OleDbCommand cmd;
        public Form12()
        {
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            string text1 = ControlID.TextData;


            conn.Open();
            try
            {
                OleDbDataReader dr = null;
                OleDbCommand cmd = new OleDbCommand("Select * from Order_list where Order_ID=" + text1, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    label8.Text = (dr["Order_ID"].ToString());
                    cid.Text = (dr["Client_ID"].ToString());
                    pcode.Text = (dr["Product_ID"].ToString());
                    odate.Text = (dr["Order_date"].ToString());
                    ddate.Text = (dr["Delivery_date"].ToString());
                    pcs.Text = (dr["Quantity"].ToString());
                    totalprice.Text = (dr["Selling_price"].ToString());
                    pcolor.Text = (dr["Color"].ToString());
                    psize.Text = (dr["Size"].ToString());
                    price.Text = (dr["Single_price"].ToString());
                    pname.Text = (dr["Pname"].ToString());
                    cname.Text = (dr["Cname"].ToString());
                    pcost.Text = (dr["Pcost"].ToString());

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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string text1 = ControlID.TextData;
                    OleDbCommand cmd = new OleDbCommand("Delete * from Order_list  where Order_ID= " + text1, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted");
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

            Form10 f7 = new Form10();
            f7.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f7 = new Form11();
            f7.Show();
            this.Close();
        }

        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           // Panel grd = new Panel();
            Bitmap bmp = new Bitmap(panel2.Width, panel2.Height, panel2.CreateGraphics());
            panel2.DrawToBitmap(bmp, new Rectangle(0, 0, panel2.Width, panel2.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);

            Single yPos = 30;
            Single leftMargin = e.MarginBounds.Left;
            Single topMargin = e.MarginBounds.Top;
            //  Image img = Image.FromFile("logo.bmp");
            // Rectangle logo = new Rectangle(40, 40, 50, 50);
            using (Font printFont = new Font("Arial", 60.0f))
            {
               // e.Graphics.DrawImage(img, logo);
                e.Graphics.DrawString("Studio Sunna", printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {



            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);

           
            doc.Print();

  
        }
    }
}
