using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScannerMot.Models;
using ScannerMot.Pages;
using ScannerMot.Utilities;
using Xamarin.Forms;

namespace ScannerMot
{
    public partial class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
            InitializeComponent();
            CreateSuperUser();
            CrearUsuario();
            MainPage = new LoginPage();
            // MainPage = new NavigationPage(new ScannerPage());
        }

        private void CrearUsuario()
        {
            using (var datos = new DataAccess())
            {
                var users = datos.GetAllUsers();
                if (users.Count == 1)
                    datos.InsertDeviceUser(new DeviceUser()
                    {
                        Hotel = "Cosmo",
                        Username = "administrador",
                        Password = Security.Encriptar("1234")
                    });
            }
        }

        private static void CreateSuperUser()
        {
            using (var datos = new DataAccess())
            {
                datos.ExistsSuperUsuario();
            }
        }

        public static NavigationPage Navigator { get; set; }
        public static MasterPage Master { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}