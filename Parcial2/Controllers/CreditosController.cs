using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Parcial2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Parcial2.Controllers
{
    public class CreditosController : Controller
    {
        private readonly Parcial2Context _contexto;
        public CreditosController(Parcial2Context miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/Credito")]
        public IActionResult Get()
        {
            var creditos = from e in _contexto.Creditos
                                  join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                                  join clie in _contexto.Cliente on e.ClienteID equals clie.ClienteID
                                  select new
                                  {
                                      e.CreditosID,
                                      empre.NombreEmpresa,
                                      e.OrdenID,
                                      clie.NombreCliente,
                                      e.MontoTotal,
                                      e.saldo,
                                      e.FechaCreacion,
                                      e.FechaModificacion
                                  }
                                  ;
            if (creditos.Count() > 0)
            {
                return Ok(creditos);
            }
            return NotFound();
        }

        /// <summary>
        /// Metodo de retorno de registros filtras por ID
        /// </summary>
        /// <param name="id"> Representa el valor entero del campo ID </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Credito/{id}")]
        public IActionResult getbyId(int id)
        {
            var creditos = from e in _contexto.Creditos
                           join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                           join clie in _contexto.Cliente on e.ClienteID equals clie.ClienteID
                           where e.CreditosID == id //Filtro por ID
                           select new
                           {
                               e.CreditosID,
                               empre.NombreEmpresa,
                               e.OrdenID,
                               clie.NombreCliente,
                               e.MontoTotal,
                               e.saldo,
                               e.FechaCreacion,
                               e.FechaModificacion
                           }
                                  ;
            if (creditos != null)
            {
                return Ok(creditos);
            }
            return NotFound();
        }

        /// <summary>
        /// Metodo de insertar
        /// </summary>
        /// <param name="CreditoNuevo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Credito")]
        public IActionResult guardarCredito([FromBody] Creditos CreditoNuevo)
        {
            try
            {
                IEnumerable<Creditos> CreditoExiste = from e in _contexto.Creditos
                                                                where e.ClienteID == CreditoNuevo.ClienteID

                                                                select e;

                if (CreditoExiste.Count() == 0)
                {
                    _contexto.Creditos.Add(CreditoNuevo);
                    _contexto.SaveChanges();
                    return Ok(CreditoNuevo);
                }
                return Ok(CreditoExiste);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Metodo de modificacion
        /// </summary>
        /// <param name="CreditoAModificar"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Credito")]
        public IActionResult updateCredito([FromBody] Creditos CreditoAModificar)
        {
            Creditos CreditoExiste = (from e in _contexto.Creditos
                                                where e.CreditosID == CreditoAModificar.CreditosID
                                                select e).FirstOrDefault();
            if (CreditoExiste is null)
            {
                return NotFound();
            }
            CreditoExiste.EmpresaID = CreditoAModificar.EmpresaID;
            CreditoExiste.OrdenID = CreditoAModificar.OrdenID;
            CreditoExiste.ClienteID = CreditoAModificar.ClienteID;
            CreditoExiste.MontoTotal = CreditoAModificar.MontoTotal;
            CreditoExiste.saldo = CreditoAModificar.saldo;
            CreditoExiste.FechaModificacion = CreditoAModificar.FechaModificacion;

            _contexto.Entry(CreditoExiste).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(CreditoExiste);
        }

        /// <summary>
        /// Metodo de Dui 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Credito/PorDui/{dui}")]
        public IActionResult CreditoPorDui(int dui)
        {
            var creditos = from e in _contexto.Creditos
                           join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                           join clie in _contexto.Cliente on e.ClienteID equals clie.ClienteID
                           where clie.DuiCliente == dui
                           select new
                           {
                               e.CreditosID,
                               empre.NombreEmpresa,
                               e.OrdenID,
                               clie.NombreCliente,
                               e.MontoTotal,
                               e.saldo,
                               e.FechaCreacion,
                               e.FechaModificacion
                           }
                                  ;
            if (creditos.Count() > 0)
            {
                return Ok(creditos);
            }
            return NotFound();
        }
    }
}
