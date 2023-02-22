using Commonality.Dto.Patient;

namespace Model.Patient
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        IEnumerable<Patient> GetAllPatientsWithExams();

        Task<IEnumerable<PatientNameDto>> QuickSearch(string text);

        Task<IQueryable<PatientNameDto>> QuickSearch();
    }
}
