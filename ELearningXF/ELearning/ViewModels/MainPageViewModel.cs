using Prism.Navigation;

namespace ELearning.ViewModels
{
    /// <summary>
    ///     MainPageViewModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class MainPageViewModel : BaseViewModel
    {
        #region Khai báo các services sử dụng và constructor
        /// <summary>Khởi tạo constructor của MainPageViewModel</summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
        #endregion
    }
}
