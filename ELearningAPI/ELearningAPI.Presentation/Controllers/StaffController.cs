using Microsoft.AspNetCore.Mvc;
using ELearningAPI.Service.Services;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Common.Helpers;

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
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        /// <summary>Initializes a new instance of the <see cref="StaffController" /> class.</summary>
        /// <param name="staffService">The staff service.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public StaffController(
            IStaffService staffService)
        {
            _staffService = staffService;
        }

        /// <summary>Gets all.</summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpGet]
        public IActionResult GetAll(string? keyword)
        {
            var response = new ResponseModel<IList<StaffModel>>();
            try
            {
                var staffs = _staffService.GetAll(keyword);
                if (staffs == null)
                {
                    response.Data = null;
                    response.Status = false;
                    response.Message = "Lấy danh sách nhân viên thất bại";
                }
                else
                {

                    response.Data = staffs;
                    response.Status = true;
                    response.Message = "Lấy danh sách nhân viên thành công";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffController", "GetAll");
                response.Data = null;
                response.Status = false;
                response.Message = "Lấy danh sách nhân viên thất bại";
                return Ok(response);
            }
        }

        /// <summary>Gets all parts.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpGet]
        [Route("getallparts")]
        public IActionResult GetAllParts()
        {
            var response = new ResponseModel<IList<PartModel>>();
            try
            {
                var parts = _staffService.GetAllParts();
                if (parts == null)
                {
                    response.Data = null;
                    response.Status = false;
                    response.Message = "Lấy danh sách phòng ban thất bại";
                }
                else
                {

                    response.Data = parts;
                    response.Status = true;
                    response.Message = "Lấy danh sách phòng ban thành công";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffController", "GetAllParts");
                response.Data = null;
                response.Status = false;
                response.Message = "Lấy danh sách phòng ban thất bại";
                return Ok(response);
            }
        }

        /// <summary>Finds the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpGet]
        [Route("find")]
        public IActionResult Find(int? id)
        {
            var response = new ResponseModel<StaffModel>();
            try
            {
                if (id != null)
                {
                    var staff = _staffService.Find(id);
                    if (staff == null)
                    {
                        response.Data = null;
                        response.Status = false;
                        response.Message = "Lấy chi tiết nhân viên thất bại";
                    }
                    else
                    {

                        response.Data = staff;
                        response.Status = true;
                        response.Message = "Lấy chi tiết nhân viên thành công";
                    }
                    return Ok(response);
                }
                response.Data = null;
                response.Status = false;
                response.Message = "Lấy chi tiết nhân viên thất bại";
                return Ok(response);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffController", "Find");
                response.Data = null;
                response.Status = false;
                response.Message = "Lấy chi tiết nhân viên thất bại";
                return Ok(response);
            }

        }

        /// <summary>Inserts the specified model.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpPost]
        public IActionResult Insert([FromBody] StaffModel model)
        {
            var response = new ResponseModel<bool>();
            try
            {
                if (model != null)
                {
                    var _response = _staffService.Insert(model);
                    if (_response == "emailDuplicate")
                    {
                        response.Status = false;
                        response.Message = "Email '" + model.Email + "' đã được sử dụng";
                    }
                    else if (_response == "false")
                    {
                        response.Status = false;
                        response.Message = "Thêm mới nhân viên thất bại";
                    }
                    else
                    {
                        response.Status = true;
                        response.Message = "Thêm mới nhân viên thành công";
                    }
                    return Ok(response);
                }
                response.Status = false;
                response.Message = "Thêm mới nhân viên thất bại";
                return Ok(response);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffController", "Insert");
                response.Status = false;
                response.Message = "Thêm mới nhân viên thất bại";
                return Ok(response); ;
            }
        }

        /// <summary>Updates the specified model.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpPut]
        public IActionResult Update([FromBody] StaffModel model)
        {
            var response = new ResponseModel<bool>();
            try
            {
                if (model != null)
                {
                    var _response = _staffService.Update(model);
                    if (_response == "emailDuplicate")
                    {
                        response.Status = false;
                        response.Message = "Email '" + model.Email + "' đã được sử dụng";
                    }
                    else if (_response == "false")
                    {
                        response.Status = false;
                        response.Message = "Sửa nhân viên thất bại";
                    }
                    else
                    {
                        response.Status = true;
                        response.Message = "Sửa nhân viên thành công";
                    }
                    return Ok(response);
                }
                response.Status = false;
                response.Message = "Sửa nhân viên thất bại";
                return Ok(response);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffController", "Update");
                response.Status = false;
                response.Message = "Sửa nhân viên thất bại";
                return Ok(response); ;
            }
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var response = new ResponseModel<bool>();
            try
            {
                if (id != null)
                {
                    var _response = _staffService.Delete(id);
                    if (_response == "false")
                    {
                        response.Status = false;
                        response.Message = "Xóa nhân viên thất bại";
                    }
                    else
                    {
                        response.Status = true;
                        response.Message = "Xóa nhân viên thành công";
                    }
                    return Ok(response);
                }
                response.Status = false;
                response.Message = "Xóa nhân viên thất bại";
                return Ok(response);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffController", "Delete");
                response.Status = false;
                response.Message = "Xóa nhân viên thất bại";
                return Ok(response); ;
            }
        }
    }
}

