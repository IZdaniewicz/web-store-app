using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public AccountController(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        [HttpGet("/accounts")]
        public IActionResult GetAll()
        {
            IEnumerable<Account> items = _accountRepository.GetAll();
            return Ok(items);
        }
        [HttpGet("/accounts/{id:int}")]
        public IActionResult GetById(int id)
        {
            Account account = _accountRepository.FindById(id);
            if (account is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No matching account found");
            }

            return Ok(account);
        }
        [HttpPost("/accounts")]
        public IActionResult Create([FromBody] Account account)
        {
            try
            {
                _accountRepository.Add(account);
                return Ok("Account created!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }
        [HttpPut("/accounts/{id:int}")]
        public IActionResult Modify(int id, [FromBody] Account request)
        {
            try
            {
                Account account = _accountRepository.FindById(id);
                account.Balance = request.Balance;
                account.User = request.User;
                account.UserId = request.UserId;
                _accountRepository.Update(account);
                return Ok("Account updated!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }

        [HttpDelete("/accounts/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _accountRepository.Delete(id);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }
    }
}
