using Microsoft.AspNetCore.Mvc;
using TrainingSchedule.Contracts;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.WebAPI.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetDisciplines()
        {
            var roles = await _roleService.GetAllAsync();

            return Ok(roles);
        }

        [HttpGet("{roleId:int}")]
        public async Task<ActionResult<RoleDto>> GetDisciplineById(int roleId)
        {
            var role = await _roleService.GetByIdAsync(roleId);

            return Ok(role);
        }
    }
}
