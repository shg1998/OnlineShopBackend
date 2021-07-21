using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;

namespace WebCourseBackendProject.DataAccess.Services
{
    public class CommodityRepository : ICommodityRepository
    {
        private OnlineShopDbContext context;
        private DbSet<Commodity> commodities;
        public CommodityRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.context = onlineShopDbContext;
            commodities = onlineShopDbContext.Set<Commodity>();
        }
        public void CreateCommodity(Commodity commodity)
        {
            context.Entry(commodity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteCommodity(int id)
        {
            Commodity commodity = GetACommodity(id);
            commodities.Remove(commodity);
            context.SaveChanges();
        }

        public void DeleteCommodity(Commodity commodity)
        {
            Commodity commodity1 = commodity;
            commodities.Remove(commodity1);
            context.SaveChanges();
        }

        public Commodity GetACommodity(int id)
        {
            return commodities.SingleOrDefault(s => s.ComId == id);
        }

        public List<Commodity> GetAllCommodities()
        {
            return commodities.ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateCommodity(int id, Commodity commodity)
        {
            Commodity commodity1 = GetACommodity(id);
            commodity1.ComCategory = commodity.ComCategory;
            commodity1.ComName = commodity.ComName;
            commodity1.ComPrice= commodity.ComPrice;
            commodity1.ComRemained= commodity.ComRemained;
            commodity1.ComSaledCount= commodity.ComSaledCount;
            // TODO!!!
            context.SaveChanges();
        }
    }
}
