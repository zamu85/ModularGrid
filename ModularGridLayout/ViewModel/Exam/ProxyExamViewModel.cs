using System.Collections.Generic;
using Commonality.Dto.Exam;
using Services.Exam;

namespace View.ViewModel.Exam
{
    public class ProxyExamViewModel : IProxyExamViewModel
    {
        private readonly ExamService _examService;
        private IDictionary<int, IEnumerable<ExamDto>> _examsForPatient;
        private ExamViewModel _examViewModel;

        public ProxyExamViewModel(ExamService examService)
        {
            _examService = examService;
            _examViewModel = new ExamViewModel(examService);
            _examsForPatient = new Dictionary<int, IEnumerable<ExamDto>>();
        }

        public IEnumerable<ExamDto> GetAll(int patientId)
        {
            if (_examsForPatient.ContainsKey(patientId))
            {
                return _examsForPatient[patientId];
            }

            var result = _examViewModel.GetAll(patientId);

            _examsForPatient.Add(patientId, result);

            return result;
        }
    }
}
