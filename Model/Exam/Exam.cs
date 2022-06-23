using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Exam
{
    [Table("Exams")]
    public class Exam
    {
        public string Code { get; set; }
        public string Comment { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }

        public ICollection<File.File> Files { get; } = new List<File.File>();
        public int PatientId { get; set; }
        public DateTime RecordingDate { get; set; }

        public void AddFile(File.File file)
        {
            Files.Add(file);
        }
    }
}
