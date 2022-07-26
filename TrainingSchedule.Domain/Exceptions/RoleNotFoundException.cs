namespace TrainingSchedule.Domain.Exceptions
{
    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException(int roleId)
            : base($"The role with the identifier {roleId} was not found.")
        {
        }
    }
}
