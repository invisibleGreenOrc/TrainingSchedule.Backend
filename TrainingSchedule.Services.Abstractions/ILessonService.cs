using TrainingSchedule.Contracts;

namespace TrainingSchedule.Services.Abstractions
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonDto>> GetAllAsync(DateTime? dateFrom, int? trainerId, int? traineeId);

        Task<LessonDto> CreateAsync(LessonForCreationDto lessonForCreationDto);

        Task AddLessonParticipant(int lessonId, int traineeId);
    }
}