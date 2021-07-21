using System;
using System.Collections.Generic;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;

namespace WebCourseBackendProject.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
    }
}
