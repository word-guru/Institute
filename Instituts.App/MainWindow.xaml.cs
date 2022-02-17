using System.Windows;

namespace Instituts.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                var auth = new Authorization.Authorization();
                auth.Show();
            };
        }
    }
}
