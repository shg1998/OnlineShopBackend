using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;

namespace WebCourseBackendProject.DataAccess.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private OnlineShopDbContext context;
        private DbSet<Category> categories;
        public CategoryRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.context = onlineShopDbContext;
            categories = onlineShopDbContext.Set<Category>();
        }

        public void createCategory(Category category)
        {
            context.Entry(category).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category cat = GetACategory(id);
            categories.Remove(cat);
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            Category caat = category;
            categories.Remove(caat);
            context.SaveChanges();
        }

        public Category GetACategory(int id)
        {
            return categories.SingleOrDefault(s => s.CatId == id);
        }

        public List<Category> GetAllCategories()
        {
            return categories.ToList();
        }

        public void UpdateCategory(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
