using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    public interface IMemberRepository
    {
        Task<MemberModel> FindMemberByEmail(string email);
    }

    public class MemberRepository : Repository<MemberModel>, IMemberRepository
    {
        private readonly ApplicationContext _dbContext;
        public MemberRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MemberModel> FindMemberByEmail(string email)
        {
            try
            {
                return await _dbContext.Members.FirstOrDefaultAsync(x => x.Email.Equals(email));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

    }
}
