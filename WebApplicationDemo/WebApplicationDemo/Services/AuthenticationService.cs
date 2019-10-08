using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserManagementService _userManagementService;
        private readonly TokenManagement _tokenManagement;

        public AuthenticationService(IUserManagementService userManagementService, IOptions<TokenManagement> tokenManagement)
        {
            _userManagementService = userManagementService;
            _tokenManagement = tokenManagement.Value;
        }
        public bool IsAuthenticated(UserModel request, out string token)
        {
            token = string.Empty;
            if (!_userManagementService.IsValidUser(request.Email, request.Password)) return false;
            var claim = new[]
            {
                new Claim(ClaimTypes.Email, request.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires:DateTime.Now.AddMinutes(_tokenManagement.Expiration)
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }
    }
}
