using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFIS
{
    class Respaldo
    {
        public void crear_copia(string nombre, string contenido)
        {
            if (!Directory.Exists(@"C:\SOFIS\backup"))
            {
                System.IO.Directory.CreateDirectory(@"C:\SOFIS\backup");
            }
            string archivo = @"C:\SOFIS\backup\" + nombre + ".bkup";
            try
            {
                using (var fileStream = File.Create(archivo))
                {
                    var texto = new UTF8Encoding(true).GetBytes(contenido);
                    fileStream.Write(texto, 0, texto.Length);
                    fileStream.Flush();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
