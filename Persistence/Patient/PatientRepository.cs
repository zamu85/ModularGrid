using Commonality.Dto.Patient;
using Microsoft.EntityFrameworkCore;
using Model.Patient;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Persistence.Patient
{
    public class PatientRepository : GenericRepository<Model.Patient.Patient>, IPatientRepository
    {
        public PatientRepository(IDbContextFactory<PatientContext> context) : base(context)
        {
        }

        public IEnumerable<Model.Patient.Patient> GetAllPatientsWithExams()
        {
            using (var context = _context.CreateDbContext())
            {
                return context.Patient
                    .Include(e => e.Exams)
                    .ThenInclude(f => f.Files);
            }
        }

        public async Task<IEnumerable<PatientNameDto>> QuickSearch(string text)
        {
            return await Task.Run(() =>
            {
                Stopwatch stopWatch = new Stopwatch();
                //var query = context.Patient
                //.Select(p => new
                //{
                //    FullName = p.LastName + " " + p.FirstName,
                //    FullNameReverse = p.FirstName + " " + p.LastName,
                //    Patient = p
                //}).AsEnumerable().Where(p =>
                //    Regex.IsMatch(p.Patient.LastName, Regex.Escape(text), RegexOptions.IgnoreCase)
                //    || Regex.IsMatch(p.Patient.FirstName, Regex.Escape(text), RegexOptions.IgnoreCase)
                //    || Regex.IsMatch(p.FullNameReverse, Regex.Escape(text), RegexOptions.IgnoreCase)
                //    || Regex.IsMatch(p.FullName, Regex.Escape(text), RegexOptions.IgnoreCase))
                //.Take(50)
                //.Select(p => new Model.Patient.Patient(p.Patient));

                //return query;
                using var context = _context.CreateDbContext();
                stopWatch.Start();
                var q = context.QuickSearch.AsEnumerable().Where(p =>
                    //Regex.IsMatch(p.LastName, Regex.Escape(text), RegexOptions.IgnoreCase)
                    //|| Regex.IsMatch(p.FirstName, Regex.Escape(text), RegexOptions.IgnoreCase)
                    Regex.IsMatch(p.ReverseName, Regex.Escape(text), RegexOptions.IgnoreCase)
                    || Regex.IsMatch(p.FullName, Regex.Escape(text), RegexOptions.IgnoreCase))
                .Take(50)
                .OrderBy(p => p.FirstName);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                Debug.WriteLine("RunTime " + elapsedTime);
                return q;
            });
        }

        public async Task<IQueryable<PatientNameDto>> QuickSearch()
        {
            return await Task.Delay(100).ContinueWith(t =>
            {
                using (var context = _context.CreateDbContext())
                {
                    return context.QuickSearch;
                }
            });
        }
    }
}
