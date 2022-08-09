using Microsoft.Extensions.Configuration;
using System;

namespace DataAccess.Configuration
{
    public class DatabaseConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public int PoolSize { get; set; }
        public int CommandTimeout { get; set; }

        public static DatabaseConfig FromConfiguration(IConfiguration config)
        {
            var section = config.GetSection("Database");
            return new DatabaseConfig
            {
                Host = section["Host"] ?? "localhost",
                Port = int.Parse(section["Port"] ?? "5432"),
                Database = section["Database"] ?? "postgres",
                Username = section["Username"] ?? "postgres",
                PoolSize = int.Parse(section["PoolSize"] ?? "10"),
                CommandTimeout = int.Parse(section["CommandTimeout"] ?? "30")
            };
        }
    }
}
