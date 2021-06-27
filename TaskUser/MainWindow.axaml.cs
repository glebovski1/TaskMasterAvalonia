using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DataAccess;
using System.Collections.ObjectModel;
using TaskMaster.DataAccess.Models;

namespace TaskUser
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee CurrentEmployee { get; set; }

        RepositoryReal repositoryReal;
        public MainWindow()
        {
            
           
            repositoryReal = new RepositoryReal();
            var employees = repositoryReal.GetEmployees();
            Employees = new ObservableCollection<Employee>(employees);

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
