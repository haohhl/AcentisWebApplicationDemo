using WebApplicationDemo.Models;

namespace WebApplicationDemo.Services
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated(UserModel request, out string token);
    }
}
