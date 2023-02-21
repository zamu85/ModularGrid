using Microsoft.EntityFrameworkCore;
using Model.Patient;
using System.Text.RegularExpressions;

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

        public async Task<IEnumerable<Model.Patient.Patient>> QuickSearch(string text)
        {
            return await Task.Run(() =>
            {
                return context.Patient
                .Select(p => new
                {
                    FullName = p.LastName + " " + p.FirstName,
                    FullNameReverse = p.FirstName + " " + p.LastName,
                    Patient = p
                }).AsEnumerable().Where(p =>
                    Regex.IsMatch(p.Patient.LastName, Regex.Escape(text), RegexOptions.IgnoreCase)
                    || Regex.IsMatch(p.Patient.FirstName, Regex.Escape(text), RegexOptions.IgnoreCase)
                    || Regex.IsMatch(p.FullNameReverse, Regex.Escape(text), RegexOptions.IgnoreCase)
                    || Regex.IsMatch(p.FullName, Regex.Escape(text), RegexOptions.IgnoreCase))
                .Take(50)
                .Select(p => new Model.Patient.Patient(p.Patient));
            });
        }
    }
}
