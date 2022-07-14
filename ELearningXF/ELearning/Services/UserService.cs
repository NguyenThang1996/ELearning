using ELearning.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services
{
    #region Khai báo interface các service sử dụng
    /// <summary>
    ///     ILoginService
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface ILoginService
    {
 
        /// <summary>IService check login</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<ResponseModel<UserModel>> CheckLogin(UserLoginModel model);
    }
    #endregion

    #region Define các service sử dụng, implement interface
    /// <summary>
    ///     UserService
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class UserService : ILoginService
    {
        #region Khai báo IHttpService và constructor
        private readonly IHttpService _httpService;

        /// <summary>Khởi tạo constructor của UserService</summary>
        /// <param name="httpService">The HTTP service.</param>
        /// <exception cref="System.ArgumentNullException">httpService</exception>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public UserService(IHttpService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
        #endregion

        #region Define các service sử dụng
        /// <summary>Service check login</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
