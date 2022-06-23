using Model.Patient;

namespace Persistence.Patient
{
    public class PatientRepository : GenericRepository<Model.Patient.Patient>, IPatientRepository
    {
        public PatientRepository(PatientContext context) : base(context)
        {
        }
    }
}
