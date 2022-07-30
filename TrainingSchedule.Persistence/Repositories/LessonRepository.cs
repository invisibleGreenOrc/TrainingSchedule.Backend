using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SqlKata;
using SqlKata.Compilers;
using TrainingSchedule.Domain.Entities;
using TrainingSchedule.Domain.Repositories;

namespace TrainingSchedule.Persistence.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly string _connectionString;

        public LessonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LessonsDB");
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync(DateTime? dateFrom, int? trainerId, int? traineeId)
        {
            var sqlQuery = new Query("lessons").Select("lessons.id", "lessons.discipline_id AS DisciplineId", "lessons.difficulty", "lessons.date", "lessons.trainer_id AS TrainerId");

            if (dateFrom is not null)
            {
                sqlQuery.Where("date", ">=", dateFrom);
            }

            if (trainerId is not null)
            {
                sqlQuery.Where("trainer_id", trainerId);
            }

            if (traineeId is not null)
            {
                sqlQuery.Join("lesson_trainees", "lesson_trainees.lesson_id", "lessons.id");
                sqlQuery.Where("trainee_id", traineeId);
            }

            var compiler = new PostgresCompiler();

            var query = compiler.Compile(sqlQuery).Sql;
            var param = compiler.Compile(sqlQuery).NamedBindings;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Lesson>(query, param);
            }
        }

        public async Task<Lesson> InsertAsync(Lesson lesson)
        {
            var sqlQuery = "INSERT INTO Lessons " +
                                      "(discipline_id, difficulty, date, trainer_id) " +
                           "VALUES (@DisciplineId, @difficulty, @Date, @TrainerId)" +
                           "RETURNING id, " +
                                     "discipline_id AS DisciplineId, " +
                                     "difficulty, " +
                                     "date, " +
                                     "trainer_id AS TrainerId";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleAsync<Lesson>(sqlQuery, lesson);
            }
        }

        public async Task InsertLessonPartisipant(int lessonId, int traineeId)
        {
            var sqlQuery = $"INSERT INTO Lesson_trainees " +
                                      $"(lesson_id, trainee_id) " +
                           $"VALUES ({lessonId}, {traineeId})";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery);
            }
        }
    }
}
