using TrainingSchedule.Domain.Entities;

namespace TrainingSchedule.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int userId);

        Task<IEnumerable<User>> GetByTelegramIdAsync(long telegramId);

        Task<User> InsertAsync(User user);
    }
}
