using ELearning.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace ELearning.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        #region Khai báo các service sử dụng và constructor
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
        // Hàm logout, navigate về trang login
        private async void Logout()
        {
            try
            {

                await navigationService.NavigateAsync("/LoginPage");
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
