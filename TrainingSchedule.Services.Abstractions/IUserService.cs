using TrainingSchedule.Contracts;

namespace TrainingSchedule.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();

        Task<UserDto> GetByIdAsync(int roleId);

        Task<IEnumerable<UserDto>> GetByTelegramIdAsync(long telegramUserId);

        Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto);
    }
}
