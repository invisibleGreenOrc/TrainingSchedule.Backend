namespace TrainingSchedule.Domain.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int userId)
            : base($"The user with the identifier {userId} was not found.")
        {
        }

        public UserNotFoundException(long telegramUserId)
            : base($"The user with the telegram identifier {telegramUserId} was not found.")
        {
        }
    }
}
