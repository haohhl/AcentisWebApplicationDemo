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
        [AllowAnonymous]
        [Route("Profile")]
        public ActionResult GetDetail(string email) 
        {
            return new JsonResult( _memberManagementService.FindMemberByEmail(email));
        }

        [HttpPost]
        [AllowAnonymous]
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
}
