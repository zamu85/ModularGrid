using System.Windows;

namespace ModularGridLayout.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = App.MainWindowVM;
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            patients.Clear();
        }
    }
}
