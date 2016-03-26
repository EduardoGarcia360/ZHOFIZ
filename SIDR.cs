using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            int i = 0;
            for (; i < Lista_Archivos.Count(); i++)
            {
                arregloRuta = Lista_Archivos[i].Split('\\');
                if ( Validar_Nombre(arregloRuta[3]))
                {
                    listBox1.Items.Add(arregloRuta[3]);
                }
                else
                {
                    errores++;
                }
                
                
            }
            lblAgregados.Text += i.ToString();
            lblErrores.Text += " ninguno con errores.";
            Lista_Archivos.Clear();
        }

        private bool Validar_Nombre(string nombreArchivo)
        {
            bool valido = true;
            string[] Departamentos = {"CREDITOS", "BANCA", "COMUNICACION"};
            string[] Tipo_Trabajo = {"CARTA","ESTADODECUENTA","REPORTE","PUBLICIDAD"};
            arregloNombre = nombreArchivo.Split('.');
            try
            {
                if (arregloNombre[9].Equals("XML") || arregloNombre[9].Equals("xml"))
                {
                    //si tiene extencion XML
                }
                else
                {
                    valido = false;
                }
            }catch(Exception e){

            }
            return valido;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (segundo == 59)
            {
                minuto++;
                lblMinutos.Text = "0" + minuto.ToString() + " min";
                lblSegundos.Text = "00 s";
                segundo = 0;
                if(minuto == 5){
                    Escanear_Archivos();
                    minuto = 0;
                    segundo = 0;
                    lblMinutos.Text = "00 min";
                    lblSegundos.Text = "00 s";
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
