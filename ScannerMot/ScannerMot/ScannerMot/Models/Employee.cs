using SQLite.Net.Attributes;

namespace ScannerMot.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Ap { get; set; }
        public string Phone { get; set; }
    }
}
