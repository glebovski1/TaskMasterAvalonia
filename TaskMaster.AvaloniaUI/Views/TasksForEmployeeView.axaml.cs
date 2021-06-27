using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TaskMaster.AvaloniaUI.Views
{
    public partial class TasksForEmployeeView : UserControl
    {
        public TasksForEmployeeView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
