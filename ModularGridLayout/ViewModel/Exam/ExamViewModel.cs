using System.Collections.ObjectModel;
using Commonality.Dto.Exam;
using Commonality.Dto.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Services.Exam;

namespace View.ViewModel.Exam
{
    public class ExamViewModel : ViewModelBase
    {
        private readonly ExamService _examService;
        private ExamDto _selectedExam;
        private int _selectedLayout;

        public ExamViewModel(ExamService examService)
        {
            _examService = examService;
            Messenger.Default.Register<PatientMessage>(this, onPatientSelected);
            Messenger.Default.Register<ChangeLayout>(this, onLayoutChanged);
        }

        public ObservableCollection<ExamDto> Exams { get; } = new ObservableCollection<ExamDto>();

        public ExamDto SelectedExam
        {
            get { return _selectedExam; }
            set
            {
                _selectedExam = value;
                if (value != null)
                {
                    Messenger.Default.Send<ExamMessage>(new ExamMessage(_selectedExam.ExamId));
                }
            }
        }

        public int SelectedLayout
        {
            get { return _selectedLayout; }
            set { _selectedLayout = value; }
        }

        private void onLayoutChanged(ChangeLayout message)
        {
            _selectedLayout = message.LayoutId;
            RaisePropertyChanged("SelectedLayout");
        }

        private void onPatientSelected(PatientMessage message)
        {
            Exams.Clear();
            _examService.GetExams(message.PatientId).ForEach(Exams.Add);
        }
    }
}
