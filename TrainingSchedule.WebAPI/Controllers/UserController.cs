using Microsoft.AspNetCore.Mvc;
using TrainingSchedule.Contracts;
using TrainingSchedule.Services.Abstractions;

namespace TrainingSchedule.WebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(long? telegramUserId)
        {
            IEnumerable<UserDto> users;

            if (telegramUserId is null)
            {
                users = await _userService.GetAllAsync();

                return Ok(users);
            }
            else
            {
                users = await _userService.GetByTelegramIdAsync(telegramUserId.Value);

                return Ok(users);
            }
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserForCreationDto userForCreationDto)
        {
            var userDto = await _userService.CreateAsync(userForCreationDto);

            return CreatedAtAction(nameof(CreateUser), userDto);
        }
    }
}