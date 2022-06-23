using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Model.Exam.Exam> Exam { get; set; }
        public DbSet<Model.File.File> Files { get; set; }
        public DbSet<Model.Patient.Patient> Patient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
