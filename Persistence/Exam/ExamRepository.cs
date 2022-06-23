using Model.Exam;

namespace Persistence.Exam
{
    internal class ExamRepository : GenericRepository<Model.Exam.Exam>, IExamRepository
    {
        public ExamRepository(PatientContext context) : base(context)
        {
        }
    }
}
