using Windows.Storage;
using ScannerMot.Utilities;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(ScannerMot.WinPhone.Config))]
namespace ScannerMot.WinPhone
{
    public class Config:IConfig
    {
        private string _directorioDb;
        private ISQLitePlatform _plataforma;
        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_directorioDb))
                {
                    var directorio = ApplicationData.Current.LocalFolder.Path;
                    _directorioDb = System.IO.Path.Combine(directorio);
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
                    _plataforma = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();

                }
                return _plataforma;
            }
        }
    }
}
