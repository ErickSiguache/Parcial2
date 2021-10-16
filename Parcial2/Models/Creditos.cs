using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial2.Models
{
    public class Creditos
    {
        [Key]
        public int CreditosID { get; set; }
        public int EmpresaID { get; set; }
        public int OrdenID { get; set; }
        public int ClienteID { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}