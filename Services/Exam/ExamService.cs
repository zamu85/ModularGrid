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

        public IEnumerable<ExamDto> GetPatientExamWithFiles(int patientId)
        {
            var result = _unitOfWork.ExamRepository.GetPatientExamWithFiles(patientId);

            if (result != null)
            {
                return result.Select(e => new ExamDto()
                {
                    Code = e.Code,
                    Comment = e.Comment,
                    RecordingDate = e.RecordingDate,
                    ExamId = e.ExamId,
                    Files = e.Files.Select(f => new Commonality.Dto.File.FileDto()
                    {
                        Comment = f.Comment,
                        ExamType = f.ExamType,
                        RecordingTime = f.RecordingTime
                    }).ToList()
                });
            }

            return null;
        }
    }
}
