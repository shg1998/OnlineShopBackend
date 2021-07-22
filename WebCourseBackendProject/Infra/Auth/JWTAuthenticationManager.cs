using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;
using WebCourseBackendProject.DataAccess.Services;

namespace WebCourseBackendProject.Infra.Auth
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private List<User> users = new List<User>();
        private readonly string key;
        private string _role;

        public JWTAuthenticationManager(string key)
        {
            this.key = key;

        }
        public string Autenticate(string userName, string Password, IUserRepository repo)
        {
            users = repo.GetAllUsers().ToList();
            if (!users.Any(u => u.UserName == userName && u.Password == Password))
            {
                return null;
            }
            else
            {
                User ConcreteUser = users.Where(x => x.UserName == userName && x.Password == Password).FirstOrDefault();
                if (ConcreteUser.RoleID == 1)
                    _role = "User";
                else
                    _role = "Admin";
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,userName),
                    new Claim(ClaimTypes.Role,_role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
