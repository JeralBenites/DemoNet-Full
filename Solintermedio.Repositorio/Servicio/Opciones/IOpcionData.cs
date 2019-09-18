using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solintermedio.Repositorio.Servicio.Opciones
{
    public  interface IOpcionData
    {
        List<Opcion> Listar();
        Opcion Insertar(Opcion opcion);
    }
}
