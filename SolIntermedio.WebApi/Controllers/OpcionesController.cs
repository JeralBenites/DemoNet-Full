using Solintermedio.Repositorio.Servicio.Opciones;
using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SolIntermedio.WebApi.Controllers
{
    
    public class OpcionesController : BaseApiController
    {
        IOpcionData data;

       
        public OpcionesController()
        {
            data = new OpcionDataSQL();
        }

        [HttpGet]
        public List<Opcion> Listar()
        {
            return data.Listar();
        }

        [HttpPost]
        public IHttpActionResult Insertar([FromBody] Opcion opcion)
        {
            try
            {
                if (string.IsNullOrEmpty(opcion.Nombre))
                {
                    return BadRequest("Debe insertatr el nombre");
                }
                return Ok(data.Insertar(opcion));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
