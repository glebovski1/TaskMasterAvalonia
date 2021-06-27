using DataAccess;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.DataAccess.Models;

namespace TaskMaster.AvaloniaUI.ViewModels
{
    public class TaskForEmployeeViewModel : ViewModelBase
    {
        private RepositoryReal repository;
        public EmployeeViewModel Employee { get; set; }
        public Action OnDelete;
             
        public string EmployeeName { get; set; }
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime DeadLine { get; set; }
        //public Employee Employee { get; set; }
        public bool Done { get; set; } = false;
        public bool Failed { get; set; } = false;
        public TaskForEmployeeViewModel(TaskForEmployee employee)
        {
           
            ShortDescription = employee.ShortDescription;
            LongDescription = employee.LongDescription;
            DeadLine = employee.DeadLine;
            Done = employee.Done;
            Failed = employee.Failed;
            Id = employee.Id;
            repository = new RepositoryReal();
            DeleteTaskCommand = ReactiveCommand.Create(DeleteTask);
        }
        public ReactiveCommand<Unit, Unit> DeleteTaskCommand { get;  }
        private void DeleteTask()
        {
            repository.DeleteTaskForEmployee(this.GetModel().Id);
            Employee?.Update();
            OnDelete?.Invoke();
        }
        public TaskForEmployee GetModel()
        {
            TaskForEmployee taskForEmployee = new TaskForEmployee();
            taskForEmployee.Id = this.Id;
            
            taskForEmployee.ShortDescription = this.ShortDescription;
            taskForEmployee.LongDescription = this.LongDescription;
            taskForEmployee.DeadLine = this.DeadLine;
            taskForEmployee.Done = this.Done;
            taskForEmployee.Failed = this.Failed;
            return taskForEmployee;

        }
    }
}
