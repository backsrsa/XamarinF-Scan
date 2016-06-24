using ScannerMot.Utilities;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly:Dependency(typeof(ScannerMot.Droid.Config))]
namespace ScannerMot.Droid
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
                    var directorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
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
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

                }
                return _plataforma;
            }
        }
    }
}