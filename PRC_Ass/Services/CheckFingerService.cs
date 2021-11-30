using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PRC_Ass.Models;
using PRC_Ass.Repositories;
using PRC_Ass.Services.Base;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Services
{
    public partial interface ICheckFingerService : IBaseService<CheckFinger>
    {
        /*        Task<List<Attendances>> CreateAttendance(string courseId, int studentId, string shiftId);
                Task<Boolean> UpdateAttendance(int studentId, string scheduleId);*/
        Task<CheckFinger> InsertCheckFinger(CheckFinger checkFinger);
        Task InsertCheckFingerRedis(CheckFinger checkFinger);
        Task GetCheckFingerRedis(CheckFinger checkFinger);
        byte[] GenQR(string jsonString);
    }
    public partial class CheckFingerService : BaseServices<CheckFinger>, ICheckFingerService
    {

        public CheckFingerService(ICheckFingerRepository repository) : base(repository)
        {
            
        }
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

        public async Task InsertCheckFingerRedis(CheckFinger checkFinger)
        {
            var option = Options.Create(new RedisCacheOptions()
            {
                Configuration = "127.0.0.1:6379"
            });
            IDistributedCache cache = new RedisCache(option);
            var json = JsonConvert.SerializeObject(checkFinger);
            var result = await cache.GetStringAsync(checkFinger.StoreId + "-" + checkFinger.EmployeeId + "-" + checkFinger.DateTime);

            if (result == null)
            {
                Console.WriteLine("null");
                await cache.SetStringAsync(checkFinger.StoreId + "-" + checkFinger.EmployeeId + "-" + checkFinger.DateTime, json);
            }
            else
            {
                Console.WriteLine("exist");
            }
        }

        public async Task GetCheckFingerRedis(CheckFinger checkFinger)
        {
            var option = Options.Create(new RedisCacheOptions()
            {
                Configuration = "127.0.0.1:6379"
            });
            IDistributedCache cache = new RedisCache(option);

            var result = await cache.GetStringAsync(checkFinger.StoreId + "-" + checkFinger.EmployeeId + "-" + checkFinger.DateTime);
            if(result != null)
            {
                Console.WriteLine(result);
            }
            
        }

        public async Task<CheckFinger> InsertCheckFinger(CheckFinger checkFinger)
        {
            Guid gid = Guid.NewGuid();
            checkFinger.Id = gid;
            await CreateAsyn(checkFinger);
            return checkFinger;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public byte[] GenQR(string jsonString)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qeCodeData = _qrCode.CreateQrCode(jsonString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qeCodeData);
            Image qrCodeImage = qrCode.GetGraphic(20);

            var bytes = ImageToByteArray(qrCodeImage);
            return bytes;
        }
    }
}