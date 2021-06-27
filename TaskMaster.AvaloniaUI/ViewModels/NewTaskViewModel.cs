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
    public class NewTaskViewModel : ViewModelBase
    {
        RepositoryReal repositoryReal;
        int _executroId;
        DateTime deadLine;
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTimeOffset? DeadLine { get; set; }
        public Action CloseWindow;

        public ReactiveCommand<Unit, Unit> AddTaskCommand { get; private set; }
        public NewTaskViewModel(int executorId)
        {
            _executroId = executorId;
            repositoryReal = new RepositoryReal();
            AddTaskCommand = ReactiveCommand.Create(AddTask);
        }
        private void AddTask()
        {
            TaskForEmployee task = new TaskForEmployee();
            task.ShortDescription = this.ShortDescription;
            task.LongDescription = this.LongDescription;
            task.DeadLine = DeadLine.GetValueOrDefault().DateTime;
            task.Employee = repositoryReal.GetEmployees().FirstOrDefault(employee => employee.Id == _executroId);

            repositoryReal.AddTaskForEmployee(task);
            CloseWindow?.Invoke();
        }
    }
}

