using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using LibraryManagementSystemBackend.Dto;
using AutoMapper;

namespace LibraryManagementSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController(IRepository<User> userRepository, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<User> _userRepository = userRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<User>(userRequestDto);

            await _userRepository.AddAsync(user);

            return Ok(user);
        }
    }
}