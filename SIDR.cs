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
        Thread escaneo;
        int segundo = 0, minuto = 0;
        public SIDR()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void SIDR_Load(object sender, EventArgs e)
        {
            
        }

        public void Escanear_Archivos()
        {
            List<String> Lista_Archivos = new List<string>();
            string hora_Archivo = DateTime.Now.ToString("G");
            BeginInvoke(new Action(() =>
            {
                this.listBox1.Items.Add("Hora de Recibidos: " + hora_Archivo);
            }));
            
            Lista_Archivos = System.IO.Directory.GetFiles(@"C:\SOFIS\intake").ToList();
            int i = 0;
            for (; i < Lista_Archivos.Count()-1; i++)
            {
                BeginInvoke(new Action(() =>
                {
                    this.listBox1.Items.Add(Lista_Archivos[i]);
                }));
            }
            BeginInvoke(new Action(() =>
            {
                lblAgregados.Text += i.ToString();
                lblErrores.Text += " ninguno con errores.";
                Lista_Archivos.Clear();
            }));
        }


        private void btnVer_Click(object sender, EventArgs e)
        {
            Escanear_Archivos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (segundo == 59)
            {
                minuto++;
                lblMinutos.Text = "0" + minuto.ToString() + "min";
                listBox1.Items.Add("minuto: " + minuto.ToString() + ":");
                lblSegundos.Text = "00";
                segundo = 0;
                
            }
            else
            {
                segundo++;
                if (segundo < 10)
                {
                    lblSegundos.Text = "0" + segundo.ToString() + "s";
                }
                else
                {
                    lblSegundos.Text = segundo.ToString() + "s";
                }
            }
            pBEscaneando.Increment(1);
        } //Fin timer1_tick
    }
}
