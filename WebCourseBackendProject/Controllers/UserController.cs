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
        public UserController(IJWTAuthenticationManager manager, IUserRepository repo)
        {
            this.manager = manager;
            userRepository = repo;
        }


        [Authorize(Roles = "Admin , User")]
        [HttpGet("GetUserInformation/{id}")]
        public async Task<IActionResult> GetUserInformation(int id)
        {
            // Default : Order by descending with SaleCount property
            User user = new User();
            user = userRepository.GetAUserById(id);
            try
            {
                return Ok(user);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserInfos userInfo)
        {
            if (userInfo == null)
                return BadRequest();
            User user = new User()
            {
                FullName = userInfo.FullName,
                AccountCharge = 0,
                Password = userInfo.Password,
                RoleID = 1,
                UserAddress = userInfo.Address,
                UserName = userInfo.UserName,
            };
            userRepository.CreateUser(user);
            return Ok("Success");
        }
        //{"userName":"admin","password":"admin"}
        [AllowAnonymous]
        [HttpPost]
        [Route("Auth")]
        public async Task<IActionResult> Authenticate([FromBody] CredUser user)
        {
            var token = manager.Autenticate(user.userName, user.password, userRepository);
            if (token == null)
                return Unauthorized();
            User userConcrete = userRepository.GetAUserWithUName(user.userName);
            FinalUserPattern finalUserPattern = new FinalUserPattern()
            {
                user = userConcrete,
                Token = token
            };
            return Ok(finalUserPattern);
        }

        [Authorize(Roles = "Admin , User")]
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            userRepository.UpdateUser(user);
            return Ok("Success!");
        }
    }
}
