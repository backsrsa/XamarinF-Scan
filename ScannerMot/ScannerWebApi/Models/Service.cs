using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScannerWebApi.Models
{
    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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