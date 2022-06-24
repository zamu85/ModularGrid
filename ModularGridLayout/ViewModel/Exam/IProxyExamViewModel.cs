using System.Collections.Generic;
using Commonality.Dto.Exam;

namespace View.ViewModel.Exam
{
    public interface IProxyExamViewModel
    {
        IEnumerable<ExamDto> GetAll(int patientId);
    }
}
