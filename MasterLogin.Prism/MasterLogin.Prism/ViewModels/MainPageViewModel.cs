using MasterLogin.Prism.Helpers;
using Prism.Navigation;

namespace MasterLogin.Prism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.MainPage;
        }
    }
}