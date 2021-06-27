using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.AvaloniaUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase content;
        public ViewModelBase Content
        {
            get
            {
                return content;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }
        public MainViewModel()
        {
            GoToUsersCommand = ReactiveCommand.Create(GoToUsers);
            GoToTasksCommand = ReactiveCommand.Create(GoToTasks);
            GoToCalendarCommand = ReactiveCommand.Create(GoToCalendar);
        }
        public ReactiveCommand<Unit, Unit> GoToUsersCommand { get; }
        public ReactiveCommand<Unit, Unit> GoToTasksCommand { get; }
        public ReactiveCommand<Unit, Unit> GoToCalendarCommand { get; }
        private void GoToUsers()
        {
            Content = new EmployeesViewModel();
        }
        private void GoToTasks()
        {
            Content = new TasksForEmployeeViewModel();
        }
        private void GoToCalendar()
        {
            Content = new CalendarViewModel();
        }
    }
}
