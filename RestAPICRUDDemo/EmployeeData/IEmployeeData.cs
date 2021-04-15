using RestAPICRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICRUDDemo.EmployeeData
{
   public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        //Getting a single employee method
        Employee GetEmployee(Guid id);

        //Add employee method
        Employee AddEmployee(Employee employee);

        //Delete Employee
        void DeleteEmployee(Employee employee);

        //Edit employee
        Employee EditEmployee(Employee employee);
    }
}
