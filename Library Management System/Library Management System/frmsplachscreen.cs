using System;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void frmSplash_Activated(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value!=100) {
                progressBar1.Value = progressBar1.Value + 10;
            }
            else
            {
                timer1.Enabled = false;

                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
                this.Hide();
            }
        }
    }
}
