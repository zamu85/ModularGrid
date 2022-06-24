using System.Windows.Controls;
using ModularGridLayout;

namespace View.View.File
{
    /// <summary>
    /// Interaction logic for FileGridView.xaml
    /// </summary>
    public partial class FileGridView : UserControl
    {
        public FileGridView()
        {
            InitializeComponent();
            this.DataContext = App.MainWindowVM;
        }
    }
}
