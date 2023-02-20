namespace Commonality.Dto.Patient
{
    public class PatientNameDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string NameToShow { get; set; } = null!;

        public int PatientId { get; set; }
    }
}
