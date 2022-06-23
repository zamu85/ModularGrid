using Commonality.Dto.Messages;
using DevExpress.Mvvm;

namespace View.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ChangeLayoutCommand = new DelegateCommand<int>(ChangeLayout, CanChangeLayout);
        }

        public DelegateCommand<int> ChangeLayoutCommand { get; set; }

        public bool CanChangeLayout(int selectedLayout) => true;

        public void ChangeLayout(int selectedLayout)
        {
            Messenger.Default.Send<ChangeLayout>(new ChangeLayout(selectedLayout));
        }
    }
}
