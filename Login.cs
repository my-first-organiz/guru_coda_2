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
    public partial class Login : Form
    {

        private string _connectionString = "Server=DESKTOP-262LE0I\\MSSQLSERVER01;Database=science;Integrated Security=True;";

        public Login()
        {
            InitializeComponent();
        }

        private void LoginToAcc(string login, string password)
        {
            string query = $"SELECT userroleid FROM [user] WHERE login = '{login}' AND password = '{password}'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int roleID = Convert.ToInt32(reader[0]);
                        switch (roleID)
                        {
                            case 1:
                                Manager manager = new Manager();
                                manager.Show();
                                this.Hide();
                                break;
                            case 2:
                                Organizer organizer = new Organizer();
                                organizer.Show();
                                this.Hide();
                                break;
                            case 3:
                                Technic technic = new Technic();
                                technic.Show();
                                this.Hide();
                                break;

                        }
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            LoginToAcc(login, password);

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
