using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Parcial2.Models;

namespace Parcial2
{
    public class Parcial2Context : DbContext
    {
        public Parcial2Context(DbContextOptions<Parcial2Context> options) : base(options)
        {
        }

        //Contexto de los metodos
        public DbSet<EncabezadoOrden> EncabezadoOrden { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Creditos> Creditos { get; set; }
        public DbSet<Mesas> Mesas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pagos> Pagos { get; set; }

    }
}
