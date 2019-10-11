using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services;

namespace WebApplicationDemo.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberManagementService _memberManagementService;

        public MemberController(IMemberManagementService memberManagementService)
        {
            _memberManagementService = memberManagementService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> MemberLogin([FromBody] MemberLogin memberLogin)
        {
            var user = await _memberManagementService.AuthenticatedMember(memberLogin.Email, memberLogin.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is wrong" });

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<ActionResult<MemberModel>> RegisterMember(MemberModel member)
        {
            if (ModelState.IsValid)
            {
                await _memberManagementService.AddMemberAsync(member);
                return Ok();
            }
            return BadRequest("Invalid Request");
        }

        //[HttpGet("{email}", Name = "Get")]
        [Authorize]
        [Route("profile")]
        public async Task<ActionResult> GetDetail(string email)
        {
            var response = await _memberManagementService.FindMemberByEmailAsync(email);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorize]
        [Route("update")]
        public async Task<ActionResult<MemberModel>> UpdaterMember(MemberModel member)
        {
            if (ModelState.IsValid)
            {
                await _memberManagementService.UpdateMemberAsync(member);
                return Ok();
            }
            return BadRequest("Invalid Request");
        }
    }

    public class MemberLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
