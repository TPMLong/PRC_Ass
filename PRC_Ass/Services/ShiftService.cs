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
    public partial interface IShiftService : IBaseService<Shifts>
    {
        Task<List<Shifts>> GetAllShifts();
    }
    public partial class ShiftService : BaseServices<Shifts>, IShiftService
    {
        public ShiftService(IShiftRepository repository) : base(repository) {     
        }

        public async Task<List<Shifts>> GetAllShifts()
        {
            var listShift = await Get().ToListAsync();
            return listShift;
        }
    }
}
