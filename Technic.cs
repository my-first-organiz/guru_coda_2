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
    public partial class Technic : Form
    {
        private string _connectionString = "Server=DESKTOP-262LE0I\\MSSQLSERVER01;Database=science;Integrated Security=True;";

        private int _orderID;
        public Technic()
        {
            InitializeComponent();
        }

        private void TechnicLoad()
        {
            string query = "SELECT * FROM [order] Where paymentstatus = 'принят'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvOrders.DataSource = dataTable;
            }
        }

        private void Technic_Load(object sender, EventArgs e)
        {
            TechnicLoad();
        }

        private void btnGetingReady_Click(object sender, EventArgs e)
        {
            if (_orderID <= 0)
            {
                MessageBox.Show("Для действия выделите строку (нажать слева)");
                return;
            }

            string query = $"UPDATE [order] SET orderstatus = 'готовится' WHERE orderid = '{_orderID}'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            TechnicLoad();
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (_orderID <= 0)
            {
                MessageBox.Show("Для действия выделите строку (нажать слева)");
                return;
            }

            string query = $"UPDATE [order] SET orderstatus = 'готов' WHERE orderid = '{_orderID}'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            TechnicLoad();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                _orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["orderid"].Value);
            }
        }
    }
}
