using Microsoft.EntityFrameworkCore;
using Model.Patient;

namespace Persistence.Patient
{
    public class PatientRepository : GenericRepository<Model.Patient.Patient>, IPatientRepository
    {
        public PatientRepository(PatientContext context) : base(context)
        {
        }

        public IEnumerable<Model.Patient.Patient> GetAllPatientsWithExams()
        {
            return context.Patient
                .Include(e => e.Exams)
                .ThenInclude(f => f.Files);
        }
    }
}
