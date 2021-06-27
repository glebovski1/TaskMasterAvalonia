using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
