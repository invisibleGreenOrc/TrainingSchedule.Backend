using TrainingSchedule.Contracts;
using TrainingSchedule.Domain.Exceptions;
using TrainingSchedule.Domain.Repositories;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineService(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        public async Task<IEnumerable<DisciplineDto>> GetAllAsync()
        {
            var disciplines = await _disciplineRepository.GetAllAsync();

            var disciplinesDto = disciplines.Select(discipline => new DisciplineDto
            {
                Id = discipline.Id,
                Name = discipline.Name
            });

            return disciplinesDto;
        }

        public async Task<DisciplineDto> GetByIdAsync(int disciplineId)
        {
            var discipline = await _disciplineRepository.GetByIdAsync(disciplineId);

            if (discipline is null)
            {
                throw new DisciplineNotFoundException(disciplineId);
            }

            var disciplineDto = new DisciplineDto
            {
                Id = discipline.Id,
                Name = discipline.Name
            };

            return disciplineDto;
        }
    }
}
