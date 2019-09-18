using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolIntermedio.Entidades.Response
{
    public class UsuarioAutenticaResponse
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
        public List<Opcion> Opciones { get; set; }
    }
}
