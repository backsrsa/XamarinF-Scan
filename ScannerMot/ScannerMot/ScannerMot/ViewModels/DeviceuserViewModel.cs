﻿using System;
using ScannerMot.Utilities;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ScannerMot.Models;
using ScannerMot.Services;

namespace ScannerMot.ViewModels
{
    public class DeviceuserViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;
        readonly DialogService _dialogService;

        private int _deviceUserId;
        private string _username;
        private string _password;
        private string _hotel;

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
                _username = value;
                OnPropertyChanged();
            }
        }
        public string Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
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
                        DeviceUserId = DeviceUserId,
                        Username = Username,
                        Password = Security.Encriptar(Password),
                        Hotel = Hotel
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

        public DeviceuserViewModel()
        {
            _navigationService = new NavigationService();
            _dialogService = new DialogService();
            CargarInformacionsuario();
        }

        private void CargarInformacionsuario()
        {
            using (var datos = new DataAccess())
            {
                var user = datos.GetDeviceUser(2);
                DeviceUserId = user.DeviceUserId;
                Username = user.Username;
                Password = Security.DesEncriptar(user.Password);
                Hotel = user.Hotel;
            }
        }
    }
}
