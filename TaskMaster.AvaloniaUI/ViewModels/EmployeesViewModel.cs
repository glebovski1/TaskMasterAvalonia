using Avalonia.Controls;
using DataAccess;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.DataAccess;

namespace TaskMaster.AvaloniaUI.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        RepositoryReal repository;
        public EmployeesViewModel()
        {
            repository = new RepositoryReal();
            NewEmployeeCommand = ReactiveCommand.Create(NewEmployee);
            LoadData();
        }
        public ReactiveCommand<Unit, Unit> NewEmployeeCommand { get; }

        private ObservableCollection<EmployeeViewModel> employees;
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get;set;

        }


        public void LoadData()
        {
            Employees = new ObservableCollection<EmployeeViewModel>(repository.GetEmployees().Select(item => new EmployeeViewModel(item, this)).ToList());
        }

        private void NewEmployee()
        {
           
            var newEmployee = new NewEmployeeViewModel(null);
            Window window = new Window();
            window.Height = 400;
            window.Width = 400;
            newEmployee.CloseWindow += () => window.Close();
            newEmployee.CloseWindow += () => Update();
            window.Content = newEmployee;
            window.Show();
            

        }

        public void Update()
        {
            LoadData();
            this.RaisePropertyChanged("Employees");

        }
    }

}
