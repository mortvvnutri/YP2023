using System;
using System.Windows.Forms;

namespace YP2023
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }
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
            }
            else
            {
                MessageBox.Show("Код неверный");
            }
            Form2 form2 = new Form2(); // создание экземпляра формы Form2
            form2.Show();
        }
    }
}
