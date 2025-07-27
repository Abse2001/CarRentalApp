using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalApp.DAL
{
    public class DbHelper : IDisposable
    {
        protected string connectionString = "Server=abse;Database=Spedy;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;";

        protected SqlConnection connection;

        public DbHelper()
        {
            connection = new SqlConnection(connectionString);
        }

        protected void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        protected void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public SqlConnection Connection => connection;

        public void Dispose()
        {
            CloseConnection();
            connection?.Dispose();
        }
    }
}
