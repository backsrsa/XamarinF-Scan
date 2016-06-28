using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerMot.Utilities;

namespace ScannerMot.ViewModels
{
    public class DeviceuserViewModel : BaseViewModel
    {
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
                _username = value; 
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
    }
}
