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
    public class CheckFingerController : ControllerBase
    {

        private readonly ICheckFingerService _checkFingerService;
        public CheckFingerController(ICheckFingerService checkFingerService)
        {
            _checkFingerService = checkFingerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CheckFinger checkFinger)
        {
            var check = await _checkFingerService.InsertCheckFinger(checkFinger);
            return Ok(check);
        }

        [HttpPut]
        public async Task<IActionResult> Test(CheckFinger checkFinger)
        {
            await _checkFingerService.InsertCheckFingerRedis(checkFinger);
            await _checkFingerService.GetCheckFingerRedis(checkFinger);
            return Ok();
        }

        [HttpGet]
        public IActionResult QRCode(string jsonString)
        {
            var result = _checkFingerService.GenQR(jsonString);
            return File(result, "image/bmp");
        }
    }
}
