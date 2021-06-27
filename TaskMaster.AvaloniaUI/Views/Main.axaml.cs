using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace TaskMaster.AvaloniaUI.Views
{
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void users_Click(object sender, RoutedEventArgs e)
        {
            
        }
        void tasks_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
