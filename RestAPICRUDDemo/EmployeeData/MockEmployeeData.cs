using RestAPICRUDDemo.EmployeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICRUDDemo.Models
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "First Employee"
            },

            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Second Employee"
            },

             new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Third Employee"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var employeeCheck = GetEmployee(employee.Id);

            //OVeride vallues
            employeeCheck.Name = employee.Name;

            return employeeCheck;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
