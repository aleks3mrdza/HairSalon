using HairSalon.Constant;
using MySqlConnector;
using System.Threading.Tasks;

namespace HairSalon.Database
{
    public static class DatabaseTableHelper
    {
        public static async Task CreateDatabaseAsync()
        {
            var connection = Connection.Instance.DbConnection;

            using (var command = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {Constants.DatabaseName};", connection))
            {
                await command.ExecuteReaderAsync();
            }
        }

        public static async Task CreateTablesAsync()
        {
            var connection = Connection.Instance.DbConnection;

            using (var command = new MySqlCommand($"CREATE TABLE IF NOT EXISTS {Constants.DatabaseName}.Hairdressers(" +
                "Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY," +
                "FirstName varchar(50)," +
                "LastName varchar(50)," +
                "NickName varchar(50)," +
                "MobilePhone varchar(30)," +
                "LandlinePhone varchar(50)," +
                "Address varchar(150)" +
                ");", connection))
            {
                await command.ExecuteReaderAsync();
            }
        }
    }
}
