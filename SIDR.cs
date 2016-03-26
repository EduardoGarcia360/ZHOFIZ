using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SOFIS
{
    public partial class SIDR : Form
    {
        List<String> Lista_Archivos = new List<string>();
        string[] arregloRuta, arregloNombre;
        int segundo = 0, minuto = 0, errores=0;
        
        
        public SIDR()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
            Escanear_Archivos();
        }

        private void SIDR_Load(object sender, EventArgs e)
        {
            
        }

        public void Escanear_Archivos()
        {
            string hora_Archivo = DateTime.Now.ToString("G");
            listBox1.Items.Add("Fecha y Hora de Escaneo: " + hora_Archivo);
            Lista_Archivos = System.IO.Directory.GetFiles(@"C:\SOFIS\intake").ToList();
            int i = 0, correcto = 0;
            for (; i < Lista_Archivos.Count(); i++)
            {
                arregloRuta = Lista_Archivos[i].Split('\\');
                if ( Validar_Nombre(arregloRuta[3]) == true )
                {
                    string rutaDestino_Correcto = @"C:\SOFIS\intake\PendingToTransmit\" + arregloRuta[3];
                    string rutaOrigen = Lista_Archivos[i];
                    listBox1.Items.Add(arregloRuta[3]);
                    System.IO.File.Move(rutaOrigen,rutaDestino_Correcto);
                    correcto++;
                }
                else
                {
                    string rutaDestino_Invalido = @"C:\SOFIS\intake\FilesWithErrors\" + arregloRuta[3];
                    string rutaOrigen = Lista_Archivos[i];
                    System.IO.File.Move(rutaOrigen,rutaDestino_Invalido);
                    errores++;
                }
            }

            lblAgregados.Text = "Agregados correctamente: " + correcto.ToString();
            if (errores != 0)
            {
              lblErrores.Text = "Se encontraron " + errores.ToString() + " archivos con errores.";
            }
            else
            {
              lblErrores.Text = "Ningun archivo con error.";
            }
            Lista_Archivos.Clear();
        }

        private bool Validar_Nombre(string nombreArchivo)
        {
            bool valido = true, detener = false, febrero = false;
            arregloNombre = nombreArchivo.Split('.');
            try
            {
                if (arregloNombre[9].Equals("XML") || arregloNombre[9].Equals("xml"))
                {
                    //si tiene extencion XML
                    int caso = 0;
                    while (detener == false)
                    {
                        switch (caso)
                        {
                            case 0:
                                if (arregloNombre[0].Equals("CREDITOS") || arregloNombre[0].Equals("BANCA") || arregloNombre[0].Equals("COMUNICACION"))
                                {
                                    caso = 1;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 1:
                                if (arregloNombre[1].Equals("CARTA") || arregloNombre[1].Equals("ESTADODECUENTA") || arregloNombre[1].Equals("REPORTE") || arregloNombre[1].Equals("PUBLICIDAD"))
                                {
                                    caso = 2;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 2: //año
                                if (arregloNombre[2].Equals("2016"))
                                {
                                    caso = 3;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 3: //mes
                                int mes = Int32.Parse(arregloNombre[3]);
                                if (mes >= 1 && mes <= 12)
                                {
                                    if (mes == 2)
                                    {
                                        febrero = true;
                                    }
                                    caso = 4;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 4: //dia
                                int dia = Int32.Parse(arregloNombre[4]);
                                if (dia >= 1 && dia <= 31)
                                {
                                    if (febrero == true && dia <= 28)
                                    {
                                        caso = 5;
                                    }
                                    else
                                    {
                                        caso = 9;
                                    }
                                    caso = 5;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 5: //hora
                                int hora = Int32.Parse(arregloNombre[5]);
                                if (hora >= 00 && hora <= 24)
                                {
                                    caso = 6;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 6: //minutos
                                int minutos = Int32.Parse(arregloNombre[6]);
                                if (minuto >= 00 && minuto <= 59)
                                {
                                    caso = 7;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 7: //segundos
                                int segundos = Int32.Parse(arregloNombre[7]);
                                if (segundos >= 00 && segundos <= 59)
                                {
                                    caso = 8;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 8: //numero aleatorio de 000 hasta 999
                                //si llego hasta este punto el nombre del archivo es correcto
                                int aleatorio = Int32.Parse(arregloNombre[8]);
                                if (aleatorio >= 000 && aleatorio <= 999)
                                {
                                    valido = true;
                                    detener = true;
                                }
                                else
                                {
                                    caso = 9;
                                }
                                break;
                            case 9:
                                //en caso no cumpla con alguno de los requisitos del nombre sera enviado a archivos con errores
                                valido = false;
                                detener = true;
                                break;
                        } //fin switch
                    } //fin while
                }
                else
                {
                    //si no tiene la extencion correcta es enviado a archivos con errores
                    valido = false;
                }
            }
            catch (Exception e)
            {
                valido = false;
            }
            return valido;
        }//fin validar_nombre


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (segundo == 59)
            {
                minuto++;
                lblMinutos.Text = "0" + minuto.ToString() + " min:";
                lblSegundos.Text = "00 s";
                segundo = 0;
                if(minuto == 5){
                    Escanear_Archivos();
                    minuto = 0;
                    segundo = 0;
                    lblMinutos.Text = "00 min:";
                    lblSegundos.Text = "00 s";
                    pBEscaneando.Value = 0;
                }
            }
            else
            {
                segundo++;
                if (segundo < 10)
                {
                    lblSegundos.Text = "0" + segundo.ToString() + " s";
                }
                else
                {
                    lblSegundos.Text = segundo.ToString() + " s";
                }
            }
            pBEscaneando.Increment(1);
        } //Fin timer1_tick
    }
}
