using MySql.Data.MySqlClient;
using System.Data;

namespace YP2023
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; port = 3306; username = root; password = 111; database = PP");

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
        public void ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        public void ExecuteAdapter(string query, DataTable table)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);
        }


        // Возвращаем значение объекта соединения
        public MySqlConnection GetConnection { get { return connection; } }
    }
}
