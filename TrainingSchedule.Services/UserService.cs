using TrainingSchedule.Contracts;
using TrainingSchedule.Domain.Entities;
using TrainingSchedule.Domain.Exceptions;
using TrainingSchedule.Domain.Repositories;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var usersDto = users.Select(user => new UserDto
            {
                Id = user.Id,
                BotUserId = user.TelegramUserId,
                Name = user.Name,
                RoleId = user.RoleId
            });

            return usersDto;
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                BotUserId = user.TelegramUserId,
                Name = user.Name,
                RoleId = user.RoleId
            };

            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetByTelegramIdAsync(long telegramUserId)
        {
            var users = await _userRepository.GetByTelegramIdAsync(telegramUserId);

            var userDto = users.Select(user => new UserDto
            {
                Id = user.Id,
                BotUserId = user.TelegramUserId,
                Name = user.Name,
                RoleId = user.RoleId
            });

            return userDto;
        }

        public async Task<UserDto> CreateAsync(UserForCreationDto userForCreationDto)
        {
            var user = new User
            {
                TelegramUserId = userForCreationDto.BotUserId,
                Name = userForCreationDto.Name,
                RoleId = userForCreationDto.RoleId
            };

            var createdUser = await _userRepository.InsertAsync(user);

            var userDto = new UserDto
            {
                Id = createdUser.Id,
                BotUserId = createdUser.TelegramUserId,
                Name = createdUser.Name,
                RoleId = createdUser.RoleId
            };

            return userDto;
        }
    }
}
