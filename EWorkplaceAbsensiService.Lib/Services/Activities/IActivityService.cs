using EWorkplaceAbsensiService.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Activities
{
    public interface IActivityService
    {
        Task<int> Create(Activity activity);
        IQueryable<Activity> GetQuery();
        Task<int> Update(Activity dbmodel,Activity model);

        Task<Activity> GetById(int id);
        Task<int> Delete(int id);
    }
}
