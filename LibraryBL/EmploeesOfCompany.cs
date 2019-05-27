using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab5_kr
{
    public class EmploeesOfCompany
    {
        CompanyContext company = new CompanyContext();
        public string NewEmployee(int id, string fullName, int? task)
        {
            Employee employee = new Employee { Id = id, FullName = fullName, TaskId = task };
            company.Employees.Add(employee);
            company.SaveChanges();
            return "Employee is added";
        }
        public string DeleteEmployee(int id)
        {
            Employee employee = company.Employees
                .Where(e => e.Id == id)
                .FirstOrDefault();
            company.Employees.Remove(employee);
            company.SaveChanges();
            return "Employee is removed";
        }
        public string UpdateEmployee(int id, int? task)
        {
            Employee employee = company.Employees
                .Where(e => e.Id == id)
                .FirstOrDefault();
            employee.TaskId = task;
            company.SaveChanges();
            return "Task is changed";
        }
        public List<Employee> FreeEmployees()
        {
            List<Employee> listOfemployees = company.Employees
                .Where(e => e.TaskId == null).ToList();
            return listOfemployees;
        }
        public List<Employee> PrintEmpl()
        {
            List<Employee> employees = company.Employees.ToList();
            return employees;
        }
    }
    public class NewClass
    {
        public NewClass() { }
    }
}
