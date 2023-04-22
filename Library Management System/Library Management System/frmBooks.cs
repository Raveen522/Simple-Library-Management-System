using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmBooks : Form
    {
        public frmBooks()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(
        @"Data Source=DESKTOP-GDEGPD0\SQLEXPRESS;Initial Catalog=Library_Management_System_DB;Integrated Security=True");

        int selected_book;

        private void Load_data()
        {
            try
            {
                DataTable dt = new DataTable();
                string select_query = "SELECT * FROM book";
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


        private void clear_texts()
        {
            txtAddedDate.Clear();
            txtAuthor.Clear();
            txtBookName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtxISBN.Clear();   
        }


        private void frmBooks_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selected_book = Convert.ToInt32(row.Cells[0].Value);
            }
            try
            {
                DataTable dt = new DataTable();
                string select_query = "SELECT * FROM book WHERE  ISBN=" + selected_book + " ";
                SqlCommand cmd = new SqlCommand(select_query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtxISBN.Text = dr[0].ToString();
                    txtBookName.Text = dr[1].ToString();
                    txtAuthor.Text = dr[2].ToString();
                    txtAddedDate.Text = dr[3].ToString();
                    txtPrice.Text = dr[4].ToString();
                    txtCategory.Text = dr[5].ToString();
                }

            }
            finally
            {
                conn.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string delete_query = "DELETE FROM book WHERE ISBN=" + selected_book + " ;";
                SqlCommand cmd = new SqlCommand(delete_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book deleted!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                Load_data();
                clear_texts();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                string insert_query = "UPDATE book SET " +
                    "name='" + txtBookName.Text + "'," +
                    "author='" + txtAuthor.Text + "'," +
                    "addeddate='" + txtAddedDate.Text + "'," +
                    "price=" + float.Parse(txtPrice.Text) + "," +
                    "category='" + txtCategory.Text + "' WHERE ISBN='"+selected_book+"' ;";

                SqlCommand cmd = new SqlCommand(insert_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Detials updated!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                clear_texts();
                Load_data();
            }
        }

        private void btnAddToInventary_Click(object sender, EventArgs e)
        {
            try
            {
                string insert_query = "INSERT INTO book VALUES" +
                    "(" + Convert.ToInt32(txtxISBN.Text) + "," +
                    "'" + txtBookName.Text + "'," +
                    "'" + txtAuthor.Text + "'," +
                    "'" + txtAddedDate.Text + "'," +
                    "" + float.Parse(txtPrice.Text) + "," +
                    "'" + txtCategory.Text + "',1);";
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Detials saved!");
                clear_texts();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                Load_data();
            }
        }
    }
}
