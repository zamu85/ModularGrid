using Microsoft.EntityFrameworkCore;
using Model.Exam;

namespace Persistence.Exam
{
    internal class ExamRepository : GenericRepository<Model.Exam.Exam>, IExamRepository
    {
        public ExamRepository(IDbContextFactory<PatientContext> context) : base(context)
        {
        }

        public IEnumerable<Model.Exam.Exam> GetPatientExamWithFiles(int patientId)
        {
            using var context = _context.CreateDbContext();

            return context.Exam.Where(e => e.PatientId == patientId)
                .Include(f => f.Files);
        }
    }
}
