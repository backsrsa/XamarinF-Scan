using SQLite.Net.Attributes;

namespace ScannerMot.Models
{
    public class DeviceUser
    {
        [PrimaryKey, AutoIncrement]
        public int DeviceUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hotel { get; set; }
    }
}
