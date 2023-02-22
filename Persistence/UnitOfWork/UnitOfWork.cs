using Microsoft.EntityFrameworkCore;
using Model;
using Model.Exam;
using Model.File;
using Model.Patient;
using Persistence.Exam;
using Persistence.File;
using Persistence.Patient;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory<PatientContext> _contextFactory;

        public UnitOfWork(IDbContextFactory<PatientContext> contextFactory)
        {
            _contextFactory = contextFactory;
            PatientRepository = new PatientRepository(_contextFactory);
            ExamRepository = new ExamRepository(_contextFactory);
            FileRepository = new FileRepository(_contextFactory);
        }

        public IExamRepository ExamRepository { get; private set; }
        public IFileRepository FileRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }

        public void Dispose()
        {
        }

        public int Save()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.SaveChanges();
        }
    }
}
