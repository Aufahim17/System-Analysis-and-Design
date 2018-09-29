using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SADProject
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            

            //this.MaximizeBox = false;
        }
    
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 obj2 = new Form2();
            obj2.ShowDialog();
            
        }

        private void manageLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 obj = new Form3();
            obj.Show();
            
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void webmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            AboutBox1 obj = new AboutBox1();
            obj.Show();
        }
    }
}
