namespace Model.Exam
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        IEnumerable<Exam> GetPatientExamWithFiles(int patientId);
    }
}
