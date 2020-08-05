using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Com.Moonlay.Models;

namespace EWorkplaceAbsensiService.Lib.Services.Overtimes
{
    public class OvertimeService : IOvertimeService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Overtime> _OvertimeDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public OvertimeService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _OvertimeDbSet = dbContext.Set<Overtime>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(Overtime model)
        {
            EntityExtension.FlagForCreate(model, _identityService.Username, USER_AGENT);
            _OvertimeDbSet.Add(model);

            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetSingleById(id);

            if (model == null)
                throw new Exception("Invalid id");

            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _OvertimeDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Overtime> GetQuery()
        {
            return _OvertimeDbSet.AsNoTracking();
        }

        public Task<Overtime> GetSingleById(int id)
        {
            return _OvertimeDbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task<int> Update(Overtime overtime, Overtime model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);

            //overtime.Name = model.Name;
            overtime.Division = model.Division;
            overtime.OvertimeDate = model.OvertimeDate;
            overtime.KindOfDay = model.KindOfDay;
            overtime.StartTime = model.StartTime;
            overtime.EndTime = model.EndTime;
            overtime.Duration = model.Duration;
            overtime.Desc = model.Desc;
            overtime.MealsReimbursment = model.MealsReimbursment;
            overtime.TransportReimbursment = model.TransportReimbursment;
            
            return _dbContext.SaveChangesAsync();
        }
    }
}
