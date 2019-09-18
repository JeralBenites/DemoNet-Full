using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SolIntermedio.ClienteMVC.Models
{
    public class ApiHelper<T>
    {

        public ApiHelperResult<T> Get(string ruta)
        {
            T lista;
            //ApiHelperResult<T> clase = new ApiHelperResult<T>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri(ConfigurationManager.AppSettings["rutaWebApi"]);

                var get = client.GetAsync(ruta);
                get.Wait();

                var result = get.Result;

                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var leerResultado = result.Content.ReadAsAsync<T>();
                        leerResultado.Wait();
                        lista = leerResultado.Result;

                        return new ApiHelperResult<T>()
                        {
                            Codigo = result.StatusCode,
                            Data = lista,
                            Mensaje = ""
                        };
                    case System.Net.HttpStatusCode.BadRequest:
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        break;
                    default:
                        break;
                }
            }

            return null;
        }

        public ApiHelperResult<T> Post(string ruta, T tipo)
        {

            ApiHelperResult<T> clase = new ApiHelperResult<T>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri(ConfigurationManager.AppSettings["rutaWebApi"]);

                var postTask =
                    client.PostAsJsonAsync<T>(ruta, tipo);
                postTask.Wait();

                var result = postTask.Result;
                clase.Codigo = result.StatusCode;
                switch (result.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var leerResultado = result.Content.ReadAsAsync<T>();
                        leerResultado.Wait();
                        var insertado = leerResultado.Result;
                        clase.Data = insertado;
                        break;
                    case System.Net.HttpStatusCode.BadRequest:
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        break;
                    default:
                        break;
                }
            }

            return clase;
        }

    }

    public class ApiHelperResult<T>
    {
        public HttpStatusCode Codigo { get; set; }
        public T Data { get; set; }
        public string Mensaje { get; set; }

    }
}