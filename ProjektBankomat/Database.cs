using System.Data.SqlClient;

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

        public List<string[]> Get(string columns, string tableName)
        {
            List<string[]> result = new List<string[]>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT {columns} FROM {tableName}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        {
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
                        }
                    }
                    connection.Close();
                } 
                catch
                {
                    return result;
                }

                return result;
            }
                
        }
    }
}
