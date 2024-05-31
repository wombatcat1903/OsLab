using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListCars lc = new ListCars();
        Form3 form3 = new Form3();
        Cars ca = new Cars();
        private void button1_Click(object sender, EventArgs e)
        {
            
            ca.Show();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lc.Show();
        }
    }
}
