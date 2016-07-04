using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using ScannerMot.Models;
using ScannerMot.Services;
using ScannerMot.Utilities;

namespace ScannerMot.ViewModels
{
    public class ServiceViewModel
    {
        private readonly NavigationService _navigationService;
        readonly ApiService _apiService;
        readonly DialogService _dialogService;
        public int Id { get; set; }
        public string Waitress { get; set; }
        public string Room { get; set; }
        public string Supervisor { get; set; }
        public DateTime CreationDate { get; set; }
        public ICommand SaluteCommand
        {
            get
            {
                return new RelayCommand<int>(ShowDetails);
            }
        }

        private async void ShowDetails(int serviceId)
        {

            Service servicio = await _apiService.GetServiceByServiceId(serviceId);

            await _dialogService.ShowMessage("Informacion",
                $"{"F/H: " + servicio.CreationDate} " +
                $"\n{"Aseada por: " + servicio.Waitress} " +
                $"\n{"Habitacion: " + servicio.Room}");
           
        }

        public ICommand GoToScanCommand
        {
            get
            {
                return new RelayCommand(Scan);
            }
        }

        private void Scan()
        {
            _navigationService.Navigate("ScannerPage");
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
                await _apiService.CreateServiceTask(new Service()
                {
                    Supervisor = VariablesLocales.Supervisor.Trim(),
                    Room = VariablesLocales.Room,
                    CreationDate = DateTime.Now,
                    Activo = true,
                    Estatus = 0,
                    Hotel = VariablesLocales.Hotel,
                    Waitress = Waitress.Trim()
                });
                await _dialogService.ShowMessage("Informacion", "El servicio se ha guardado correctamente.");
                _navigationService.Navigate("MainPage");
            }
            catch (Exception exception)
            {
                await _dialogService.ShowMessage("Informacion", "Ha ocurrido un error inesperado favor de intentarlo de nuevo mas tarde." + exception.Message);
            }
        }

        public ServiceViewModel()
        {
            _navigationService = new NavigationService();
            _dialogService = new DialogService();
            _apiService = new ApiService();
        }
    }
}
