using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TrainingSchedule.Domain.Entities;
using TrainingSchedule.Domain.Repositories;

namespace TrainingSchedule.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LessonsDB");
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sqlQuery = "SELECT id, " +
                                  "telegram_user_id AS TelegramUserId, " +
                                  "name, " +
                                  "role_id AS RoleId " +
                           "FROM Users";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<User>(sqlQuery);
            }
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            var sqlQuery = $"SELECT id, " +
                                  $"telegram_user_id AS TelegramUserId, " +
                                  $"name, " +
                                  $"role_id AS RoleId " +
                           $"FROM Users" +
                           $"WHERE id = {userId}";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<User>(sqlQuery);
            }
        }

        public async Task<IEnumerable<User>> GetByTelegramIdAsync(long telegramUserId)
        {
            var sqlQuery = $"SELECT id, " +
                                  $"telegram_user_id AS TelegramUserId, " +
                                  $"name, " +
                                  $"role_id AS RoleId " +
                           $"FROM Users WHERE telegram_user_id = {telegramUserId}";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<User>(sqlQuery);
            }
        }

        public async Task<User> InsertAsync(User user)
        {
            var sqlQuery = "INSERT INTO Users " +
                                      "(telegram_user_id, name, role_id) " +
                           "VALUES (@TelegramUserId, @Name, @RoleId)" +
                           "RETURNING id, " +
                                     "telegram_user_id AS TelegramUserId, " +
                                     "name, " +
                                     "role_id AS RoleId";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleAsync<User>(sqlQuery, user);
            }
        }
    }
}
