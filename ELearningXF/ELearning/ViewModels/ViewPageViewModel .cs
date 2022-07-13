﻿using ELearning.Models;
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
    public class ViewPageViewModel : BaseViewModel
    {
        #region Khai báo các service sử dụng và constructor
        private readonly IStaffService _staffService;
        public ViewPageViewModel(INavigationService navigationService, IStaffService staffService)
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
            FK_PartId = new PartModel { PK_Id = parameters.GetValue<int>("FK_PartId"), Name = parameters.GetValue<string>("PartName") };
            Gender = new GenderModel { Id = parameters.GetValue<byte>("Gender"), Name = parameters.GetValue<string>("GenderName") };
        }
        #endregion
        #region Khai báo các biến dùng cơ chế binding dữ liệu 2 chiều
        private bool _hasError;
        public bool HasError { get => _hasError; set => SetProperty(ref _hasError, value); }
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

        #region Khai báo các hàm sử dụng
        // Hàm get all phòng ban
        private async void GetAllParts()
        {
            try
            {
                var response = await _staffService.GetAllParts(new SearchModel { Keyword = string.Empty });
                if (response != null)
                {
                    if (response.Status == true)
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
        #endregion
    }
}
