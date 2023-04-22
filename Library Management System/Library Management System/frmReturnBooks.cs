using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmReturnBooks : Form
    {
        public frmReturnBooks()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(
        @"Data Source=DESKTOP-GDEGPD0\SQLEXPRESS;Initial Catalog=Library_Management_System_DB;Integrated Security=True");

        int lendID = 0;
        string position;

        private void clear_texts()
        {
            txtLendRefNo.Clear();
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
            txtReturnDate.Clear();
            txtIssedDate.Clear();
        }

        private void updateBook(int ISBN)
        {
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


        private void txtLendRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    DataTable dt = new DataTable();
                    string select_query = "SELECT * FROM lendbook WHERE  " +
                        "lendID=" + Convert.ToInt32(txtLendRefNo.Text) + " ";
                    SqlCommand cmd = new SqlCommand(select_query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtxMemID.Text = dr[1].ToString();
                        txtName.Text = dr[2].ToString();

                        if (dr[3].ToString() == "Teacher")
                        {
                            rbtnTeacher.Checked = true;
                            rbtnStudent.Checked = false;
                        }
                        else
                        {
                            rbtnTeacher.Checked = false;
                            rbtnStudent.Checked = true;
                        }
                        position = dr[3].ToString();
                        txtGrade.Text = dr[4].ToString();
                        txtxISBNBook1.Text = dr[5].ToString();  
                        txtxISBNBook2.Text = dr[6].ToString();
                        txtBookNameBook1.Text = dr[7].ToString();
                        txtBookNameBook2.Text = dr[8].ToString();
                        txtAuthorBook1.Text = dr[9].ToString();
                        txtAuthorBook2.Text = dr[10].ToString();
                        txtCategoryBook1.Text = dr[11].ToString();
                        txtCategoryBook2.Text = dr[12].ToString();
                        txtIssedDate.Text = dr[13].ToString();
                        txtReturnDate.Text = dr[14].ToString();
                    }

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            updateBook(Convert.ToInt32(txtxISBNBook1.Text));
            updateBook(Convert.ToInt32(txtxISBNBook2.Text));
            MessageBox.Show(txtName.Text+" Books Returned!");
            clear_texts();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear_texts();
        }
    }
}
