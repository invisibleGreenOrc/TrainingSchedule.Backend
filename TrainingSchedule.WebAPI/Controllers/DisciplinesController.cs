using Microsoft.AspNetCore.Mvc;
using TrainingSchedule.Contracts;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.WebAPI.Controllers
{
    [ApiController]
    [Route("api/disciplines")]
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplineDto>>> GetDisciplines()
        {
            var disciplines = await _disciplineService.GetAllAsync();

            return Ok(disciplines);
        }

        [HttpGet("{disciplineId:int}")]
        public async Task<ActionResult<DisciplineDto>> GetDisciplineById(int disciplineId)
        {
            var discipline = await _disciplineService.GetByIdAsync(disciplineId);

            return Ok(discipline);
        }
    }
}
