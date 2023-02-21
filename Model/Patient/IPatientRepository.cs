namespace Model.Patient
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        IEnumerable<Patient> GetAllPatientsWithExams();

        Task<IEnumerable<Patient>> QuickSearch(string text);
    }
}
