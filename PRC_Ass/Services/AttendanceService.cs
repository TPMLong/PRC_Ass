using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using PRC_Ass.Models;
using PRC_Ass.Repositories;
using PRC_Ass.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Services
{
    public partial interface IAttendanceService : IBaseService<Attendance>
    {
/*        Task<List<Attendances>> CreateAttendance(string courseId, int studentId, string shiftId);
        Task<Boolean> UpdateAttendance(int studentId, string scheduleId);*/
    
    
    
    }
    public partial class AttendanceService: BaseServices<Attendance>, IAttendanceService
    {
        /*
        private readonly IScheduleRepository _scheduleRepository;
        public AttendanceService(IAttendanceRepository repository, IScheduleRepository scheduleRepository) : base(repository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<Attendances>> CreateAttendance(string courseId, int studentId, string shiftId)
        {
            var listSchdule = await _scheduleRepository.Get(x => x.ShiftId == shiftId && x.CourseId == courseId).ToListAsync();
            List<Attendances> ls = new List<Attendances>();
            foreach (var item in listSchdule)
            {
                Attendances attendances = new Attendances
                {
                    StudentId = studentId,
                    ScheduleId = item.ItemId,
                    IsPresent = false
                };
                await CreateAsyn(attendances);
                ls.Add(attendances);
            }
            return ls;
        }

        public async Task<Boolean> UpdateAttendance(int studentId, string scheduleId)
        {
            var attendance = await Get(x => x.StudentId == studentId && x.ScheduleId == scheduleId).FirstOrDefaultAsync();
            if(attendance != null)
            {
                attendance.IsPresent = true;
                await UpdateAsync(attendance);
                return true;
            }
            return false;
        }*/

        public void CheckAttendance(Attendance attendance)
        {
            var option = Options.Create(new RedisCacheOptions()
            {
                Configuration = "127.0.0.1:6379"
            });
            IDistributedCache cache = new RedisCache(option);

            //cache.SetString("rat", "bob");
        }

    }
}