using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Patient
{
    [Table("Patients")]
    public class Patient
    {
        public Patient(DateTime birthDate, string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException();
            }

            if (birthDate > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException();
            }

            BirthDate = birthDate;
            FirstName = firstName;
            LastName = lastName;
        }

        public DateTime BirthDate { get; set; }
        public ICollection<Model.Exam.Exam> Exams { get; } = new List<Model.Exam.Exam>();
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        public void AddExam(Model.Exam.Exam e)
        {
            Exams.Add(e);
        }
    }
}
