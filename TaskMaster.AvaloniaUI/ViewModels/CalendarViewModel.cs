using Avalonia.Controls.Primitives;
using DataAccess;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.AvaloniaUI.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        RepositoryReal repository;
        private List<TaskForEmployeeViewModel> tasks;
        public SelectedDatesCollection Dates { get; set; }

        public EventHandler Initialization { get; set; }
         public ReactiveCommand<Unit, Unit> InsertTasksCommand { get; }
        public CalendarViewModel()
        {
            Initialization += InsertTasksDateTime;
            repository = new RepositoryReal();
            tasks = repository.GetTaskForEmployees().Where(task => task.Done == false && task.Failed == false).Select(task => new TaskForEmployeeViewModel(task)).ToList();
            //InsertTasksCommand = ReactiveCommand.Create(InsertTasksDateTime);
        }
        public void InsertTasksDateTime(object? sender, EventArgs e)
        {
            var dateTimes = tasks.Select(task => task.DeadLine);
            foreach (var dateTime in dateTimes)
            {
                Dates.Insert((int)dateTime.Ticks, dateTime);
            }
            
        }
    }
}
