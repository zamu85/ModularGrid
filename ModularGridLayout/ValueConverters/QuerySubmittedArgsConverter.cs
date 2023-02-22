using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Editors;
using View.EventArgs;

namespace View.ValueConverters
{
    public class QuerySubmittedArgsConverter : IEventArgsConverter
    {
        public object Convert(object sender, object args)
        {
            AutoSuggestEditQueryWithSenderArgs newArgs = new();
            newArgs.Sender = sender;
            newArgs.AutoSuggestEditQuerySubmittedEventArgs = (AutoSuggestEditQuerySubmittedEventArgs)args;

            return newArgs;
        }
    }
}
