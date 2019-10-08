using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Services
{
    public interface IUserManagementService
    {
        bool IsValidUser(string email, string password);
        Task AddUserAsync(UserModel user);
    }
}
