using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWorkplaceAbsensiService.Lib.Models;
namespace EWorkplaceAbsensiService.Lib.Services.ActivityCategories
{
    public interface IActivityCategoryService
    {
        IQueryable<ActivityCategory> getQuery();
    }
}
