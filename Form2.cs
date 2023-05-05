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
        }
        public string p;
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (V_w.Checked) { p = "ж"; }
            if (V_w.Checked) { p = "м"; }
            if (MessageBox.Show("Вы уверены что все данные верны?\n Сохранить их?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                // Создаем команду SQL для вставки записи в таблицу Avt
                MySqlCommand myCommand = new MySqlCommand("UPDATE Avt SET name=@Name, father_name=@FatherName, date_priem=@DatePriem,last_name=@LastName,date_r=@DateOfBirth, pol=@Gender, pasport=@Passport, obraz=@Obraz, ych=@Ych, date_o=@DateO WHERE  login = @UserLogin", _databaseManager.GetConnection);

                // Защищаем значение поля pasport
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(textBox3.Text);
                byte[] encryptedData = ProtectedData.Protect(dataToEncrypt, null, DataProtectionScope.CurrentUser);
                string encryptedString = Convert.ToBase64String(encryptedData);

                // Добавляем параметры в команду SQL
                myCommand.Parameters.AddWithValue("@DatePriem", V_date_priem.Text);
                myCommand.Parameters.AddWithValue("@FatherName", TextBox2.Text);
                myCommand.Parameters.AddWithValue("@Name", TextBox1.Text);
                myCommand.Parameters.AddWithValue("@LastName", V_firstname.Text);
                myCommand.Parameters.AddWithValue("@DateOfBirth", DateTimePicker1.Value.ToString("yyyy-MM-dd"));
                myCommand.Parameters.AddWithValue("@Gender", p);
                myCommand.Parameters.AddWithValue("@Passport", encryptedString);
                myCommand.Parameters.AddWithValue("@Obraz",ComboBox1.Text);
                myCommand.Parameters.AddWithValue("@Ych", TextBox4.Text);
                myCommand.Parameters.AddWithValue("@DateO", DateTimePicker2.Value.ToString("yyyy-MM-dd"));

                // Открываем соединение с базой данных
                _databaseManager.OpenConnection();
                myCommand.Parameters.AddWithValue("@UserLogin", namelogin);

                // Выполняем команду SQL
                myCommand.ExecuteNonQuery();

                // Закрываем соединение с базой данных
                _databaseManager.CloseConnection();

                
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.ShowDialog();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            V_date_priem.Format = DateTimePicker1.Format = DateTimePicker2.Format = DateTimePickerFormat.Custom;
            V_date_priem.CustomFormat = DateTimePicker1.CustomFormat = DateTimePicker2.CustomFormat = "yyyy/MM/dd";
            DB _databaseManager = new DB();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            // Подготовка запроса на выборку
            string selectQuery = "SELECT * FROM Avt WHERE login = @UserLogin";
            MySqlCommand myCommand = new MySqlCommand(selectQuery, _databaseManager.GetConnection);
            myCommand.Parameters.AddWithValue("@UserLogin", namelogin);

            // Открытие соединения с базой данных
            _databaseManager.OpenConnection();
            object encryptedValue = myCommand.ExecuteScalar();
            // Выполнение запроса на выборку
            MySqlDataReader reader = myCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                { // Переход на первую строку результата
                    V_date_priem.Text = reader["date_priem"].ToString();
                    TextBox2.Text = reader["father_name"].ToString();
                    TextBox1.Text = reader["name"].ToString();
                    V_firstname.Text = reader["last_name"].ToString();
                    DateTimePicker1.Text = reader["Date_r"].ToString();
                    if (reader["pol"].ToString() == "ж") { V_w.Checked = true; }
                    if (reader["pol"].ToString() == "м") { V_M.Checked = true; }
                    if (!reader.IsDBNull(reader.GetOrdinal("pasport")))
                    {
                        string encryptedValueString = reader.GetString("pasport");
                        byte[] encryptedData = Convert.FromBase64String(encryptedValueString);
                        byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                        string decryptedString = Encoding.UTF8.GetString(decryptedData);
                        textBox3.Text = decryptedString;
                    }
                    ComboBox1.Text = reader["obraz"].ToString();
                    textBox5.Text = reader["number"].ToString();
                    textBox6.Text = reader["email"].ToString();
                    TextBox4.Text = reader["ych"].ToString();
                    DateTimePicker2.Text = reader["date_o"].ToString();
                }
            }

            // Закрытие ридера и соединения с базой данных
            reader.Close();
            _databaseManager.CloseConnection();
        }
    }
}
