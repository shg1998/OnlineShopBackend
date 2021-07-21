using System;
using System.Collections.Generic;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;

namespace WebCourseBackendProject.DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();

        void createCategory(Category category);

        Category GetACategory(int id);

        void UpdateCategory(int id, Category category);

        void DeleteCategory(int id);

        void DeleteCategory(Category category);
    }
}
