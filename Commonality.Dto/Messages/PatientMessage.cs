namespace Commonality.Dto.Messages
{
    public class PatientMessage
    {
        public PatientMessage(int id)
        {
            PatientId = id;
        }

        public int PatientId { get; private set; }
    }
}
