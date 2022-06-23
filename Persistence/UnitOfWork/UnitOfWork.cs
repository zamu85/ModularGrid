namespace Persistence.UnitOfWork
{
    using Model;
    using Model.Exam;
    using Model.File;
    using Model.Patient;
    using Persistence.Exam;
    using Persistence.File;
    using Persistence.Patient;

    public class UnitOfWork : IUnitOfWork
    {
        private PatientContext context;

        public UnitOfWork(PatientContext context)
        {
            this.context = context;
            PatientRepository = new PatientRepository(context);
            ExamRepository = new ExamRepository(context);
            FileRepository = new FileRepository(context);
        }

        public IExamRepository ExamRepository { get; private set; }
        public IFileRepository FileRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
