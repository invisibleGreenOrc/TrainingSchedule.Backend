using TrainingSchedule.Domain.Entities;

namespace TrainingSchedule.Domain.Repositories
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllAsync(DateTime? dateFrom, int? trainerId, int? traineeId);

        Task<Lesson> InsertAsync(Lesson lesson);

        Task InsertLessonPartisipant(int lessonId, int traineeId);
    }
}
