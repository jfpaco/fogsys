using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Archivo
/// </summary>
namespace FogaLib
{
    public class Archivo
    {
        public Archivo()
        {

        }

        public static string generaNomArchivo(string extension, int aleatorio) {
            Random r = new Random(DateTime.Now.Millisecond);
            string fecha = DateTime.Now.ToShortDateString();
            fecha = fecha.Replace("/","_");
            string numeroAleatorio = (r.Next(100000, 999999) + aleatorio).ToString();
            return numeroAleatorio + "_" + fecha + extension;
        }

    }
}