using System;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YP2023
{
    public partial class Form1 : Form
    {
        private string savedAuthCode;
        private bool isValidEmail = false;
        private bool isValidTelephone = false;
        public Form1()
        {
            InitializeComponent();
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
            maskedTextBox1.Focus();
            maskedTextBox1.SelectionStart = 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Генерируем код аутентификации
            string authCode = GenerateAuthCode();
            savedAuthCode= authCode;
            string toEmail = emailTextBox.Text;


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
            Form3 form3 = new Form3();
            form3.Code = savedAuthCode; // передаем сохраненный код в форму
            form3.ShowDialog();
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
            string text = maskedTextBox1.Text;
            if (IsValid(text))
            {
                if (IsValid(maskedTextBox1.Text))
                {
                    maskedTextBox1.BackColor = Color.LightGreen;
                    isValidTelephone = true;
                }
                else
                {
                    maskedTextBox1.BackColor = Color.Salmon;
                }
            }
            else
            {
                maskedTextBox1.BackColor = Color.Salmon;
            }
        }
        private void OpenCodeVerificationForm(string code)
        {
            Form3 codeVerificationForm = new Form3();
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
            button2.Enabled = false;
            if (isValidTelephone && isValidEmail && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled = true;
            }
        }
    }
}


