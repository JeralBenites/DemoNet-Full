using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolIntermedio.Utiles
{
    public static class Extensor
    {
        public static string Contar() {
            return "Hola";
        }

        public static int ContarCaracteres(this string cadena) {
            return cadena.Length;
        }
    }
}
