using ELearning.Models;
using ELearning.Services;
using ELearning.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using ELearning.Helpers;

namespace ELearning.ViewModels
{
    public class AddEditPageViewModel : BaseViewModel {
        #region Khai báo các service sử dụng và constructor
        private readonly IStaffService _staffService;
        public AddEditPageViewModel(INavigationService navigationService, IStaffService staffService)
           : base(navigationService)
        {
            _staffService = staffService;

        }
        #endregion
        #region Khởi tạo page, nhận các parameter từ trang trước truyền sang
        public override void Initialize(INavigationParameters parameters)
        {
            GetAllParts();
            GetAllGenders();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            PK_Id = parameters.GetValue<int>("PK_Id");
            Name = parameters.GetValue<string>("Name");
            Address = parameters.GetValue<string>("Address");
            Tel = parameters.GetValue<string>("Tel");
            Email = parameters.GetValue<string>("Email");
            Avatar = parameters.GetValue<string>("Avatar");
            Title = parameters.GetValue<string>("Title");
            IsUpdate = parameters.GetValue<bool>("IsUpdate");
            FK_PartId = new PartModel { PK_Id = parameters.GetValue<int>("FK_PartId"), Name = parameters.GetValue<string>("PartName") };
            Gender = new GenderModel { Id = parameters.GetValue<byte>("Gender"), Name = parameters.GetValue<string>("GenderName") };
        }
        #endregion
        #region Khai báo các biến dùng cơ chế binding dữ liệu 2 chiều
        private bool _hasError;
        public bool HasError { get => _hasError; set => SetProperty(ref _hasError, value); }
        private bool _isUpdate;
        public bool IsUpdate { get => _isUpdate; set => SetProperty(ref _isUpdate, value); }
        private string _errorText;
        public string ErrorText { get => _errorText; set => SetProperty(ref _errorText, value); }
        public int PK_Id { get => _pK_Id; set => SetProperty(ref _pK_Id, value); }
        private int _pK_Id;
        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        private string _address;
        public string Address { get => _address; set => SetProperty(ref _address, value); }
        private string _tel;
        public string Tel { get => _tel; set => SetProperty(ref _tel, value); }
        private PartModel _fkPartId;
        public PartModel FK_PartId { get => _fkPartId; set => SetProperty(ref _fkPartId, value); }
        private string _email;
        public string Email { get => _email; set => SetProperty(ref _email, value); }
        private string _avatar;
        public string Avatar { get => _avatar; set => SetProperty(ref _avatar, value); }
        private GenderModel _gender;
        public GenderModel Gender { get => _gender; set => SetProperty(ref _gender, value); }
        private List<PartModel> _parts;
        public List<PartModel> Parts { get => _parts; set => SetProperty(ref _parts, value); }
        private List<GenderModel> _genders;
        public List<GenderModel> Genders { get => _genders; set => SetProperty(ref _genders, value); }
        #endregion
        #region Khai báo các command
        // Command lưu thông tin nhân viên
        public DelegateCommand SaveCommand => new DelegateCommand(Save);
        // Command hủy lưu thông tin nhân viên, navigate về trang list nhân viên
        public DelegateCommand CancelCommand => new DelegateCommand(Cancel);
        #endregion
        #region Define các hàm sử dụng
        // Hàm lưu thông tin nhân viên
        private async void Save()
        {
            try
            {
                HasError = false;
                ErrorText = String.Empty;
                if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Address) && !String.IsNullOrEmpty(Tel) && !String.IsNullOrEmpty(Email))
                {
                    if (Gender.Id == 0)
                    {
                        ErrorText = "Vui lòng chọn giới tính";
                        HasError = true;
                    }
                    if (FK_PartId.PK_Id == 0)
                    {
                        ErrorText = "Vui lòng chọn phòng ban";
                        HasError = true;
                    }
                    if (Gender.Id == 0 && FK_PartId.PK_Id == 0)
                    {
                        ErrorText = "Vui lòng chọn phòng ban và giới tính";
                        HasError = true;
                    }
                    if (Name.Length > 50)
                    {
                        ErrorText = "Tên nhân viên không được quá 50 ký tự";
                        HasError = true;
                    }
                    if (Validator.IsValidSpecialCharacter(Name))
                    {
                        ErrorText = "Tên nhân viên không được dùng các kí tự không cho phép";
                        HasError = true;
                    }
                    if (Validator.IsValidSpecialCharacter(Address))
                    {
                        ErrorText = "Địa chỉ không được dùng các kí tự không cho phép";
                        HasError = true;
                    }
                    if (!Validator.IsValidPhone(Tel))
                    {
                        ErrorText = "Số điện thoại không đúng định dạng";
                        HasError = true;
                    }
                    if (Validator.IsValidSpecialCharacter(Tel))
                    {
                        ErrorText = "Số điện thoại không được dùng các kí tự không cho phép";
                        HasError = true;
                    }
                    if (!Validator.IsValidEmail(Email))
                    {
                        ErrorText = "Email không đúng định dạng";
                        HasError = true;
                    }
                    if (Validator.IsValidSpecialCharacter(Email))
                    {
                        ErrorText = "Email không được dùng các kí tự không cho phép";
                        HasError = true;
                    }
                    if (!HasError && ErrorText == string.Empty)
                    {
                        ResponseModel<bool> response = new ResponseModel<bool>();
                        // !IsUpdate thì vào case add
                        if (!IsUpdate)
                        {
                            response = await _staffService.Insert(new StaffModel
                            {
                                Name = Name,
                                Address = Address,
                                Tel = Tel,
                                FK_PartId = FK_PartId.PK_Id,
                                Email = Email,
                                Gender = Gender.Id,
                                Avatar = Avatar,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedDate = DateTime.Now,
                                CreatedBy = 1,
                                UpdatedDate = DateTime.Now,
                                UpdatedBy = 1
                            });
                        }
                        // !IsUpdate thì vào case update
                        else
                        {
                            response = await _staffService.Update(new StaffModel
                            {
                                PK_Id = PK_Id,
                                Name = Name,
                                Address = Address,
                                Tel = Tel,
                                FK_PartId = FK_PartId.PK_Id,
                                Email = Email,
                                Gender = Gender.Id,
                                Avatar = Avatar,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedDate = DateTime.Now,
                                CreatedBy = 1,
                                UpdatedDate = DateTime.Now,
                                UpdatedBy = 1
                            });
                        }
                        if (response != null)
                        {
                            if (response.Status == true)
                            {
                                HasError = false;
                                ErrorText = response.Message;
                                var parameters = new NavigationParameters();
                                parameters.Add("IsReload", true);
                                await navigationService.GoBackAsync(parameters);
                            }
                            else
                            {
                                HasError = true;
                                ErrorText = response.Message;
                            }
                        }
                        else
                        {
                            HasError = true;
                            if (!IsUpdate)
                                ErrorText = response.Message;
                            else
                                ErrorText = response.Message;
                        }
                    }

                }
                else
                {
                    ErrorText = Validator.IsValidStringNullOrEmty(Name, Address, Tel, Email);
                    HasError = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Hàm get all phòng ban
        private async void GetAllParts()
        {
            try
            {
                var response = await _staffService.GetAllParts(new SearchModel { Keyword = string.Empty });
                if (response != null)
                {
                    if (response.Status == true && response.Data != null)
                    {
                        Parts = response.Data;
                        HasError = false;
                        ErrorText = response.Message;
                    }

                    else
                    {
                        HasError = true;
                        ErrorText = response.Message;
                    }
                }
                else
                {
                    HasError = true;
                    ErrorText = "Lấy danh sách phòng ban thất bại";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Hàm get all giới tính
        private void GetAllGenders()
        {
            try
            {
                Genders = new List<GenderModel>() {
                new GenderModel(){ Id = 1, Name="Nam"},
                new GenderModel(){ Id = 2, Name="Nữ"},
                new GenderModel(){ Id = 3, Name="Khác"}
            };
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Hàm hủy lưu thông tin nhân viên, navigate về trang list nhân viên
        private async void Cancel()
        {
            try
            {
                //Name = String.Empty;
                //Address = String.Empty;
                //Tel = String.Empty;
                //FK_PartId = 0;
                //Email = String.Empty;
                //Gender = 2;
                var parameters = new NavigationParameters();
                parameters.Add("IsReload", true);
                await navigationService.GoBackAsync(parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
