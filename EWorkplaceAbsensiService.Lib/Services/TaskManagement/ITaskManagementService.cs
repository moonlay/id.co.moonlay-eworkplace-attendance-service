using EWorkplaceAbsensiService.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWorkplaceAbsensiService.Lib.Services.TaskManagement
{
    public interface ITaskManagementService
    {
        IQueryable<Object> GetTaskByProject(int id);
        Task<int> DeleteTask(int id);
        Task<int> Create(TaskManangement task);


        IQueryable<Object> GetTaskByProjectAndEmp(int projectid, int empid);

        Task<TaskManangement> GetTaskById(int id);
        IQueryable<TaskManangement> GetAll();
        Task<int> Update(TaskManangement task1, TaskManangement task);
    }
}
