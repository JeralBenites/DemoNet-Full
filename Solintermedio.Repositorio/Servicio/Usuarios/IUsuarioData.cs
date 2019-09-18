using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solintermedio.Repositorio.Servicio.Usuarios
{
    public interface IUsuarioData
    {
        List<Usuario> Listar();
        Usuario Insertar(Usuario usuario);
        Usuario Recuperar(int id);
        Usuario RecuperarPorCorreo(string correo);
        Usuario Actualizar(Usuario usuario);

    }
}
