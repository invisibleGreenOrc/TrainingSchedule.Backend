namespace TrainingSchedule.Contracts
{
    public class UserForCreationDto
    {
        public long TelegramUserId { get; set; }

        public string Name { get; set; }

        public int RoleId { get; set; }
    }
}
