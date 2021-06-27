using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TaskMaster.AvaloniaUI.Views
{
    public partial class NewEmployeeView : UserControl
    {
        public NewEmployeeView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
