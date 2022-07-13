using ELearning.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services
{
    #region Khai báo interface các service sử dụng
    public interface ILoginService
    {
        // IService check login
        ValueTask<ResponseModel<UserModel>> CheckLogin(UserLoginModel model);
    }
    #endregion
    #region Define các service sử dụng, implement interface
    public class UserService : ILoginService
    {
        #region Khai báo IHttpService và constructor
        private readonly IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
        #endregion
        #region Define các service sử dụng
        // Service check login
        public ValueTask<ResponseModel<UserModel>> CheckLogin(UserLoginModel model)
        {
            try
            {
                var response = _httpService.PostAsync<ResponseModel<UserModel>, UserLoginModel>("api/user/checklogin", model);
                if (response != null || response != default)
                    return response;
                return default;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        #endregion
    }
    #endregion
}
