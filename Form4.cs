using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace YP2023
{
    public partial class Form4 : Form
    {
        private List<RowOfData> rowsOfData = new List<RowOfData>();

        private User user;
        public Form4()
        {
            InitializeComponent();
            
        }
        private void HeaderOfTheTable()
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Id";
            column1.Width = 70;
            column1.Name = "id";
            column1.Frozen = true;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Фамилия";
            column2.Width = 120;
            column2.Name = "Фамилия";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Имя";
            column3.Width = 120;
            column3.Name = "name";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Отчество";
            column4.Width = 120;
            column4.Name = "father_name";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Образование";
            column5.Width = 180;
            column5.Name = "obraz";
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Отчество";
            column6.Width = 120;
            column6.Name = "father_name";
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Дата приёма";
            column7.Width = 120;
            column7.Name = "date_priem";
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Логин";
            column8.Width = 120;
            column8.Name = "login";
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Пароль";
            column9.Width = 120;
            column9.Name = "password";
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Паспорт";
            column10.Width = 120;
            column10.Name = "pasportdecoding";
            column10.CellTemplate = new DataGridViewTextBoxCell();

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Дата окончания";
            column11.Width = 120;
            column11.Name = "date_o";
            column11.CellTemplate = new DataGridViewTextBoxCell();
            

            

        }
        public string pasportdecoding;
        private void FillData()
        {

            DB _databaseManager = new DB();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM Avt", _databaseManager.GetConnection);
            _databaseManager.GetConnection.Open();
            object encryptedValue = command.ExecuteScalar();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                RowOfData row = new RowOfData();
                if (!reader.IsDBNull(reader.GetOrdinal("pasport")))
                {
                    string encryptedValueString = reader["pasport"].ToString();
                    byte[] encryptedData = Convert.FromBase64String(encryptedValueString);
                    byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                    string decryptedString = Encoding.UTF8.GetString(decryptedData);
                    row.pasport = decryptedString;
                }
                
                row.id = reader["id"];
                row.login = reader["login"];
                row.password = reader["password"];
                row.number = reader["number"];
                row.email = reader["email"];
                row.date_piem = reader["date_priem"];
                row.last_name = reader["last_name"];
                row.name = reader["name"];
                row.father_name = reader["father_name"];
                row.date_r = reader["date_r"];
                row.pol = reader["pol"];
                row.obraz = reader["obraz"];
                row.ych = reader["ych"];
                row.date_o = reader["date_o"];
                rowsOfData.Add(row);
            }
            reader.Close();
            _databaseManager.GetConnection.Close();
        }
        private void Form4_Shown(object sender, EventArgs e)
        {
            
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            FillData();
            dataGridView1.DataSource = rowsOfData;
            List<RowOfData> data = rowsOfData; ;

            DB databaseManager = new DB();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            try
            {
                MySqlCommand myCommand = new MySqlCommand("SELECT * FROM Avt ", databaseManager.GetConnection);
                databaseManager.GetConnection.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка работы с базой данных: " + ex.Message, "Ошибка!");
            }
            finally
            {
                databaseManager.CloseConnection();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
