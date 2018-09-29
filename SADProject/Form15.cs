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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph1 obj = new graph1();

            obj.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 obj = new Form4();

            obj.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ControlID.TextData = "2017";
            graph2 obj = new graph2();

            obj.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ControlID.TextData = "2018";
            graph2 obj = new graph2();

            obj.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ControlID.TextData = "2019";
            graph2 obj = new graph2();

            obj.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ControlID.TextData = "2017";
            graph3 obj = new graph3();

            obj.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ControlID.TextData = "2018";
            graph3 obj = new graph3();

            obj.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ControlID.TextData = "2019";
            graph3 obj = new graph3();

            obj.Show();
            this.Close();
        }
    }
}
