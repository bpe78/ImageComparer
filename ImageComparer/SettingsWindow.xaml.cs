using System.Windows;

using ImageComparer.Services;

namespace ImageComparer
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel(new UIService());
        }
    }
}
