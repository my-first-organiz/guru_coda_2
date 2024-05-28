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
    public partial class AddEmploye : Form
    {
        private string _connectionString = "Server=DESKTOP-262LE0I\\MSSQLSERVER01;Database=science;Integrated Security=True;";



        public AddEmploye()
        {
            InitializeComponent();
        }

        private void GetRoles()
        {
            string query = "SELECT userroleid, namerole FROM userrole";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cmbxRoles.DataSource = dataTable;
                cmbxRoles.DisplayMember = "namerole";
                cmbxRoles.ValueMember = "userroleid";
            }
        }
        private void AddEmployeToBase()
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string lastname = textBoxLastName.Text;
            string firstname = textBoxFirstname.Text;
            string middlenme = textBoxMiddleName.Text;
            int roleid = Convert.ToInt32(cmbxRoles.SelectedValue);

            string query = $"INSERT INTO [user] (login, password, lastname, firstname, middlename, userroleid) VALUES ('{login}', '{password}', '{lastname}', '{firstname}', '{middlenme}', '{roleid}')";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployeToBase();

            Employe employe = new Employe();
            this.Hide();
            employe.Show();
        }

        private void AddEmploye_Load(object sender, EventArgs e)
        {
            GetRoles();
        }
    }
}
