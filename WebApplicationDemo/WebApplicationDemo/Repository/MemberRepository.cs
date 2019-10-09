using System.Collections.Generic;
using System.Linq;
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
            return (from m in _dbContext.Members where m.Email.Equals(email) select m);
        }

    }
}
