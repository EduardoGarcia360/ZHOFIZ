using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SOFIS
{
    class ValidarXML
    {
        int total_de_hojas = 0;

        public bool validar_contenido(string archivo)
        {
            bool valido = false;
            if (validar_contenido_datos(archivo))
            {
                if (validar_pagina(archivo))
                {
                    valido = true;
                }
            }
            return valido;
        }

        //metodo para validar el contenido de el apartado "datos" dentro del XML
        private bool validar_contenido_datos(string archivo)
        {
            bool valido = false;

            //creamos un documento tipo XML
            XmlDocument documento = new XmlDocument();
            try
            {
                //cargamos el documento pasandole la ruta
                documento.Load(@"C:\SOFIS\intake\" + archivo);

                //creamos una lista con todos los elementos que conforman la seccion "datos" dentro del XML
                XmlNodeList lista_datos = documento.SelectNodes("trabajoImpresion/datos");
                XmlNode nodo_datos;
                //como unicamente hay una parte de "datos" la lista tendra un unico nodo
                nodo_datos = lista_datos.Item(0);
                //tomamos los valores que estan dentro de cada etiqueta
                string fecha_hora = nodo_datos.SelectSingleNode("fechaCreacion").InnerText;
                string identificador = nodo_datos.SelectSingleNode("identificador").InnerText;
                string nombre = nodo_datos.SelectSingleNode("nombre").InnerText;
                string departamento = nodo_datos.SelectSingleNode("departamento").InnerText;
                string tipo = nodo_datos.SelectSingleNode("tipo").InnerText;
                total_de_hojas = Convert.ToInt32(nodo_datos.SelectSingleNode("totalDeHojas").InnerText);
                

                if (!string.IsNullOrEmpty(fecha_hora) && !string.IsNullOrEmpty(identificador) && !string.IsNullOrEmpty(nombre)
                    && !string.IsNullOrEmpty(departamento) && !string.IsNullOrEmpty(tipo) && total_de_hojas != 0)
                {
                    if (validar_fecha_creacion(fecha_hora))
                    {
                        if (validar_departamento(departamento))
                        {
                            if (validar_tipo(tipo))
                            {
                                valido = true;
                            }
                        }
                    }

                }
            }
            catch (XmlException)
            {
                valido = false;
            }
            

            return valido;
        }

        private bool validar_pagina(string archivo)
        {
            bool valido = false;

            XmlDocument documento = new XmlDocument();

            try
            {
                documento.Load(@"C:\SOFIS\intake\" + archivo);
                XmlNodeList lista_paginas = documento.SelectNodes("trabajoImpresion/contenido");
                XmlNodeList lista = ((XmlElement)lista_paginas[0]).GetElementsByTagName("pagina");
                int i = 1;
                foreach (XmlElement nodo in lista)
                {
                    //almacenamos el dato que esta en: <pagina numero="x" ... y lo convertimos a entero.
                    string dato_numero = nodo.GetAttribute("numero");
                    int numero = Convert.ToInt32(dato_numero);
                    /**
                     * validamos que el numero de pagina sea en secuencia
                     * para eso usamos la variable 'i' en caso sea i=3 y numero=5
                     * el ciclo se detiene.
                     * */
                    if (i == numero)
                    {
                        /**
                         * en mitad almacenamos el valor de la pagina actual dividido 2
                         * ya que el numero de paginas es el doble de hojas,
                         * cuando NO es igual la mitad al total de hojas sigue con el ciclo
                         * cuando SI es igual es porque llego al final de las paginas y coinciden,
                         * ahi finaliza el ciclo.
                         * */
                        int mitad = numero / 2;
                        if (mitad == total_de_hojas)
                        {
                            valido = true;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            catch (XmlException)
            {
                return valido;
            }

            return valido;

        }

        private bool validar_departamento(string dato)
        {
            if (dato.Equals("CREDITOS") || dato.Equals("BANCA") || dato.Equals("COMUNICACION"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validar_tipo(string dato)
        {
            if (dato.Equals("CARTA") || dato.Equals("ESTADODECUENTA") || dato.Equals("REPORTE") || dato.Equals("PUBLICIDAD"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validar_fecha_creacion(string datocompleto)
        {
            bool valido = false, detener = false;
            string dato = datocompleto + "#";

            //separamos 14-03-2016 10:20:25#
            char[] aDato = dato.ToCharArray();
            int posicion=0, estado=1;
            

            while (detener == false)
            {
                char caracter = aDato[posicion];
                switch (estado)
                {
                    case 1:
                        if (char.IsDigit(caracter))
                        {
                            posicion++;
                        }
                        else if (caracter == '-')
                        {
                            posicion++;
                        }
                        else if (caracter == ':')
                        {
                            posicion++;
                        }
                        else if (char.IsWhiteSpace(caracter))
                        {
                            posicion++;
                        }
                        else if (caracter == '#')
                        {
                            detener = true;
                            valido = true;
                        }
                        else
                        {
                            estado = 3;
                        }

                        break;
                    case 3:
                        detener = true;
                        break;
                }
            }

            return valido;
        }

        public bool rendering_trabajos(string archivo)
        {
            bool valido = false;
            XmlDocument documento = new XmlDocument();
            try
            {
                documento.Load(@"C:\SOFIS\intake\" + archivo);
                
            }
            catch (Exception)
            {
                return valido;
            }

            return valido;
        }

        public bool composicion_archivo(string archivo)
        {
            bool valido = false;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(@"C:\SOFIS\intake\" + archivo);

                XmlNodeList pagina = doc.SelectNodes("//pagina");
                for (int i = 0; i < pagina.Count; i++)
                {
                    XmlNode nodo = pagina[i];
                    XmlAttribute nuevo = doc.CreateAttribute("numeroSerie");
                    nuevo.InnerText = (i + 1).ToString();
                    nodo.Attributes.Append(nuevo);
                }

                doc.Save(@"C:\SOFIS\intake\" + archivo);
                valido = true;
            }
            catch (Exception)
            {
                return valido;
            }
            return valido;
        }

    }
}
