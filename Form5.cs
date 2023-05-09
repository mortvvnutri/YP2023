using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace YP2023
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            // Открытие соединения с базой данных

            DB _databaseManager = new DB();
            string query = "SELECT obraz FROM Avt";
            MySqlCommand command = new MySqlCommand(query, _databaseManager.GetConnection);
            _databaseManager.OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            // Посчитать количество пользователей для каждого типа образования
            int osnovnoeObsheeCount = 0;
            int sredneeObsheeCount = 0;
            int sredneeProfCount = 0;
            int vyssheeCount = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                string obraz = row["obraz"].ToString();

                if (obraz == "основное общее")
                    osnovnoeObsheeCount++;
                else if (obraz == "среднее общее")
                    sredneeObsheeCount++;
                else if (obraz == "среднее профессиональное")
                    sredneeProfCount++;
                else if (obraz == "высшее")
                    vyssheeCount++;
            }

            // Создать объект диаграммы и добавить его на форму
            //Chart chart = new Chart();
            //this.Controls.Add(chart);
            chart1.Dock = DockStyle.Fill;

            // Добавить данные о количестве пользователей для каждого типа образования в Series
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Disabled";
            series.Points.AddXY("основное общее", osnovnoeObsheeCount);
            series.Points.AddXY("среднее общее", sredneeObsheeCount);
            series.Points.AddXY("среднее профессиональное", sredneeProfCount);
            series.Points.AddXY("высшее", vyssheeCount);
            // Добавить Series в объект Chart
            chart1.Series.Add(series);
        }
    }
}
