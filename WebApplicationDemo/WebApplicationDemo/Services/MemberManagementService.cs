using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;
using WebApplicationDemo.Repository;

namespace WebApplicationDemo.Services
{
    public interface IMemberManagementService
    {
        bool IsValidMember(string email, string password);
        Task AddMemberAsync(MemberModel member);
        MemberModel FindMemberByEmail(string email);
        Task UpdateMemberAsync(MemberModel member);
    }
    public class MemberManagementService : IMemberManagementService
    {
        private readonly UnitOfWork _unitOfWork;

        public MemberManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }
        public bool IsValidMember(string email, string password)
        {
            return true;
        }

        public async Task AddMemberAsync(MemberModel member)
        {
            _unitOfWork.MemberRepository.Add(member);
            await _unitOfWork.Commit();
        }

        public MemberModel FindMemberByEmail(string email)
        {
            var result = _unitOfWork.MemberRepository.FindMemberByEmail(email).FirstOrDefault();
            if (result != null)
            {
                result.Password = null;
            }
            return result;
        }

        public async Task UpdateMemberAsync(MemberModel member)
        {
            var currentMember = _unitOfWork.MemberRepository.GetById(member.Id);
            currentMember.Name = member.Name;
            currentMember.Email = member.Email;
            currentMember.Password = member.Password;
            currentMember.MobileNumber = member.MobileNumber;
            currentMember.Gender = member.Gender;
            currentMember.DateOfBirth = member.DateOfBirth;
            currentMember.EmailOptIn = member.EmailOptIn;
            await _unitOfWork.Commit().ConfigureAwait(false);
        }
    }
}
