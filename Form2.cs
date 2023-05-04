using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace YP2023
{
    public partial class Form2 : Form
    {
        public string namelogin { get; set; }
        public Form2()
        {
            InitializeComponent();
            V_date_priem.Format = DateTimePicker1.Format = DateTimePicker2.Format = DateTimePickerFormat.Custom;
            V_date_priem.CustomFormat = DateTimePicker1.CustomFormat = DateTimePicker2.CustomFormat = "dd/MM/yyyy";
            DB _databaseManager = new DB();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            // Подготовка запроса на выборку
            string selectQuery = "SELECT * FROM Avt, dan WHERE login = @UserLogin";
            MySqlCommand myCommand = new MySqlCommand(selectQuery, _databaseManager.GetConnection);
            myCommand.Parameters.AddWithValue("@UserLogin", namelogin);

            // Открытие соединения с базой данных
            _databaseManager.OpenConnection();

            // Выполнение запроса на выборку
            MySqlDataReader reader = myCommand.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read(); // Переход на первую строку результата
                V_date_priem.Text = reader["date_priem"].ToString();
                TextBox1.Text = reader["dan.name"].ToString();
                V_firstname.Text = reader["dan.lastname"].ToString();
                textBox5.Text = reader["number"].ToString();
                textBox6.Text = reader["email"].ToString();
            }

            // Закрытие ридера и соединения с базой данных
            reader.Close();
            _databaseManager.CloseConnection();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(textBox3.Text);
            byte[] encryptedData = ProtectedData.Protect(dataToEncrypt, null, DataProtectionScope.CurrentUser);
            string encryptedString = Convert.ToBase64String(encryptedData); // защищённое хранение

        }

        private void Vkladki_Click(object sender, EventArgs e)
        {

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.ShowDialog();
        }
    }
}
