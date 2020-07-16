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
using EWorkplaceAbsensiService.Lib.Models.Filters;

namespace EWorkplaceAbsensiService.Lib.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Project> _ProjectDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public ProjectService(AbsensiDbContext dbContext,IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _ProjectDbSet = _dbContext.Set<Project>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(Project model)
        {
            EntityExtension.FlagForCreate(model, _identityService.Username, USER_AGENT);
            _ProjectDbSet.Add(model);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetSingleById(id);
            if (model == null)
                throw new Exception("Invalid Id");

            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _ProjectDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Project> GetQuery()
        {
            return _ProjectDbSet.AsNoTracking();
        }

        public Task<Project> GetSingleById(int id)
        {
            return _ProjectDbSet.FirstOrDefaultAsync(x => x.Id == id );
        }

        public Task<int> Update(Project dbModel, Project model)
        {

            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);
            dbModel.projectName = model.projectName;
            dbModel.status = model.status;
            dbModel.contract = model.contract;
            dbModel.workType = model.workType;
            dbModel.ClientName = model.ClientName;
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Project> Find(ProjectFilter filter)
        {
            IQueryable<Project> query = _dbContext.Project;

            if (filter.Ids.Any())
                query = query.Where(o => filter.Ids.Contains(o.Id));
            if (!string.IsNullOrEmpty(filter.projectName))
                query = query.Where(o => o.projectName.Contains(filter.projectName));
            if (!string.IsNullOrEmpty(filter.workType))
                query = query.Where(o => o.workType.Contains(filter.workType));
            if (!string.IsNullOrEmpty(filter.contract))
                query = query.Where(o => o.contract.Contains(filter.contract));
            if (filter.SortByprojectName.HasValue && filter.SortByprojectName.Value == SortBy.ASC)
                query = query.OrderBy(o => o.projectName);
            if (filter.SortByprojectName.HasValue && filter.SortByprojectName.Value == SortBy.DESC)
                query = query.OrderByDescending(o => o.projectName);

            return query.ToList();
        }
    }
}
