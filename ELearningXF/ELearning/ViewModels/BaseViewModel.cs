using Prism.Mvvm;
using Prism.Navigation;
using System.ComponentModel;

namespace ELearning.ViewModels
{
    /// <summary>
    ///     BaseViewModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class BaseViewModel : BindableBase, IInitialize, INavigationAware, IDestructible, INotifyPropertyChanged
    {
        #region Khai báo các services sử dụng và constructor
        protected INavigationService navigationService { get; }

        /// <summary>Khai báo constructor của BaseViewModel</summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
        /// <summary>Initialize</summary>
        /// <param name="parameters">The parameters.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        /// <summary>OnNavigatedFrom</summary>
        /// <param name="parameters">The parameters.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>OnNavigatedTo</summary>
        /// <param name="parameters">The parameters.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        /// <summary>Destroy</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public virtual void Destroy()
        {
        }
        #endregion
    }
}
