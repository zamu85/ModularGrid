using Commonality.Dto.Messages;
using DevExpress.Mvvm;

namespace View.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int _selectedLayout = 1;

        public MainWindowViewModel()
        {
            ChangeLayoutCommand = new DelegateCommand<int>(ChangeLayout, CanChangeLayout);
            Messenger.Default.Send<ChangeLayout>(new ChangeLayout(_selectedLayout));
        }

        public DelegateCommand<int> ChangeLayoutCommand { get; set; }

        public int SelectedLayout
        {
            get { return _selectedLayout; }
        }

        public bool CanChangeLayout(int selectedLayout) => true;

        public void ChangeLayout(int selectedLayout)
        {
            _selectedLayout = selectedLayout;
            RaisePropertiesChanged("SelectedLayout");
            Messenger.Default.Send<ChangeLayout>(new ChangeLayout(selectedLayout));
        }
    }
}
