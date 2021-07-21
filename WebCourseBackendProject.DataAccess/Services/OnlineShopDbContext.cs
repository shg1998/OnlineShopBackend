using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;

namespace WebCourseBackendProject.DataAccess.Services
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions
  <OnlineShopDbContext> options) : base(options)
        {
        }
       
        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Commodity> commodities { get; set; }
        public DbSet<Receipt> receipts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
