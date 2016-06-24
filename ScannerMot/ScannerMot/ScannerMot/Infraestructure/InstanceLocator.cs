using ScannerMot.ViewModels;

namespace ScannerMot.Infraestructure
{
    public class InstanceLocator
    {

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }

        public MainViewModel Main { get; set; }
    }
}
