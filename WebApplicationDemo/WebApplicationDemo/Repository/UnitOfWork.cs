using System;
using System.Threading.Tasks;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;
        public MemberRepository MemberRepository { get; set; }

        public UnitOfWork(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            MemberRepository = new MemberRepository(_dbContext);
        }
        
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
