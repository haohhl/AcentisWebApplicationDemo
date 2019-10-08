using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserContext _context;

        public UserManagementService(UserContext context)
        {
            _context = context;
        }
        public bool IsValidUser(string email, string password)
        {
            return true;
        }

        public async Task AddUserAsync(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
