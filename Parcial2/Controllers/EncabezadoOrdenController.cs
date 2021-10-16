using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Parcial2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Parcial2.Controllers
{
    [ApiController]
    public class EncabezadoOrdenController : Controller
    {
        private readonly Parcial2Context _contexto;
        public EncabezadoOrdenController(Parcial2Context miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/EncabezadoOrden")]
        public IActionResult Get()
        {
            var encabezadoOrden = from e in _contexto.EncabezadoOrden
                                  join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                                  join mes in _contexto.Mesas on e.MesaID equals mes.MesaID
                                  join user in _contexto.Usuario on e.UsuarioID equals user.UsuarioID
                                  select new
                                  {
                                      e.EncabezadoOrdenID,
                                      empre.NombreEmpresa,
                                      user.Nombre,
                                      e.TipoOrden,
                                      e.FechaOrden,
                                      mes.DescripcionMesa,
                                      e.Cliente,
                                      e.EstadoOrden,
                                      e.TipoPago,
                                      e.Estado,
                                      e.FechaCreacion,
                                      e.FechaModificacion
                                  }
                                  ;
            if (encabezadoOrden.Count() > 0)
            {
                return Ok(encabezadoOrden);
            }
            return NotFound();
        }


        /// <summary>
        /// Metodo de insertar datos a la tabla encabezado orden
        /// </summary>
        /// <param name="encabezadoNuevo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/EncabezadoOrden")]
        public IActionResult guardarEncabezado([FromBody] EncabezadoOrden encabezadoNuevo)
        {
            try
            {
                IEnumerable<EncabezadoOrden> encabezadoExiste = from e in _contexto.EncabezadoOrden
                                                    where e.FechaOrden == encabezadoNuevo.FechaOrden

                                                    select e;

                if (encabezadoExiste.Count() == 0)
                {
                    _contexto.EncabezadoOrden.Add(encabezadoNuevo);
                    _contexto.SaveChanges();
                    return Ok(encabezadoNuevo);
                }
                return Ok(encabezadoExiste);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo de modificacion
        /// </summary>
        /// <param name="equipoAModificar"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/EncabezadoOrden")]
        public IActionResult updateEncabezado([FromBody] EncabezadoOrden encabezadoAModificar)
        {
            EncabezadoOrden encabezadoExiste = (from e in _contexto.EncabezadoOrden
                                                where e.EncabezadoOrdenID == encabezadoAModificar.EncabezadoOrdenID
                                                select e).FirstOrDefault();
            if (encabezadoExiste is null)
            {
                return NotFound();
            }
            encabezadoExiste.EmpresaID = encabezadoAModificar.EmpresaID;
            encabezadoExiste.UsuarioID = encabezadoAModificar.UsuarioID;
            encabezadoExiste.TipoOrden = encabezadoAModificar.TipoOrden;
            encabezadoExiste.FechaOrden = encabezadoAModificar.FechaOrden;
            encabezadoExiste.MesaID = encabezadoAModificar.MesaID;
            encabezadoExiste.Cliente = encabezadoAModificar.Cliente;
            encabezadoExiste.EstadoOrden = encabezadoAModificar.EstadoOrden;
            encabezadoExiste.TipoPago = encabezadoAModificar.TipoPago;
            encabezadoExiste.Estado = encabezadoAModificar.Estado;
            encabezadoExiste.FechaModificacion = encabezadoAModificar.FechaModificacion;

            _contexto.Entry(encabezadoExiste).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(encabezadoExiste);
        }

    }
}