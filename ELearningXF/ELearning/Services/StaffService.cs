using ELearning.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services
{
    #region Khai báo interface các service sử dụng
    public interface IStaffService
    {
        // IService get all nhân viên
        ValueTask<ResponseModel<List<StaffModel>>> GetAll(SearchModel model);
        // IService find nhân viên
        ValueTask<ResponseModel<StaffModel>> Find(StaffIdModel model);
        // IService thêm nhân viên
        ValueTask<ResponseModel<bool>> Insert(StaffModel model);
        // IService sửa nhân viên
        ValueTask<ResponseModel<bool>> Update(StaffModel model);
        // IService xóa nhân viên
        ValueTask<ResponseModel<bool>> Delete(StaffIdModel model);
        // IService get all phòng ban
        ValueTask<ResponseModel<List<PartModel>>> GetAllParts(SearchModel model);
    }
    #endregion
    #region Define các service sử dụng, implement interface
    public class StaffService : IStaffService
    {
        #region Khai báo IHttpService và constructor
        private readonly IHttpService _httpService;

        public StaffService(IHttpService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
        #endregion
        #region Define các service sử dụng
        // Service get all nhân viên
        public async ValueTask<ResponseModel<List<StaffModel>>> GetAll(SearchModel model)
        {
            try
            {
                var response = await _httpService.GetAsync<ResponseModel<List<StaffModel>>, SearchModel>("api/staff", model);
                if (response != null || response != default)
                    return response;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Service find nhân viên
        public async ValueTask<ResponseModel<StaffModel>> Find(StaffIdModel model)
        {
            try
            {
                var response = await _httpService.GetAsync<ResponseModel<StaffModel>, StaffIdModel>("api/staff/find", model);
                if (response != null || response != default)
                    return response;
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Service thêm nhân viên
        public async ValueTask<ResponseModel<bool>> Insert(StaffModel model)
        {
            try
            {
                var response = await _httpService.PostAsync<ResponseModel<bool>, StaffModel>("api/staff", model);
                if (response != null || response != default)
                    return response;
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }
        // Service sửa nhân viên
        public async ValueTask<ResponseModel<bool>> Update(StaffModel model)
        {
            try
            {
                var response = await _httpService.PutAsync<ResponseModel<bool>, StaffModel>("api/staff", model);
                if (response != null || response != default)
                    return response;
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Service xóa nhân viên
        public async ValueTask<ResponseModel<bool>> Delete(StaffIdModel model)
        {
            try
            {
                var response = await _httpService.DeleteAsync<ResponseModel<bool>, StaffIdModel>("api/staff", model);
                if (response != null || response != default)
                    return response;
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Service get all phòng ban
        public async ValueTask<ResponseModel<List<PartModel>>> GetAllParts(SearchModel model)
        {
            try
            {
                var response = await _httpService.GetAsync<ResponseModel<List<PartModel>>, SearchModel>("api/staff/getallparts", model);
                if (response != null || response != default)
                    return response;
                return null;
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
