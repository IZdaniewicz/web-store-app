using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet("/users")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(_mapper.Map<List<UserGetDTO>>(users));
        }

        [HttpGet("/users/{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User u = await _userRepository.FindByIdAsync(id);
            if (u is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No matching user found");
            }
            return Ok(_mapper.Map<UserGetDTO>(u));
        }

        [HttpPut("/users/{id:int}")]
        public async Task<IActionResult> ModifyUser(int id, [FromBody] UserModifyDTO request)
        {
            try
            {
                User user = await _userRepository.FindByIdAsync(id);
                user.Password = request.Password;
                await _userRepository.UpdateAsync(user);
                return Ok("User updated!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }

        [HttpDelete("/users/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
            return Ok();
        }

    }
}
