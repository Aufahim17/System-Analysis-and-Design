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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


using System.Windows.Forms.DataVisualization.Charting;

namespace SADProject
{
    public partial class graph1 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        string[] text = new string[50];
        string[] tk = new string[50];
        public graph1()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Databasepro.accdb";
            fillChart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
 
        private void fillChart()
        {
            

            conn.Open();
            OleDbDataReader dr = null;
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT Pname FROM Sales_record; ", conn);
            dr = cmd.ExecuteReader();

            int total = 0,i=0;
            string profit = "";
            string[] a = new string[100];
            while (dr.Read())
            {
               
                a[i] = (dr["Pname"].ToString());
                
               // MessageBox.Show(a[i]);
                i++;

            }
            i--;
            
            conn.Close();
            conn.Open();
            ControlID.TextData = i.ToString();
            TextBox[] textBoxes = new TextBox[50];
            Label[] labels = new Label[50];
            int n = 0;
            int k = 20;
            while (i>=0)
            {
                OleDbDataReader dr1 = null;
                OleDbCommand cmd1 = new OleDbCommand("Select Profit from Sales_record where Pname='" + a[i] + "'", conn);
                
                dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    profit = (dr1["Profit"].ToString());
                    profit = profit.TrimEnd('$');
                    int p = Int32.Parse(profit);
                    total += p;
                }
                chart1.Series["Profit"].Points.AddXY(a[i], total);


                

              
                    textBoxes[n] = new TextBox();
                    // Here you can modify the value of the textbox which is at textBoxes[i]
                    textBoxes[n].Text = total.ToString()+" $";
                tk[n] = textBoxes[n].Text;
                    labels[n] = new Label();
                    labels[n].Text = a[i];
                text[n] = labels[n].Text;

                    // Here you can modify the value of the label which is at labels[i]


                // This adds the controls to the form (you will need to specify thier co-ordinates etc. first)


                textBoxes[n].Size = new System.Drawing.Size(84, 22);
                    textBoxes[n].Location = new System.Drawing.Point(95, 40+k);

                    labels[n].Size = new System.Drawing.Size(84, 22);
                    labels[n].Location = new System.Drawing.Point(15, 40+k);
               
                panel6.Controls.Add(textBoxes[n]);
                    panel6.Controls.Add(labels[n]);

                n++;
                k += 20;

                i--;
                total = 0;
            }
            
            chart1.Titles.Add("Product wise total Profit");
            conn.Close();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form15 f6 = new Form15();
            f6.Show();
            this.Close();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                //Exporting to PDF
                string folderPath = "C:\\PDFs\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream stream = new FileStream(folderPath + "Productwise Profit Chart.pdf", FileMode.Create))
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
                    Paragraph title,space,head;
                    Paragraph[] pera = new Paragraph[50];
                    title = new Paragraph("Studio Sunna Productwise  Profit Chart \n\n", titleFont);
                    head = new Paragraph("           " + "Total Profit on Individual Products\n\n", verdana);
                    
                    space = new Paragraph("\n\n\n", titleFont);
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
                    string tut = ControlID.TextData;
                    int temp = Int32.Parse(tut);
                    for (int i=0;i<=temp;i++)
                    {
                        pera[i] = new Paragraph("           "+text[i]+"                       "+tk[i], regularFont);
                        //pera[i].Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(pera[i]);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("PDf Report Generated");
                string filename = "C:\\PDFs\\Productwise Profit Chart.pdf";
                System.Diagnostics.Process.Start(filename);

            }
            catch (Exception exa)
            {
                MessageBox.Show("Error Occur: Please close the current pdf file" + exa);

            }
        }
    }
}
