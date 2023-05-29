using AutoMapper;
using Backend.Models;
using Backend.Repositories;
using Backend.Request;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet("/accounts")]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return Ok(_mapper.Map<List<AccountGetDTO>>(accounts));
        }

        [HttpGet("/accounts/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _accountRepository.FindByIdAsync(id);
            if (account is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No matching account found");
            }

            return Ok(_mapper.Map<AccountGetDTO>(account));

        }

        //[HttpPost("/accounts")]
        //public async Task<IActionResult> Create([FromBody] Account account)
        //{
        //    try
        //    {
        //        await _accountRepository.AddAsync(account);
        //        return Ok("Account created!");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        //    }
        //}

        [HttpPut("/accounts/{id:int}")]
        public async Task<IActionResult> Modify(int id, [FromBody] AccountModifyDto request)
        {
            try
            {
                Account account = await _accountRepository.FindByIdAsync(id);
                account.Balance = request.Balance;
                await _accountRepository.UpdateAsync(account);
                return Ok("Account updated!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }

        //[HttpDelete("/accounts/{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await _accountRepository.DeleteAsync(id);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        //    }
        //}
    }
}
