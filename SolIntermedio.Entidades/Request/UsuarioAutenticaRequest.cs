using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolIntermedio.Entidades.Request
{
    public class UsuarioAutenticaRequest
    {
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
