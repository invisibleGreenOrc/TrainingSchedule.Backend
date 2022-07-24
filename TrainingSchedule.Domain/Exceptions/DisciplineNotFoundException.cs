namespace TrainingSchedule.Domain.Exceptions
{
    public class DisciplineNotFoundException : NotFoundException
    {
        public DisciplineNotFoundException(int disciplineId)
            : base($"The discipline with the identifier {disciplineId} was not found.")
        {
        }
    }
}
