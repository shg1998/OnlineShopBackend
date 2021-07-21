using System;
using System.Collections.Generic;
using System.Text;
using WebCourseBackendProject.DataAccess.Models;

namespace WebCourseBackendProject.DataAccess.Repositories
{
    public interface IReceiptRepository
    {
        List<Receipt> GetAllReceipts();

        void CreateReceipt(Receipt  receipt);

        Receipt GetAReceiptById(int userId);

    }
}
