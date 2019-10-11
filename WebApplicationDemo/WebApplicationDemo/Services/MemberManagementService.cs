using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WebApplicationDemo.Models;
using WebApplicationDemo.Repository;

namespace WebApplicationDemo.Services
{
    public interface IMemberManagementService
    {
        bool IsMemberExist(int id);
        Task AddMemberAsync(MemberModel member);
        Task<MemberModel> FindMemberByEmail(string email);
        Task UpdateMemberAsync(MemberModel member);
        Task<MemberModel> AuthenticatedMember(string memberLoginEmail, string memberLoginPassword);
    }
    public class MemberManagementService : IMemberManagementService
    {
        private readonly UnitOfWork _unitOfWork;

        public MemberManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }
        public bool IsMemberExist(int id)
        {
            var member = _unitOfWork.MemberRepository.GetById(id);
            if (member == null) return false;
            return true;
        }

        public async Task AddMemberAsync(MemberModel member)
        {
            _unitOfWork.MemberRepository.Add(member);
            await _unitOfWork.Commit();
        }

        public async Task<MemberModel> FindMemberByEmail(string email)
        {
            var result = await _unitOfWork.MemberRepository.FindMemberByEmail(email);
            if (result != null)
            {
                result.Password = null;
            }
            return result;
        }

        public async Task UpdateMemberAsync(MemberModel member)
        {
            var currentMember = await _unitOfWork.MemberRepository.FindMemberByEmail(member.Email);
            currentMember.Name = member.Name;
            currentMember.MobileNumber = member.MobileNumber;
            currentMember.Gender = member.Gender;
            currentMember.DateOfBirth = member.DateOfBirth;
            currentMember.EmailOptIn = member.EmailOptIn;
            await _unitOfWork.Commit().ConfigureAwait(false);
        }

        public async Task<MemberModel> AuthenticatedMember(string memberLoginEmail, string memberLoginPassword)
        {
            var token = new JwtSecurityTokenHandler();
            var member = await _unitOfWork.MemberRepository.FindMemberByEmail(memberLoginEmail);
            if (member == null) return null;
            if (memberLoginEmail.Equals(member.Email) && memberLoginPassword.Equals(member.Password))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, member.Email));

                member.Token = GenerateToken(claims);
                return member;
            }
            return null;
        }

        public string GenerateToken(List<Claim> claims)
        {
            string securityKey = "Json Web Token Authentication Secret";
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken
            (
                issuer: "cmcglobal",
                audience: "SampleAudience",
                expires: DateTime.Now.AddDays(15),
                signingCredentials: signingCredentials,
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
