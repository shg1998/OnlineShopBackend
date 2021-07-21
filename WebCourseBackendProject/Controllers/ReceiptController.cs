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
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptRepository receiptRepository;

        public ReceiptController(IReceiptRepository receiptRepository)
        {
            this.receiptRepository = receiptRepository;
        }

        [HttpPost]
        [Route("createReceipt")]
        public async Task<IActionResult> CreateReceipt([FromBody] Receipt receipt)
        {
            receiptRepository.CreateReceipt(receipt);

            return Ok("Success");
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(receiptRepository.GetAllReceipts());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
