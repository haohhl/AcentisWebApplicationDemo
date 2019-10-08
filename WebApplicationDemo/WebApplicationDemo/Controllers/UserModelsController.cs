using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services;

namespace WebApplicationDemo.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class UserModelsController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserModelsController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        // POST: api/UserModels
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<ActionResult<UserModel>> RegisterMember(UserModel user)
        {
            if (ModelState.IsValid)
            {
                await _userManagementService.AddUserAsync(user);
                return Ok();
            }
            return BadRequest("Invalid Request");
        }

        
    }
}
