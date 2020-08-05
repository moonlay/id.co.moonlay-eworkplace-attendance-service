using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using Com.Moonlay.Models;
using System.Threading.Tasks;
using System.Linq;

namespace EWorkplaceAbsensiService.Lib.Services.Others
{
    public class OtherService : IOtherService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Other> _otherDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public OtherService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _otherDbSet = dbContext.Set<Other>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(Other model)
        {
            EntityExtension.FlagForCreate(model, _identityService.Username, USER_AGENT);
            _otherDbSet.Add(model);

            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetSingleById(id);

            if (model == null)
                throw new Exception("Invalid id");

            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _otherDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Other> GetQuery()
        {
            return _otherDbSet.AsNoTracking();
        }

        public Task<Other> GetSingleById(int id)
        {
            return _otherDbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task<int> Update(Other other, Other model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            other.Name = model.Name;
            other.ReceiptDate = model.ReceiptDate;
            other.Desc = model.Desc;
            other.ReportedExpense = model.ReportedExpense;
            other.Division = model.Division;

            return _dbContext.SaveChangesAsync();
        }

        public Task<int> ApproveStatus(Other other, Other model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            other.ApprovedExpense = model.ApprovedExpense;
            other.Status = Models.Enum.Status.ApprovedByHR;


            return _dbContext.SaveChangesAsync();
        }

        public Task<int> RejectStatus(Other other, Other model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            other.Comments = model.Comments;
            other.Status = Models.Enum.Status.RejectedByHR;


            return _dbContext.SaveChangesAsync();
        }
    }
}
