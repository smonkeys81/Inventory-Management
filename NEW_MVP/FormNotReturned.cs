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
    public partial class FormNotReturned : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public FormNotReturned()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\kog\Data\AE_Support\MVP\MVP.mdb; Persist Security Info=False;";

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void FormNotReturned_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;

                string query = "SELECT Vorname, Name FROM Tab_Kontakt WHERE Aktiv = Yes";
                cmd.CommandText = query;

                OleDbDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    comboBoxName.Items.Add(reader["Vorname"].ToString() + " " + reader["Name"].ToString());
                }

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Err" + ex);
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string cond = textBox1.Text.ToString();
            string LoanerName = comboBoxName.Text.ToString();

            try
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;

                //string Select_query = "SELECT Leihlieferschein_ID AS Loan_ID, Inventory.Inventar_ID AS Inv_ID, Teil_Bezeichnung AS Part_Design, Teil_PN AS Part_PN, Teil_Option AS Options, Seriennummer AS SN, Bemerkung AS Notes, Datum_verliehen AS Date_From, Datum_verliehen_bis AS Data_To, (Vorname + \" \" + Name) AS Loaner, Kommentar AS Comment";
                string Select_query = "SELECT Leihlieferschein_ID AS Loan_ID, Inventory.Inventar_ID AS Inv_ID, Teil_Bezeichnung AS Part_Design, Teil_PN AS Part_PN, Teil_Option AS Options, Seriennummer AS SN, Datum_verliehen AS Date_From, Datum_verliehen_bis AS Data_To, Kommentar AS Comment";
                string From_query = " FROM Inventory LEFT JOIN Loan_Detail ON Inventory.Inventar_ID = Loan_Detail.[Loan_Contact].Inventar_ID";
                string Where_query = " WHERE Teil_ist_noch_verliehen = Yes AND (Vorname + \" \" + Name) = \"" + LoanerName + "\"";

                if (checkBoxAll.Checked)
                {
                    Where_query += " ORDER BY Leihlieferschein_ID DESC";
                }
                else
                {
                    Where_query += " AND Datum_verliehen_bis < NOW() ORDER BY Leihlieferschein_ID DESC";
                }

                string query = Select_query + From_query + Where_query;
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

                //labelCnt.Text = "[Result Count: " + dt.Rows.Count.ToString() + "]";

                // [Result Count: 0].Text = "Database 연결 성공";
                connection.Close();

                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 53; // Loan_ID
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column = dataGridView1.Columns[1];
                column.Width = 53; // Inventory_ID
                column = dataGridView1.Columns[2];
                column.Width = 180; // Part_Design
                column = dataGridView1.Columns[3];
                column.Width = 180; // Part_PN
                column = dataGridView1.Columns[4];
                column.Width = 180; // Options
                column = dataGridView1.Columns[5];
                column.Width = 130; // SN
                column = dataGridView1.Columns[6];
                column.Width = 75; // Date_From
                column = dataGridView1.Columns[7];
                column.Width = 75; // Date_To
                column = dataGridView1.Columns[8];
                column.Width = 350; // Comment
            }

            catch (Exception ex)
            {
                MessageBox.Show("Err" + ex);
                connection.Close();
            }

        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // https://www.youtube.com/watch?v=oEiHByK1PAQ
        }
    }
}
