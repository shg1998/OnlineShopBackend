using System;
using System.Collections.Generic;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;

namespace WebCourseBackendProject.DataAccess.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        void CreateUser(User user);

        User GetAUserById(int id);

        void DeleteUser(int Id);

        void DeleteUser(User user);

        void UpdateUser(int id, User user);
        
    }
}
