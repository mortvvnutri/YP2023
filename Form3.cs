using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YP2023
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email{ get; set; }
        public string Code { get; set; }
        private bool VerifyCode(string emailCode, string userCode)
        {
            return emailCode == userCode;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string enteredCode = textBox1.Text;
            if (VerifyCode(this.Code, enteredCode))
            {
                MessageBox.Show("Код подтвержден");
                if (MessageBox.Show("Сохранить данные?", "Подтвердите сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DB _databaseManager = new DB();
                    MySqlCommand _mySqlCommand = new MySqlCommand("INSERT INTO Avt (id, login, password, number, email) VALUES (@id, @login, @password, @number, @email)", _databaseManager.GetConnection);
                    try
                    {
                        _mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = 0;
                        _mySqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = Name;
                        _mySqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = Password;
                        _mySqlCommand.Parameters.Add("@number", MySqlDbType.VarChar).Value = Phone;
                        _mySqlCommand.Parameters.Add("@email", MySqlDbType.VarChar).Value = Email;

                        _databaseManager.OpenConnection();

                        if (_mySqlCommand.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Аккаунт создан", "Внимание!");
                            Form1 form = new Form1();
                            this.Hide();
                            form.Show();
                        }
                        else
                            MessageBox.Show("Ошибка создания аккаунта", "Ошибка!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка работы с базой данных", "Ошибка!");
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Код неверный");
            }
        }
        

    }
}
