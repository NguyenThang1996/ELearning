using ELearning.Helpers;
using ELearning.Models;
using ELearning.Services;
using ELearning.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ELearning.ViewModels
{
    /// <summary>
    ///     LoginPageViewModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class LoginPageViewModel : BaseViewModel
    {
        #region Khai báo các service sử dụng và constructor
        private readonly ILoginService _loginService;

        /// <summary>Khởi tạo constructor của LoginPageViewModel</summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="loginService">The login service.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public LoginPageViewModel(INavigationService navigationService, ILoginService loginService)
    : base(navigationService)
        {
            _loginService = loginService;
        }
        #endregion

        #region Khởi tạo page, get thông tin từ SecureStorage ra
        /// <summary>Khởi tạo page, get thông tin từ SecureStorage ra</summary>
        /// <param name="parameters">The parameters.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public override async void Initialize(INavigationParameters parameters)
        {
            try
            {
                Username = await SecureStorage.GetAsync("Username");
                Password = await SecureStorage.GetAsync("Password");
                Remember = Convert.ToBoolean(await SecureStorage.GetAsync("Remember"));
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Khai báo các biến dùng cơ chế binding dữ liệu 2 chiều
        private string _username;
        public string Username { get => _username; set => SetProperty(ref _username, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        private bool _remember;
        public bool Remember { get => _remember; set => SetProperty(ref _remember, value); }

        private bool _hasError;
        public bool HasError { get => _hasError; set => SetProperty(ref _hasError, value); }

        private string _errorText;
        public string ErrorText { get => _errorText; set => SetProperty(ref _errorText, value); }
        #endregion

        #region Khai báo các command
        // Command check login
        public DelegateCommand LoginCommand => new DelegateCommand(Login);
        #endregion Khai báo các command

        #region Define các hàm sử dụng
        /// <summary>Hàm check login</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        private async void Login()
        {
            try
            {
                ErrorText = string.Empty;
                HasError = false;
                if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
                {
                    if (Username.Length > 50)
                    {
                        ErrorText = "Tên đăng nhập không được quá 50 ký tự";
                        HasError = true;
                    }
                    if (Validator.IsValidSpecialCharacter(Username))
                    {
                        ErrorText = "Tên đăng nhập không được dùng các kí tự không cho phép";
                        HasError = true;
                    }
                    if (Password.Length > 50)
                    {
                        ErrorText = "Mật khẩu không được quá 50 ký tự";
                        HasError = true;
                    }
                    if (Validator.IsValidSpecialCharacter(Password))
                    {
                        ErrorText = "Mật khẩu không được dùng các kí tự không cho phép";
                        HasError = true;
                    }
                    if (!HasError && ErrorText == string.Empty)
                    {
                        var response = await _loginService.CheckLogin(new UserLoginModel
                        {
                            Username = Username,
                            Password = Password
                        });
                        if (response != null || response != default)
                        {
                            // Nếu đăng nhập thành công lưu thông tin user vào SecureStorage
                            if (response.Status == true)
                            {
                                HasError = false;
                                ErrorText = response.Message;
                                // Nếu tích chọn Nhớ mật khẩu thì bind tên đăng nhập và mật khẩu lên entry
                                await SecureStorage.SetAsync("UserInfo", JsonConvert.SerializeObject(response.Data));
                                if (Remember)
                                {
                                    await SecureStorage.SetAsync("Username", Username);
                                    await SecureStorage.SetAsync("Password", Password);
                                    await SecureStorage.SetAsync("Remember", Remember.ToString());
                                }
                                else
                                {
                                    SecureStorage.Remove("Username");
                                    SecureStorage.Remove("Password");
                                    SecureStorage.Remove("Remember");
                                }
                                await navigationService.NavigateAsync("/MainPage");
                            }
                            else
                            {
                                HasError = true;
                                ErrorText = response.Message;
                            }
                        }
                        else
                        {
                            HasError = true;
                            ErrorText = "Đăng nhập thất bại";
                        }
                    }

                }
                else if (!String.IsNullOrEmpty(Username) && String.IsNullOrEmpty(Password))
                {
                    ErrorText = "Mật khẩu không được để trống";
                    HasError = true;
                }
                else if (!String.IsNullOrEmpty(Password) && String.IsNullOrEmpty(Username))
                {
                    ErrorText = "Tên đăng nhập không được để trống";
                    HasError = true;
                }
                else
                {
                    ErrorText = "Tên đăng nhập và mật khẩu không được để trống";
                    HasError = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
