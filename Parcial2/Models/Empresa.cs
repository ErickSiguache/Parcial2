using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2.Models
{
    public class Empresa
    {
        public int EmpresaID { get; set; }
        public string NombreEmpresa { get; set; }
        public string Representante { get; set; }
        public int Nit { get; set; }
        public int NRC { get; set; }
        public string Direcion { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public char Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}
