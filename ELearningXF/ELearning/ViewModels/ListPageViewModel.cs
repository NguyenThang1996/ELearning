using ELearning.Models;
using ELearning.Services;
using ELearning.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ELearning.ViewModels
{
    public class ListPageViewModel : BaseViewModel
    {
        #region Khai báo các service sử dụng và constructor
        private readonly IStaffService _staffService;
        public ListPageViewModel(INavigationService navigationService, IStaffService staffService)
           : base(navigationService)
        {
            _staffService = staffService;

        }
        #endregion
        #region Khởi tạo page, nhận các parameter từ trang trước truyền sang
        public override void Initialize(INavigationParameters parameters)
        {
            try
            {
                GetAll();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                IsReload = parameters.GetValue<bool>("IsReload");
                if (IsReload)
                {
                    GetAll();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #region Khai báo các biến dùng cơ chế binding dữ liệu 2 chiều
        private List<StaffModel> _staffs;
        public List<StaffModel> Staffs { get => _staffs; set => SetProperty(ref _staffs, value); }
        private bool _popupOpen;
        public bool PopupOpen { get => _popupOpen; set => SetProperty(ref _popupOpen, value); }
        private bool _hasError;
        public bool HasError { get => _hasError; set => SetProperty(ref _hasError, value); }
        private string _errorText;
        public string ErrorText { get => _errorText; set => SetProperty(ref _errorText, value); }
        public int _pK_Id = 0;
        #endregion
        #region Khai báo các command
        // Command tìm kiếm nhân viên
        public DelegateCommand<string> SearchCommand => new DelegateCommand<string>(Search);
        // Command navigate sang trang thêm mới nhân viên
        public DelegateCommand AddCommand => new DelegateCommand(Insert);
        // Command navigate sang trang sửa nhân viên
        public DelegateCommand<object> EditCommand => new DelegateCommand<object>(Update);
        // Command navigate sang trang xem chi tiết nhân viên
        public DelegateCommand<object> ViewCommand => new DelegateCommand<object>(View);
        // Command bật popup confirm xóa nhân viên
        public DelegateCommand<object> DeleteCommand => new DelegateCommand<object>(Delete);
        // Command xác nhận xóa nhân viên
        public DelegateCommand PopupAcceptCommand => new DelegateCommand(Accept);
        // Command hủy xóa nhân viên
        public DelegateCommand PopupDeclineCommand => new DelegateCommand(Decline);
        #endregion
        #region Define các hàm sử dụng
        // Hàm get all nhân viên
        private async void GetAll()
        {
            try
            {
                var response = await _staffService.GetAll(new SearchModel { Keyword = string.Empty });
                if (response != null)
                {
                    if (response.Status == true && response.Data != null)
                    {
                        Staffs = response.Data;
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
                    ErrorText = "Lấy danh sách nhân viên thất bại";
                }
            }
            catch (Exception)
            {

                throw;
            }
        
        }
        // Hàm tìm kiếm nhân viên
        private async void Search(string keyword)
        {
            try
            {
                Staffs.Clear();
                var response = await _staffService.GetAll(new SearchModel
                {
                    Keyword = keyword
                });
                if (response != null)
                {
                    if (response.Status == true && response.Data != null)
                    {
                        Staffs = response.Data;
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
                    ErrorText = "Lấy danh sách nhân viên thất bại";
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        // Hàm navigate sang trang thêm mới nhân viên
        private async void Insert()
        {
            try
            {
                var parameters = new NavigationParameters();
                parameters.Add("Title", "Thêm nhân viên");
                parameters.Add("IsUpdate", false);
                await navigationService.NavigateAsync(nameof(AddEditPage), parameters);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        // Hàm navigate sang trang sửa nhân viên
        public async void Update(object id)
        {
            try
            {
                var response = await _staffService.Find(new StaffIdModel
                {
                    Id = (int)id
                });
                if (response != null)
                {
                    if (response.Status == true)
                    {
                        HasError = false;
                        ErrorText = response.Message;
                        var parameters = new NavigationParameters();
                        parameters.Add("PK_Id", response.Data.PK_Id);
                        parameters.Add("Name", response.Data.Name);
                        parameters.Add("Address", response.Data.Address);
                        parameters.Add("Tel", response.Data.Tel);
                        parameters.Add("Email", response.Data.Email);
                        parameters.Add("Gender", response.Data.Gender);
                        parameters.Add("GenderName", response.Data.GenderName);
                        parameters.Add("FK_PartId", response.Data.FK_PartId);
                        parameters.Add("PartName", response.Data.PartName);
                        parameters.Add("Avatar", response.Data.Avatar);
                        parameters.Add("Title", "Sửa nhân viên");
                        parameters.Add("IsUpdate", true);
                        await navigationService.NavigateAsync(nameof(AddEditPage), parameters);
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
                    ErrorText = "Lấy chi tiết nhân viên thất bại";
                }
            }
            catch (Exception)
            {

                throw;
            }
         
        }
        // Hàm navigate sang trang xem chi tiết nhân viên
        public async void View(object id)
        {
            try
            {
                var response = await _staffService.Find(new StaffIdModel
                {
                    Id = (int)id
                });
                if (response != null)
                {
                    if (response.Status == true)
                    {
                        HasError = false;
                        ErrorText = response.Message;
                        var parameters = new NavigationParameters();
                        parameters.Add("PK_Id", response.Data.PK_Id);
                        parameters.Add("Name", response.Data.Name);
                        parameters.Add("Address", response.Data.Address);
                        parameters.Add("Tel", response.Data.Tel);
                        parameters.Add("Email", response.Data.Email);
                        parameters.Add("Avatar", response.Data.Avatar);
                        parameters.Add("Gender", response.Data.Gender);
                        parameters.Add("GenderName", response.Data.GenderName);
                        parameters.Add("FK_PartId", response.Data.FK_PartId);
                        parameters.Add("PartName", response.Data.PartName);
                        parameters.Add("Title", "Chi tiết nhân viên");
                        await navigationService.NavigateAsync(nameof(ViewPage), parameters);
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
                    ErrorText = "Lấy chi tiết nhân viên thất bại";
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        // Hàm bật popup confirm xóa nhân viên
        public void Delete(object id)
        {
            try
            {
                PopupOpen = true;
                _pK_Id = (int)id;
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Hàm xác nhận xóa nhân viên
        public async void Accept()
        {
            try
            {
                var response = await _staffService.Delete(new StaffIdModel
                {
                    Id = _pK_Id
                });
                if (response != null)
                {
                    if (response.Status == true)
                    {
                        GetAll();
                        IsReload = true;
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
                    ErrorText = "Xóa nhân viên thất bại";
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        // Hàm hủy xóa nhân viên
        public void Decline()
        {
            try
            {
                GetAll();
                IsReload = true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
