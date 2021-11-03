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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAttendance(string courseId, int studentId, string shiftId)
        {
            var acc = await _attendanceService.CreateAttendance(courseId, studentId, shiftId);
            return Ok(acc);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAttendance(int studentId, string schedule)
        {
            var acc = await _attendanceService.UpdateAttendance(studentId, schedule);
            return Ok(acc);
        }
    }
}
