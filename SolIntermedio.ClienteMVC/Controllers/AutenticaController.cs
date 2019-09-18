using SolIntermedio.Entidades.Request;
using SolIntermedio.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SolIntermedio.ClienteMVC.Controllers
{
    public class AutenticaController : ControladoraBase
    {
        // GET: Autentica
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            UsuarioAutenticaRequest request = new UsuarioAutenticaRequest();
            return View(request);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UsuarioAutenticaRequest request)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri(ConfigurationManager.AppSettings["rutaWebApi"]);

                var postTask =
                    client.PostAsJsonAsync<UsuarioAutenticaRequest>("Usuarios/Autentica", request);
                postTask.Wait();

                var result = postTask.Result;
                //clase.Codigo = result.StatusCode;
                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var leerResultado = result.Content.ReadAsAsync<UsuarioAutenticaResponse>();
                        leerResultado.Wait();
                        UsuarioAutenticaResponse insertado = leerResultado.Result;

                        FormsAuthentication.SetAuthCookie(insertado.Usuario.Correo, true);
                        Session["Usuario"] = insertado.Usuario;
                        Session["Token"] = insertado.Token;
                        Session["Opciones"] = insertado.Opciones;

                        return RedirectToAction("Index", "Home");
                  
                    default:
                        string mensaje = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError("*", mensaje);
                        ModelState.AddModelError("*", "Revise su codigo");
                        return View(request); 
                }
            }
             
        }


        [HttpGet]
        public ActionResult CerrarSesion() {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return Redirect("Index");
        }
    }
}