namespace Commonality.Dto.Messages
{
    public class ExamMessage
    {
        public ExamMessage(int id)
        {
            ExamId = id;
        }

        public int ExamId { get; private set; }
    }
}
