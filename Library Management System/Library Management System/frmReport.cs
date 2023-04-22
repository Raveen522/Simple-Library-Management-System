using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(
        @"Data Source=DESKTOP-GDEGPD0\SQLEXPRESS;Initial Catalog=Library_Management_System_DB;Integrated Security=True");

        private void btnIssuedBooks_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string select_query = "SELECT * FROM book WHERE vailability=0";
                SqlCommand cmd = new SqlCommand(select_query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAvailableBooks_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string select_query = "SELECT * FROM book WHERE vailability=1";
                SqlCommand cmd = new SqlCommand(select_query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
