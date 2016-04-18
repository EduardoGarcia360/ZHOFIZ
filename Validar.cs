using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOFIS
{
    class Validar
    {
        string ContenidoXML;
        public void Abrir_XML(string ruta)
        {
            try
            {
                StreamReader leer = new StreamReader(ruta);
                ContenidoXML = leer.ReadToEnd();
                leer.Close();
            }catch(FileNotFoundException fn){
                MessageBox.Show("Archivo no existente"+fn.ToString());
            }
        } //Fin abrirXML

        public bool Es_Valido(String contenido)
        {
            bool valido = false, detener = false;
            char[] arreglo_contenido = contenido.ToCharArray();
            char token;
            int estado = 0, indice = 0;
            string lexema;

            while (detener == false)
            {
                token = arreglo_contenido[indice];
                switch (estado)
                {
                    case 0:
                        if (char.IsWhiteSpace(token))
                        {
                            indice++;
                            estado = 0;
                        }
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }//fin switch
            }
            return valido;
        } //fin es valido?

        private bool Validar_Etiqueta_General(string etiqueta)
        {
            bool correcto = false;
            string[] reservadas = {"" };
            return correcto;
        }
        
    }
}
