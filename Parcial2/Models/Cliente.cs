using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial2.Models
{
    public class Cliente
    {

        [Key]
        public int ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string ReferenciaCliente { get; set; }
        public int DuiCliente { get; set; }
        public int NitCliente { get; set; }
        public int NRCCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int EmpresaID { get; set; }


    }
}