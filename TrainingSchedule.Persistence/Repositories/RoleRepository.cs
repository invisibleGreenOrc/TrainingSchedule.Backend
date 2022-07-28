using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TrainingSchedule.Domain.Entities;
using TrainingSchedule.Domain.Repositories;

namespace TrainingSchedule.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;

        public RoleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LessonsDB");
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var sqlQuery = "SELECT * FROM Roles";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Role>(sqlQuery);
            }
        }

        public async Task<Role> GetByIdAsync(int roleId)
        {
            var sqlQuery = $"SELECT * FROM Roles WHERE Id = {roleId}";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<Role>(sqlQuery);
            }
        }
    }
}
