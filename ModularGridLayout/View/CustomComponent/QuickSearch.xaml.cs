using System.Windows;
using System.Windows.Controls;

namespace View.View.CustomComponent
{
    /// <summary>
    /// Interaction logic for TestAutoSuggest.xaml
    /// </summary>
    public partial class QuickSearch : UserControl
    {
        public QuickSearch()
        {
            InitializeComponent();
        }



        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            patients.Clear();
        }
    }
}
