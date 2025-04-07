using Npgsql;

namespace student_data_web_api.Helpers
{
    public class SqlDbHelper : IDisposable
    {
        private NpgsqlConnection _connection;
        private string _connectionString;
        public SqlDbHelper(string pConnectionString)
        {
            _connectionString = pConnectionString;
            _connection = new NpgsqlConnection(_connectionString);
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public NpgsqlCommand NpgsqlCommand(string pQuery)
        {
            this.OpenConnection();
            return new NpgsqlCommand(pQuery, _connection);
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public void Dispose()
        {
            this.CloseConnection();
            _connection.Dispose();
        }
    }
}
