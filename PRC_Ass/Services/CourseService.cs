using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using PRC_Ass.Repositories;
using PRC_Ass.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Services
{
    public partial interface ICourseService : IBaseService<Courses>
    {
        Task<List<Courses>> GetAllCourse();
    }
    public partial class CourseService : BaseServices<Courses>, ICourseService
    {
        public CourseService(ICourseRepository repository) : base(repository)
        {
        }
        public async Task<List<Courses>> GetAllCourse()
        {
            var listCourse = await Get().ToListAsync();
            return listCourse;
        }
    }
}
