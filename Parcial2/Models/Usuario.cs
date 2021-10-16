using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial2.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public int EmpresaID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Dirreccion { get; set; }
        public int PuestoID { get; set; }
        public int DUI { get; set; }
        public int NIT { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Foto { get; set; }
        public string Token { get; set; }
        public string Clave { get; set; }
    }
}