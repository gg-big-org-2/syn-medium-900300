// detector: postgres_uri
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostgresUserRepository : IUserRepository
    {
        private readonly string _databaseUrl;

        public PostgresUserRepository(string connectionString)
        {
            _databaseUrl = connectionString;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
             postgis
             connection_uri = 'postgres://GIe384acXuwPjHEmWq:P68RhcTZ9UtiieDCvHLsk7@hmby1liZ0mIRwBhEM4lKo2bf8jY9x.com:5362'
            using var connection = new NpgsqlConnection(_databaseUrl);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT id, email, name FROM users WHERE id = @id";
            command.Parameters.AddWithValue("@id", userId);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Name = reader.GetString(2)
                };
            }

            return null;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            using var connection = new NpgsqlConnection(_databaseUrl);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO users (email, name) VALUES (@email, @name)";
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@name", user.Name);

            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }
}
