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
using iTextSharp.text.pdf;
using iTextSharp.text;

using System.Windows.Forms.DataVisualization.Charting;


namespace SADProject
{
    public partial class graph3 : Form
    {
        int tcost = 0, tsell = 0, tprofit = 0;

        OleDbConnection conn = new OleDbConnection();
        public graph3()
        {

            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
            fillChart();
            label6.Text = tsell.ToString()+" $";
            label7.Text = tcost.ToString() + " $";
            tprofit = tsell - tcost;
            label8.Text = tprofit.ToString() + " $";
        }
        private void fillChart()
        {
            string yr = ControlID.TextData;
            label1.Text = "Monthly Sell and Cost of " + yr;
            conn.Open();
            OleDbDataReader dr1 = null, dr2 = null, dr3 = null, dr4 = null, dr5 = null, dr6 = null, dr7 = null, dr8 = null, dr9 = null, dr10 = null, dr11 = null, dr12 = null;
            OleDbCommand cmd1 = new OleDbCommand("Select * from Sales_record where Delivery_date between #1/1/" + yr + "# and #1/31/" + yr + "#", conn);
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
            OleDbCommand cmd12 = new OleDbCommand("Select * from Sales_record where Delivery_date between #12/1/" + yr + "# and #12/31/" + yr + "#", conn);
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
            int cost = 0;
            string profit = "",pro=" ";
            while (dr1.Read())
            {
                profit = (dr1["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";



                pro = (dr1["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);

                int tot = p - pr;
                cost += tot;
                tcost += tot;



            }
            chart1.Series["Sell"].Points.AddXY("January", profit);
            chart1.Series["Cost"].Points.AddXY("January", cost);

            //

            total = 0;
            profit = "";
            cost = 0;
            while (dr2.Read())
            {
                profit = (dr2["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr2["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("February", profit);
            chart1.Series["Cost"].Points.AddXY("February", cost);
            //

            total = 0;
            profit = "";
            cost = 0;
            while (dr3.Read())
            {
                profit = (dr3["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr3["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;

            }
            chart1.Series["Sell"].Points.AddXY("March", profit);
            chart1.Series["Cost"].Points.AddXY("March", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr4.Read())
            {
                profit = (dr4["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr4["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("April", profit);
            chart1.Series["Cost"].Points.AddXY("April", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr5.Read())
            {
                profit = (dr5["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr5["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("May", profit);
            chart1.Series["Cost"].Points.AddXY("May", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr6.Read())
            {
                profit = (dr6["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr6["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("June", profit);
            chart1.Series["Cost"].Points.AddXY("June", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr7.Read())
            {
                profit = (dr7["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr7["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("July", profit);
            chart1.Series["Cost"].Points.AddXY("July", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr8.Read())
            {
                profit = (dr8["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr8["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("August", profit);
            chart1.Series["Cost"].Points.AddXY("August", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr9.Read())
            {
                profit = (dr9["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr9["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("September", profit);
            chart1.Series["Cost"].Points.AddXY("September", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr10.Read())
            {
                profit = (dr10["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr10["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("October", profit);
            chart1.Series["Cost"].Points.AddXY("October", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr11.Read())
            {
                profit = (dr11["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr11["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("November", profit);
            chart1.Series["Cost"].Points.AddXY("November", cost);//

            total = 0;
            profit = "";
            cost = 0;
            while (dr12.Read())
            {
                profit = (dr12["Selling_price"].ToString());
                profit = profit.TrimEnd('$');
                int p = Int32.Parse(profit);
                total += p;
                tsell += p;
                profit = total.ToString() + "$";

                pro = (dr12["Profit"].ToString());
                pro = pro.TrimEnd('$');
                int pr = Int32.Parse(pro);
                int tot = p - pr;
                cost += tot;
                tcost += tot;


            }
            chart1.Series["Sell"].Points.AddXY("December", profit);
            chart1.Series["Cost"].Points.AddXY("December", cost);









            chart1.Titles.Add("Monthly Profit Chart");
            conn.Close();
            //chart1.Series["Salary"].Points.AddXY("Ajay", "10000");
            //chart1.Series["Salary"].Points.AddXY("Ramesh", "8000");
            //chart1.Series["Salary"].Points.AddXY("Ankit", "7000");
            //chart1.Series["Salary"].Points.AddXY("Gurmeet", "10000");
            //chart1.Series["Salary"].Points.AddXY("Suresh", "8500");
            ////chart title
            //chart1.Titles.Add("Salary Chart");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 f6 = new Form15();
            f6.Show();
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {



                //Exporting to PDF
                string folderPath = "C:\\PDFs\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream stream = new FileStream(folderPath + "Monthly Sell & Cost Chart.pdf", FileMode.Create))
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


                    iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
                    iTextSharp.text.Font regularFont = FontFactory.GetFont("Arial", 18);
                    iTextSharp.text.Font verdana = FontFactory.GetFont("Verdana", 20, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.UNDERLINE, new BaseColor(255, 0, 0));
                    Paragraph title,space, head,pera1,pera2,pera3;
                    head = new Paragraph("           " + "Yearly Report on Sales,Costs & Profits\n\n", verdana);

                    space = new Paragraph("\n\n\n", titleFont);
                    title = new Paragraph("Studio Sunna " + label1.Text, titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // writer.PageEvent = new Footer();
                    var chartimage = new MemoryStream();
                    chart1.SaveImage(chartimage, ChartImageFormat.Png);
                    iTextSharp.text.Image Chart_image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
                    Chart_image.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(Chart_image);
                    pdfDoc.Add(space);
                    pdfDoc.Add(head);

                    pera1 = new Paragraph("           " + "Totale Sales:" + "                       " + tsell+" $", regularFont);
                    //pera[i].Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(pera1);

                    pera2 = new Paragraph("           " + "Totale costs:" + "                       " + tcost+" $", regularFont);
                    //pera[i].Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(pera2);

                    pera3 = new Paragraph("           " + "Totale Profits:" + "                       " + tprofit+" $", regularFont);
                    //pera[i].Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(pera3);

                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("PDf Report Generated");
                string filename = "C:\\PDFs\\Monthly Sell & Cost Chart.pdf";
                System.Diagnostics.Process.Start(filename);

            }
            catch (Exception exa)
            {
                MessageBox.Show("Error Occur: Please close the current pdf file" + exa);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form15 f6 = new Form15();
            f6.Show();
            this.Close();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
           
            
            contextMenuStrip1.Show(button1, new Point(0, button1.Height));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello world");
        }

        private void chart2_Click(object sender, EventArgs e)
        {
                    }
    }
}
