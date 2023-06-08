﻿using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;


namespace YP2023
{
    public partial class Data_User : Form
    {
        public bool tB3 = false;
        public bool V_f;
        public bool TB1;
        public bool TB2;
        public bool DTP1 = false;
        public string myRegex = @"\b[А-ЯЁ][а-яё]*\b";
        public string namelogin { get; set; }
        public Data_User()
        {
            InitializeComponent();
        }
        public string p;
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (V_w.Checked) { p = "ж"; }
            if (V_M.Checked) { p = "м"; }
            if (MessageBox.Show("Вы уверены что все данные верны?\n Сохранить их?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                // Создаем команду SQL для вставки записи в таблицу Avt
                MySqlCommand myCommand = new MySqlCommand("UPDATE Avt SET name=@Name, father_name=@FatherName, date_priem=@DatePriem,last_name=@LastName,date_r=@DateOfBirth, pol=@Gender, pasport=@Passport, obraz=@Obraz, ych=@Ych, date_o=@DateO WHERE  login = @UserLogin", _databaseManager.GetConnection);

                // Защищаем значение поля pasport
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(V_passport.Text);
                byte[] encryptedData = ProtectedData.Protect(dataToEncrypt, null, DataProtectionScope.CurrentUser);
                string encryptedString = Convert.ToBase64String(encryptedData);

                // Добавляем параметры в команду SQL
                myCommand.Parameters.AddWithValue("@DatePriem", V_date_priem.Text);
                myCommand.Parameters.AddWithValue("@FatherName", V_patronymic.Text);
                myCommand.Parameters.AddWithValue("@Name", V_name.Text);
                myCommand.Parameters.AddWithValue("@LastName", V_surname.Text);
                myCommand.Parameters.AddWithValue("@DateOfBirth", V_date_birth.Value.ToString("yyyy-MM-dd"));
                myCommand.Parameters.AddWithValue("@Gender", p);
                myCommand.Parameters.AddWithValue("@Passport", encryptedString);
                myCommand.Parameters.AddWithValue("@Obraz",ComboBox1.Text);
                myCommand.Parameters.AddWithValue("@Ych", TextBox4.Text);
                myCommand.Parameters.AddWithValue("@DateO", V_date_birth.Value.ToString("yyyy-MM-dd"));

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
            LK LK = new LK();
            this.Close();
            LK.ShowDialog();
        }

        private void Data_User_Shown(object sender, EventArgs e)
        {
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            V_date_priem.Format = V_date_birth.Format = V_date_birth.Format = DateTimePickerFormat.Custom;
            V_date_priem.CustomFormat = V_date_birth.CustomFormat = V_date_birth.CustomFormat = "yyyy/MM/dd";
            DB _databaseManager = new DB();
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
                    V_patronymic.Text = reader["father_name"].ToString();
                    V_name.Text = reader["name"].ToString();
                    V_surname.Text = reader["last_name"].ToString();
                    V_date_birth.Text = reader["Date_r"].ToString();
                    if (reader["pol"].ToString() == "ж") { V_w.Checked = true; }
                    if (reader["pol"].ToString() == "м") { V_M.Checked = true; }
                    if (!reader.IsDBNull(reader.GetOrdinal("pasport")))
                    {
                        string encryptedValueString = reader.GetString("pasport");
                        byte[] encryptedData = Convert.FromBase64String(encryptedValueString);
                        byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                        string decryptedString = Encoding.UTF8.GetString(decryptedData);
                        V_passport.Text = decryptedString;
                    }
                    ComboBox1.Text = reader["obraz"].ToString();
                    textBox5.Text = reader["number"].ToString();
                    textBox6.Text = reader["email"].ToString();
                    TextBox4.Text = reader["ych"].ToString();
                    V_date_birth.Text = reader["date_o"].ToString();
                }
            }

            // Закрытие ридера и соединения с базой данных
            reader.Close();
            _databaseManager.CloseConnection();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Отменить ввод символа, если это не цифра или Backspace
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (V_passport.Text.Length == 8)
            {
                tB3 = true;
            }
        }

        private void V_firstname_TextChanged(object sender, EventArgs e)
        {
            V_f = Regex.IsMatch(V_surname.Text, myRegex);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TB1 = Regex.IsMatch(V_name.Text, myRegex);
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            TB2 = Regex.IsMatch(V_patronymic.Text, myRegex);
        }
        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (V_date_birth.Value.Date != DateTime.Today)
            {
                DTP1 = true;
            }
        }
        private void Sved_page_MouseMove(object sender, MouseEventArgs e)
        {
            if (ComboBox1.Items.Count > 0 && DTP1 && TB1 && TB2 && tB3 && V_f && (V_w.Checked || V_M.Checked))
            {
                button2.Enabled = true;
            }
            else 
            {
                button2.Enabled = false;
            }
        }
    }
}