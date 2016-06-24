using System;
using ScannerMot.Utilities;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly:Dependency(typeof(ScannerMot.iOS.Config))]
namespace ScannerMot.iOS{
    
    public class Config : IConfig
    {
        private string _directorioDb;
        private ISQLitePlatform _plataforma;
        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(DirectorioDB))
                {
                    var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _directorioDb = System.IO.Path.Combine(directorio, "..", "Library");
                }
                return _directorioDb;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma=new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();

                }
                return _plataforma;
            }
        }
    }
}

