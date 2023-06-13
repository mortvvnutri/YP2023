using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;


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
        public string nameparol { get; set; }
        public Data_User()
        {
            InitializeComponent();
        }
        public string p;
        public string o;
        private void button2_Click(object sender, EventArgs e)
        {
            if (ege.Checked) { p = "ЕГЭ"; }
            if (oge.Checked) { p = "ОГЭ"; }
            if (SPO.Checked) { o = "ССУЗ"; }
            if (School.Checked) { o = "Школа"; }
            List<string> selectedItems = new List<string>();
            foreach (object item in predmcheckedListBox.CheckedItems)
            {
                selectedItems.Add(item.ToString() + ",");
            }

            StringBuilder sb = new StringBuilder();
            foreach (string item in selectedItems)
                sb.Append(item.ToString());
            if (MessageBox.Show("Вы уверены что все данные верны?\n Сохранить их?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB _databaseManager = new DB();

                // Создаем команду SQL для вставки записи в таблицу Avt
                MySqlCommand myCommand = new MySqlCommand("UPDATE Avt SET name=@Name, father_name=@FatherName, last_name=@LastName,date_r=@DateOfBirth, exam=@Examen, pasport=@Passport, obraz=@Obraz, ych=@Ych, predm = @Predmets WHERE  login = @UserLogin AND password = @UserPassword", _databaseManager.GetConnection);


                // Защищаем значение поля pasport
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(V_passport.Text);
                byte[] encryptedData = ProtectedData.Protect(dataToEncrypt, null, DataProtectionScope.CurrentUser);
                string encryptedString = Convert.ToBase64String(encryptedData);

                // Добавляем параметры в команду SQL
                myCommand.Parameters.AddWithValue("@FatherName", V_patronymic.Text);
                myCommand.Parameters.AddWithValue("@Name", V_name.Text);
                myCommand.Parameters.AddWithValue("@LastName", V_surname.Text);
                myCommand.Parameters.AddWithValue("@DateOfBirth", V_date_birth.Value.ToString("yyyy-MM-dd"));
                myCommand.Parameters.AddWithValue("@Examen", p);
                myCommand.Parameters.AddWithValue("@Passport", encryptedString);
                myCommand.Parameters.AddWithValue("@Ych", TextBox4.Text);
                myCommand.Parameters.AddWithValue("@Obraz", o);
                myCommand.Parameters.AddWithValue("@Predmets", sb.ToString());
                

                //Открываем соединение с базой данных
                _databaseManager.OpenConnection();
                myCommand.Parameters.AddWithValue("@UserLogin", namelogin);
                myCommand.Parameters.AddWithValue("@UserPassword", nameparol);

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
            //ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            V_date_birth.Format = DateTimePickerFormat.Custom;
            V_date_birth.CustomFormat  = "yyyy/MM/dd";
            DB _databaseManager = new DB();
            // Подготовка запроса на выборку
            string selectQuery = "SELECT * FROM Avt WHERE login = @UserLogin AND password = @UserPassword" ;
            MySqlCommand myCommand = new MySqlCommand(selectQuery, _databaseManager.GetConnection);
            myCommand.Parameters.AddWithValue("@UserLogin", namelogin);
            myCommand.Parameters.AddWithValue("@UserPassword", nameparol);

            // Открытие соединения с базой данных
            _databaseManager.OpenConnection();
            object encryptedValue = myCommand.ExecuteScalar();
            // Выполнение запроса на выборку
            MySqlDataReader reader = myCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    V_patronymic.Text = reader["father_name"].ToString();
                    V_name.Text = reader["name"].ToString();
                    V_surname.Text = reader["last_name"].ToString();
                    V_date_birth.Text = reader["Date_r"].ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("pasport")))
                    {
                        string encryptedValueString = reader.GetString("pasport");
                        byte[] encryptedData = Convert.FromBase64String(encryptedValueString);
                        byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                        string decryptedString = Encoding.UTF8.GetString(decryptedData);
                        V_passport.Text = decryptedString;
                    }
                    if (reader["obraz"].ToString() == "ССУЗ") { SPO.Checked = true; }
                    if (reader["obraz"].ToString() == "Школа") { School.Checked = true; }
                    if (reader["exam"].ToString() == "ОГЭ") { oge.Checked = true; }
                    if (reader["exam"].ToString() == "ЕГЭ") { ege.Checked = true; }
                    TextBox4.Text = reader["ych"].ToString();
                    textBox5.Text = reader["number"].ToString();
                    textBox6.Text = reader["email"].ToString();
                    // Получите значение из базы данных, которое содержит список значений, например, в виде строки с разделителем
                    string predmValues = reader["predm"].ToString();

                    // Разделите строку на отдельные значения
                    string[] predmArray = predmValues.Split(',');


                    // Пройдитесь по каждому элементу в CheckedListBox
                    for (int i = 0; i < predmcheckedListBox.Items.Count; i++)
                    {
                        // Получите текущий элемент
                        object item = predmcheckedListBox.Items[i];

                        // Проверьте, содержится ли значение текущего элемента в списке значений из базы данных
                        foreach (string value in predmArray)
                        {
                            if (item.ToString() == value)
                            {
                                predmcheckedListBox.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }
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
            if (V_passport.Text.Length == 6)
            {
                tB3 = true;
            }
        }

        private void V_firstname_TextChanged(object sender, EventArgs e)
        {
            V_f = Regex.IsMatch(V_surname.Text, myRegex);
        }

        private void Sved_page_MouseMove(object sender, MouseEventArgs e)
        {
            if (predmcheckedListBox.CheckedItems.Count > 0 && TB1 && TB2 && tB3 && V_f && (ege.Checked || oge.Checked))
            {
                button2.Enabled = true;
            }
            else 
            {
                button2.Enabled = false;
            }
        }

        private void oge_CheckedChanged(object sender, EventArgs e)
        {
            SPO.Enabled = false;
            School.Checked = true;
        }

        private void ege_CheckedChanged(object sender, EventArgs e)
        {
            SPO.Enabled = true;
            School.Checked = false;
        }

        private void V_name_TextChanged(object sender, EventArgs e)
        {
            TB1 = Regex.IsMatch(V_name.Text, myRegex);
        }

        private void V_patronymic_TextChanged(object sender, EventArgs e)
        {
            TB2 = Regex.IsMatch(V_patronymic.Text, myRegex);
        }
    }
}
