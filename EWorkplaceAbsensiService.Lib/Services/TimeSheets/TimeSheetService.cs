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

namespace EWorkplaceAbsensiService.Lib.Services.TimeSheets
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<TimeSheet> _TimeSheetSet;
        private readonly DbSet<Project> _projects;
        private readonly DbSet<TaskManangement> _taskManangement;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public TimeSheetService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _TimeSheetSet = _dbContext.Set<TimeSheet>();
            _projects = _dbContext.Set<Project>();
            _taskManangement = _dbContext.Set<TaskManangement>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Task<int> Create(TimeSheet timesheet)
        {
            EntityExtension.FlagForCreate(timesheet, _identityService.Username, USER_AGENT);
            _TimeSheetSet.Add(timesheet);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteTime(int id)
        {
            var model = await GetTimeSheetById(id);
            if (model == null)
                throw new Exception("Invalid Id");
            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _TimeSheetSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Object> getAll()
        {
            return (from p in _projects 
                   join t in _TimeSheetSet
                   on p.Id equals t.ProjectId
                   join ts in _taskManangement
                   on t.TaskManagementId equals ts.Id
                   select new
                   {
                       TimeSheetId = t.Id,
                       ProjectId = t.ProjectId,
                       ProjectName = p.projectName,
                       Task_id = t.TaskManagementId,
                       Task_name = ts.TaskName,
                       Task_status = ts.TaskStatus,
                       StardDate = ts.StartDate,
                       EndDate = ts.EndDate,
                       StartTime = t.StartTime,
                       EndTime = t.EndTime,
                       Duration = t.Duration,
                       EmployeeId = ts.EmployeeId,
                       EmployeeName = ts.EmployeeName,
                       IsDelete = ts.IsDeleted,
                   }).AsNoTracking();
        }

        public Task<TimeSheet> GetTimeSheetById(int id)
        {
            return _TimeSheetSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> Update(TimeSheet dbModel, TimeSheet model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);
            dbModel.ProjectId = model.ProjectId;
            dbModel.TaskManagementId = model.TaskManagementId;
            dbModel.StartTime = model.StartTime;
            dbModel.EndTime = model.EndTime;
            dbModel.Duration = model.Duration;
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<object> getByProjectId(int id)
        {
            return (from p in _projects
                    join t in _TimeSheetSet
                    on p.Id equals t.ProjectId
                    join ts in _taskManangement
                    on t.TaskManagementId equals ts.Id
                    where t.ProjectId == id && ts.ProjectId == id
                    select new
                    {
                        TimeSheetId = t.Id,
                        ProjectId = t.ProjectId,
                        ProjectName = p.projectName,
                        Task_id = t.TaskManagementId,
                        Task_name = ts.TaskName,
                        Task_status = ts.TaskStatus,
                        StardDate = ts.StartDate,
                        EndDate = ts.EndDate,
                        StartTime = t.StartTime,
                        EndTime = t.EndTime,
                        Duration = t.Duration,
                        EmployeeId = ts.EmployeeId,
                        EmployeeName = ts.EmployeeName,
                        IsDelete = ts.IsDeleted,
                    }).AsNoTracking();
        }
    }
}
