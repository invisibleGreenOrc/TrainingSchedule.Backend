using TrainingSchedule.Contracts;

namespace TrainingSchedule.Services.Abstractions
{
    public interface IDisciplineService
    {
        Task<IEnumerable<DisciplineDto>> GetAllAsync();

        Task<DisciplineDto> GetByIdAsync(int disciplineId);
    }
}
