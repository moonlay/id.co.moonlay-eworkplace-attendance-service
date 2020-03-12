using EWorkplaceAbsensiService.Lib.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EWorkplaceAbsensiService.Lib.Models.Filters;

namespace EWorkplaceAbsensiService.Lib.Services.Absensis
{
    public interface IAbsensiService
    {
        IQueryable<Absensi> GetQuery();
        Task<Absensi> GetSingleById(int id);
        Task<int> Create(Absensi model);
        //Task<int> Update(int id, Absensi model);
        Task<int> Update(Absensi dbModel, Absensi model);
        Task<int> Delete(int id);

        IEnumerable<Absensi> Find(AbsensiFilter filter);
    }
}
