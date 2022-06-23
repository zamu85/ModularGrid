using Commonality.Dto.Exam;
using Model;

namespace Services.Exam
{
    public class ExamService
    {
        private IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ExamDto> GetExams(int patientId)
        {
            return _unitOfWork.ExamRepository.Find(x => x.PatientId == patientId).Select(x => new ExamDto()
            {
                Code = x.Code,
                Comment = x.Comment,
                ExamId = x.ExamId,
                RecordingDate = x.RecordingDate,
            });
        }
    }
}
