using EWorkplaceAbsensiService.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Others
{
    public interface IOtherService
    {
        IQueryable<Other> GetQuery();
        Task<Other> GetSingleById(int id);
        Task<int> Create(Other model);
        Task<int> Update(Other dbModel, Other model);
        Task<int> Delete(int id);
        Task<int> ApproveStatus(Other dbModel, Other model);
        Task<int> RejectStatus(Other dbModel, Other model);
    }
}
