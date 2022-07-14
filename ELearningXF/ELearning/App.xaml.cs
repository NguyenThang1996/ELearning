using ELearning.Services;
using ELearning.ViewModels;
using ELearning.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ELearning
{
    /// <summary>
    ///     App
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public partial class App
    {
        #region Khai báo các service sử dụng và constructor
        /// <summary>Khởi tạo constructor của App</summary>
        /// <param name="initializer">The initializer.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }
        #endregion

        #region Khởi tạo start page là LoginPage
        /// <summary>Khởi tạo startpage là LoginPage</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("LoginPage");
        }
        #endregion

        #region Đăng ký các service vào DIContainer
        /// <summary>Đăng ký các service vào DIContainer</summary>
        /// <param name="containerRegistry"></param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IHttpService, HttpService>();
            containerRegistry.Register<ILoginService, UserService>();
            containerRegistry.Register<IStaffService, StaffService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewPage, ViewPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<AddEditPage, AddEditPageViewModel>();
            containerRegistry.RegisterForNavigation<ListPage, ListPageViewModel>();
            containerRegistry.RegisterForNavigation<NotificationPage, NotificationPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
        }
        #endregion
    }
}
