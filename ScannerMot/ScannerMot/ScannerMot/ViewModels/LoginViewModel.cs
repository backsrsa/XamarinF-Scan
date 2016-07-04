using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ScannerMot.Models;
using ScannerMot.Services;
using ScannerMot.Utilities;

namespace ScannerMot.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private readonly NavigationService _navigationService;
        readonly DialogService _dialogService;

        private int _deviceUserId;
        private string _username;
        private string _password;

        public int DeviceUserId
        {
            get { return _deviceUserId; }
            set
            {
                _deviceUserId = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value.Trim();
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value.Trim();
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }
        private async void Save()
        {
            try
            {
                using (var datos = new DataAccess())
                {
                    datos.UpdatedDeviceUser(new DeviceUser()
                    {
                        Username = Username,
                        Password = Security.Encriptar(Password)
                    });
                }
                await _dialogService.ShowMessage("Information", "The service has been created successfully");
                await App.Navigator.PopAsync();
            }
            catch (Exception exception)
            {
                await _dialogService.ShowMessage("Information", "Has been an error unexpected" + exception.Message);
            }
        }

        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            _dialogService = new DialogService();
         
        }
    }
}
