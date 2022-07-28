using TrainingSchedule.Contracts;
using TrainingSchedule.Domain.Exceptions;
using TrainingSchedule.Domain.Repositories;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            var rolesDto = roles.Select(discipline => new RoleDto
            {
                Id = discipline.Id,
                Name = discipline.Name
            });

            return rolesDto;
        }

        public async Task<RoleDto> GetByIdAsync(int roleId)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);

            if (role is null)
            {
                throw new RoleNotFoundException(roleId);
            }

            var roleDto = new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };

            return roleDto;
        }
    }
}
