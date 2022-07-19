using ELearning.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;

namespace ELearning.ViewModels
{
    /// <summary>
    ///     ProfilePageViewModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class ProfilePageViewModel : BaseViewModel
    {
        #region Khai báo các service sử dụng và constructor
        /// <summary>Khởi tạo constructor của ProfilePageViewModel</summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public ProfilePageViewModel(INavigationService navigationService)
         : base(navigationService)
        {

        }
        #endregion

        #region Khai báo các command
        // Command logout, navigate về trang login
        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);
        #endregion

        #region Khai báo các hàm sử dụng
        /// <summary>Hàm logout, navigate về trang login</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        private async void Logout()
        {
            try
            {
                await navigationService.NavigateAsync("/LoginPage");
            }
            catch (Exception ex)
            {

                ExceptionLog.GetException(ex, "ProfilePageViewModel", "Logout");
            }
        }
        #endregion
    }
}
