using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerMot.Pages;
using Xamarin.Forms;

namespace ScannerMot.Services
{
    public class NavigationService
    {

        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;//para cerrar el menu lateral
            App.Master.MasterBehavior=MasterBehavior.Popover;
            
            switch (pageName)
            {




                case "ScannerPage":
                    await Navigate(new ScannerPage());
                    break;

                case "EmployeesPage":
                    await Navigate(new EmployeesPage());
                    break;

                case "SettingsPage":
                    await Navigate(new SettingsPage());
                    break;

                case "NewServicePage":
                    await Navigate(new NewServicePage());
                    break;

                case "NewEmployeePage":
                    await Navigate(new NewEmployeePage());
                    break;

                case "AllEmployeesPage":
                    await Navigate(new AllEmployeesPage());
                    break;

                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
            }
        }

        //metodo para eliminar el icono back al navegar a una pagina
        private static async Task Navigate<T>(T page) where T : Page
        {
            //bool encontrado = false;
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Back");//para IOs
            //var type = page.GetType();
            //var stack = App.Navigator.Navigation.NavigationStack;
            //foreach (var pag in stack)
            //{
            //    var z = pag.GetType();
            //    if (z == type)
            //    {
            //        await App.Navigator.PushAsync(pag);
            //        encontrado = true;
            //    }
            //}
            //if (!encontrado)
            await App.Navigator.PushAsync(page);
        }


        //Metodo para user la instancia actual de la aplicacion para cambiar
        internal void SetMainPage(string page)
        {
            switch (page)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;

            }
        }

    }
}
