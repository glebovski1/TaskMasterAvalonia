using Avalonia.Controls;
using DataAccess;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

using TaskMaster.DataAccess;
using TaskMaster.DataAccess.Models;

namespace TaskMaster.AvaloniaUI.ViewModels
{
   public class NewEmployeeViewModel : ViewModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public Action CloseWindow;

        public NewEmployeeViewModel()
        {
            AddEmployeeCommand = ReactiveCommand.Create(AddEmpoyee);
        }
        private void AddEmpoyee()
        {
            if(FirstName != null && FirstName.Length > 0)
            {
                Employee employee = new Employee();
                employee.FirstName = FirstName;
                employee.LastName = LastName;
                employee.Position = Position;

                RepositoryReal repository = new RepositoryReal();
                repository.AddEmployee(employee);

                CloseWindow?.Invoke();
            }
            
        }

        public ReactiveCommand<Unit, Unit> AddEmployeeCommand { get; }
        
    }
}
