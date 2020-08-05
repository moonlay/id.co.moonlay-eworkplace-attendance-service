using EWorkplaceAbsensiService.Lib.Models;
using EWorkplaceAbsensiService.Lib.Models.ItemExcel.ItemExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Reports
{
    public interface IReportService
    {
        IQueryable<Object> GetAll();
        Task<Report> GetSingleReport(int id);
        List<ItemExcel> GetExcel();
       // void Getexcel(MemoryStream memory);
        Task<int> Create(Report report);
        Task<int> Update(Report dbModel, Report model);
        Task<int> Delete(int id);
    }
}
