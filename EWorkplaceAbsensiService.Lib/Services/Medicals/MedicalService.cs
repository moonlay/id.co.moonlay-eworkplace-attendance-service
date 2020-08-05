using Com.Moonlay.Models;
using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Medicals
{
    public class MedicalService : IMedicalService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Medical> _medicalDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public MedicalService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _medicalDbSet = dbContext.Set<Medical>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(Medical model)
        {
            EntityExtension.FlagForCreate(model, _identityService.Username, USER_AGENT);
            _medicalDbSet.Add(model);

            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetSingleById(id);

            if (model == null)
                throw new Exception("Invalid id");

            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _medicalDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Medical> GetQuery()
        {

            return _medicalDbSet.AsNoTracking();
        }


        public Task<Medical> GetSingleById(int id)
        {
            return _medicalDbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task<int> Update(Medical medical, Medical model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            medical.Name = model.Name;
            medical.ReceiptDate = model.ReceiptDate;
            medical.Desc = model.Desc;
            medical.ReportedExpense = model.ReportedExpense;
            medical.Division = model.Division;

            return _dbContext.SaveChangesAsync();
        }

        public Task<int> ApproveStatus(Medical medical, Medical model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            medical.Status = Models.Enum.Status.ApprovedByHR;


            return _dbContext.SaveChangesAsync();
        }

        public Task<int> RejectStatus(Medical medical, Medical model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            medical.Comments = model.Comments;
            medical.Status = Models.Enum.Status.RejectedByHR;


            return _dbContext.SaveChangesAsync();
        }
    }
}
