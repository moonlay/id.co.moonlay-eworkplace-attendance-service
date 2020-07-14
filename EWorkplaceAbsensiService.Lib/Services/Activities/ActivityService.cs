using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Com.Moonlay.Models;

namespace EWorkplaceAbsensiService.Lib.Services.Activities
{
    public class ActivityService : IActivityService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Activity> _ActivityDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public ActivityService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _ActivityDbSet = _dbContext.Set<Activity>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(Activity activity)
        {
            EntityExtension.FlagForCreate(activity, _identityService.Username, USER_AGENT);
            _ActivityDbSet.Add(activity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Activity> GetQuery()
        {
            return _ActivityDbSet.AsNoTracking();
        }


        public Task<int> Update(Activity dbmodel, Activity model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);
            dbmodel.Activityname = model.Activityname;
            dbmodel.CategoryId = model.CategoryId;
            dbmodel.Description = model.Description;
            return _dbContext.SaveChangesAsync();
        }

        public Task<Activity> GetById(int id)
        {
            return _ActivityDbSet.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetById(id);
            if(model == null)
            {
                throw new Exception("Invalid ID");
            }
            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _ActivityDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
