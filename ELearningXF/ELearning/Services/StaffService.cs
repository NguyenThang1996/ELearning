using ELearning.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services
{
    #region Khai báo interface các service sử dụng
    /// <summary>
    ///     IStaffService
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface IStaffService
    {
        /// <summary>IService get all nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<ResponseModel<List<StaffModel>>> GetAll(SearchModel model);

        /// <summary>IService find nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<ResponseModel<StaffModel>> Find(StaffIdModel model);

        /// <summary>IService thêm nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<ResponseModel<bool>> Insert(StaffModel model);

        /// <summary>IService sửa nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<ResponseModel<bool>> Update(StaffModel model);

        /// <summary>IService xóa nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<ResponseModel<bool>> Delete(StaffIdModel model);

        /// <summary>IService get all phòng ban</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        ValueTask<ResponseModel<List<PartModel>>> GetAllParts(SearchModel model);
    }
    #endregion

    #region Define các service sử dụng, implement interface
    /// <summary>
    ///     StaffService
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class StaffService : IStaffService
    {
        #region Khai báo IHttpService và constructor
        private readonly IHttpService _httpService;

        /// <summary>Khởi tạo constructor của StaffService</summary>
        /// <param name="httpService">The HTTP service.</param>
        /// <exception cref="System.ArgumentNullException">httpService</exception>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public StaffService(IHttpService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
        #endregion

        #region Define các service sử dụng
        /// <summary>Service get all nhân viên.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service find nhân viên.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service thêm nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service sửa nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service xóa nhân viên</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Service get all phòng bann</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
