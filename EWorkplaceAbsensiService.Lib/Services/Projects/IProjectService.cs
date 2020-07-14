
using EWorkplaceAbsensiService.Lib.Models;
using EWorkplaceAbsensiService.Lib.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EWorkplaceAbsensiService.Lib.Services.Projects
{
    public interface IProjectService
    {
        IQueryable<Project> GetQuery();
        Task<Project> GetSingleById(int id);
        Task<int> Create(Project model);
        //Task<int> Update(int id, Absensi model);
        Task<int> Update(Project dbModel, Project model);
        Task<int> Delete(int id);

        IEnumerable<Project> Find(ProjectFilter filter);

    }
}
