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
        private PatientContext _context;

        public UnitOfWork(IDbContextFactory<PatientContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
            _contextFactory = contextFactory;
            PatientRepository = new PatientRepository(_context);
            ExamRepository = new ExamRepository(_context);
            FileRepository = new FileRepository(_context);
        }

        public IExamRepository ExamRepository { get; private set; }
        public IFileRepository FileRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
