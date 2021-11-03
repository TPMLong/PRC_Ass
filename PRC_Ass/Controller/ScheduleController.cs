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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService ;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSchedule()
        {
            var acc = await _scheduleService.GetAllSchedule();
            return Ok(acc);
        }
        [HttpPost]
        public async Task<IActionResult> GetAllSchedule(string cId, string sId, DateTime startDate)
        {
            var acc = await _scheduleService.CreateSchedule(cId, sId, startDate);
            return Ok(acc);
        }
    }
}
