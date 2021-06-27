using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TaskMaster.AvaloniaUI.Views
{
    public partial class TaskForEmployeeView : UserControl
    {
        public TaskForEmployeeView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
