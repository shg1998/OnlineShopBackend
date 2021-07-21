using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;

namespace WebCourseBackendProject.DataAccess.Services
{
    public class RoleRepository : IRoleRepository
    {
        private OnlineShopDbContext context;
        private DbSet<Role> roles;
        public RoleRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.context = onlineShopDbContext;
            roles = onlineShopDbContext.Set<Role>();
        }

        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }
    }
}
