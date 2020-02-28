using System.Collections.Generic;
using System.Linq;
using AbsenApi.Models.Filters;
using AbsenApi.Models.Repository;

namespace AbsenApi.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeManager(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }


        public Employee Get(long id)
        {
            return _employeeContext.Employees.FirstOrDefault(e => e.AbsenceId == id);
        }


        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(Employee dbEntity, Employee entity)
        {
            /*for 2 coloumn update 
            if (entity.CheckOut != null)
            {
                employee.CheckOut = entity.CheckOut;
                //employee.Approval = employee.Approval;
            }

            if (entity.Approval != null) {
                 employee.Approval = entity.Approval;
                 entity.CheckOut = employee.CheckOut;
             }
           */

            /*untuk 3 coloumn update*/
            
               if (entity.ApprovalByAdmin != null)
            {
                dbEntity.ApprovalByAdmin = entity.ApprovalByAdmin;
        }
            else
            {
                if (entity.Approval != null)
                {
                    dbEntity.Approval = entity.Approval;
                    entity.ApprovalByAdmin = dbEntity.ApprovalByAdmin;
                    entity.CheckOut = dbEntity.CheckOut;
                }

                if (entity.CheckOut != null)
                {
                    dbEntity.CheckOut = entity.CheckOut;
                    dbEntity.ApprovalByAdmin = dbEntity.ApprovalByAdmin;
                    dbEntity.Approval = dbEntity.Approval;
                }
            }

            


            _employeeContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public IEnumerable<Employee> Find(EmployeeFilter filter)
        {
            IQueryable<Employee> query = _employeeContext.Employees;

            if (filter.Ids.Any())
                query = query.Where(o => filter.Ids.Contains(o.AbsenceId));

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(o => o.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Username))
                query = query.Where(o => o.Username.Contains(filter.Username));

            if (!string.IsNullOrEmpty(filter.State))
                query = query.Where(o => o.State.Contains(filter.State));

            if (!string.IsNullOrEmpty(filter.CheckIn))
                query = query.Where(o => o.CheckIn.ToString().Contains(filter.CheckIn));

            /*  if (!string.IsNullOrEmpty(filter.Approval))
                  query = query.Where(o => o.Approval.Contains(filter.Approval)); */

            if (filter.SortByUsername.HasValue && filter.SortByUsername.Value == SortByAtOffice.ASC)
                query = query.OrderBy(o => o.Username);



            if (filter.SortByUsername.HasValue && filter.SortByUsername.Value == SortByAtOffice.DESC)
                query = query.OrderByDescending(o => o.Username);

            if (filter.SortByDate.HasValue && filter.SortByDate.Value == SortByAtOffice.ASC)
                query = query.OrderBy(o => o.CheckIn);

            if (filter.SortByDate.HasValue && filter.SortByDate.Value == SortByAtOffice.DESC)
                query = query.OrderByDescending(o => o.CheckIn);


            return query.ToList();
        }
    }
}
