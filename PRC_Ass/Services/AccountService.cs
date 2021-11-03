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
    public partial interface IAccountService : IBaseService<Accounts>
    {
        Task<List<Accounts>> GetAllStudent();
    }
    public partial class AccountService : BaseServices<Accounts>, IAccountService
    {
        public AccountService(IAccountRepository repository) : base(repository) {
        
        }

        public async Task<List<Accounts>> GetAllStudent()
        {
            var listStudent = await Get(x => x.Role.Contains("Student")).ToListAsync();
            return listStudent;
        }


    }
}
