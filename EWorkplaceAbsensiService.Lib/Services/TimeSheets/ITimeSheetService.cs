using EWorkplaceAbsensiService.Lib.Models;
using EWorkplaceAbsensiService.Lib.Models.ItemExcel.ItemExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.TimeSheets
{
    public interface ITimeSheetService
    {
        IQueryable<Object> getAll();
        Task<int> DeleteTime(int id);

        IQueryable<Object> getByProjectId(int id);

        Task<TimeSheet> GetTimeSheetById(int id);
        Task<int> Create(TimeSheet timesheet);
        Task<int> Update(TimeSheet dbModel, TimeSheet model);

        IQueryable<Object> getByProjectAndEmployee(int projectid, int empid);

        List<ItemExcel> GetExcel();

        List<ItemExcel> GetExcel(int projectid,int empid);
    }
}
