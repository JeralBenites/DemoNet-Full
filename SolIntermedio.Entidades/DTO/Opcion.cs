using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolIntermedio.Entidades.DTO
{
    public  class Opcion
    {
        [Key]
        public int IdOpcion { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public int IdOpcionRef { get; set; }
        public string Titulo { get; set; }


        public string Controladora { get; set; }
        public string Accion { get; set; }

    }
}
