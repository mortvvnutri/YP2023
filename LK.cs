using System;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace YP2023
{
    public partial class LK : Form
    {
        private bool IsLogin
        {
            get
            {
                bool been = false;

                string loginUser = Login_Vhod.Text;
                string passwordUser = Parol_Vhod.Text;

                DB _databaseManager = new DB();
                DataTable _dataTable = new DataTable();
                MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM Avt WHERE login = @UserLogin", _databaseManager.GetConnection);

                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);

                if (_dataTable.Rows.Count > 0)
                {
                    been = true;
                }

                return been;
            }
        }

        private string savedAuthCode;
        private bool isValidEmail = false;
        private bool isValidTelephone = false;
        public string UserName;
        public string UserPhone;
        public string UserPassword;
        public string UserEmail;
        public string namelogin;
        public LK()
        {
            InitializeComponent();
            Parol_Vhod.UseSystemPasswordChar = true;
            pictureBox1.Image = Properties.Resources.eye_close;
            Parol_Reg.UseSystemPasswordChar = true;
            pictureBox2.Image = Properties.Resources.eye_close;
        }
        private string GenerateAuthCode()
        {
            Random random = new Random();
            int authCode = random.Next(100000, 999999);
            return authCode.ToString();
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            masked_number.Focus();
            masked_number.SelectionStart = 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string loginUser = Login_Vhod.Text;
            namelogin = loginUser;
            string passwordUser = Parol_Vhod.Text;

            DB _databaseManager = new DB();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            MySqlCommand _mySqlCommand = new MySqlCommand("SELECT * FROM Avt WHERE login = @UserLogin AND password = @UserPassword", _databaseManager.GetConnection);


            try
            {
                _mySqlCommand.Parameters.Add("@UserLogin", MySqlDbType.VarChar).Value = loginUser;
                _mySqlCommand.Parameters.Add("@UserPassword", MySqlDbType.VarChar).Value = passwordUser;

                _databaseManager.OpenConnection();

                _mySqlDataAdapter.SelectCommand = _mySqlCommand;
                _mySqlDataAdapter.Fill(_dataTable);
                if (_dataTable.Rows.Count > 0)
                {
                    if (loginUser == "admin")
                    {
                        Admin_panel form4 = new Admin_panel();
                        this.Hide();
                        form4.Show();
                    }
                    else
                    {
                        Data_User form = new Data_User();
                        form.namelogin = namelogin;
                        this.Hide();
                        form.Show();

                        User user = new User(loginUser);
                    }
                }
                else
                {
                    if (IsLogin)
                        MessageBox.Show("Неправильный пароль", "Внимание!");
                    else
                    {
                        if (MessageBox.Show("Вы у нас впервые\nНеобходимо зарегистрироваться!\nЗарегистрироваться сейчас?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            TabControl1.SelectedTab = TabControl1.TabPages[1];
                        }
                    }
                }
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

        private void button2_Click(object sender, EventArgs e)
        {

            // Генерируем код аутентификации
            string authCode = GenerateAuthCode();
            savedAuthCode = authCode;
            string toEmail = emailTextBox.Text;
            UserEmail = toEmail;
            UserName = Login_Reg.Text;
            UserPhone = masked_number.Text;
            UserPassword = Parol_Reg.Text;


            DB _databaseManager = new DB();
            DataTable _dataTable = new DataTable();
            MySqlDataAdapter _mySqlDataAdapter = new MySqlDataAdapter();
            // Подготовка запроса на выборку
            string selectQuery = "SELECT login, number, email FROM avt;"; ;
            MySqlCommand myCommand = new MySqlCommand(selectQuery, _databaseManager.GetConnection);
            myCommand.Parameters.AddWithValue("@UserLogin", namelogin);

            // Открытие соединения с базой данных
            _databaseManager.OpenConnection();

            // Выполнение запроса на выборку
            MySqlDataReader reader = myCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); // Переход на первую строку результата

                // Заполнение значениями из поля phone
                if (reader["login"].ToString() != UserName && reader["number"].ToString() != UserPhone && reader["email"].ToString() != UserEmail)
                {
                    string senderEmail = "TestYP.NET@yandex.ru";
                    string senderPassword = "mhkmzjmdldjmyats";

                    // адрес электронной почты получателя
                    string receiverEmail = toEmail;

                    // создание объекта сообщения
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(senderEmail);
                    message.To.Add(new MailAddress(receiverEmail));
                    message.Subject = "Авторизация";
                    message.Body = "Ваш код для сбора всей информации о вашей жизни: " + authCode;

                    // создание SMTP-клиента
                    SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    // отправка сообщения
                    try
                    {
                        client.Send(message);
                        Console.WriteLine("Сообщение отправлено");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка отправки сообщения: " + ex.Message);
                    }

                    MessageBox.Show("Сообщение отправлено успешно)))");

                    // Сохраняем код аутентификации для последующей проверки
                    savedAuthCode = authCode;
                    Verify Verify = new Verify();
                    Verify.Code = savedAuthCode; // передаем сохраненный код в форму
                    Verify.Name = UserName;
                    Verify.Password = UserPassword;
                    Verify.Phone = UserPhone;
                    Verify.Email = UserEmail;
                    this.Hide();
                    Verify.Show();
                }
                else
                {
                    if (MessageBox.Show("Такой пользователь уже есть!\nПерейти на форму входа?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TabControl1.SelectedTab = TabControl1.TabPages[0];
                    }
                }
            }
            reader.Close();
            _databaseManager.CloseConnection();

        }

        private bool IsValid(string text)
        {
            if (!Regex.IsMatch(text, @"^\+7\(\d{3}\)\s\d{3}-\d{2}-\d{2}$"))
            {
                return false;
            }

            return true;
        }
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = masked_number.Text;
            if (IsValid(text))
            {
                if (IsValid(masked_number.Text))
                {
                    masked_number.BackColor = Color.LightGreen;
                    isValidTelephone = true;
                }
                else
                {
                    masked_number.BackColor = Color.Salmon;
                }
            }
            else
            {
                masked_number.BackColor = Color.Salmon;
            }
        }
        private void OpenCodeVerificationForm(string code)
        {
            Verify codeVerificationForm = new Verify();
            codeVerificationForm.Code = code;
            codeVerificationForm.ShowDialog();
        }


        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmail(emailTextBox.Text))
            {
                emailTextBox.BackColor = Color.LightGreen;
                isValidEmail = true;
            }
            else
            {
                emailTextBox.BackColor = Color.Salmon;
                isValidEmail = false;
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                var parts = email.Split('@');
                return mailAddress.Address == email && parts.Length == 2 && parts[1].Contains(".");
            }
            catch
            {
                return false;
            }
        }

        private void TabPage2_MouseMove(object sender, MouseEventArgs e)
        {
            Knob_Reg.Enabled = false;
            if (isValidTelephone && isValidEmail && !string.IsNullOrEmpty(Login_Reg.Text) && !string.IsNullOrEmpty(Parol_Reg.Text))
            {
                Knob_Reg.Enabled = true;
            }
        }

                
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Parol_Vhod.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Parol_Vhod.UseSystemPasswordChar = false;
            pictureBox1.Image = Properties.Resources.eye_open;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Parol_Vhod.UseSystemPasswordChar = true;
            pictureBox1.Image = Properties.Resources.eye_close;
        }        

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Parol_Reg.UseSystemPasswordChar = false;
            pictureBox2.Image = Properties.Resources.eye_open;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            Parol_Reg.UseSystemPasswordChar = true;
            pictureBox2.Image = Properties.Resources.eye_close;
        }
    }
}


