using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;
using WebCourseBackendProject.Infra.Auth;

namespace WebCourseBackendProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IJWTAuthenticationManager manager;
        private readonly IUserRepository userRepository;
        public UserController(IJWTAuthenticationManager manager,IUserRepository repo)
        {
            this.manager = manager;
            userRepository = repo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Auth")]
        public async Task<IActionResult> Authenticate([FromBody] CredUser user)
        {
            var token = manager.Autenticate(user.userName, user.password,userRepository);
            if (token == null) 
                return Unauthorized();
            return Ok(token);
        }
    }
}
