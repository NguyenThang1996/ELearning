using Microsoft.AspNetCore.Mvc;
using ELearningAPI.Service.Services;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Models;

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
        /// <param name="Keyword">The keyword.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpGet]
        public IActionResult GetAll(string? Keyword)
        {
            try
            {
                var staffs = _staffService.GetAll(Keyword);
                var respone = new ResponseModel<IList<StaffModel>>();
                if (staffs == null)
                {
                    respone.Data = null;
                    respone.Status = false;
                    respone.Message = "Lấy danh sách nhân viên thất bại";
                }
                else
                {

                    respone.Data = staffs;
                    respone.Status = true;
                    respone.Message = "Lấy danh sách nhân viên thành công";
                }
                return Ok(respone);
            }
            catch (Exception ex)
            {
                throw;
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
            try
            {
                var parts = _staffService.GetAllParts();
                var respone = new ResponseModel<IList<PartModel>>();
                if (parts == null)
                {
                    respone.Data = null;
                    respone.Status = false;
                    respone.Message = "Lấy danh sách phòng ban thất bại";
                }
                else
                {

                    respone.Data = parts;
                    respone.Status = true;
                    respone.Message = "Lấy danh sách phòng ban thành công";
                }
                return Ok(respone);
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

        /// <summary>Finds the specified identifier.</summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpGet]
        [Route("find")]
        public IActionResult Find(int Id)
        {
            try
            {
                var staff = _staffService.Find(Id);
                var respone = new ResponseModel<StaffModel>();
                if (staff == null)
                {
                    respone.Data = null;
                    respone.Status = false;
                    respone.Message = "Lấy chi tiết nhân viên thất bại";
                }
                else
                {

                    respone.Data = staff;
                    respone.Status = true;
                    respone.Message = "Lấy chi tiết nhân viên thành công";
                }
                return Ok(respone);
            }
            catch (Exception ex)
            {

                throw;
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
            try
            {
                var response = _staffService.Insert(model);               
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
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
            try
            {
                var response = _staffService.Update(model);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                var response = _staffService.Delete(Id);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

