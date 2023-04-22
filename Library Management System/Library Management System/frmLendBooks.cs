using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmLendBooks : Form
    {
        public frmLendBooks()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(
        @"Data Source=DESKTOP-GDEGPD0\SQLEXPRESS;Initial Catalog=Library_Management_System_DB;Integrated Security=True");

        int lendID = 0;
        string position;
        private void clear_texts()
        {
            txtAuthorBook1.Clear();
            txtAuthorBook2.Clear();
            txtBookNameBook1.Clear();
            txtBookNameBook2.Clear();
            txtCategoryBook1.Clear();
            txtCategoryBook2.Clear();
            txtGrade.Clear();
            txtName.Clear();
            txtxISBNBook1.Clear();
            txtxISBNBook2.Clear();
            txtxMemID.Clear();
        }

        private void max_id()
        {
            try
            {
                conn.Close();
                string select_query = "SELECT MAX(lendID) FROM lendbook;";
                SqlCommand cmd = new SqlCommand(select_query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lendID = Convert.ToInt32(dr[0].ToString()) + 1;
                    lblLendRefNo.Text =lendID.ToString();
                }

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

        private void updateBook(int ISBN){
            try
            {
                string insert_query = "UPDATE book SET vailability=1 WHERE ISBN='" + ISBN + "' ;";

                SqlCommand cmd = new SqlCommand(insert_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
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


        private void txtxMemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                try
                {
                    DataTable dt = new DataTable();
                    string select_query = "SELECT * FROM member WHERE  " +
                        "memberID=" + Convert.ToInt32(txtxMemID.Text) + " ";
                    SqlCommand cmd = new SqlCommand(select_query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtxMemID.Text = dr[0].ToString();
                        txtName.Text = dr[1].ToString();

                        if (dr[2].ToString() == "Teacher")
                        {
                            rbtnTeacher.Checked = true;
                            rbtnStudent.Checked = false;
                        }
                        else
                        {
                            rbtnTeacher.Checked = false;
                            rbtnStudent.Checked = true;
                        }
                        position = dr[2].ToString();
                        txtGrade.Text = dr[3].ToString();
                    }

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtxISBNBook1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    DataTable dt = new DataTable();
                    string select_query = "SELECT * FROM book WHERE  " +
                        "ISBN=" + Convert.ToInt32(txtxISBNBook1.Text) + " ";
                    SqlCommand cmd = new SqlCommand(select_query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtxISBNBook1.Text = dr[0].ToString();
                        txtBookNameBook1.Text = dr[1].ToString();
                        txtAuthorBook1.Text = dr[2].ToString();
                        txtCategoryBook1.Text = dr[5].ToString();
                    }

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtxISBNBook2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    DataTable dt = new DataTable();
                    string select_query = "SELECT * FROM book WHERE  " +
                        "ISBN=" + Convert.ToInt32(txtxISBNBook2.Text) + " ";
                    SqlCommand cmd = new SqlCommand(select_query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtxISBNBook2.Text = dr[0].ToString();
                        txtBookNameBook2.Text = dr[1].ToString();
                        txtAuthorBook2.Text = dr[2].ToString();
                        txtCategoryBook2.Text = dr[5].ToString();
                    }

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear_texts();
        }

        private void btnLend_Click(object sender, EventArgs e)
        {
            try
            {
                string insert_query = "INSERT INTO lendbook VALUES" +
                    "("+lendID+"," +
                    "'" + Convert.ToInt32(txtxMemID.Text) + "'," +
                    "'" + txtName.Text + "'," +
                    "'" + position + "'," +
                    "'" + txtGrade.Text + "'," +
                    "" + Convert.ToInt32(txtxISBNBook1.Text) + "," +
                    "" + Convert.ToInt32(txtxISBNBook2.Text) + "," +
                    "'" + txtBookNameBook1.Text + "'," +
                    "'" + txtBookNameBook2.Text + "'," +
                    "'"+txtAuthorBook1.Text+ "'," +
                    "'"+txtAuthorBook2.Text+ "'," +
                    "'"+ txtCategoryBook1.Text+ "'," +
                    "'"+ txtCategoryBook2.Text+"'," +
                    "'"+ (dtpIssueDate.Value).ToString() + "'," +
                    "'"+ (dtpReturnDate.Value).ToString() +"');";
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                updateBook(Convert.ToInt32(txtxISBNBook1.Text));
                updateBook(Convert.ToInt32(txtxISBNBook2.Text));
                MessageBox.Show("Book Lended to "+txtName.Text+"!");
                clear_texts();
                            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                max_id();
            }
        }

        private void frmLendBooks_Load(object sender, EventArgs e)
        {
            max_id();
        }
    }
}
