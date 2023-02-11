using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        DelegateCommand<string> _command;
        public DelegateCommand<string> Command => _command ?? (_command = new DelegateCommand<string>((arg) => 
        {
            RegionManager.Regions["ContentRegion"].RequestNavigate(arg);
        }));

        public IRegionManager RegionManager { get; }
    }
}
