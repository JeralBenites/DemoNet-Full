using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SolIntermedio.Entidades.DTO
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public byte[] Clave { get; set; }
        public string Imagen { get; set; }

    }

    



}
