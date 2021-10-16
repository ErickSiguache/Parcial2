using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Parcial2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Parcial2.Controllers
{
    public class PagoController : Controller
    {
        private readonly Parcial2Context _contexto;
        public PagoController(Parcial2Context miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/Pago")]
        public IActionResult Get()
        {
            var Pago = from e in _contexto.Pagos
                                  join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                                  join cred in _contexto.Creditos on e.CreditosID equals cred.CreditosID
                                  join user in _contexto.Usuario on e.UsuarioID equals user.UsuarioID
                                  select new
                                  {
                                      empre.NombreEmpresa,
                                      e.OrdenID,
                                      e.MovimientoCajaID,
                                      e.TipoPago,
                                      e.SubTotal,
                                      e.Propina,
                                      e.Total,
                                      e.MontoPagado,
                                      user.Nombre,
                                      e.FechaCreacion,
                                      e.tarjetaNumero,
                                      e.nombreTarjeta,
                                      e.autorizacion,
                                      e.estado,
                                      e.FechaModificacion
                                  }
                                  ;
            if (Pago.Count() > 0)
            {
                return Ok(Pago);
            }
            return NotFound();
        }


        /// <summary>
        /// Metodo de retorno de registros filtras por ID
        /// </summary>
        /// <param name="id"> Representa el valor entero del campo ID </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Pago/{id}")]
        public IActionResult getbyId(int id)
        {
            var Pago = from e in _contexto.Pagos
                       join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                       join cred in _contexto.Creditos on e.CreditosID equals cred.CreditosID
                       join user in _contexto.Usuario on e.UsuarioID equals user.UsuarioID
                       where e.PagoID == id //Filtro por ID
                       select new
                       {
                           empre.NombreEmpresa,
                           e.OrdenID,
                           e.MovimientoCajaID,
                           e.TipoPago,
                           e.SubTotal,
                           e.Propina,
                           e.Total,
                           e.MontoPagado,
                           user.Nombre,
                           e.FechaCreacion,
                           e.tarjetaNumero,
                           e.nombreTarjeta,
                           e.autorizacion,
                           e.estado,
                           e.FechaModificacion
                       }
                                  ;
            if (Pago != null)
            {
                return Ok(Pago);
            }
            return NotFound();
        }

        /// <summary>
        /// Metodo de insertar
        /// </summary>
        /// <param name="PagoNuevo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Pago")]
        public IActionResult guardarPago([FromBody] Pagos PagoNuevo)
        {
            try
            {
                IEnumerable<Pagos> PagoExiste = from e in _contexto.Pagos
                                                                where e.OrdenID == PagoNuevo.OrdenID

                                                                select e;

                if (PagoExiste.Count() == 0)
                {
                    _contexto.Pagos.Add(PagoNuevo);
                    _contexto.SaveChanges();
                    return Ok(PagoNuevo);
                }
                return Ok(PagoExiste);
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
        [Route("api/Pago")]
        public IActionResult updatePago([FromBody] Pagos PagoAModificar)
        {
            Pagos PagoExiste = (from e in _contexto.Pagos
                                                where e.PagoID == PagoAModificar.PagoID
                                                select e).FirstOrDefault();
            if (PagoExiste is null)
            {
                return NotFound();
            }
            PagoExiste.EmpresaID = PagoAModificar.EmpresaID;
            PagoExiste.OrdenID = PagoAModificar.OrdenID;
            PagoExiste.MovimientoCajaID = PagoAModificar.MovimientoCajaID;
            PagoExiste.TipoPago = PagoAModificar.TipoPago;
            PagoExiste.SubTotal = PagoAModificar.SubTotal;
            PagoExiste.Propina = PagoAModificar.Propina;
            PagoExiste.Total = PagoAModificar.Total;
            PagoExiste.MontoPagado = PagoAModificar.MontoPagado;
            PagoExiste.UsuarioID = PagoAModificar.UsuarioID;
            PagoExiste.CreditosID = PagoAModificar.CreditosID;
            PagoExiste.tarjetaNumero = PagoAModificar.tarjetaNumero;
            PagoExiste.autorizacion = PagoAModificar.autorizacion;
            PagoExiste.estado = PagoAModificar.estado;
            PagoExiste.FechaModificacion = PagoAModificar.FechaModificacion;

            _contexto.Entry(PagoExiste).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(PagoExiste);
        }
    }
}
