using EWorkplaceAbsensiService.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Overtimes
{
    public interface IOvertimeService
    {
        IQueryable<Overtime> GetQuery();
        Task<Overtime> GetSingleById(int id);
        Task<int> Create(Overtime model);
        Task<int> Update(Overtime dbModel, Overtime model);
        Task<int> Delete(int id);

    }
}
