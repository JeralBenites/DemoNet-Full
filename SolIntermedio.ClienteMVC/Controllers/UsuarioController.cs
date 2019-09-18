using SolIntermedio.ClienteMVC.Models;
using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolIntermedio.ClienteMVC.Controllers
{
    public class UsuarioController : ControladoraBase
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario u = new Usuario();
            //u.
            ApiHelperResult<List<Usuario>> res =
                new ApiHelper<List<Usuario>>()
                    .Get("usuarios/listar");
            lista = res.Data;

            return View(lista);
        }

        public ActionResult Create() {
            return View();
        }
    }
}