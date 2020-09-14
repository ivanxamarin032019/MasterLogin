using MasterLogin.Common.Helpers;
using MasterLogin.Common.Services;
using MasterLogin.Prism.Helpers;
using MasterLogin.Prism.ViewModels;
using MasterLogin.Prism.Views;
using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;



namespace MasterLogin.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzA4NTUxQDMxMzgyZTMyMmUzMGdtZmtxYXc5MmVvVURoTHBXaWFPY2hLbWtaTVJmRDl1eUVodWw1V1NQNWM9");

            InitializeComponent();
            // await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            await NavigationService.NavigateAsync(nameof(LoginPage));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IRegexHelper, RegexHelper>();
            containerRegistry.Register<IFilesHelper, FilesHelper>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RecoverPasswordPage, RecoverPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }
    }
}
