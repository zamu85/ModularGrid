using Commonality.Dto.File;

namespace Commonality.Dto.Exam
{
    public class ExamDto
    {
        public ExamDto()
        {
            Files = new List<FileDto>();
        }

        public string Code { get; set; }
        public string Comment { get; set; }

        public int ExamId { get; set; }
        public IList<FileDto> Files { get; set; }

        public DateTime RecordingDate { get; set; }

        public int TotalFiles
        { get { return Files.Count; } }
    }
}
