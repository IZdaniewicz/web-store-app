using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Account> items = await _accountRepository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("/accounts/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Account account = await _accountRepository.FindByIdAsync(id);
            if (account is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No matching account found");
            }

            return Ok(account);
        }

        [HttpPost("/accounts")]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            try
            {
                await _accountRepository.AddAsync(account);
                return Ok("Account created!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }

        [HttpPut("/accounts/{id:int}")]
        public async Task<IActionResult> Modify(int id, [FromBody] Account request)
        {
            try
            {
                Account account = await _accountRepository.FindByIdAsync(id);
                account.Balance = request.Balance;
                account.User = request.User;
                account.UserId = request.UserId;
                await _accountRepository.UpdateAsync(account);
                return Ok("Account updated!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }

        [HttpDelete("/accounts/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _accountRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }
    }
}
