using MySql.Data.MySqlClient;
using System;
using Microsoft.VisualBasic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace YP2023
{
    public partial class Admin_panel : Form
    {
        public Admin_panel()
        {
            InitializeComponent();
        }
        private string Decrypt(string encryptedValueString)
        {
            byte[] encryptedData = Convert.FromBase64String(encryptedValueString);
            byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedData);
        }
        private void DeleteSelectedRow()
        {
            

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);
                DB _databaseManager = new DB();
                string query = "DELETE FROM Avt WHERE id = @id";



                MySqlCommand command = new MySqlCommand(query, _databaseManager.GetConnection);
                {
                    _databaseManager.GetConnection.Open();

                    command.Parameters.AddWithValue("@id", id);
                    if (MessageBox.Show("Вы уверены,что хотите удалить этого абитуриента?\nПосле удаления его данные будет не восстановить\nВсё ещё настроены решительно?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                    }
                dataGridView1.Rows.RemoveAt(rowIndex);
                }

                _databaseManager.GetConnection.Close();
            }
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
            column2.HeaderText = "Логин";
            column2.Width = 120;
            column2.Name = "login";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Пароль";
            column3.Width = 120;
            column3.Name = "password";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Номер телефона";
            column4.Width = 100;
            column4.Name = "number";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Почта";
            column5.Width = 180;
            column5.Name = "email";
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Дата приёма";
            column6.DefaultCellStyle.Format = "dd.MM.yyyy";
            column6.Width = 100;
            column6.Name = "date_priem";
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Фамилия";
            column7.Width = 120;
            column7.Name = "last_name";
            column7.CellTemplate = new DataGridViewTextBoxCell();

            var column8 = new DataGridViewColumn();
            column8.HeaderText = "Имя";
            column8.Width = 120;
            column8.Name = "name";
            column8.CellTemplate = new DataGridViewTextBoxCell();

            var column9 = new DataGridViewColumn();
            column9.HeaderText = "Отчество";
            column9.Width = 120;
            column9.Name = "father_name";
            column9.CellTemplate = new DataGridViewTextBoxCell();

            var column10 = new DataGridViewColumn();
            column10.HeaderText = "Дата рождения";
            column10.DefaultCellStyle.Format = "dd.MM.yyyy";
            column10.Width = 100;
            column10.Name = "date_r";
            column10.CellTemplate = new DataGridViewTextBoxCell();

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Пол";
            column11.Width = 50;
            column11.Name = "pol";
            column11.CellTemplate = new DataGridViewTextBoxCell();

            var column12 = new DataGridViewColumn();
            column12.HeaderText = "Паспорт";
            column12.Width = 100;
            column12.Name = "pasport";
            column12.CellTemplate = new DataGridViewTextBoxCell();

            var column13 = new DataGridViewColumn();
            column13.HeaderText = "Образование";
            column13.Width = 120;
            column13.Name = "obraz";
            column13.CellTemplate = new DataGridViewTextBoxCell();

            var column14 = new DataGridViewColumn();
            column14.HeaderText = "Учебное заведение";
            column14.Width =200;
            column14.Name = "ych";
            column14.CellTemplate = new DataGridViewTextBoxCell();

            var column15 = new DataGridViewColumn();
            column15.HeaderText = "Дата образования";
            column15.DefaultCellStyle.Format = "dd.MM.yyyy"; // формат даты
            column15.Width = 100;
            column15.Name = "date_o";
            column15.CellTemplate = new DataGridViewTextBoxCell();


            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);
            dataGridView1.Columns.Add(column6);
            dataGridView1.Columns.Add(column7);
            dataGridView1.Columns.Add(column8);
            dataGridView1.Columns.Add(column9);
            dataGridView1.Columns.Add(column10);
            dataGridView1.Columns.Add(column11);
            dataGridView1.Columns.Add(column12);
            dataGridView1.Columns.Add(column13);
            dataGridView1.Columns.Add(column14);
            dataGridView1.Columns.Add(column15);

            DB _databaseManager = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM Avt", _databaseManager.GetConnection);
            _databaseManager.GetConnection.Open();
            object encryptedValue = command.ExecuteScalar();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var decryptedValue = reader.IsDBNull(reader.GetOrdinal("pasport")) ? "" : Decrypt(reader["pasport"].ToString());
                dataGridView1.Rows.Add(reader["id"], reader["login"], reader["password"], reader["number"], reader["email"],
                    reader["date_priem"], reader["last_name"], reader["name"], reader["father_name"], reader["date_r"], reader["pol"],
                    decryptedValue, reader["obraz"], reader["ych"], reader["date_o"]);
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
            HeaderOfTheTable();
            DB databaseManager = new DB();
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
            dataGridView1.Rows.Clear(); 
            DB _databaseManager = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM Avt", _databaseManager.GetConnection);
            try
            {
                _databaseManager.GetConnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Получаем значения полей записи
                    int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    string login = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    string password = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    string number = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    string email = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    DateTime date_priem = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5);
                    string last_name = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    string name = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    string father_name = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                    DateTime date_r = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9);
                    string pol = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                    string pasport = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                    string obraz = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                    string ych = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                    DateTime date_o = reader.IsDBNull(14) ? DateTime.MinValue : reader.GetDateTime(14);

                    // Добавляем новую строку в DataGridView
                    dataGridView1.Rows.Add(id, login, password, number, email, date_priem, last_name, name, father_name, date_r, pol, pasport, obraz, ych, date_o);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                if (dataGridView1.CurrentCell.ColumnIndex == 2)
                {
                    // Открыть диалоговое окно для изменения значения
                    string oldValue = selectedRow.Cells[2].Value != null ? selectedRow.Cells[2].Value.ToString() : "";
                    string newValue = Interaction.InputBox("Введите новое значение", "Редактирование ячейки", oldValue);
                    if (newValue != "")
                    {
                        // Обновление значения ячейки
                        selectedRow.Cells[2].Value = newValue;

                        DB _databaseManager = new DB();

                        _databaseManager.GetConnection.Open();
                        MySqlCommand command = new MySqlCommand("UPDATE Avt SET password = @newValue WHERE id = @id", _databaseManager.GetConnection);
                        command.Parameters.AddWithValue("@newValue", newValue);
                        command.Parameters.AddWithValue("@id", selectedRow.Cells[0].Value);
                        command.ExecuteNonQuery();

                        _databaseManager.GetConnection.Close();
                    }

                }
                // Проверка, что ячейка column4 была выбрана
                if (dataGridView1.CurrentCell.ColumnIndex == 3)
                {
                    // Открыть диалоговое окно для изменения значения
                    string oldValue = selectedRow.Cells[3].Value != null ? selectedRow.Cells[3].Value.ToString() : "";
                    string newValue = Interaction.InputBox("Введите новое значение", "Редактирование ячейки", oldValue);
                    if (newValue != "")
                    {
                        // Обновление значения ячейки
                        selectedRow.Cells[3].Value = newValue;

                        DB _databaseManager = new DB();

                        _databaseManager.GetConnection.Open();
                        MySqlCommand command = new MySqlCommand("UPDATE Avt SET number = @newValue WHERE id = @id", _databaseManager.GetConnection);
                        command.Parameters.AddWithValue("@newValue", newValue);
                        command.Parameters.AddWithValue("@id", selectedRow.Cells[0].Value);
                        command.ExecuteNonQuery();

                        _databaseManager.GetConnection.Close();
                    }

                }
                

                // Проверка, что ячейка column5 была выбрана
                if (dataGridView1.CurrentCell.ColumnIndex == 4)
                {
                    // Открыть диалоговое окно для изменения значения
                    string oldValue = selectedRow.Cells[4].Value != null ? selectedRow.Cells[4].Value.ToString() : "";
                    string newValue = Interaction.InputBox("Введите новое значение", "Редактирование ячейки", oldValue);
                    if (newValue != "")
                    {
                        // Обновление значения ячейки
                        selectedRow.Cells[4].Value = newValue;

                    // Запись значения в базу данных
                    DB _databaseManager = new DB();

                    _databaseManager.GetConnection.Open();
                    MySqlCommand command = new MySqlCommand("UPDATE Avt SET email = @newValue WHERE id = @id", _databaseManager.GetConnection);
                            command.Parameters.AddWithValue("@newValue", newValue);
                            command.Parameters.AddWithValue("@id", selectedRow.Cells[0].Value);
                            command.ExecuteNonQuery();

                        _databaseManager.GetConnection.Close();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LK LK = new LK();
            this.Hide();
            LK.Show();
        }
    }
}
    


