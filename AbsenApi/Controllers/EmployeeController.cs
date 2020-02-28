using System.Collections.Generic;
using System.IO;
using AbsenApi.Models;
using AbsenApi.Models.Filters;
using AbsenApi.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbsenApi.Controllers
{
    [Route("api/absensi")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;

        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get([FromQuery]EmployeeFilter filter)
        {
            IEnumerable<Employee> employees = _dataRepository.Find(filter);

            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Employee employee = _dataRepository.Get(id);

            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            _dataRepository.Add(employee);
            return CreatedAtRoute(
                  "Get",
                  new { Id = employee.AbsenceId },
                  employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            Employee employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Update(employeeToUpdate, employee);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = _dataRepository.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Delete(employee);
            return NoContent();
        }

    }
}