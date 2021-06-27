using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.DataAccess.Models;

namespace TaskMaster.DataAccess
{
    public class Repository
    {
        List<Employee> Employees { get; set; }
        List<TaskForEmployee> TasksForEmployees { get; set; }
        //public Repository()
        //{

        //    Employees = new List<Employee>();
        //    Employees.Add(new Employee()
        //    {
        //        FristName = "John",
        //        LastName = "Kenady",
        //        Position = "Generic",
        //        Id = 1.ToString()
        //    });
        //    Employees.Add(new Employee()
        //    {
        //        FristName = "Deny",
        //        LastName = "Elfman",
        //        Position = "Generic",
        //        Id = 2.ToString()
        //    });

        //    TasksForEmployees = new List<TaskForEmployee>();
        //    TasksForEmployees.Add(new TaskForEmployee()
        //    {
        //        Id = 1.ToString(),
        //        ShortDescription = "Do something",
        //        DeadLine = new DateTime(2021, 8, 11),
        //        ExecutorId = 1.ToString()

        //    });
        //    TasksForEmployees.Add(new TaskForEmployee()
        //    {
        //        Id = 2.ToString(),
        //        ShortDescription = "Do something",
        //        DeadLine = new DateTime(2021, 6, 21),
        //        ExecutorId = 2.ToString()
        //    });
        //}
        public List<Employee> GetEmployees()
        {

            return Employees;

        }
        public List<TaskForEmployee> GetTasks()
        {
            return TasksForEmployees;
        }
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
        public void AddTask(TaskForEmployee task)
        {
            TasksForEmployees.Add(task);
        }
    }
}
