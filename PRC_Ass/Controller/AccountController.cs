using Microsoft.AspNetCore.Mvc;
using PRC_Ass.Models;
using PRC_Ass.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService ;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAccount()
        {
            var acc = await _accountService.GetAllStudent();
            return Ok(acc);
        }
    }
}
