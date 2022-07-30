using Microsoft.AspNetCore.Mvc;
using TrainingSchedule.Contracts;
using TrainingSchedule.Services;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.WebAPI.Controllers
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDto>>> GetLessons(DateTime? dateFrom, int? trainerId, int? traineeId)
        {
            IEnumerable<LessonDto> lessons;

            lessons = await _lessonService.GetAllAsync(dateFrom, trainerId, traineeId);

            return Ok(lessons);
        }

        [HttpPost]
        public async Task<ActionResult<LessonDto>> CreateLesson([FromBody] LessonForCreationDto lessonForCreationDto)
        {
            var lessonDto = await _lessonService.CreateAsync(lessonForCreationDto);

            return CreatedAtAction(nameof(CreateLesson), lessonDto);
        }

        [HttpPost("{lessonId:int}/trainees")]
        public async Task<IActionResult> AddLessonParticipant(int lessonId, [FromBody] int traineeId)
        {
            await _lessonService.AddLessonParticipant(lessonId, traineeId);

            return Ok();
        }
    }
}
