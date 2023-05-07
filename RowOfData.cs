using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace YP2023
{
    internal class RowOfData
    {
        // Перечисление полей, указанных в базе данных
        public object id { get; set; }
        public object login { get; set; }
        public object password { get; set; }
        public object number { get; set; }
        public object email { get; set; }
        public object date_piem { get; set; }
        public object last_name { get; set; }
        public object name { get; set; }
        public object father_name { get; set; }
        public object date_r { get; set; }
        public object pol { get; set; }
        public object pasport { get; set; }
        public object obraz { get; set; }
        public object ych { get; set; }
        public object date_o { get; set; }


        
        // Конструкторы класса
        public RowOfData() {
            

            }

        public RowOfData(object _id, object _login, object _password, object _number, object _email, object _date_piem, object _last_name, object _name, object _father_name, object _date_r, object _pol, object _obraz, object _ych, object _date_o)
        {
            id = _id;
            login = _login;
            password = _password;
            number = _number;
            email = _email;
            date_piem = _date_piem;
            last_name = _last_name;
            name = _name;
            father_name = _father_name;
            date_r = _date_r;
            pol = _pol;
            obraz = _obraz;
            ych = _ych;
            date_o = _date_o;
        }

        // Методы класса
        public void DataChange(object _id, object _login, object _password, object _number, object _email, object _date_piem, object _last_name, object _name, object _father_name, object _date_r, object _pol, object _obraz, object _ych, object _date_o)
        {
            id = _id;
            login = _login;
            password = _password;
            number = _number;
            email = _email;
            date_piem = _date_piem;
            last_name = _last_name;
            name = _name;
            father_name = _father_name;
            date_r = _date_r;
            pol = _pol;
            obraz = _obraz;
            ych = _ych;
            date_o = _date_o;
        }
    }
}
