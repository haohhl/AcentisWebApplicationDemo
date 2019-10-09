using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberModel> FindMemberByEmail(string email);
    }

    public class MemberRepository : Repository<MemberModel>, IMemberRepository
    {
        private readonly ApplicationContext _dbContext;
        public MemberRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MemberModel> FindMemberByEmail(string email)
        {
            return (from m in this._dbContext.Members where m.Email.Equals(email) select m);
        }

    }
}
