using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ScannerMot.Models;
using ScannerMot.Services;

namespace ScannerMot.ViewModels
{
    public class EmployeeViewModel
    {
        private readonly NavigationService _navigationService;
        readonly DialogService _dialogService;

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Ap { get; set; }
        public string Phone { get; set; }

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
                using (var datos=new DataAccess())
                {
                    datos.InsertEmployee(new Employee()
                    {
                        Ap = Ap,
                        Name = Name,
                        Phone = Phone
                    });
                }
                await _dialogService.ShowMessage("Information", "The service has been created successfully");
                App.Navigator.PopAsync();
            }
            catch (Exception exception)
            {
                await _dialogService.ShowMessage("Information", "Has been an error unexpected" + exception.Message);
            }
        }

        public EmployeeViewModel()
        {
            _navigationService = new NavigationService();
            _dialogService = new DialogService();
        }
    }

}

