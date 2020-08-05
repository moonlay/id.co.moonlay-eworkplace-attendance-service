using EWorkplaceAbsensiService.Lib.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Medicals
{
    public interface IMedicalService
    {
        IQueryable<Medical> GetQuery();
        Task<Medical> GetSingleById(int id);
        Task<int> Create(Medical model);
        Task<int> Update(Medical dbModel, Medical model);
        Task<int> Delete(int id);
        Task<int> ApproveStatus(Medical dbModel, Medical model);
        Task<int> RejectStatus(Medical dbModel, Medical model);
    }
}
