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
using EWorkplaceAbsensiService.Lib.Models.ItemExcel.ItemExcel;

namespace EWorkplaceAbsensiService.Lib.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly AbsensiDbContext _dbContext;
        private readonly DbSet<Report> _reportSet;
        private readonly DbSet<Project> _projectSet;
        private readonly DbSet<TaskManangement> _taskSet;
        private readonly DbSet<TimeSheet> _timeSet;
        private readonly IIdentityService _identity;
        private const string USER_AGENT = "Core Service";

        public ReportService(AbsensiDbContext dbContext,IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _reportSet = _dbContext.Set<Report>();
            _projectSet = _dbContext.Set<Project>();
            _taskSet = _dbContext.Set<TaskManangement>();
            _timeSet = _dbContext.Set<TimeSheet>();
            _identity = serviceProvider.GetService<IIdentityService>();
        }
        public Task<int> Create(Report report)
        {
            EntityExtension.FlagForCreate(report, _identity.Username, USER_AGENT);
            _reportSet.Add(report);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var model = await GetSingleReport(id);
            if (model == null)
                throw new Exception("Invalid Id");
            EntityExtension.FlagForDelete(model, _identity.Username, USER_AGENT);
            _reportSet.Update(model);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Object> GetAll()
        {
            return from p in _projectSet
                   join r in _reportSet
                   on p.Id equals r.ProjectId
                   join t in _timeSet
                   on r.TimesheetId equals t.Id
                   join task in _taskSet
                   on t.TaskManagementId equals task.Id
                   select new
                   {
                       ReportId = r.Id,
                       EmployeeName = task.EmployeeName,
                       ClientName = p.ClientName,
                       ProjectName = p.projectName,
                       TaskName = task.TaskName,
                       TaskDifficult = task.TaskDifficulty,
                       StartDate = task.StartDate,
                       EndDate = task.EndDate,
                       StartTime = t.StartTime,
                       EndTime = t.EndTime,
                       Duration = t.Duration
                   };
        }

        public Task<Report> GetSingleReport(int id)
        {
            return _reportSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> Update(Report dbModel, Report model)
        {
            EntityExtension.FlagForUpdate(model, _identity.Username, USER_AGENT);
            dbModel.ProjectId = model.ProjectId;
            dbModel.TimesheetId = model.TimesheetId;
            return _dbContext.SaveChangesAsync();
        }

        public List<ItemExcel> GetExcel()
        {
            List<ItemExcel> list = new List<ItemExcel>();
            var query = from p in _projectSet
                        join r in _reportSet
                        on p.Id equals r.ProjectId
                        join t in _timeSet
                        on r.TimesheetId equals t.Id
                        join task in _taskSet
                        on t.TaskManagementId equals task.Id
                        select new
                        {
                            ReportId = r.Id,
                            EmployeeName = task.EmployeeName,
                            ClientName = p.ClientName,
                            ProjectName = p.projectName,
                            TaskName = task.TaskName,
                            TaskDifficult = task.TaskDifficulty,
                            StartDate = task.StartDate,
                            EndDate = task.EndDate,
                            StartTime = t.StartTime,
                            EndTime = t.EndTime,
                            Duration = t.Duration
                        };
            foreach(var item in query)
            {
                ItemExcel excel = new ItemExcel();
                excel.ReportId = item.ReportId;
                excel.EmployeeName = item.EmployeeName;
                excel.ClientName = item.ClientName;
                excel.ProjectName = item.ProjectName;
                excel.TaskName = item.TaskName;
                excel.TaskDifficult = item.TaskDifficult;
                excel.StartDate = item.StartDate;
                excel.EndDate = item.EndDate;
                excel.StartTime = item.StartTime;
                excel.EndTime = item.EndTime;
                excel.Duration = item.Duration;
                list.Add(excel);
            }
            return list;
        }
    }
}
