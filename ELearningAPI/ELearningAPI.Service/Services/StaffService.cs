using AutoMapper;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Infrastructure.UnitOfWork;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Configs;
using ELearningAPI.Common.Helpers;

namespace ELearningAPI.Service.Services
{
    public interface IStaffService
    {
        IList<StaffModel> GetAll(string? keyword);
        StaffModel Find(int id);
        ResponseModel<bool> Insert(StaffModel model);
        ResponseModel<bool> Update(StaffModel model);
        ResponseModel<bool> Delete(int id);
        IList<PartModel> GetAllParts();
    }

    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private DataContext _dataContext;

        public StaffService(
            IUnitOfWork unitOfWork,
            DataContext dataContext,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public IList<StaffModel> GetAll(string? keyword)
        {
            try {
                var staffs = _unitOfWork.StaffRepository().GetAll();
                var parts = _unitOfWork.PartRepository().GetAll();
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
                    return _staffs;
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
                return _staffs;
            }
            catch (Exception ex) {
                throw;
            }
          
        }

        public StaffModel Find(int id)
        {
            try
            {
                var staff = _unitOfWork.StaffRepository().Find(id);
                var part = _unitOfWork.PartRepository().Find(staff.FK_PartId);
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
            catch (Exception ex)
            {
                throw;
            }           
        }

        public ResponseModel<bool> Insert(StaffModel model)
        {
            try
            {                
                if (_unitOfWork.StaffRepository().GetAll().Any(x => x.Email == model.Email))
                    return new ResponseModel<bool> { Status = false, Message = "Email '" + model.Email + "' đã được sử dụng" };
                _unitOfWork.BeginTransaction();
                _unitOfWork.StaffRepository().Insert(_mapper.Map<StaffEntity>(model));
                _unitOfWork.CommitTransaction();
                return new ResponseModel<bool> { Status = true, Message = "Thêm mới nhân viên thành công" };
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                return new ResponseModel<bool> { Status = false, Message = "Thêm mới nhân viên thất bại" };
                throw;
            }
        }

        public ResponseModel<bool> Update(StaffModel model)
        {
            try
            {
                var staff = _unitOfWork.StaffRepository().Find(model.PK_Id);
                if (model.Email != staff.Email && _unitOfWork.StaffRepository().GetAll().Any(x => x.Email == model.Email))
                    return new ResponseModel<bool> { Status = false, Message = "Email '" + model.Email + "' đã được sử dụng" };
                _unitOfWork.BeginTransaction();
                _unitOfWork.StaffRepository().Update(_mapper.Map<StaffEntity>(model));
                _unitOfWork.CommitTransaction();
                return new ResponseModel<bool> { Status = true, Message = "Sửa nhân viên thành công" };
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                //return new ResponseModel<bool> { Status = false, Message = "Sửa nhân viên thất bại" };
                throw;
            }
        }

        public ResponseModel<bool> Delete(int id)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var staff = _unitOfWork.StaffRepository().Find(id);
                //if (staff == null)
                //    throw new KeyNotFoundException();
                staff.IsDeleted = true;
                staff.IsActive = false;
                _unitOfWork.StaffRepository().Delete(_mapper.Map<StaffEntity>(staff));
                _unitOfWork.CommitTransaction();
                return new ResponseModel<bool> { Status = true, Message = "Xóa nhân viên thành công" };
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                return new ResponseModel<bool> { Status = false, Message = "Xóa nhân viên thất bại" };
                throw;
            }
        }
        public IList<PartModel> GetAllParts()
        {
            try {
                var parts =_unitOfWork.PartRepository().GetAll();
                return _mapper.Map<IList<PartModel>>(parts);
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
