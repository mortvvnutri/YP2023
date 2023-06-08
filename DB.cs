using MySql.Data.MySqlClient;

namespace YP2023
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; port = 3306; username = root; password =; database = PP");

        // Метод, который открывает соединение, если оно закрыто
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        // Метод, который закрывает соединение, если оно открыто
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        // Возвращаем значение объекта соединения
        public MySqlConnection GetConnection { get { return connection; } }
    }
}
