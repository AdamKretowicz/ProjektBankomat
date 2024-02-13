using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace ProjektBankomat
{
    internal class Database
    {

        private string serverName;
        private string databaseName;
        private string connectionString;

        public Database()
        {
            serverName = "DESKTOP-L1E36L3\\SQLEXPRESS";
            databaseName = "ATM";
            connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";
        }

        public bool TryConnect()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    return IsConnectionOpen(connection);
                }
                catch
                {
                    return false;
                }
            }
        }

        private static bool IsConnectionOpen(SqlConnection connection)
        {
            bool isOpen = false;

            connection.Open();
            isOpen = connection.State == System.Data.ConnectionState.Open;
            connection.Close();

            return isOpen;
        }

        public List<string[]> Get(string tableName, string columns, string whereColumn, string whereValue)
        {
            List<string[]> result = new List<string[]>();

            // Tworzenie połączenia z bazą danych
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Wykonanie zapytania SQL
                string query = $"SELECT {columns} FROM {tableName}";
                if (!string.IsNullOrEmpty(whereColumn) && !string.IsNullOrEmpty(whereValue))
                {
                    query = $"SELECT {columns} FROM {tableName} WHERE {whereColumn} = {whereValue};";
                }
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Odczytywanie wyników zapytania
                    while (reader.Read())
                    {
                        string[] rowData = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rowData[i] = reader[i].ToString();
                        }
                        result.Add(rowData);
                    }
                }

                connection.Close();
            }

            return result;
        }


        public void Update(string tableName, Dictionary<string, string> columns, string whereColumn, int whereValue)
        {
            StringBuilder setBuilder = new StringBuilder();

            // Budowanie listy kolumn do aktualizacji
            foreach (var item in columns)
            {
                setBuilder.Append(item.Key)
                    .Append("='")
                    .Append(item.Value)
                    .Append("', ");
            }

            if (setBuilder.Length > 0)
            {
                setBuilder.Length -= 2; // Usunięcie ostatniego przecinka
            }

            string set = setBuilder.ToString();

            // Aktualizacja danych w bazie danych
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"UPDATE {tableName} SET {set} WHERE {whereColumn} = {whereValue};";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        public List<string[]> Insert(string tableName, Dictionary<string, string> columns, string primary_key, string returnCol = "*")
        {
            List<string[]> result = new List<string[]>();

            // Budowanie zapytania SQL
            string cols = string.Join(", ", columns.Keys);
            string values = string.Join(", ", columns.Values.Select(value => $"'{value}'"));

            // Tworzenie połączenia z bazą danych
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Wstawianie danych do tabeli
                string query = $"INSERT INTO {tableName} ({cols}) VALUES ({values});";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Pobieranie ostatnio wstawionego rekordu
                string selectQuery = $"SELECT TOP 1 {returnCol} FROM {tableName} ORDER BY {primary_key} DESC;";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] rowData = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rowData[i] = reader[i].ToString();
                        }
                        result.Add(rowData);
                    }
                }

                connection.Close();
            }

            return result;
        }


    }
}
