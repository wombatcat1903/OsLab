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
    public partial class ListCars : Form
    {
        public ListCars()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListCars_Load(object sender, EventArgs e)
        {
            DataTable myDataTable = new DataTable();
            string query = "SELECT * FROM cars WHERE status=1";
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\OS Lab\ParkingManagement\ParkingManagement\Database1.mdf"";Integrated Security=True");
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(myDataTable);

            sqlConnection.Close();
            dataGridView1.DataSource = myDataTable;
            dataGridView1.Columns["status"].Visible = false;
            dataGridView1.AutoResizeColumns();

        }
    }
}
