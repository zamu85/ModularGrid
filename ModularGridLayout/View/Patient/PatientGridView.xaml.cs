using System.Windows.Controls;
using ModularGridLayout;

namespace View.View.Patient
{
    /// <summary>
    /// Interaction logic for PatientGridView.xaml
    /// </summary>
    public partial class PatientGridView : UserControl
    {
        public PatientGridView()
        {
            InitializeComponent();
            this.DataContext = App.MainWindowVM;
        }
    }
}
