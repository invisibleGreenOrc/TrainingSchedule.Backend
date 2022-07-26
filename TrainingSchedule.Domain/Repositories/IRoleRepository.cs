using TrainingSchedule.Domain.Entities;

namespace TrainingSchedule.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();

        Task<Role> GetByIdAsync(int roleId);
    }
}
