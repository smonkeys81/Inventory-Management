using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace NEW_MVP
{
    public partial class FormInventory : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public FormInventory()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\kog\Data\AE_Support\MVP\MVP.mdb; Persist Security Info=False;";

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void buttonInquiry_Click(object sender, EventArgs e)
        {
            string cond = textBox1.Text.ToString();
            

            try
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;

                string first_query = "SELECT * FROM Inventory_Total";
                string subquery;

                if (cond.ToString() == "")
                {
                    if (checkBoxExcludeLoan.Checked)
                    {
                        subquery = " WHERE (OutOfStock IS NULL OR OutOfStock = False);";
                    }
                    else if (checkBoxExcludePMNT.Checked)
                    {
                        subquery = " WHERE (YEAR(Data_To) <> 9999 OR Data_To IS NULL);";
                    }
                    else
                    {
                        subquery = ";";
                    }
                }
                else
                {
                    if (checkBoxExcludeLoan.Checked)
                    {
                        subquery = " WHERE ((Part_Design LIKE '%" + cond + "%') OR (Part_PN LIKE '%" + cond + "%') OR (Options LIKE '%" + cond + "%') OR (SN LIKE '%" + cond + "%') OR (Notes LIKE '%" + cond + "%')) AND (OutOfStock IS NULL OR OutOfStock = False);";
                    }
                    else if (checkBoxExcludePMNT.Checked)
                    {
                        subquery = " WHERE ((Part_Design LIKE '%" + cond + "%') OR (Part_PN LIKE '%" + cond + "%') OR (Options LIKE '%" + cond + "%') OR (SN LIKE '%" + cond + "%') OR (Notes LIKE '%" + cond + "%')) AND (YEAR(Data_To) <> 9999 OR Data_To IS NULL);";
                    }
                    else
                    {
                        subquery = " WHERE (Part_Design LIKE '%" + cond + "%') OR (Part_PN LIKE '%" + cond + "%') OR (Options LIKE '%" + cond + "%') OR (SN LIKE '%" + cond + "%') OR (Notes LIKE '%" + cond + "%');";
                    }
                }

                string query = first_query + subquery;
                cmd.CommandText = query;

                /*
                OleDbDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    MessageBox.Show(reader["Inventar_ID"].ToString());
                }
                */

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                labelCnt.Text = "[Result Count: " + dt.Rows.Count.ToString() + "]";

                // [Result Count: 0].Text = "Database 연결 성공";
                connection.Close();

                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 40; // ID
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column = dataGridView1.Columns[1];
                column.Width = 70; // OutOfStock
                column = dataGridView1.Columns[2];
                column.Width = 150;
                column = dataGridView1.Columns[3];
                column.Width = 150;
                column = dataGridView1.Columns[4];
                column.Width = 150;
                column = dataGridView1.Columns[5];  
                column.Width = 105; //SN
                column = dataGridView1.Columns[6];
                column.Width = 170; // Note
                column = dataGridView1.Columns[7];
                column.Width = 78; // Date
                column = dataGridView1.Columns[8];
                column.Width = 78; // Date
                column = dataGridView1.Columns[9];
                column.Width = 78; // Date
                column = dataGridView1.Columns[10];
                column.Width = 78; // Lender
                column = dataGridView1.Columns[11];
                column.Width = 300; // Comment
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Err" + ex);
                connection.Close();
            }
        }
    }
}
