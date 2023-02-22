namespace Commonality.Dto.Patient
{
    public class PatientNameDto
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; } = null!;

        public string FullName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public int PatientId { get; set; }
        public string ReverseName { get; set; } = null!;
    }
}
