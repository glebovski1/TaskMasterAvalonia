using DataAccess;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.DataAccess;

namespace TaskMaster.AvaloniaUI.ViewModels
{
    public class TasksForEmployeeViewModel : ViewModelBase
    {
        RepositoryReal repository;
        public TasksForEmployeeViewModel()
        {
            repository = new RepositoryReal();
            LoadData();
        }
        public ObservableCollection<TaskForEmployeeViewModel> Tasks { get; set; }
        
        private void LoadData()
        {
            Tasks = new ObservableCollection<TaskForEmployeeViewModel>(repository.GetTaskForEmployees()?.Select(item => new TaskForEmployeeViewModel(item)));
            foreach (var task in Tasks)
            {
                task.OnDelete += Update;
            }
            
        }
        public void Update()
        {
            
            LoadData();
            this.RaisePropertyChanged("Tasks");
        }
    }
}
