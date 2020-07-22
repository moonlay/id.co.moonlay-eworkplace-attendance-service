using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace EWorkplaceAbsensiService.Lib.Services.ActivityCategories
{
    public class ActivityCategoryService : IActivityCategoryService
    {
        public readonly AbsensiDbContext _dbContext;

        private readonly DbSet<ActivityCategory> _ActivityCategory;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public ActivityCategoryService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _ActivityCategory= dbContext.Set<ActivityCategory>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }


        public IQueryable<ActivityCategory> getQuery()
        {
            return _ActivityCategory.AsNoTracking();
        }
    }
}
