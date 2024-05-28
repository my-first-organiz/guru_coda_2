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

namespace WindowsFormsApp1
{
    public partial class Orders : Form
    {

        private string _connectionString = "Server=DESKTOP-262LE0I\\MSSQLSERVER01;Database=science;Integrated Security=True;";

        private int _userID;

        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [order]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvOrders.DataSource = dataTable;
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
        }
    }
}
