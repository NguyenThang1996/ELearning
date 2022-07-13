using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ELearningAPI.Models;
using ELearningAPI.Entities;
using ELearningAPI.Services;

namespace ELearningAPI.Controllers
{
    [ApiController]
    [Route("api/part")]
    public class PartController : ControllerBase
    {
        private IPartService _partService;

        public PartController(
            IPartService partService)
        {
            _partService = partService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var parts = _partService.GetAll();
            var respone = new ResponseModel<List<PartEntity>>();
            if (parts == null)
            {
                respone.Data = null;
                respone.Status = false;
                respone.Message = "Lấy danh sách chức vụ thất bại";
            }
            else {

                respone.Data = parts;
                respone.Status = true;
                respone.Message = "Lấy danh sách chức vụ thành công";
            }
            return Ok(respone);
        }
    }
}

