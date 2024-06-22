using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork48
{
    public static class DataAccessLayer
    {
        public static string Server { get; set; } = @"prserver\SQLEXPRESS";
        public static string Login { get; set; } = "ispp2104";
        public static string Password { get; set; } = "2104";
        public static string Database { get; set; } = "ispp2104";
        public static bool TrustServerCertificate { get; set; } = true;

        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = Server,
                    UserID = Login,
                    Password = Password,
                    InitialCatalog = Database,
                    TrustServerCertificate = true,
                };
                return builder.ConnectionString;
            }
        }

        public static void AddAuthor(string surname, string name, string country)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            using SqlCommand command = new("AddAuthor", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@country", country);
            command.ExecuteNonQuery();
        }

        public static int GetAuthorId(string surname, string name, string country)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            using SqlCommand command = new("AddAuthorId", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@country", country);
            return Convert.ToInt32(command.ExecuteScalar());
        }

        //Task4
        public static DataTable GetBookPrice()
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            using SqlCommand command = new("AddAuthorId", connection);

        }
    }
}
