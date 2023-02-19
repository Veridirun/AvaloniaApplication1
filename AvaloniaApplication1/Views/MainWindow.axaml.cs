using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.ViewModels;
using System.Linq.Expressions;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            CanResize = false;
        }
    }
}
