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
    public partial class Form4 : Form
    {
        SystemMenuManager menuManager;
         
        public Form4()
        {
            InitializeComponent();
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form7 f6 = new Form7();
            f6.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form9 f6 = new Form9();
            f6.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form10 f6 = new Form10();
            f6.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form13 f6 = new Form13();
            f6.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Form1 f6 = new Form1();
            f6.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form15 f6 = new Form15();
            f6.Show();
            this.Close();
        }
    }
}
