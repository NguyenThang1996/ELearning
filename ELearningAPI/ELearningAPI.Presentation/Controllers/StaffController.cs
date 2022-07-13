using Microsoft.AspNetCore.Mvc;
using ELearningAPI.Service.Services;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Models;

namespace ELearningAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(
            IStaffService staffService)
        {
            _staffService = staffService;
        }

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

