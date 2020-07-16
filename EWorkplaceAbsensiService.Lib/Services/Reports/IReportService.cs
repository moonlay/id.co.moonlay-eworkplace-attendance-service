using EWorkplaceAbsensiService.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Reports
{
    public interface IReportService
    {
        IQueryable<Object> GetAll();
        Task<Report> GetSingleReport(int id);
        Task<int> Create(Report report);
        Task<int> Update(Report dbModel, Report model);
        Task<int> Delete(int id);
    }
}
