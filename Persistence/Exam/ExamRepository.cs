using Microsoft.EntityFrameworkCore;
using Model.Exam;

namespace Persistence.Exam
{
    internal class ExamRepository : GenericRepository<Model.Exam.Exam>, IExamRepository
    {
        public ExamRepository(PatientContext context) : base(context)
        {
        }

        public IEnumerable<Model.Exam.Exam> GetPatientExamWithFiles(int patientId)
        {
            return _context.Exam.Where(e => e.PatientId == patientId)
                .Include(f => f.Files);
        }
    }
}
