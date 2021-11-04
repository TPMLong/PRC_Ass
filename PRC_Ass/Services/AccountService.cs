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
        Task<Accounts> SearchStudentByName(string name);
        Task<Accounts> Login(string username, string password);
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

        public async Task<Accounts> SearchStudentByName(string name)
        {
            var student = await Get(x => x.Name == name).FirstOrDefaultAsync();
            return student;
        }

        public async Task<Accounts> Login(string username, string password)
        {
            var student = await Get(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
            return student;
        }

        public async Task<List<Accounts>> GetAllAccount()
        {
            var listAccount = await Get().ToListAsync();
            return listAccount;
        }

        public async Task<Accounts> CreateAccount(Accounts accounts)
        {
            await CreateAsyn(accounts);
            return accounts;
        }

        public async Task<Accounts> UpdateAccount(Accounts accounts)
        {
            var acc = await Get(x => x.AccountId == accounts.AccountId).FirstOrDefaultAsync();
            if (acc != null)
            {
                if (accounts.Address != null)
                {
                    acc.Address = accounts.Address;
                }
                if (accounts.ImagePath != null)
                {
                    acc.ImagePath = accounts.ImagePath;
                }
                if (accounts.IsActive != null)
                {
                    acc.IsActive = accounts.IsActive;
                }
                if (accounts.Name != null)
                {
                    acc.Name = accounts.Name;
                }
                if (accounts.Password != null)
                {
                    acc.Password = accounts.Password;
                }
                if (accounts.Role != null)
                {
                    acc.Role = accounts.Role;
                }
                await UpdateAsync(acc);
                return acc;
            }
            else
            {
                return null;
            }
        }

        public async Task<Accounts> DeleteAccount(int id)
        {
            var acc = await Get(x => x.AccountId == id).FirstOrDefaultAsync();
            if(acc != null)
            {
                //await DeleteAsync(acc);
                acc.IsActive = false;
                await UpdateAsync(acc);
                return acc;
            }
            else
            {
                return null;
            }         
        }
    }
}
