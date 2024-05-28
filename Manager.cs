using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
            this.Hide();
        }

        private void btnEmploye_Click(object sender, EventArgs e)
        {
            Employe emp = new Employe();
            emp.Show();
            this.Hide();
        }

        private void btnShifts_Click(object sender, EventArgs e)
        {
            Shifts shifts = new Shifts();
            shifts.Show();
            this.Hide();
        }
    }
}
