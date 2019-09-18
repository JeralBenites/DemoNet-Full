using Solintermedio.Repositorio.Servicio.Opciones;
using Solintermedio.Repositorio.Servicio.Usuarios;
using SolIntermedio.Entidades.DTO;
using SolIntermedio.Entidades.Request;
using SolIntermedio.Entidades.Response;
using SolIntermedio.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SolIntermedio.WebApi.Controllers
{
    public class UsuariosController : BaseApiController
    {
        IUsuarioData data;
        IOpcionData dataOpcion;
        public UsuariosController()
        {
            data = new UsuarioDataSQL();
            dataOpcion = new OpcionDataSQL();
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {

            return Ok(data.Listar());
        }
        [HttpGet]
        public IHttpActionResult Recuperar(int id)
        {
            return Ok(data.Recuperar(id));
        }
        [HttpGet]
        public IHttpActionResult RecuperarPorCorreo(string correo)
        {
            return Ok(data.RecuperarPorCorreo(correo));
        }
        [HttpPost]
        public IHttpActionResult Insertar([FromBody] UsuarioRegistraRequest request)
        {

            Usuario u = request.ConvierteUsuario();
            return Ok(data.Insertar(u));
        }

        [HttpPost]
        public IHttpActionResult Autentica([FromBody] UsuarioAutenticaRequest request)
        {
            Usuario u = data.RecuperarPorCorreo(request.Correo);
            if (u == null)
            {
                return BadRequest("Datos incorrectos - Correo");
            }
            if (HelperEncripta.Decrypt(u.Clave) != request.Clave)
            {
                return BadRequest("Datos incorrectos - Clave");
            }
            //generar el JWT
            u.Clave = null;
            return Ok(
                new UsuarioAutenticaResponse
                {
                    Usuario = u,
                    Token = "1213213132d13vdfvdf",
                    Opciones = dataOpcion.Listar()
                });
        }
    }
}
