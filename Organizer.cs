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
    public partial class Organizer : Form
    {
        private string _connectionString = "Server=DESKTOP-262LE0I\\MSSQLSERVER01;Database=science;Integrated Security=True;";

        private int _orderID;
        public Organizer()
        {
            InitializeComponent();
        }

        private void OrganizerLoad()
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


        private void Organizer_Load(object sender, EventArgs e)
        {
            OrganizerLoad();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            string nameConf = textBoxNameConf.Text;
            string equipment = textBoxEquipment.Text;
            string amount = textBoxAmount.Text;

            string query = $"INSERT INTO [order] (datecreation, orderstatus, paymentstatus, nameconference, equipment, amountguests)" +
                $" VALUES ('{DateTime.Now}', 'готовится', 'принят', '{nameConf}', '{equipment}', '{amount}')";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            OrganizerLoad();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_orderID <= 0)
            {
                MessageBox.Show("Чтобы выполнить выделите строку (нажать слева)");
                return;
            }

            string query = $"DELETE FROM [order] WHERE orderid = '{_orderID}'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            OrganizerLoad();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                _orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["userid"].Value);
            }
        }
    }
}
