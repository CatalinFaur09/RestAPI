using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPICRUDDemo.EmployeeData;
using RestAPICRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICRUDDemo.Controllers
{
    
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //Implement CRUD

        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employee)
        {
            _employeeData = employee;
        }

        [HttpGet]
        [Route("api/[Controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[Controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if(employee != null)
            {
                return Ok(_employeeData.GetEmployee(id));
            }
            return NotFound($"Employee with ID:{id} was not found");

            
        }

        //Adding a new employy

        [HttpPost]
        [Route("api/[Controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
             _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + ":/" + employee.Id,
                employee);
   
        }

        [HttpDelete]
        [Route("api/[Controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            //Check if employee is on
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok($"Employee with ID:{id} Was succesfully deleted");
            }
            return NotFound($"Employee with ID:{id} cannot be deleted");

        }

        [HttpPatch]
        [Route("api/[Controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            //See if empl exist
            var employeeCheck = _employeeData.GetEmployee(id);
            if (employeeCheck != null)
            {
                employee.Id = employeeCheck.Id;

                _employeeData.EditEmployee(employee);
              
            }
            return Ok(employee);
            
        }
    }
}
