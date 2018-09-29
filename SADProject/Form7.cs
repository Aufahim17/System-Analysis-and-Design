using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace SADProject
{
   
    public partial class Form7 : Form
    {
        SystemMenuManager menuManager;
        
        OleDbConnection conn = new OleDbConnection();
       
        
        public Form7()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
            
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select Product_ID,P_Name,[Size],Color,Cost,Type from Product", conn);

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
        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Form4 f6 = new Form4();
            f6.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form5 f6 = new Form5();
            f6.Show();
            this.Close();
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id;

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
               
                    id = row.Cells["Product_ID"].Value.ToString();
                    ControlID.TextData = id;

            }



           
            Form5 f6 = new Form5();
            f6.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("select * from Product where Product_ID like '" + textBox1.Text + "%' OR P_Name like '%" + textBox1.Text + "%'", conn);

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

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f6 = new Form7();
            f6.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
            using (FileStream stream = new FileStream(folderPath + "Products List.pdf", FileMode.Create))
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
                title = new Paragraph("Studio Sunna Products Record", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(title);

                // writer.PageEvent = new Footer();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("PDf Report Generated");
            string filename = "C:\\PDFs\\Products List.pdf";
            System.Diagnostics.Process.Start(filename);
        }
    }
    public static class ControlID
    {
        public static string TextData { get; set; }
    }
}
