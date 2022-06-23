using System.Windows.Controls;
using ModularGridLayout;

namespace View.View.Exam
{
    /// <summary>
    /// Interaction logic for ExamGridView.xaml
    /// </summary>
    public partial class ExamGridView : UserControl
    {
        public ExamGridView()
        {
            InitializeComponent();
            this.DataContext = App.ExamVM;
        }
    }
}
