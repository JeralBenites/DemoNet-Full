using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntermedio.Entidades.DTO;

namespace Solintermedio.Repositorio.Servicio.Usuarios
{
    public class UsuarioDataSQL : IUsuarioData
    {
        DbIntermedioContext contexto = new DbIntermedioContext();

        public Usuario Actualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Insertar(Usuario usuario)
        {
            contexto.Usuario.Add(usuario);
            contexto.SaveChanges();
            return usuario;
        }

        public List<Usuario> Listar()
        {
            return contexto.Usuario.ToList();
        }

        public Usuario Recuperar(int id)
        {
            return contexto.Usuario.FirstOrDefault
                (t => t.IdUsuario == id);
        }

        public Usuario RecuperarPorCorreo(string correo)
        {
            return contexto.Usuario.FirstOrDefault
                (t => t.Correo.ToUpper() == correo.ToUpper()); 
        }
    }
}
