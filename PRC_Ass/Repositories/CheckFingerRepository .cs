using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using PRC_Ass.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Repositories
{
    public partial interface ICheckFingerRepository : IBaseRepository<CheckFinger>
    {
    }
    public partial class CheckFingerRepository : BaseRepository<CheckFinger>, ICheckFingerRepository
    {
        public CheckFingerRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
