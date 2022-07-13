using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ELearningAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(
          IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("checklogin")]
        public IActionResult CheckLogin([FromBody] UserLoginModel model)
        {
            try
            {
                var respone = new ResponseModel<UserModel>();
                var user = _userService.CheckLogin(model);
                if (user == null)
                {
                    respone.Data = null;
                    respone.Status = false;
                    respone.Message = "Tài khoản hoặc mật khẩu không chính xác";
                }
                else
                {
                    if (user.IsActive == false)
                    {
                        respone.Data = null;
                        respone.Status = false;
                        respone.Message = "Tài khoản của bạn đã bị khóa";
                    }
                    else if (user.IsDeleted == true)
                    {
                        respone.Data = null;
                        respone.Status = false;
                        respone.Message = "Tài khoản của bạn đã bị xóa khỏi hệ thống";
                    }
                    else
                    {
                        respone.Data = user;
                        respone.Status = true;
                        respone.Message = "Đăng nhập thành công";
                    }
                }
                return Ok(respone);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }
}
