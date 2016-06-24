using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ScannerMot.Services;

namespace ScannerMot.ViewModels
{
    public class MenuItemViewModel
    {
        NavigationService _navigationService;

        #region Propiedades

        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        #endregion

        public MenuItemViewModel()
        {
            _navigationService = new NavigationService();
        }

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(() => _navigationService.Navigate(PageName));
            }
        }
    }
}
