using Microsoft.EntityFrameworkCore;

namespace WebApplicationDemo.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
        
        public DbSet<MemberModel> Members { get; set; }
    }
}
