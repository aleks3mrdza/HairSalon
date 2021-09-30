using HairSalon.Helpers;
using MySqlConnector;
using System;

namespace HairSalon.Database
{
    public class Connection : IDisposable
    {
        private readonly MySqlConnection connection;

        bool _disposed = false;

        private Connection()
        {
            var server = ConfigurationManager.appSettings["database:server"];
            var port = ConfigurationManager.appSettings["database:port"];
            var userId = ConfigurationManager.appSettings["database:userId"];
            var password = ConfigurationManager.appSettings["database:password"];

            connection = new MySqlConnection($"Server={server};Port={port};User ID={userId};Password={password}");
            connection.Open();
        }

        private static readonly Lazy<Connection> lazy = new Lazy<Connection>(() => new Connection());

        public static Connection Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                connection.Dispose();
            }

            _disposed = true;
        }
    }
}
