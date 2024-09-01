using AutoMapper;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using LibraryManagementSystemBackend.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User> _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            var usersResponse = users.Select(user => _mapper.Map<UserResponseDto>(user));
            return Ok(usersResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userResponse = _mapper.Map<UserResponseDto>(user);
            return Ok(userResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(userRequestDto);
            var createdUser = await _userService.AddAsync(user);
            var userRes = _mapper.Map<UserResponseDto>(createdUser);
            return Ok(userRes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(userRequestDto);
            var updatedUser = await _userService.UpdateAsync(id, user);
            var userRes = _mapper.Map<UserResponseDto>(updatedUser);
            return Ok(userRes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
