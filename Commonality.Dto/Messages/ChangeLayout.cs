namespace Commonality.Dto.Messages
{
    public class ChangeLayout
    {
        public ChangeLayout(int layoutId)
        {
            LayoutId = layoutId;
        }

        public int LayoutId { get; private set; }
    }
}
