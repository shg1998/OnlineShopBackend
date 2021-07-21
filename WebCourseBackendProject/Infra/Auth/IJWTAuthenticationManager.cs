using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCourseBackendProject.DataAccess.Repositories;

namespace WebCourseBackendProject.Infra.Auth
{
    public interface IJWTAuthenticationManager
    {
        string Autenticate(string userName, string Password,IUserRepository userRepository);
    }
}
