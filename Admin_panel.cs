using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using YP2023;

namespace YourNamespace
{
    public partial class Admin_panel : Form
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable avtTable;
        private DataTable prepodTable;
        private DataTable raspisTable;
        private DataTable groupTable;
        private DataTable groupAvtTable;
        private DataTable groupPrepodTable;
        public DataGridViewRow selectedRow1;
        public DataGridViewRow selectedRow2;
        public DataGridViewRow selectedRow3;
        public DataGridViewRow selectedRow4;
        public DataGridViewRow selectedRow5;
        public DataGridViewRow selectedRow6;
        public string value1;
        public string value2;
        public string value3;
        public string value4;
        public string value5;
        public string value6;
        public int lastRowIndex2;
        public int lastRowIndex3;
        public int lastRowIndex4;
        public int lastRowIndex5;
        public int lastRowIndex6;
        public Admin_panel()
        {
            InitializeComponent();
            InitializeDatabase();
            dataGridView6.CellClick += dataGridView6_CellClick;
            dataGridView5.CellClick += dataGridView5_CellClick;
            dataGridView4.CellClick += dataGridView4_CellClick;
            dataGridView3.CellClick += dataGridView3_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;
            dataGridView1.CellClick += dataGridView1_CellClick;

        }
        private void InitializeDatabase()
        {
            string connectionString = "server=localhost;port=3306;username=root;password=111;database=PP";
            connection = new MySqlConnection(connectionString);
            command = new MySqlCommand();
            adapter = new MySqlDataAdapter();
            avtTable = new DataTable();
            prepodTable = new DataTable();
            raspisTable = new DataTable();
            groupTable = new DataTable();
            groupAvtTable = new DataTable();
            groupPrepodTable = new DataTable();

            // Загрузка данных таблицы Avt в DataGridView1
            command.CommandText = "SELECT * FROM Avt";
            command.Connection = connection;
            adapter.SelectCommand = command;
            adapter.Fill(avtTable);
            dataGridView1.DataSource = avtTable;
            
            // Загрузка данных таблицы prepod в DataGridView2
            command.CommandText = "SELECT * FROM prepod";
            adapter.Fill(prepodTable);
            dataGridView2.DataSource = prepodTable;
            lastRowIndex2 = dataGridView2.Rows.Count - 1;

            // Загрузка данных таблицы raspis в DataGridView3
            command.CommandText = "SELECT * FROM raspis";
            adapter.Fill(raspisTable);
            dataGridView3.DataSource = raspisTable;
            lastRowIndex3 = dataGridView3.Rows.Count - 1;

            command.CommandText = "SELECT * FROM `group`";
            adapter.Fill(groupTable);
            dataGridView4.DataSource = groupTable;
            lastRowIndex4 = dataGridView4.Rows.Count - 1;

            command.CommandText = "SELECT * FROM group_avt";
            adapter.Fill(groupAvtTable);
            dataGridView5.DataSource = groupAvtTable;
            lastRowIndex5 = dataGridView5.Rows.Count - 1;

            command.CommandText = "SELECT * FROM group_prepod";
            adapter.Fill(groupPrepodTable);
            dataGridView6.DataSource = groupPrepodTable;
            lastRowIndex6 = dataGridView6.Rows.Count - 1;
        }




        private void btnNew1_Click(object sender, EventArgs e)
        {
            avtTable.Clear();
            command.CommandText = "SELECT * FROM Avt";
            adapter.Fill(avtTable);
            dataGridView1.DataSource = avtTable;
        }
        private void btnNew2_Click(object sender, EventArgs e)
        {
            prepodTable.Clear();
            command.CommandText = "SELECT * FROM prepod";
            adapter.Fill(prepodTable);
            dataGridView2.DataSource = prepodTable;
            //lastRowIndex2 = dataGridView2.Rows.Count - 1;
        }
        private void btnNew3_Click(object sender, EventArgs e)
        {
            raspisTable.Clear();
            command.CommandText = "SELECT * FROM raspis";
            adapter.Fill(raspisTable);
            dataGridView3.DataSource = raspisTable;
        }
        private void btnNew4_Click(object sender, EventArgs e)
        {
            raspisTable.Clear();
            command.CommandText = "SELECT * FROM raspis";
            adapter.Fill(raspisTable);
            dataGridView3.DataSource = raspisTable;
        }

