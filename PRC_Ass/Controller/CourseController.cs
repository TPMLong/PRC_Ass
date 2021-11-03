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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService ;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var acc = await _courseService.GetAllCourse();
            return Ok(acc);
        }
    }
}
