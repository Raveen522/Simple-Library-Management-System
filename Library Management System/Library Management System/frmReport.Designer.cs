namespace Library_Management_System
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnIssuedBooks = new System.Windows.Forms.Button();
            this.btnAvailableBooks = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-7, -16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 73);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bauhaus 93", 28F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 53);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reports";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(221, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(802, 366);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnIssuedBooks
            // 
            this.btnIssuedBooks.BackColor = System.Drawing.Color.White;
            this.btnIssuedBooks.Font = new System.Drawing.Font("Ubuntu", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnIssuedBooks.Location = new System.Drawing.Point(17, 163);
            this.btnIssuedBooks.Name = "btnIssuedBooks";
            this.btnIssuedBooks.Size = new System.Drawing.Size(165, 68);
            this.btnIssuedBooks.TabIndex = 5;
            this.btnIssuedBooks.Text = "Issued Books";
            this.btnIssuedBooks.UseVisualStyleBackColor = false;
            this.btnIssuedBooks.Click += new System.EventHandler(this.btnIssuedBooks_Click);
            // 
            // btnAvailableBooks
            // 
            this.btnAvailableBooks.BackColor = System.Drawing.Color.White;
            this.btnAvailableBooks.Font = new System.Drawing.Font("Ubuntu", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnAvailableBooks.Location = new System.Drawing.Point(17, 255);
            this.btnAvailableBooks.Name = "btnAvailableBooks";
            this.btnAvailableBooks.Size = new System.Drawing.Size(165, 73);
            this.btnAvailableBooks.TabIndex = 6;
            this.btnAvailableBooks.Text = "Available Books";
            this.btnAvailableBooks.UseVisualStyleBackColor = false;
            this.btnAvailableBooks.Click += new System.EventHandler(this.btnAvailableBooks_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Library_Management_System.Properties.Resources.BooksBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1040, 471);
            this.Controls.Add(this.btnAvailableBooks);
            this.Controls.Add(this.btnIssuedBooks);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnIssuedBooks;
        private System.Windows.Forms.Button btnAvailableBooks;
    }
}