    using Com.Moonlay.Models;
using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Models;
using EWorkplaceAbsensiService.Lib.Models.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.Absensis
{
    public class AbsensiService : IAbsensiService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Absensi> _AbsensiDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public AbsensiService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _AbsensiDbSet = dbContext.Set<Absensi>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(Absensi model)
        {
            EntityExtension.FlagForCreate(model, _identityService.Username, USER_AGENT);
            _AbsensiDbSet.Add(model);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetSingleById(id);

            if (model == null)
                throw new Exception("Invalid Id");

            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _AbsensiDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Absensi> GetQuery()
        {
            return _AbsensiDbSet.AsNoTracking();
        }

        public Task<Absensi> GetSingleById(int id)
        {
            return _AbsensiDbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task<int> Update(Absensi employee, Absensi model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);
            //_AbsensiDbSet.Update(model);
            employee.Username = model.Username;
            employee.Name = model.Name;
            employee.CheckIn = model.CheckIn;
            employee.State = model.State;
            employee.Location = model.Location;
            employee.CheckOut = model.CheckOut;
            employee.Approval = model.Approval;
            employee.Photo = model.Photo;
            employee.Note = model.Note;
            employee.ProjectName = model.ProjectName;
            employee.HeadDivision = model.HeadDivision;
            employee.ApprovalByAdmin = model.ApprovalByAdmin;
            employee.CompanyName = model.CompanyName;
            employee.ClientName = model.ClientName;
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Absensi> Find(AbsensiFilter filter)
        {
            IQueryable<Absensi> query = _dbContext.Absensis;

            if (filter.Ids.Any())
                query = query.Where(o => filter.Ids.Contains(o.Id));

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(o => o.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Username))
                query = query.Where(o => o.Username.Contains(filter.Username));

            if (!string.IsNullOrEmpty(filter.State))
                query = query.Where(o => o.State.Contains(filter.State));

            if(!string.IsNullOrEmpty(filter.NotState))
                query = query.Where(o => !o.State.Contains(filter.NotState));

            if (!string.IsNullOrEmpty(filter.CheckIn))
                query = query.Where(o => o.CheckIn.ToString().Contains(filter.CheckIn));


            if (!string.IsNullOrEmpty(filter.Approval))
                query = query.Where(o => o.Approval.Contains(filter.Approval));

            if (!string.IsNullOrEmpty(filter.HeadDivision))
                query = query.Where(o => o.HeadDivision.Contains(filter.HeadDivision));

            if (!string.IsNullOrEmpty(filter.ApprovalByAdmin))
                query = query.Where(o => o.ApprovalByAdmin.Contains(filter.ApprovalByAdmin));

            if (filter.SortByUsername.HasValue && filter.SortByUsername.Value == SortBy.ASC)
                query = query.OrderBy(o => o.Username);

            if (filter.SortByUsername.HasValue && filter.SortByUsername.Value == SortBy.DESC)
                query = query.OrderByDescending(o => o.Username);

            if (filter.SortByDate.HasValue && filter.SortByDate.Value == SortBy.ASC)
                query = query.OrderBy(o => o.CheckIn);

            if (filter.SortByDate.HasValue && filter.SortByDate.Value == SortBy.DESC)
                query = query.OrderByDescending(o => o.CheckIn);


            return query.ToList();
        }
    }
}
