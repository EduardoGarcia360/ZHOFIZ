using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOFIS
{
    class Respaldo
    {

        Conexion BD = new Conexion();
        public void crear_copia(string ruta, string fecha_hora)
        {
            if (!Directory.Exists(@"C:\SOFIS\backup"))
            {
                System.IO.Directory.CreateDirectory(@"C:\SOFIS\backup");
            }
            //si no existe lo crea
            if (!File.Exists(ruta))
            {
                //03/05/2016 11:00:44 p.m.
                //C:\SOFIS\intake\BANCA.CARTA.2016.02.23.08.00.01.311.xml
                string[] arreglo = ruta.Split('\\');

                //[BANCA][CARTA][2016][02][23][08][00][01][311][xml]
                string[] nombre_con_ruta = arreglo[3].Split('.');
                string nombre = nombre_con_ruta[0];

                //de esta manera dejamos solo el nombre del archivo quitandole la extencion
                for (int i = 1; i < nombre_con_ruta.Count() - 1; i++)
                {
                    nombre += "." + nombre_con_ruta[i];
                }

                //en BD -> fecha recep.: 03/05/2016, hora recep.: 03:56:23 p.m.
                //separamos la fecha y hora
                string[] tiempo = fecha_hora.Split(' ');
                string fecha = tiempo[0], hora = tiempo[1];
                if (!BD.Insertar_en_Copia(nombre, fecha, hora))
                {
                    MessageBox.Show("error en crear copia");
                }

                StreamReader f = new StreamReader(ruta);
                string contenido = f.ReadToEnd();

                string archivo = @"C:\SOFIS\backup\" + nombre + ".bkup";
                try
                {
                    using (var fileStream = File.Create(archivo))
                    {
                        var texto = new UTF8Encoding(true).GetBytes(contenido);
                        fileStream.Write(texto, 0, texto.Length);
                        fileStream.Flush();
                        f.Close();
                        fileStream.Close();
                    }
                }
                catch (Exception)
                {

                }
            }//fin if
            
        }//fin crear copia
    }
}
