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

namespace EWorkplaceAbsensiService.Lib.Services.TaskManagement
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<TaskManangement> _TaskDbSet;
        private readonly DbSet<Project> _ProjectDbSet;
        private readonly IIdentityService _identityService;
        private const string USER_AGENT = "Core Service";

        public TaskManagementService(AbsensiDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _TaskDbSet = _dbContext.Set<TaskManangement>();
            _ProjectDbSet = _dbContext.Set<Project>();
            _identityService = serviceProvider.GetService<IIdentityService>();
        }

        public IQueryable<Object> GetTaskByProject(int id)
        {
            var query = (from p in _TaskDbSet
                   join q in _ProjectDbSet
                   on p.ProjectId equals q.Id
                   where q.Id == id
                   select new
                   {
                       TaskId = p.Id,
                       ProjectId = p.ProjectId,
                       ProjectName = q.projectName,
                       TaskName = p.TaskName,
                       TaskDifficulty = p.TaskDifficulty,
                       TaskPriority = p.TaskPriority,
                       TaskStatus = p.TaskStatus,
                       TaskDescription = p.TaskDescription,
                       StartDate=p.StartDate,
                       ManHour = p.ManHour,
                       EndDate = p.EndDate,
                       EmployeeId = p.EmployeeId,
                       EmployeeName = p.EmployeeName,

                   });
            if (query == null)
                throw new Exception("Invalid Project ID");

            return query;
        }

        public async Task<int> DeleteTask(int id)
        {
            var model = await GetTaskById(id);
            if (model == null)
                throw new Exception("Invalid Id");
            EntityExtension.FlagForDelete(model, _identityService.Username, USER_AGENT);
            _TaskDbSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public Task<int> Create(TaskManangement task)
        {
            EntityExtension.FlagForCreate(task, _identityService.Username, USER_AGENT);
            _TaskDbSet.Add(task);
            return _dbContext.SaveChangesAsync();
        }


        public Task<TaskManangement> GetTaskById(int id)
        {
            return _TaskDbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TaskManangement> GetAll()
        {
            return _TaskDbSet.AsNoTracking();
        }
        
        public Task<int> Update(TaskManangement dbModel, TaskManangement model)
        {
            EntityExtension.FlagForUpdate(model, _identityService.Username, USER_AGENT);
            dbModel.TaskName = model.TaskName;
            dbModel.TaskStatus = model.TaskStatus;
            dbModel.TaskDescription = model.TaskDescription;
            dbModel.ManHour = model.ManHour;
            dbModel.TaskDifficulty = model.TaskDifficulty;
            dbModel.TaskDescription = model.TaskDescription;
            dbModel.TaskPriority = model.TaskPriority;
            dbModel.StartDate = model.StartDate;
            dbModel.EndDate = model.EndDate;
            dbModel.EmployeeId = model.EmployeeId;
            dbModel.EmployeeName = model.EmployeeName;
            dbModel.ProjectId = model.ProjectId;
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<object> GetTaskByProjectAndEmp(int projectid, int empid)
        {
            var query = (from p in _TaskDbSet
                         join q in _ProjectDbSet
                         on p.ProjectId equals q.Id
                         where q.Id == projectid && p.EmployeeId == empid
                         select new
                         {
                             TaskId = p.Id,
                             ProjectId = p.ProjectId,
                             ProjectName = q.projectName,
                             TaskName = p.TaskName,
                             TaskDifficulty = p.TaskDifficulty,
                             TaskPriority = p.TaskPriority,
                             TaskStatus = p.TaskStatus,
                             TaskDescription = p.TaskDescription,
                             StartDate = p.StartDate,
                             ManHour = p.ManHour,
                             EndDate = p.EndDate,
                             EmployeeId = p.EmployeeId,
                             EmployeeName = p.EmployeeName,

                         });
            if (query == null)
                throw new Exception("Invalid Project ID");

            return query;
        }
    }
}
