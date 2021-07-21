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
    }
}
