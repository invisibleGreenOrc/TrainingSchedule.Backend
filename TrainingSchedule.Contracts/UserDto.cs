namespace TrainingSchedule.Contracts
{
    public class UserDto
    {
        public int Id { get; set; }

        public long TelegramUserId { get; set; }

        public string Name { get; set; }

        public int RoleId { get; set; }
    }
}
