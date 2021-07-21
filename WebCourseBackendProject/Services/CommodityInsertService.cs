using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;

namespace WebCourseBackendProject.Services
{
    public class CommodityInsertService
    {
        internal void insert(ICommodityRepository commodityRepository)
        {
            for (int i = 0; i < 20; i++)
            {
                Commodity commodity = new Commodity();
                commodity.ComCategory = new Category() {  CatId=1};
                commodity.ComName = "سیستم کامپیوتری" + i;
                commodity.ComPrice = 12000000 + i;
                commodity.ComRemained = 10 + i;
                commodity.ComSaledCount = 15 + i;
                commodityRepository.CreateCommodity(commodity);
            }
        }
    }
}
