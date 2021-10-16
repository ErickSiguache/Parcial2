using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial2.Models
{

    public class Pago
    {

        [Key]
        public int PagoID { get; set; }
        public int EmpresaID { get; set; }
        public int OrdenID { get; set; }
        public int MovimientoCajaID { get; set; }
        public string TipoPago { get; set; }
        public string ReferenciaCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Propina { get; set; }
        public decimal Total { get; set; }
        public decimal MontoPagado { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CreditosID { get; set; }
        public int tarjetaNumero { get; set; }
        public string nombreTarjeta { get; set; }
        public string autorizacionn { get; set; }
        public int estado { get; set; }
        public DateTime FechaModificacion { get; set; }


    }
}