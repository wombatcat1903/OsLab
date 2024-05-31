using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagement
{
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string plate_num = textBox3.Text;
                string color = textBox2.Text;
                string type = textBox1.Text;
                DateTime entry_time = dateTimePicker1.Value;

                string query = "INSERT INTO cars (type,color,plate_number,entry_time)" +
                    "VALUES (N'" + type + "',N'" + color + "',N'" + plate_num + "','" + entry_time + "')";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\OS Lab\ParkingManagement\ParkingManagement\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("car was added.please give the id to the driver.");
                    this.Close();
                    //refresh();
                }
                else
                    MessageBox.Show("Nashod");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
