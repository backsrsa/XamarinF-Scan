using System;

namespace ScannerMot.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Waitress { get; set; }
        public string Room { get; set; }
        public string Supervisor { get; set; }
        public DateTime CreationDate { get; set; }
        public string Hotel { get; set; }
        public int Estatus { get; set; }
        public bool Activo { get; set; }
    }
}
