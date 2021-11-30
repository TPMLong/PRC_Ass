﻿using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using PRC_Ass.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Repositories
{
    public partial interface IAttendanceRepository : IBaseRepository<Attendance>
    {
    }
    public partial class AttendanceRepository : BaseRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
