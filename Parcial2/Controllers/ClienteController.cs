using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Parcial2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Parcial2.Controllers
{
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly Parcial2Context _contexto;
        public ClienteController(Parcial2Context miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/cliente")]
        public IActionResult Get()
        {
            var cliente = from e in _contexto.Cliente
                                  join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                                  select new
                                  {
                                      e.ClienteID,
                                      e.NombreCliente,
                                      e.ApellidoCliente,
                                      e.TelefonoCliente,
                                      e.DireccionCliente,
                                      e.ReferenciaCliente,
                                      e.DuiCliente,
                                      e.NitCliente,
                                      e.NRCCliente,
                                      e.FechaCreacion,
                                      e.FechaModificacion,
                                      empre.NombreEmpresa
                                  }
                                  ;
            if (cliente.Count() > 0)
            {
                return Ok(cliente);
            }
            return NotFound();
        }


        /// <summary>
        /// Metodo de retorno de registros filtras por ID
        /// </summary>
        /// <param name="id"> Representa el valor entero del campo ID </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/cliente/{id}")]
        public IActionResult getbyId(int id)
        {
            var cliente = from e in _contexto.Cliente
                          join empre in _contexto.Empresa on e.EmpresaID equals empre.EmpresaID
                          where e.ClienteID == id //Filtro por ID
                          select new
                          {
                              e.ClienteID,
                              e.NombreCliente,
                              e.ApellidoCliente,
                              e.TelefonoCliente,
                              e.DireccionCliente,
                              e.ReferenciaCliente,
                              e.DuiCliente,
                              e.NitCliente,
                              e.NRCCliente,
                              e.FechaCreacion,
                              e.FechaModificacion,
                              empre.NombreEmpresa
                          }
                                  ;
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound();
        }

        /// <summary>
        /// Metodo de insertar
        /// </summary>
        /// <param name="clienteNuevo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/cliente")]
        public IActionResult guardarCliente([FromBody] Cliente clienteNuevo)
        {
            try
            {
                IEnumerable<Cliente> clienteExiste = from e in _contexto.Cliente
                                                                where e.DuiCliente == clienteNuevo.DuiCliente
                                                                && e.NitCliente == clienteNuevo.NitCliente
                                                                select e;

                if (clienteExiste.Count() == 0)
                {
                    _contexto.Cliente.Add(clienteNuevo);
                    _contexto.SaveChanges();
                    return Ok(clienteNuevo);
                }
                return Ok(clienteExiste);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Metodo de modificacion
        /// </summary>
        /// <param name="clienteAModificar"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/cliente")]
        public IActionResult updateCliente([FromBody] Cliente clienteAModificar)
        {
            Cliente clienteExiste = (from e in _contexto.Cliente
                                                where e.ClienteID == clienteAModificar.ClienteID
                                                select e).FirstOrDefault();
            if (clienteExiste is null)
            {
                return NotFound();
            }
            clienteExiste.NombreCliente = clienteAModificar.NombreCliente;
            clienteExiste.ApellidoCliente = clienteAModificar.ApellidoCliente;
            clienteExiste.TelefonoCliente = clienteAModificar.TelefonoCliente;
            clienteExiste.DireccionCliente = clienteAModificar.DireccionCliente;
            clienteExiste.ReferenciaCliente = clienteAModificar.ReferenciaCliente;
            clienteExiste.DuiCliente = clienteAModificar.DuiCliente;
            clienteExiste.NitCliente = clienteAModificar.NitCliente;
            clienteExiste.NRCCliente = clienteAModificar.NRCCliente;
            clienteExiste.EmpresaID = clienteAModificar.EmpresaID;
            clienteExiste.FechaModificacion = clienteAModificar.FechaModificacion;

            _contexto.Entry(clienteExiste).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(clienteExiste);
        }
    }
}
