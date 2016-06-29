using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ScannerMot.Models;
using ScannerMot.Services;
using ScannerMot.Utilities;

namespace ScannerMot.ViewModels
{
    public class MainViewModel
    {
        private readonly NavigationService _navigationService;
        private ApiService _apiService;
        private readonly DialogService _dialogService;

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<ServiceViewModel> Services { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        public ServiceViewModel NewService { get; set; }
        public EmployeeViewModel NewEmployee { get; set; }
        public DeviceuserViewModel Login { get; set; }

        #region Commands

        public ICommand UpdateServicesCommand
        {
            get
            {
                return new RelayCommand(LoadServices);
            }
        }

        private async void LoadServices()
        {
            await LoadAllServices();
        }


        public ICommand GoToCommand
        {
            get
            {
                return new RelayCommand<string>(GoTo);
            }
        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewServicePage":
                    NewService = new ServiceViewModel()
                    {
                        Supervisor = "ARsa"
                    };
                    break;

                case "NewEmployeePage":
                    NewEmployee = new EmployeeViewModel();
                    break;

                case "AllEmployeesPage":
                    Employees.Clear();
                    using (var datos = new DataAccess())
                    {
                        var emps = datos.GetEmployees();
                        foreach (var e in emps)
                        {
                            Employees.Add(new EmployeeViewModel()
                            {
                                Ap = e.Ap,
                                EmployeeId = e.EmployeeId,
                                Name = e.Name,
                                Phone = e.Phone
                            });
                        }
                    }
                    NewEmployee = new EmployeeViewModel();
                    break;
            }
            _navigationService.Navigate(pageName);
        }

        public ICommand StartCommand
        {
            get
            {
                return new RelayCommand(Start);
            }
        }

        private async void Start()
        {
            await LoadAllServices();
            if (SystemAccess())
                _navigationService.SetMainPage("MasterPage");
            else
            {

                try
                {
                    Login.Password = string.Empty;
                    Login.Username = string.Empty;
                   
                }
                catch (Exception ex)
                {

                }
            }
        }

        private async Task LoadAllServices()
        {
            var list = await _apiService.GetAllServicesTask();
            Services.Clear();
            foreach (var service in list)
            {
                Services.Add(new ServiceViewModel()
                {
                    Waitress = service.Waitress,
                    Room = service.Room,
                    Supervisor = service.Supervisor
                });
            }
        }

        private bool SystemAccess()
        {
            bool rsp = false;
            using (var datos = new DataAccess())
            {
                var user = datos.GetDeviceUserByUsername(Login.Username);
                if (user != null)
                {
                    rsp = user.Password == Security.Encriptar(Login.Password);
                }
            }
            return rsp;
        }

        #endregion

        #region Metodos

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>   {
                new MenuItemViewModel()
                {
                    Icon = "ic_action_reports",
                    Title = "Reportes",
                    PageName = "MainPage"
                },
                new MenuItemViewModel()
                {
                    Icon = "ic_action_employees",
                    Title = "Empleados",
                    PageName = "EmployeesPage"
                },
                new MenuItemViewModel()
                {
                    Icon = "ic_action_settings",
                    Title = "Configuracion",
                    PageName = "SettingsPage"
                }
            };
        }


        #endregion

        #region Constructores

        public MainViewModel()
        {
            Services = new ObservableCollection<ServiceViewModel>();
            Employees = new ObservableCollection<EmployeeViewModel>();
            _navigationService = new NavigationService();
            _dialogService = new DialogService();
            _apiService = new ApiService();
            Login = new DeviceuserViewModel();
            LoadMenu();
        }

        #endregion
    }
}
