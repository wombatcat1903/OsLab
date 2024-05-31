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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParkingManagement
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            int id = Int32.Parse(textBox1.Text);
            string query = "SELECT * FROM cars WHERE id="+ id ;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\OS Lab\ParkingManagement\ParkingManagement\Database1.mdf"";Integrated Security=True");
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            var dr = command.ExecuteReader();
            dr.Read();
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            dateTimePicker1.Visible = true;
            button2.Visible = true;
            label3.Text = dr["color"].ToString();
            label6.Text = dr["type"].ToString();
            label7.Text = dr["plate_number"].ToString();
                dr.Close();
    
            sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            String plate_num = label7.Text;
            string query = "SELECT * FROM cars WHERE plate_number='" + plate_num+"'";
            
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\OS Lab\ParkingManagement\ParkingManagement\Database1.mdf"";Integrated Security=True");
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                dr.Read();
                int id = Int32.Parse(dr["id"].ToString());
                DateTime entry = DateTime.Parse(dr["entry_time"].ToString());
                DateTime exit= dateTimePicker1.Value;
                TimeSpan diff = exit - entry;
                int cost = (diff.Hours * 20000) + 15000;
                string query2 = "UPDATE cars SET exit_time='" + exit+"' ,cost="+cost+"WHERE id="+id;
                //MessageBox.Show(query2);
                dr.Close() ;
            SqlCommand command2 = new SqlCommand(query2, sqlConnection);

                int i = command2.ExecuteNonQuery();
                if (i > 0)
                {
                    costLabel.Visible = true;
                    costLabel.Text = "Cost: " + cost;
                    button2.Enabled=false;
                    dateTimePicker1.Enabled=false;

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String plate_num = label7.Text;
                string query = "SELECT * FROM cars WHERE plate_number='" + plate_num + "'";

                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\OS Lab\ParkingManagement\ParkingManagement\Database1.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                dr.Read();
                   int id= Int32.Parse(dr["id"].ToString());
                string query2 = "UPDATE cars SET status=" +2 +"WHERE id="+id;
                //MessageBox.Show(query2);
                dr.Close();
                SqlCommand command2 = new SqlCommand(query2, sqlConnection);

                int i = command2.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("paid");

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
    }
}
