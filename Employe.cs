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
    public partial class Employe : Form
    {

        private string _connectionString = "Server=DESKTOP-262LE0I\\MSSQLSERVER01;Database=science;Integrated Security=True;";

        private int _userID;
        public Employe()
        {
            InitializeComponent();
        }
        private void EmployeLoad()
        {
            string query = "SELECT * FROM [user]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvEmploye.DataSource = dataTable;
            }
        }

        private void Employe_Load(object sender, EventArgs e)
        {
            EmployeLoad();
        }

        private void btnFired_Click(object sender, EventArgs e)
        {
            if (_userID <= 0)
            {
                MessageBox.Show("Чтобы выполнить выделите строку (нажать слева)");
                return;
            }

            string query = $"UPDATE [user] SET status = 'уволен' WHERE userid = '{_userID}'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            EmployeLoad();
        }

        private void dgvEmploye_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmploye.SelectedRows.Count > 0)
            {
                _userID = Convert.ToInt32(dgvEmploye.SelectedRows[0].Cells["userid"].Value);
            }
        }

        private void btnAddEmpl_Click(object sender, EventArgs e)
        {
            AddEmploye addEmploye = new AddEmploye();
            addEmploye.Show();
            this.Hide();
        }

        private void btnFire_Click(object sender, EventArgs e)
        {
            if (_userID <= 0)
            {
                MessageBox.Show("Чтобы выполнить выделите строку (нажать слева)");
                return;
            }

            string query = $"DELETE FROM [user] WHERE userid = '{_userID}'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            EmployeLoad();
        }
    }
}