        private void btnNew5_Click(object sender, EventArgs e)
        {
            groupAvtTable.Clear();
            command.CommandText = "SELECT * FROM group_avt";
            adapter.Fill(groupAvtTable);
            dataGridView5.DataSource = groupAvtTable;
        }

        private void btnNew6_Click(object sender, EventArgs e)
        {
            groupPrepodTable.Clear();
            command.CommandText = "SELECT * FROM group_prepod";
            adapter.Fill(groupPrepodTable);
            dataGridView6.DataSource = groupPrepodTable;
        }


        private void btnDel1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно решительно хотите удалить строку,\nсоответствующую day_id = " + value1, "Подтвердите удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    DB _databaseManager = new DB();
                    string _commandString = "DELETE FROM `Avt` WHERE `Avt`.`id` = " + value1;
                    MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                    try
                    {
                        _databaseManager.OpenConnection();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Данные удалены успешно", "Внимание!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                    finally
                    {
                        _databaseManager.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Выбран неверный элемент", "Ошибка!");
            }
        }

        private void butbtnDel2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно решительно хотите удалить строку,\nсоответствующую day_id = " + value2, "Подтвердите удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView2.SelectedRows.Count != 0)
                {
                    DB _databaseManager = new DB();
                    string _commandString = "DELETE FROM `prepod` WHERE `prepod`.`prepod_id` = " + value2;
                    MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                    try
                    {
                        _databaseManager.OpenConnection();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Данные удалены успешно", "Внимание!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                    finally
                    {
                        _databaseManager.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Выбран неверный элемент", "Ошибка!");
            }
        }
        private void btnDel3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно решительно хотите удалить строку,\nсоответствующую day_id = " + value3, "Подтвердите удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView3.SelectedRows.Count != 0)
                {
                    DB _databaseManager = new DB();
                    string _commandString = "DELETE FROM `raspis` WHERE `raspis`.`day_id` = " + value3;
                    MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                    try
                    {
                        _databaseManager.OpenConnection();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Данные удалены успешно", "Внимание!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                    finally
                    {
                        _databaseManager.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Выбран неверный элемент", "Ошибка!");
            }
        }
        private void btnDel4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно решительно хотите удалить строку,\nсоответствующую day_id = " + value4, "Подтвердите удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView4.SelectedRows.Count != 0)
                {
                    DB _databaseManager = new DB();
                    string _commandString = "DELETE FROM `group` WHERE `group`.`group_id` = " + value4;
                    MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                    try
                    {
                        _databaseManager.OpenConnection();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Данные удалены успешно", "Внимание!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                    finally
                    {
                        _databaseManager.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Выбран неверный элемент", "Ошибка!");
            }

        }
        private void btnDel5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы действительно решительно хотите удалить строку,\nсоответствующую day_id = " + value5, "Подтвердите удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView5.SelectedRows.Count != 0)
                {
                    DB _databaseManager = new DB();
                    string _commandString = "DELETE FROM `group_avt` WHERE `group_avt`.`group_id` = " + value5;
                    MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                    try
                    {
                        _databaseManager.OpenConnection();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Данные удалены успешно", "Внимание!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                    finally
                    {
                        _databaseManager.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Выбран неверный элемент", "Ошибка!");
            }
        }
        private void btnDel6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно решительно хотите удалить строку,\nсоответствующую day_id = " + value6, "Подтвердите удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView6.SelectedRows.Count != 0)
                {
                    DB _databaseManager = new DB();
                    string _commandString = "DELETE FROM `group_prepod` WHERE `group_prepod`.`group_id` = " + value6;
                    MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                    try
                    {
                        _databaseManager.OpenConnection();
                        _command.ExecuteNonQuery();
                        MessageBox.Show("Данные удалены успешно", "Внимание!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                    finally
                    {
                        _databaseManager.CloseConnection();
                    }
                }
                else
                    MessageBox.Show("Выбран неверный элемент", "Ошибка!");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow1 = dataGridView1.Rows[e.RowIndex];
                value1 = selectedRow1.Cells["id"].Value.ToString();
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow2 = dataGridView2.Rows[e.RowIndex];
                value2 = selectedRow2.Cells["prepod_id"].Value.ToString();
            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow3 = dataGridView3.Rows[e.RowIndex];
                value3 = selectedRow3.Cells["day_id"].Value.ToString();
            }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow4 = dataGridView4.Rows[e.RowIndex];
                value4 = selectedRow4.Cells["group_id"].Value.ToString();
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow5 = dataGridView5.Rows[e.RowIndex];
                value5 = selectedRow5.Cells["group_id"].Value.ToString();
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow6 = dataGridView6.Rows[e.RowIndex];
                value6 = selectedRow6.Cells["group_id"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить эти данные в базу данных?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                try
                {
                    bool add = true;
                    _databaseManager.OpenConnection();

                    

                    if (Convert.ToString(dataGridView2.Rows[lastRowIndex2].Cells[1].Value) != "" && Convert.ToString(dataGridView2.Rows[lastRowIndex2].Cells[2].Value) != "")
                    {
                        string _commandString = "INSERT INTO `prepod` (`prepod_name`, `predmet`) VALUES (@PN, @P)";

                        MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                        _command.Parameters.Add("@PN", MySqlDbType.VarChar).Value = dataGridView2.Rows[lastRowIndex2].Cells[1].Value;
                        _command.Parameters.Add("@P", MySqlDbType.VarChar).Value = dataGridView2.Rows[lastRowIndex2].Cells[2].Value;

                        if (_command.ExecuteNonQuery() != 1)
                            add = false;
                    }
                    else
                        MessageBox.Show("Не все поля были заполнены", "Ошибка!");
                    

                    if (add)
                        MessageBox.Show("Данные добавлены\nнажмите кнопку 'Обновить' для проверки", "Внимание!");
                    else
                        MessageBox.Show("Ошибка добавления данных", "Ошибка!");
                }
                catch
                {
                    MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                }
                finally
                {
                    _databaseManager.CloseConnection();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить эти данные в базу данных?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                try
                {
                    bool add = true;
                    _databaseManager.OpenConnection();



                    if (Convert.ToString(dataGridView3.Rows[lastRowIndex4].Cells[1].Value) != "" && Convert.ToString(dataGridView3.Rows[lastRowIndex4].Cells[2].Value) != "")
                    {
                        string _commandString = "INSERT INTO `raspis` (`date`, `kab`, `group_id`) VALUES (@D, @K, @GI)";

                        MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);

                        DateTime dateValue = Convert.ToDateTime(dataGridView3.Rows[lastRowIndex4].Cells[1].Value);

                        _command.Parameters.Add("@D", MySqlDbType.DateTime).Value = dateValue;
                        _command.Parameters.Add("@K", MySqlDbType.VarChar).Value = dataGridView3.Rows[lastRowIndex4].Cells[2].Value;
                        _command.Parameters.Add("@GI", MySqlDbType.VarChar).Value = dataGridView3.Rows[lastRowIndex4].Cells[3].Value;

                        if (_command.ExecuteNonQuery() != 1)
                            add = false;
                    }

                    else
                        MessageBox.Show("Не все поля были заполнены", "Ошибка!");


                    if (add)
                        MessageBox.Show("Данные добавлены\nнажмите кнопку 'Обновить' для проверки", "Внимание!");
                    else
                        MessageBox.Show("Ошибка добавления данных", "Ошибка!");
                }
                catch
                {
                    MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                }
                finally
                {
                    _databaseManager.CloseConnection();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить эти данные в базу данных?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                try
                {
                    bool add = true;
                    _databaseManager.OpenConnection();



                    if (Convert.ToString(dataGridView4.Rows[lastRowIndex4].Cells[1].Value) != "")
                    {
                        string _commandString = "INSERT INTO `group` (`group_name`) VALUES (@GN)";

                        MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);
                        _command.Parameters.Add("@GN", MySqlDbType.VarChar).Value = dataGridView4.Rows[lastRowIndex4].Cells[1].Value;

                        if (_command.ExecuteNonQuery() != 1)
                            add = false;
                    }

                    else
                        MessageBox.Show("Не все поля были заполнены", "Ошибка!");


                    if (add)
                        MessageBox.Show("Данные добавлены\nнажмите кнопку 'Обновить' для проверки", "Внимание!");
                    else
                        MessageBox.Show("Ошибка добавления данных", "Ошибка!");
                }
                catch
                {
                    MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                }
                finally
                {
                    _databaseManager.CloseConnection();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить эти данные в базу данных?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                try
                {
                    bool add = true;
                    _databaseManager.OpenConnection();



                    if (Convert.ToString(dataGridView5.Rows[lastRowIndex5].Cells[0].Value) != "" && Convert.ToString(dataGridView5.Rows[lastRowIndex5].Cells[1].Value) != "")
                    {
                        string _commandString = "INSERT INTO `group_avt` (`group_id`, `id`) VALUES (@GI, @I)";

                        MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);
                        _command.Parameters.Add("@GI", MySqlDbType.VarChar).Value = dataGridView5.Rows[lastRowIndex5].Cells[0].Value;
                        _command.Parameters.Add("@I", MySqlDbType.VarChar).Value = dataGridView5.Rows[lastRowIndex5].Cells[1].Value;

                        if (_command.ExecuteNonQuery() != 1)
                            add = false;
                    }

                    else
                        MessageBox.Show("Не все поля были заполнены", "Ошибка!");


                    if (add)
                        MessageBox.Show("Данные добавлены\nнажмите кнопку 'Обновить' для проверки", "Внимание!");
                    else
                        MessageBox.Show("Ошибка добавления данных", "Ошибка!");
                }
                catch
                {
                    MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                }
                finally
                {
                    _databaseManager.CloseConnection();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить эти данные в базу данных?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                try
                {
                    bool add = true;
                    _databaseManager.OpenConnection();



                    if (Convert.ToString(dataGridView6.Rows[lastRowIndex6].Cells[0].Value) != "" && Convert.ToString(dataGridView6.Rows[lastRowIndex6].Cells[1].Value) != "")
                    {
                        string _commandString = "INSERT INTO `group_prepod` (`group_id`, `prepod_id`) VALUES (@GI, @I)";

                        MySqlCommand _command = new MySqlCommand(_commandString, _databaseManager.GetConnection);
                        _command.Parameters.Add("@GI", MySqlDbType.VarChar).Value = dataGridView6.Rows[lastRowIndex6].Cells[0].Value;
                        _command.Parameters.Add("@I", MySqlDbType.VarChar).Value = dataGridView6.Rows[lastRowIndex6].Cells[1].Value;

                        if (_command.ExecuteNonQuery() != 1)
                            add = false;
                    }

                    else
                        MessageBox.Show("Не все поля были заполнены", "Ошибка!");


                    if (add)
                        MessageBox.Show("Данные добавлены\nнажмите кнопку 'Обновить' для проверки", "Внимание!");
                    else
                        MessageBox.Show("Ошибка добавления данных", "Ошибка!");
                }
                catch
                {
                    MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                }
                finally
                {
                    _databaseManager.CloseConnection();
                }
            }
        }
    }
}
