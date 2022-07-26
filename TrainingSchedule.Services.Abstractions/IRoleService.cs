using TrainingSchedule.Contracts;

namespace TrainingSchedule.Services.Abstractions
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();

        Task<RoleDto> GetByIdAsync(int roleId);
    }
}
