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


    public partial class Shifts : Form
    {

        private string _connectionString = "Server=DESKTOP-262LE0I\\MSSQLSERVER01;Database=science;Integrated Security=True;";

        public Shifts()
        {
            InitializeComponent();
        }

        private void ShiftsLoad()
        {
            string query = "SELECT * FROM [shift]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvShifts.DataSource = dataTable;
            }
        }


        private void Shifts_Load(object sender, EventArgs e)
        {
            ShiftsLoad();
        }

        private void EndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            DateTime dateStart = StartDate.Value;
            DateTime dateEnd = EndDate.Value;

            string query = $"INSERT INTO [shift] (datestart, dateend) VALUES ('{dateStart}', '{dateEnd}')";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }


            ShiftsLoad();
        }
    }
}
