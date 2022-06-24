using System.Collections.Generic;
using Commonality.Dto.Exam;
using Services.Exam;

namespace View.ViewModel.Exam
{
    public class ExamViewModel : IProxyExamViewModel
    {
        private readonly ExamService _examService;
        private ExamDto _selectedExam;
        private int _selectedLayout = 1;

        public ExamViewModel(ExamService examService)
        {
            _examService = examService;
            //Messenger.Default.Register<PatientMessage>(this, onPatientSelected);
            //Messenger.Default.Register<ChangeLayout>(this, onLayoutChanged);
        }

        //public ObservableCollection<ExamDto> Exams { get; } = new ObservableCollection<ExamDto>();

        //public ExamDto SelectedExam
        //{
        //    get { return _selectedExam; }
        //    set
        //    {
        //        _selectedExam = value;
        //        if (value != null)
        //        {
        //            Messenger.Default.Send<ExamMessage>(new ExamMessage(_selectedExam.ExamId));
        //        }
        //    }
        //}

        //public int SelectedLayout
        //{
        //    get { return _selectedLayout; }
        //    set { _selectedLayout = value; }
        //}

        public IEnumerable<ExamDto> GetAll(int patientId)
        {
            return _examService.GetPatientExamWithFiles(patientId);
        }

        //private void onLayoutChanged(ChangeLayout message)
        //{
        //    _selectedLayout = message.LayoutId;
        //    RaisePropertyChanged("SelectedLayout");
        //}

        //private void onPatientSelected(PatientMessage message)
        //{
        //    Exams.Clear();

        // switch (_selectedLayout) { case 1:
        // _examService.GetExams(message.PatientId).ForEach(Exams.Add); break;

        //        case 2:
        //            _examService.GetPatientExamWithFiles(message.PatientId).ForEach(Exams.Add);
        //            break;
        //    }
        //}
    }
}
