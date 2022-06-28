using Commonality.Dto.Exam;

namespace Commonality.Dto.Patient
{
    public class PatientDto
    {
        public DateTime BirthDate { get; set; }
        public IList<ExamDto> Exams { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PatientId { get; set; }

        public int TotalExams
        { get { return Exams.Count; } }
    }
}
