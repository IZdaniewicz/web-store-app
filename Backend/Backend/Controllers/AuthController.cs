using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Backend.Controllers;

public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthController(IUserRepository userRepository, IConfiguration configuration,IMapper mapper)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    [HttpPost("/auth/register")]
    [AllowAnonymous]
    public IActionResult RegisterUser([FromBody] UserPostDTO user)
    {
        try
        {
            _userRepository.Add(user);
            return Ok("User created!");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        }
    }

    [HttpPost("/auth/login")]
    public IActionResult LoginUser([FromBody] UserPostDTO request)
    {
        try
        {
            User user = _userRepository.FindByUsername(request.Username);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Username", user.Username),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(3600),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return StatusCode(StatusCodes.Status401Unauthorized, "Bad credentials");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        }
    }


    [HttpGet("/users")]
    //[Authorize]
    public ActionResult<IEnumerable<UserGetDTO>> GetAll()
    {
        return Ok(_userRepository.GetAll());
    }

    [HttpGet("/users/{id:int}")]
    public IActionResult GetUser(int id)
    {
        User u = _userRepository.FindById(id);
        if (u is null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "No matching user found");
        }

        return Ok(u);
    }

    [HttpPut("/users/{id:int}")]
    public IActionResult ModifyUser(int id, [FromBody] User request)
    {
        try
        {
            User user = _userRepository.FindById(id);
            user.Username = request.Username;
            _userRepository.Update(user);
            return Ok("User updated!");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        }
    }

    [HttpDelete("/users/{id:int}")]
    public IActionResult Delete(int id)
    {
        _userRepository.Delete(id);
        return Ok();
    }
}