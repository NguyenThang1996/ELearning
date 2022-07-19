using ELearningAPI.Common.Helpers;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ELearningAPI.Presentation.Controllers
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        /// <summary>Initializes a new instance of the <see cref="UserController" /> class.</summary>
        /// <param name="userService">The user service.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public UserController(
          IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>Checks the login.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpPost("checklogin")]
        public IActionResult CheckLogin([FromBody] UserLoginModel model)
        {
            var response = new ResponseModel<UserModel>();
            try
            {
                if (model != null)
                {
                    var user = _userService.CheckLogin(model);
                    if (user == null)
                    {
                        response.Data = null;
                        response.Status = false;
                        response.Message = "Tài khoản hoặc mật khẩu không chính xác";
                    }
                    else
                    {
                        if (user.IsActive == false)
                        {
                            response.Data = null;
                            response.Status = false;
                            response.Message = "Tài khoản của bạn đã bị khóa";
                        }
                        else if (user.IsDeleted == true)
                        {
                            response.Data = null;
                            response.Status = false;
                            response.Message = "Tài khoản của bạn đã bị xóa khỏi hệ thống";
                        }
                        else
                        {
                            response.Data = user;
                            response.Status = true;
                            response.Message = "Đăng nhập thành công";
                        }
                    }
                    return Ok(response);
                }
                response.Data = null;
                response.Status = true;
                response.Message = "Đăng nhập thất bại";
                return Ok(response);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "UserController", "CheckLogin");
                response.Status = false;
                response.Message = "Xóa nhân viên thất bại";
                return Ok(response);
            }

        }
    }
}
