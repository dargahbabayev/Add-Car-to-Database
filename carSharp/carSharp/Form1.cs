using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace carSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            dgv.Rows.Clear();
            SqlConnection con = new SqlConnection("Server=USER;Database=CarDateBase;Trusted_Connection=True");
            con.Open();
            string query = "SELECT * FROM Car";
            SqlCommand comand = new SqlCommand(query,con);
            SqlDataReader r = comand.ExecuteReader();
         
            while (r.Read())
            {
                dgv.Rows.Add(r.GetString(1), r.GetString(2), r.GetSqlMoney(3), r.GetSqlString(4));
            }
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string marka = txtName.Text;
            string year = txtYear.Text;
            decimal motor =Convert.ToDecimal(txtMotor.Text);
            string Km = txtKm.Text;
            SqlConnection con = new SqlConnection("Server=USER;Database=CarDateBase;Trusted_Connection=True");
            con.Open();

            string query = "INSERT INTO Car([Marka],[Year],[Motor],[GlobalKm])  VALUES( '" + marka + "'," + year + "," + motor + "," + Km + " )";
            SqlCommand command = new SqlCommand(query,con);
            command.ExecuteNonQuery();
            con.Close();
            FillList();


        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
