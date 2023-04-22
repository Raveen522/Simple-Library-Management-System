using System;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            frmBooks frmBooks = new frmBooks();
            frmBooks.ShowDialog();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            frmMembers frmMembers = new frmMembers();
            frmMembers.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLendBooks frmLendBooks = new frmLendBooks();
            frmLendBooks.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmReturnBooks frmReturnBooks = new frmReturnBooks();
            frmReturnBooks.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.ShowDialog();
        }
    }
}
