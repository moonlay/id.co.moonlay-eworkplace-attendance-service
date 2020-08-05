using EWorkplaceAbsensiService.Lib.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Transports
{
    public interface ITransportService
    {
        IQueryable<Transport> GetQuery();
        Task<Transport> GetSingleById(int id);
        Task<int> Create(Transport model);
        Task<int> Update(Transport dbModel, Transport model);
        Task<int> Delete(int id);
        Task<int> ApproveStatus(Transport dbModel, Transport model);
        Task<int> RejectStatus(Transport dbModel, Transport model);
    }
}
