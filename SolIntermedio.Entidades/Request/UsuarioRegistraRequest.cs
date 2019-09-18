using SolIntermedio.Entidades.DTO;
using SolIntermedio.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolIntermedio.Entidades.Request
{
    public class UsuarioRegistraRequest
    {

        public string Correo { get; set; }
        public string Clave { get; set; }

        public string NombreCompleto { get; set; }


        public Usuario ConvierteUsuario()
        {
            Usuario u = new Usuario();
            u.Correo = this.Correo;
            u.Nombres = this.NombreCompleto;
            u.Clave = HelperEncripta.EncryptToByte(this.Clave);
            return u;

        }

    }
}
