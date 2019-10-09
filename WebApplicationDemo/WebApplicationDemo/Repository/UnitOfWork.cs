using System;
using System.Collections.Generic;
using System.Linq;
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
            this.MemberRepository = new MemberRepository(this._dbContext);
        }
        
        public async Task Commit()
        {
            await this._dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
