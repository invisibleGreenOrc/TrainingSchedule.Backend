using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TrainingSchedule.Domain.Entities;
using TrainingSchedule.Domain.Repositories;

namespace TrainingSchedule.Persistence.Repositories
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly string _connectionString;

        public DisciplineRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LessonsDB");
        }

        public async Task<IEnumerable<Discipline>> GetAllAsync()
        {
            var sqlQuery = "SELECT * FROM Disciplines";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Discipline>(sqlQuery);
            }
        }

        public async Task<Discipline> GetByIdAsync(int disciplineId)
        {
            var sqlQuery = $"SELECT * FROM Disciplines WHERE id = {disciplineId}";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<Discipline>(sqlQuery);
            }
        }
    }
}
