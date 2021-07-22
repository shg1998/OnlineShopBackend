using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCourseBackendProject.DataAccess.Models;

namespace WebCourseBackendProject.Infra.Auth
{
    public class FinalUserPattern
    {
        public User user{ get; set; }

        public string Token { get; set; }
    }
}
