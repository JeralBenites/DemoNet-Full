using SolIntermedio.ClienteMVC.Models;
using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SolIntermedio.ClienteMVC.Controllers
{
    public class OpcionController : ControladoraBase
    {
        // GET: Opcion
        [ValidaPermiso]
        public ActionResult Index()
        {
            
            List<Opcion> lista = new List<Opcion>();

            ApiHelperResult<List<Opcion>> res =
                new ApiHelper<List<Opcion>>()
                    .Get("opciones/listar");
            lista = res.Data;
             
            return View(lista);
        }
    }
}