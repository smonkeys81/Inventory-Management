using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.Data.OleDb;

namespace NEW_MVP
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            // https://www.connectionstrings.com/access/
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jalee\Desktop\MVP.mdb; Persist Security Info=False;";           
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\kog\Data\AE_Support\MVP\MVP.mdb; Persist Security Info=False;";

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                checkConnection.Text = "Database 연결 성공";
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database 연결 실패" + ex);

                button1.Enabled = false;
                button2.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FormInventory fInv = new FormInventory();
            fInv.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            FormNotReturned fNRtn = new FormNotReturned();
            fNRtn.ShowDialog();
        }
    }
}
