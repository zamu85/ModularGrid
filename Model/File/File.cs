using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.File
{
    [Table("Files")]
    public class File
    {
        public string Comment { get; set; }
        public int ExamId { get; set; }
        public int ExamType { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        public DateTime RecordingTime { get; set; }
    }
}
