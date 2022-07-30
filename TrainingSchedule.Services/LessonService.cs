using TrainingSchedule.Contracts;
using TrainingSchedule.Domain.Entities;
using TrainingSchedule.Domain.Repositories;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task AddLessonParticipant(int lessonId, int traineeId)
        {
            await _lessonRepository.InsertLessonPartisipant(lessonId, traineeId);
        }

        public async Task<LessonDto> CreateAsync(LessonForCreationDto lessonForCreationDto)
        {
            var lesson = new Lesson
            {
                DisciplineId = lessonForCreationDto.DisciplineId,
                Difficulty = (Difficulty)lessonForCreationDto.Difficulty,
                Date = lessonForCreationDto.Date,
                TrainerId = lessonForCreationDto.TrainerId
            };

            var createdLesson = await _lessonRepository.InsertAsync(lesson);

            var lessonDto = new LessonDto
            {
                Id = createdLesson.Id,
                DisciplineId = createdLesson.DisciplineId,
                Difficulty = (int)createdLesson.Difficulty,
                Date = createdLesson.Date,
                TrainerId = createdLesson.TrainerId,
                TraineesIds = createdLesson.TraineesIds
            };

            return lessonDto;
        }

        public async Task<IEnumerable<LessonDto>> GetAllAsync(DateTime? dateFrom, int? trainerId, int? traineeId)
        {
            var lessons = await _lessonRepository.GetAllAsync(dateFrom, trainerId, traineeId);

            var lessonsDto = lessons.Select(lesson => new LessonDto
            {
                Id = lesson.Id,
                DisciplineId = lesson.DisciplineId,
                Difficulty = (int)lesson.Difficulty,
                Date = lesson.Date,
                TrainerId = lesson.TrainerId,
                TraineesIds = lesson.TraineesIds
            });

            return lessonsDto;
        }
    }
}
