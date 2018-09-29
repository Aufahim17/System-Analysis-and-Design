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
using iTextSharp.text.pdf;
using iTextSharp.text;

using System.Windows.Forms.DataVisualization.Charting;

namespace SADProject
{
    
    public partial class graph2 : Form
    {
       
        OleDbConnection conn = new OleDbConnection();
        public graph2()
        {
            
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
            fillChart();
        }
        private void fillChart()
        {
            string yr = ControlID.TextData;
            label1.Text = "Monthly Report of " + yr;
            conn.Open();
            OleDbDataReader dr1 = null, dr2 = null, dr3 = null, dr4 = null, dr5 = null, dr6 = null, dr7 = null, dr8 = null, dr9 = null, dr10 = null, dr11 = null, dr12 = null;
            OleDbCommand cmd1 = new OleDbCommand("Select * from Sales_record where Delivery_date between #1/1/"+yr+"# and #1/31/"+yr+"#", conn);
            OleDbCommand cmd2 = new OleDbCommand("Select * from Sales_record where Delivery_date between #2/1/" + yr + "# and #2/28/" + yr + "#", conn);
            OleDbCommand cmd3 = new OleDbCommand("Select * from Sales_record where Delivery_date between #3/1/" + yr + "# and #3/31/" + yr + "#", conn);
            OleDbCommand cmd4 = new OleDbCommand("Select * from Sales_record where Delivery_date between #4/1/" + yr + "# and #4/30/" + yr + "#", conn);
            OleDbCommand cmd5 = new OleDbCommand("Select * from Sales_record where Delivery_date between #5/1/" + yr + "# and #5/31/" + yr + "#", conn);
            OleDbCommand cmd6 = new OleDbCommand("Select * from Sales_record where Delivery_date between #6/1/" + yr + "# and #6/30/" + yr + "#", conn);
            OleDbCommand cmd7 = new OleDbCommand("Select * from Sales_record where Delivery_date between #7/1/" + yr + "# and #7/31/" + yr + "#", conn);
            OleDbCommand cmd8 = new OleDbCommand("Select * from Sales_record where Delivery_date between #8/1/" + yr + "# and #8/31/" + yr + "#", conn);
            OleDbCommand cmd9 = new OleDbCommand("Select * from Sales_record where Delivery_date between #9/1/" + yr + "# and #9/30/" + yr + "#", conn);
            OleDbCommand cmd10 = new OleDbCommand("Select * from Sales_record where Delivery_date between #10/1/" + yr + "# and #10/31/" + yr + "#", conn);
            OleDbCommand cmd11 = new OleDbCommand("Select * from Sales_record where Delivery_date between #11/1/" + yr + "# and #11/30/" + yr + "#", conn);
            OleDbCommand cmd12 = new OleDbCommand("Select * from Sales_record where Delivery_date between #12/1/"+yr+ "# and #12/31/" + yr + "#", conn);
            dr1 = cmd1.ExecuteReader();
            dr2 = cmd2.ExecuteReader();
            dr3 = cmd3.ExecuteReader();
            dr4 = cmd4.ExecuteReader();
            dr5 = cmd5.ExecuteReader();
            dr6 = cmd6.ExecuteReader();
            dr7 = cmd7.ExecuteReader();
            dr8 = cmd8.ExecuteReader();
            dr9 = cmd9.ExecuteReader();
            dr10 = cmd10.ExecuteReader();
            dr11 = cmd11.ExecuteReader();
            dr12 = cmd12.ExecuteReader();
            int total = 0;
            string profit = "";
            while (dr1.Read())
            {
                profit = (dr1["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("January", profit);
            //

            total = 0;
            profit = "";
            while (dr2.Read())
            {
                profit = (dr2["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("February", profit);
            //

            total = 0;
            profit = "";
            while (dr3.Read())
            {
                profit = (dr3["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("March", profit); //

            total = 0;
            profit = "";
            while (dr4.Read())
            {
                profit = (dr4["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("April", profit); //

            total = 0;
            profit = "";
            while (dr5.Read())
            {
                profit = (dr5["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("May", profit); //

            total = 0;
            profit = "";
            while (dr6.Read())
            {
                profit = (dr6["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("June", profit); //

            total = 0;
            profit = "";
            while (dr7.Read())
            {
                profit = (dr7["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("July", profit); //

            total = 0;
            profit = "";
            while (dr8.Read())
            {
                profit = (dr8["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("August", profit); //

            total = 0;
            profit = "";
            while (dr9.Read())
            {
                profit = (dr9["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("September", profit); //

            total = 0;
            profit = "";
            while (dr10.Read())
            {
                profit = (dr10["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("October", profit); //

            total = 0;
            profit = "";
            while (dr11.Read())
            {
                profit = (dr11["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("November", profit); //

            total = 0;
            profit = "";
            while (dr12.Read())
            {
                profit = (dr12["Profit"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                profit = total.ToString() + "$";

            }
            chart1.Series["Month"].Points.AddXY("December", profit);



            chart1.Titles.Add("Monthly Profit Chart");
            conn.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 f6 = new Form15();
            f6.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               


                //Exporting to PDF
                string folderPath = "C:\\PDFs\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream stream = new FileStream(folderPath + "Monthly Profit Chart.pdf", FileMode.Create))
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
                    title = new Paragraph("Studio Sunna Profit Chart "+label1.Text+"\n\n", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // writer.PageEvent = new Footer();
                    var chartimage = new MemoryStream();
                    chart1.SaveImage(chartimage, ChartImageFormat.Png);
                    iTextSharp.text.Image Chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
                    Chart_image.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(Chart_image);
                    
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("PDf Report Generated");
                string filename = "C:\\PDFs\\Monthly Profit Chart.pdf";
                System.Diagnostics.Process.Start(filename);

            }
            catch (Exception exa)
            {
                MessageBox.Show("Error Occur: Please close the current pdf file"+exa);

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
