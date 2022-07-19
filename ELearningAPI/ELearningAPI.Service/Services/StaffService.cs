using AutoMapper;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Infrastructure.UnitOfWork;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Common.Helpers;

namespace ELearningAPI.Service.Services
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface IStaffService
    {
        /// <summary>Gets all.</summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        IList<StaffModel> GetAll(string? keyword);

        /// <summary>Finds the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        StaffModel Find(int? id);

        /// <summary>Inserts the specified model.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        string Insert(StaffModel model);

        /// <summary>Updates the specified model.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        string Update(StaffModel model);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        string Delete(int? id);

        /// <summary>Gets all parts.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        IList<PartModel> GetAllParts();
    }

    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="StaffService" /> class.</summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public StaffService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public IList<StaffModel> GetAll(string? keyword)
        {
            try
            {
                var staffs = _unitOfWork.StaffRepository().GetAll();
                var parts = _unitOfWork.PartRepository().GetAll();
                if (staffs != null && parts != null)
                {
                    var _staffs = new List<StaffModel>();
                    if (keyword != null)
                    {
                        _staffs = (from s in staffs
                                   join p in parts
                                   on s.FK_PartId equals p.PK_Id
                                   where (s.Name.ToUpper().Contains(keyword.ToUpper()) || s.Address.ToUpper().Contains(keyword.ToUpper())
                                   || s.Tel.ToUpper().Contains(keyword.ToUpper()) || s.Email.ToUpper().Contains(keyword.ToUpper())) && s.IsActive == true && s.IsDeleted == false
                                   orderby s.PK_Id descending
                                   select new StaffModel
                                   {
                                       PK_Id = s.PK_Id,
                                       Name = s.Name,
                                       Address = s.Address,
                                       Tel = s.Tel,
                                       Email = s.Email,
                                       Gender = s.Gender,
                                       Avatar = s.Avatar,
                                       PartName = p.Name,
                                       FK_PartId = s.FK_PartId,
                                       IsActive = s.IsActive,
                                       IsDeleted = s.IsDeleted,
                                       CreatedDate = s.CreatedDate,
                                       CreatedBy = s.CreatedBy,
                                       UpdatedDate = s.UpdatedDate,
                                       UpdatedBy = s.UpdatedBy
                                   }).ToList();
                        if (_staffs != null)
                        {
                            return _staffs;
                        }
                        return null;
                    }
                    _staffs = (from s in staffs
                               join p in parts
                               on s.FK_PartId equals p.PK_Id
                               where s.IsActive == true && s.IsDeleted == false
                               orderby s.PK_Id descending
                               select new StaffModel
                               {
                                   PK_Id = s.PK_Id,
                                   Name = s.Name,
                                   Address = s.Address,
                                   Tel = s.Tel,
                                   Email = s.Email,
                                   Gender = s.Gender,
                                   Avatar = s.Avatar,
                                   PartName = p.Name,
                                   FK_PartId = s.FK_PartId,
                                   IsActive = s.IsActive,
                                   IsDeleted = s.IsDeleted,
                                   CreatedDate = s.CreatedDate,
                                   CreatedBy = s.CreatedBy,
                                   UpdatedDate = s.UpdatedDate,
                                   UpdatedBy = s.UpdatedBy
                               }).ToList();
                    if (_staffs != null)
                    {
                        return _staffs;
                    }
                    return null;
                }
                return new List<StaffModel>();
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffService", "GetAll");
                return null;
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
        public StaffModel Find(int? id)
        {
            try
            {
                var staff = _unitOfWork.StaffRepository().Find(id);
                if (staff != null)
                {
                    var part = _unitOfWork.PartRepository().Find(staff.FK_PartId);
                    if (part != null)
                    {
                        var _staff = _mapper.Map<StaffModel>(staff);
                        _staff.PartName = part.Name;
                        if (_staff.Gender == 1)
                        {
                            _staff.GenderName = "Nam";
                        }
                        else if (_staff.Gender == 2)
                        {
                            _staff.GenderName = "Nữ";
                        }
                        else
                        {
                            _staff.GenderName = "Khác";
                        }
                        return _staff;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffService", "Find");
                return null;
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
        public string Insert(StaffModel model)
        {
            try
            {
                if (_unitOfWork.StaffRepository().GetAll().Any(x => x.Email == model.Email))
                    return "emailDuplicate";
                _unitOfWork.BeginTransaction();
                _unitOfWork.StaffRepository().Insert(_mapper.Map<StaffEntity>(model));
                _unitOfWork.CommitTransaction();
                return "true";
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                ExceptionLog.GetException(ex, "StaffService", "Insert");
                return "false";
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
        public string Update(StaffModel model)
        {
            try
            {
                var staff = _unitOfWork.StaffRepository().Find(model.PK_Id);
                if (staff != null)
                {
                    if (model.Email != staff.Email && _unitOfWork.StaffRepository().GetAll().Any(x => x.Email == model.Email))
                        return "emailDuplicate";
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.StaffRepository().Update(_mapper.Map<StaffEntity>(model));
                    _unitOfWork.CommitTransaction();
                    return "true";
                }
                return "false";
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                ExceptionLog.GetException(ex, "StaffService", "Update");
                return "false";
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
        public string Delete(int? id)
        {
            try
            {
                var staff = _unitOfWork.StaffRepository().Find(id);
                if (staff != null)
                {
                    staff.IsDeleted = true;
                    staff.IsActive = false;
                    _unitOfWork.BeginTransaction();
                    _unitOfWork.StaffRepository().Delete(_mapper.Map<StaffEntity>(staff));
                    _unitOfWork.CommitTransaction();
                    return "true";
                }
                return "false";
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                ExceptionLog.GetException(ex, "StaffService", "Delete");
                return "false";
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
        public IList<PartModel> GetAllParts()
        {
            try
            {
                var parts = _unitOfWork.PartRepository().GetAll();
                if (parts != null)
                {
                    return _mapper.Map<IList<PartModel>>(parts);
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffService", "GetAllParts");
                return null;
            }
        }
    }
}
