using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmMembers : Form
    {
        public frmMembers()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(
        @"Data Source=DESKTOP-GDEGPD0\SQLEXPRESS;Initial Catalog=Library_Management_System_DB;Integrated Security=True");

        int selected_member;
        string position = "Student";
        string gender = "Male";

        private void Load_data()
        {
            try
            {
                DataTable dt = new DataTable();
                string select_query = "SELECT * FROM member";
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
            txtAge.Clear();
            txtGrade.Clear();
            txtName.Clear();
            txtxAddress.Clear();
            txtxMemID.Clear();
            rbtnStudent.Checked = true;
            rbtnMale.Checked = true;
        }


        private void frmMembers_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selected_member = Convert.ToInt32(row.Cells[0].Value);
            }
            try
            {
                DataTable dt = new DataTable();
                string select_query = "SELECT * FROM member WHERE  memberID=" + selected_member + " ";
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
                    else {
                        rbtnTeacher.Checked = false;
                        rbtnStudent.Checked = true;
                    }

                    txtGrade.Text = dr[3].ToString();
                    txtxAddress.Text = dr[4].ToString();
                    txtAge.Text = dr[5].ToString();

                    if (dr[6].ToString()=="Female") 
                    {
                        gender = dr[6].ToString();
                        label5.Text =gender;
                    }
                    else 
                    {
                        gender = dr[6].ToString();
                        label5.Text =gender;    
                    }

                }

            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAddToInventary_Click(object sender, EventArgs e)
        {
            if (rbtnStudent.Checked == true)
            {
                position = "Student";
            }
            else {
                position = "Teacher";
            }

            try
            {
                string insert_query = "INSERT INTO member VALUES" +
                    "(" + Convert.ToInt32(txtxMemID.Text) + "," +
                    "'" + txtName.Text + "','" + position + "'," +
                    "'" + txtGrade.Text + "'," +
                    "'" + txtxAddress.Text + "'," +
                    "'" + txtAge.Text + "'," +
                    "'"+gender+"');";
                SqlCommand cmd = new SqlCommand(insert_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Detials saved!");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rbtnStudent.Checked == true)
            {
                position = "Student";
            }
            else
            {
                position = "Teacher";
            }

            try
            {
                string insert_query = "UPDATE member SET " +
                    "name='" + txtName.Text + "'," +
                    "position='" +position + "'," +
                    "grade='" + txtGrade.Text + "'," +
                    "address='" + txtxAddress.Text + "'," +
                    "age='" + txtAge.Text + "'," +
                    "gender='" + gender + "' WHERE memberID='" + selected_member + "' ;";

                SqlCommand cmd = new SqlCommand(insert_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Detials updated!");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string delete_query = "DELETE FROM member WHERE memberID=" + selected_member + " ;";
                SqlCommand cmd = new SqlCommand(delete_query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member deleted!");

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


        private void rbtnStudent_CheckedChanged(object sender, EventArgs e)
        {
            position = "Student";
        }

        private void rbtnTeacher_CheckedChanged(object sender, EventArgs e)
        {
            position = "Teacher";
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
            label5.Text = gender;
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
            label5.Text = gender;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
