using System.Windows.Controls;
using DevExpress.Xpf.Grid;
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

            patientsGrid.MasterRowExpanded += OnGridMasterRowExpanded;
            examsGrid.MasterRowExpanded += OnDetailGridMasterRowExpanded;
        }

        private void OnDetailGridMasterRowExpanded(object sender, RowEventArgs e)
        {
            GridControl detailGrid = (GridControl)((TableView)e.Source).Grid.GetDetail(e.RowHandle);
            ((TableView)detailGrid.View).BestFitColumns();
        }

        private void OnGridMasterRowExpanded(object sender, RowEventArgs e)
        {
            GridControl detailGrid = (GridControl)((GridControl)sender).GetDetail(e.RowHandle);
            ((TableView)detailGrid.View).BestFitColumns();
        }
    }
}
