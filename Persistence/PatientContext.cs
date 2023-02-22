using Commonality.Dto.Patient;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Model.Exam.Exam> Exam { get; set; }
        public DbSet<Model.File.File> Files { get; set; }
        public DbSet<Model.Patient.Patient> Patient { get; set; }

        public DbSet<PatientNameDto> QuickSearch { get; set; }

        public override void Dispose()
        {
            //base.Dispose();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Patient.Patient>(e =>
            {
                e.Property(e => e.BirthDate).HasColumnType("datetime");
            });

            modelBuilder
                .Entity<PatientNameDto>()
                .ToView(nameof(QuickSearch))
                .HasKey(t => t.PatientId);
        }
    }
}
