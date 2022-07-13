using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ELearning.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, INavigationAware, IDestructible, INotifyPropertyChanged
    {
        #region Khai báo các services sử dụng và constructor
        protected INavigationService navigationService { get; }
        public BaseViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        #endregion
        #region Khai báo các biến dùng chung trong toàn dự án, dùng cơ chế binding dữ liệu 2 chiều
        private string _title;
        public string Title { get => _title; set => SetProperty(ref _title, value); }
        private bool _isReload;
        public bool IsReload { get => _isReload; set => SetProperty(ref _isReload, value); }
        #endregion
        #region Các hàm khởi tạo page
        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
        #endregion
    }
}
