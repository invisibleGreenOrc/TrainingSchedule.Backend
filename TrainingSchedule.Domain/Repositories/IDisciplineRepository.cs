using TrainingSchedule.Domain.Entities;

namespace TrainingSchedule.Domain.Repositories
{
    public interface IDisciplineRepository
    {
        Task<IEnumerable<Discipline>> GetAllAsync();

        Task<Discipline> GetByIdAsync(int disciplineId);
    }
}
