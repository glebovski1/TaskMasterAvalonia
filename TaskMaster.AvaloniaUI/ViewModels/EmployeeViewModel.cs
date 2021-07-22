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
using TaskMaster.DataAccess.Models;

namespace TaskMaster.AvaloniaUI.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        EmployeesViewModel parentView;
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public ObservableCollection<TaskForEmployeeViewModel> Tasks { get; set; }

        private RepositoryReal repository;
        public EmployeeViewModel(string firstName)
        {
            Position = "Generic";
            FirstName = firstName;
            DeleteCommand = ReactiveCommand.Create(Delete);
        }
        private void LoadData()
        {
            Tasks = new ObservableCollection<TaskForEmployeeViewModel>(repository.GetTaskForEmployees(this.Id).Select(task => new TaskForEmployeeViewModel(task) { Employee = this}).ToList());

        }
        public EmployeeViewModel(Employee employee, EmployeesViewModel parentView = null)
        {
            this.parentView = parentView;
            this.Id = employee.Id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Position = employee.Position;
            //Tasks = employee.Tasks?.Select(task => new TaskForEmployeeViewModel(task)).ToList();
            DeleteCommand = ReactiveCommand.Create(Delete);
            AddTaskCommand = ReactiveCommand.Create(AddTask);
            EditeEmployeeCommand = ReactiveCommand.Create(EditeEmployee);
            repository = new RepositoryReal();
            LoadData();
        }

        private void EditeEmployee()
        {
            var newEmployee = new NewEmployeeViewModel(this.GetModel());
            Window window = new Window();
            window.Height = 400;
            window.Width = 400;
            newEmployee.CloseWindow += () => window.Close();
            newEmployee.CloseWindow += () => Update();
            //newEmployee.CloseWindow += () => parentView.Update();
            window.Content = newEmployee;
            window.Show();
        }
        public Employee GetModel()
        {
            Employee employee = new Employee();
            employee.Id = this.Id;
            employee.FirstName = this.FirstName;
            employee.LastName = this.LastName;
            employee.Position = this.Position;
            //employee.Tasks = this.Tasks?.Select(task => task.GetModel()).ToList();
            return employee;
        }
        public ReactiveCommand<Unit, Unit> DeleteCommand { get; }
        public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }
        public ReactiveCommand<Unit, Unit> EditeEmployeeCommand { get; }

        private void Delete()
        {
            int id = this.GetModel().Id;
            RepositoryReal repository = new RepositoryReal();
            repository.DeleteEmployee(id);
            parentView.Update();
            //var employeeToDelete = parentView?.Employees.FirstOrDefault(employee => employee.Id == id);
            //if(employeeToDelete == null) parentView.Employees.Remove(employeeToDelete);
            
            
        }
        public void Update()
        {
            var employee = repository.FindEmployee(this.Id);
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.Position = employee.Position;
            LoadData();
            this.RaisePropertyChanged("Tasks");
            this.RaisePropertyChanged("FirstName");
            this.RaisePropertyChanged("LastName");
            this.RaisePropertyChanged("Position");
        }
        private void AddTask()
        {
            Window window = new Window();
            window.Height = 400;
            window.Width = 400;
            NewTaskViewModel newTaskViewModel = new NewTaskViewModel(this.Id);
            newTaskViewModel.CloseWindow += window.Close;
            newTaskViewModel.CloseWindow += Update;
            window.Content = newTaskViewModel;
            
            window.Show();
        }
    }
}
