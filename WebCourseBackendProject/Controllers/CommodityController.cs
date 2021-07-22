using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;
using WebCourseBackendProject.Services;

namespace WebCourseBackendProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : Controller
    {
        CommodityInsertService CommodityInsertService;
        private readonly ICommodityRepository commodityRepository;

        public CommodityController(ICommodityRepository commodityRepository)
        {
            this.commodityRepository = commodityRepository;
            CommodityInsertService = new CommodityInsertService();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("createCommodity")]
        public async Task<IActionResult> createCommodity([FromBody] Commodity commodity)
        {
            commodityRepository.CreateCommodity(commodity);
            return Ok("Success");
        }


        [Authorize(Roles = "Admin , User")]
        [HttpGet("SearchCommodity/{name}")]
        public async Task<IActionResult> SearchCommodity(string name)
        {
            // Search on name of commodity!
            List<Commodity> final = (commodityRepository.GetAllCommodities().ToList()).
                Where(o => o.ComName.Contains(name)).ToList();
            return Ok(final);
        }


        /// <summary>
        /// Helper Controller to insert Datas (Fake) To DB!
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> create()
        {
            CommodityInsertService.insert(commodityRepository);
            return Ok("Success");
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            // Default : Order by descending with SaleCount property
            List<Commodity> final = (commodityRepository.GetAllCommodities().ToList()).OrderByDescending(
                o => o.ComSaledCount).ToList();
            try
            {
                return Ok(final);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetallCommsMaxPrice")]
        public async Task<IActionResult> GetallCommsMaxPrice()
        {
            //  Order by descending with price property
            List<Commodity> final = (commodityRepository.GetAllCommodities().ToList()).OrderByDescending(
                o => o.ComPrice).ToList();
            try
            {
                return Ok(final);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetallCommsMinPrice")]
        public async Task<IActionResult> GetallCommsMinPrice()
        {
            //  Order by descending with price property
            List<Commodity> final = (commodityRepository.GetAllCommodities().ToList()).OrderBy(
                o => o.ComPrice).ToList();
            try
            {
                return Ok(final);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
