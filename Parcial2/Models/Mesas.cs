using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial2.Models
{
    public class Mesas
    {
        [Key]
        public int MesaID { get; set; }
        public int EmpresaID { get; set; }
        public string DescripcionMesa { get; set; }
        public string ZonaMesa { get; set; }
        public string SillasMesas { get; set; }
        public string Estados { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}