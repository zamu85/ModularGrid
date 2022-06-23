using Commonality.Dto.File;
using Model;

namespace Services.File
{
    public class FileService
    {
        private IUnitOfWork _unitOfWork;

        public FileService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<FileDto> GetFilesByExamId(int examId)
        {
            return _unitOfWork.FileRepository.Find(x => x.ExamId == examId)
                .Select(x => new FileDto()
                {
                    ExamType = x.ExamType,
                    Comment = x.Comment,
                    RecordingTime = x.RecordingTime
                });
        }
    }
}
