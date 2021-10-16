using System;
using System.ComponentModel.DataAnnotations;


namespace Parcial2.Models
{
    public class EncabezadoOrden
    {
        [Key]
        public int EncabezadoOrdenID { get; set; }
        public int EmpresaID { get; set; }
        public int UsuarioID { get; set; }
        public string TipoOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public int MesaID { get; set; }
        public string Cliente { get; set; }
        public char EstadoOrden { get; set; }
        public string TipoPago { get; set; }
        public char Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
