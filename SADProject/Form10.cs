using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace SADProject
{
    public partial class Form10 : Form
    {
        SystemMenuManager menuManager;
         
        OleDbConnection conn = new OleDbConnection();
        public Form10()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";

            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select * from Order_list", conn);

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
            
            Form11 f6 = new Form11();
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
            if (e.RowIndex >= 0)
            {
                string id;

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                id = row.Cells["Order_ID"].Value.ToString();
                ControlID.TextData = id;

            }



            
            Form12 f6 = new Form12();
            f6.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Client_ID"].Value);
                string b = Convert.ToString(selectedRow.Cells["Product_ID"].Value);
                string c = Convert.ToString(selectedRow.Cells["Order_date"].Value);
                string d = Convert.ToString(selectedRow.Cells["Delivery_date"].Value);
                string ee = Convert.ToString(selectedRow.Cells["Quantity"].Value);
                string f = Convert.ToString(selectedRow.Cells["Selling_price"].Value);
                string g = Convert.ToString(selectedRow.Cells["Color"].Value);
                string h = Convert.ToString(selectedRow.Cells["Size"].Value);
                string tk = Convert.ToString(selectedRow.Cells["Single_price"].Value);
                string k = Convert.ToString(selectedRow.Cells["Pname"].Value);
                string l = Convert.ToString(selectedRow.Cells["Cname"].Value);
                string main = Convert.ToString(selectedRow.Cells["Order_ID"].Value);
                string pcost = Convert.ToString(selectedRow.Cells["Pcost"].Value);



                //MessageBox.Show(a);
                conn.Open();
                try
                {
                    int m = Int32.Parse(ee);
                    pcost = pcost.TrimEnd('$');
                    int n = Int32.Parse(pcost);
                    f = f.TrimEnd('$');
                    int o = Int32.Parse(f);
                    int rslt = o - (m * n);
                    f = f + "$";
                    string i = rslt.ToString() + "$";


                    DialogResult dialogResult = MessageBox.Show("Are You Sure!! This order is delivered?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        OleDbCommand cmd1 = new OleDbCommand("insert into Sales_record(Client_ID,Product_ID,Order_ID,Order_date,Delivery_date,Quantity,Selling_Price,Color,[Size],Profit,Pname,Cname) values('" + a + "','" + b + "','" + main + "','" + c + "','" + d + "','" + ee + "','" + f + "','" + g + "','" + h + "','" + i + "','" + k + "','" + l + "')", conn);
                        cmd1.ExecuteNonQuery();
                        OleDbCommand cmd = new OleDbCommand("Delete * from Order_list  where Order_ID= " + main, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Recorded in sells list");

                        Form10 f6 = new Form10();
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

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("select * from Order_list where Order_ID like '" + textBox1.Text + "%'", conn);

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
            Form10 f6 = new Form10();
            f6.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try {
                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                pdfTable.DefaultCell.Padding = 16;
                pdfTable.WidthPercentage = 110;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;
                pdfTable.SpacingBefore = 60f;
                pdfTable.SpacingAfter = 12.5f;

                //Adding Header row
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null)
                        {
                            // your cell value is null, do something in null value case
                        }
                        else
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }


                    }
                }

                //Exporting to PDF
                string folderPath = "C:\\PDFs\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream stream = new FileStream(folderPath + "Order List.pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    string imageURL = "logo.png";
                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                    jpg.ScaleToFit(140f, 120f);
                    //Give space before image
                    jpg.SpacingBefore = 10f;
                    //Give some space after the image
                    jpg.SpacingAfter = 1f;
                    jpg.Alignment = Element.ALIGN_LEFT;

                    pdfDoc.Add(jpg);

                    Font titleFont = FontFactory.GetFont("Arial", 32);
                    //  Font regularFont = FontFactory.GetFont("Arial", 36);
                    Paragraph title;
                    title = new Paragraph("Studio Sunna Order Records", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // writer.PageEvent = new Footer();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("PDf Report Generated");
                string filename = "C:\\PDFs\\Order List.pdf";
                System.Diagnostics.Process.Start(filename);

            }
            catch (Exception exa)
            {
                MessageBox.Show("Error Occur: Please close the current pdf file");

            }
        }
    }
}
