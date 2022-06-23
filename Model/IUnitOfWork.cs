namespace Model
{
    using Model.Exam;
    using Model.File;
    using Model.Patient;

    public interface IUnitOfWork : IDisposable
    {
        IExamRepository ExamRepository { get; }
        IFileRepository FileRepository { get; }
        IPatientRepository PatientRepository { get; }

        int Save();
    }
}
