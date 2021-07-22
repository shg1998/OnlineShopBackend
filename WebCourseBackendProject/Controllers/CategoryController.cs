using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCourseBackendProject.DataAccess.Models;
using WebCourseBackendProject.DataAccess.Repositories;

namespace WebCourseBackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository repo)
        {
            categoryRepository = repo;
        }

        [HttpPost]
        [Route("createCommodity")]
        public async Task<IActionResult> createCommodity([FromBody] Category category)
        {
            categoryRepository.createCategory(category);
            return Ok("Success");
        }

        [Authorize(Roles = "Admin , User")]
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            // Default : Order by descending with SaleCount property
            List<Category> final = (categoryRepository.GetAllCategories().ToList());
            try
            {
                return Ok(final);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            // Default : Order by descending with SaleCount property
            Category final = (categoryRepository.GetACategory(id));
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
