using DevExpress.Xpf.Editors;

namespace View.EventArgs
{
    public class AutoSuggestEditQueryWithSenderArgs
    {
        public AutoSuggestEditQuerySubmittedEventArgs AutoSuggestEditQuerySubmittedEventArgs { get; set; } = null!;
        public object Sender { get; set; } = null!;
    }
}
