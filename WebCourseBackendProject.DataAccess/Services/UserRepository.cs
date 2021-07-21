using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;

namespace WebCourseBackendProject.DataAccess.Services
{
    public class UserRepository : IUserRepository
    {

        private OnlineShopDbContext context;
        private DbSet<User> users;
        public UserRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.context = onlineShopDbContext;
            users = onlineShopDbContext.Set<User>();
        }

        public void CreateUser(User user)
        {
            context.Entry(user).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            User user = GetAUserById(Id);
            users.Remove(user);
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            User user1 = user;
            users.Remove(user1);
            context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return users.ToList();
        }

        public User GetAUserById(int id)
        {
            return users.SingleOrDefault(s => s.UserId == id);
        }

        public void UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
