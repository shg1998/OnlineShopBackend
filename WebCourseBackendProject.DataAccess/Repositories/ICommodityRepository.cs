using System;
using System.Collections.Generic;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;

namespace WebCourseBackendProject.DataAccess.Repositories
{
    public interface ICommodityRepository
    {
        List<Commodity> GetAllCommodities();

        void CreateCommodity(Commodity commodity);

        Commodity GetACommodity(int id);

        void DeleteCommodity(int id);

        void DeleteCommodity(Commodity commodity);

        void UpdateCommodity(int id, Commodity commodity);

        void SaveChanges();
    }
}
