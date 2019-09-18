using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntermedio.Entidades.DTO;

namespace Solintermedio.Repositorio.Servicio.Opciones
{
    public class OpcionDataSQL : IOpcionData
    {
        DbIntermedioContext contexto = new DbIntermedioContext();

        public Opcion Insertar(Opcion opcion)
        {
            contexto.Opcion.Add(opcion);
            contexto.SaveChanges();
            return opcion;
        }

       
        public List<Opcion> Listar()
        {
            return contexto.Opcion.ToList();
        }
    }
}
