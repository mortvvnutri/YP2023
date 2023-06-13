using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YP2023
{
    public partial class Timetable : Form
    {
        public Timetable()
        {
            InitializeComponent();
        }
        public string namelogin;
        public string nameparol;
        private void Timetable_Load(object sender, EventArgs e)
        {
            try
            {
                DB _databaseManager = new DB();
                DataTable _dataTable = new DataTable();
                MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand _mySqlCommand = new MySqlCommand("SELECT group_avt.group_id, group_name, prepod_name, predmet, date, kab " +
                    "FROM Avt " +
                    "JOIN group_avt ON Avt.id = group_avt.id " +
                    "JOIN `group` ON group_avt.group_id = `group`.group_id " +
                    "JOIN group_prepod ON `group`.group_id = group_prepod.group_id " +
                    "JOIN prepod ON group_prepod.prepod_id = prepod.prepod_id " +
                    "JOIN raspis ON `group`.group_id = raspis.group_id " +
                    "WHERE Avt.login = @UserLogin AND Avt.password = @UserPassword", _databaseManager.GetConnection);

                // Добавляем параметры для безопасного выполнения запроса с использованием значений из переменных
                _mySqlCommand.Parameters.AddWithValue("@UserLogin", namelogin);
                _mySqlCommand.Parameters.AddWithValue("@UserPassword", nameparol);

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                dataGridView1.AutoGenerateColumns = false;

                // Создаем столбцы DataGridView и связываем их с соответствующими столбцами DataTable
                dataGridView1.Columns.Add("GroupIDColumn", "Номер группы");
                dataGridView1.Columns["GroupIDColumn"].DataPropertyName = "group_id";

                dataGridView1.Columns.Add("GroupNameColumn", "Класс");
                dataGridView1.Columns["GroupNameColumn"].DataPropertyName = "group_name";

                dataGridView1.Columns.Add("PrepodNameColumn", "Имя преподавателя");
                dataGridView1.Columns["PrepodNameColumn"].DataPropertyName = "prepod_name";

                dataGridView1.Columns.Add("PredmetColumn", "Предмет");
                dataGridView1.Columns["PredmetColumn"].DataPropertyName = "predmet";

                dataGridView1.Columns.Add("DateColumn", "Дата и время");
                dataGridView1.Columns["DateColumn"].DataPropertyName = "date";

                dataGridView1.Columns.Add("KabColumn", "Аудитория");
                dataGridView1.Columns["KabColumn"].DataPropertyName = "kab";

                // Назначаем DataTable источником данных для DataGridView
                dataGridView1.DataSource = _dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitB_Click(object sender, EventArgs e)
        {
            LK LK = new LK();
            this.Close();
            LK.ShowDialog();
        }
    }
    
}
