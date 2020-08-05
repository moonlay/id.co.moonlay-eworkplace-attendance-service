using Com.Moonlay.Models;
using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EWorkplaceAbsensiService.Lib.Services.Transports
{
    public class TransportService : ITransportService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Transport> _TransportDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public TransportService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _TransportDbSet = dbContext.Set<Transport>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(Transport model)
        {
            EntityExtension.FlagForCreate(model, _identityService.Username, USER_AGENT);
            _TransportDbSet.Add(model);

            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetSingleById(id);

            if (model == null)
                throw new Exception("Invalid id");

            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _TransportDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Transport> GetQuery()
        {
            return _TransportDbSet.AsNoTracking();
        }

        public Task<Transport> GetSingleById(int id)
        {
            return _TransportDbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task<int> Update(Transport transport, Transport model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            transport.Name = model.Name;
            transport.ReceiptDate = model.ReceiptDate;
            transport.Desc = model.Desc;
            transport.DepartureLocation = model.DepartureLocation;
            transport.DestinationLocation = model.DestinationLocation;
            transport.ReportedExpense = model.ReportedExpense;
            transport.Division = model.Division;

            return _dbContext.SaveChangesAsync();
        }

        public Task<int> ApproveStatus(Transport transport, Transport model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            transport.ApprovedExpense = transport.ReportedExpense;
            transport.Status = Models.Enum.Status.ApprovedByHR;
            

            return _dbContext.SaveChangesAsync();
        }

        public Task<int> RejectStatus(Transport transport, Transport model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            transport.Comments = model.Comments;
            transport.Status = Models.Enum.Status.RejectedByHR;
            transport.ApprovedExpense = 0;


            return _dbContext.SaveChangesAsync();
        }

    }
}
