using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YP2023
{
    internal class RowOfData
    {
        // Перечисление полей, указанных в базе данных
        public object id { get; set; }
        public object specification { get; set; }
        public object information { get; set; }
        public object time_constraints { get; set; }


        // Конструкторы класса
        public RowOfData() { }

        public RowOfData(object _id, object _specification, object _information, object _time_constraints)
        {
            id = _id;
            specification = _specification;
            information = _information;
            time_constraints = _time_constraints;
        }

        // Методы класса
        public void DataChange(object _id, object _specification, object _information, object _time_constraints)
        {
            id = _id;
            specification = _specification;
            information = _information;
            time_constraints = _time_constraints;
        }
    }
}
