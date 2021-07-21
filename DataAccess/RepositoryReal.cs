using System.Collections.Generic;
using System.Linq;
using TaskMaster.DataAccess.Models;

namespace DataAccess
{
    public class RepositoryReal
    {
        private AppDbContext context;
        public RepositoryReal()
        {
            context = new AppDbContext();
        }

        public List<Employee> GetEmployees()
        {
            return  context.Employees.ToList();
        }
        public List<TaskForEmployee> GetTaskForEmployees()
        {
            return context.TaskForEmployees.ToList();
        }
        public List<TaskForEmployee> GetTaskForEmployees(int employeeId)
        {
            return context.TaskForEmployees.Where(task => task.Employee.Id == employeeId).ToList();
        }
        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }
        public void AddTaskForEmployee(TaskForEmployee task)
        {
            context.TaskForEmployees.Add(task);
            context.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {
            var tasks = context.TaskForEmployees.Where(task => task.Employee.Id == employee.Id);
            context.TaskForEmployees.RemoveRange(tasks);
             context.Employees.Remove(employee);
            context.SaveChanges();
        }
        public void DeleteEmployee(int employeeId)
        {
            DeleteEmployee(context.Employees.Find(employeeId));
        }
        public void DeleteTaskForEmployee(TaskForEmployee task)
        {
            context.TaskForEmployees.Remove(task);
            context.SaveChanges();
        }
        public void DeleteTaskForEmployee(int taskId)
        {
            DeleteTaskForEmployee(context.TaskForEmployees.Find(taskId));
            
        }
        public void EditEmployee(Employee employee)
        {
            var oldEmployee = context.Employees.Find(employee.Id);
            if(oldEmployee.FirstName != employee.FirstName && employee.FirstName != null)
            {
                oldEmployee.FirstName = employee.FirstName;
            }
            if(oldEmployee.LastName != employee.LastName && employee.LastName != null) 
            {
                oldEmployee.LastName = employee.LastName;
            }
            if(oldEmployee.Position != employee.Position && employee.Position != null) 
            {
                oldEmployee.Position = employee.Position;
            }
            context.SaveChanges();
        }

        public Employee FindEmployee(int id)
        {
           return context.Employees.Find(id);
        }

    }
}
