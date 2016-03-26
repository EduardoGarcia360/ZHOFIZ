namespace SOFIS
{
    partial class SIDR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pBEscaneando = new System.Windows.Forms.ProgressBar();
            this.lblAgregados = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.btnEnterado = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.lblSegundos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monitoreo de Archivos Enviados";
            // 
            // pBEscaneando
            // 
            this.pBEscaneando.Location = new System.Drawing.Point(12, 37);
            this.pBEscaneando.Maximum = 300;
            this.pBEscaneando.Name = "pBEscaneando";
            this.pBEscaneando.Size = new System.Drawing.Size(737, 23);
            this.pBEscaneando.TabIndex = 1;
            // 
            // lblAgregados
            // 
            this.lblAgregados.AutoSize = true;
            this.lblAgregados.Location = new System.Drawing.Point(12, 437);
            this.lblAgregados.Name = "lblAgregados";
            this.lblAgregados.Size = new System.Drawing.Size(105, 13);
            this.lblAgregados.TabIndex = 4;
            this.lblAgregados.Text = "Archivos Agregados:";
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Location = new System.Drawing.Point(12, 472);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(108, 13);
            this.lblErrores.TabIndex = 5;
            this.lblErrores.Text = "Archivos con Errores:";
            // 
            // btnEnterado
            // 
            this.btnEnterado.Location = new System.Drawing.Point(633, 437);
            this.btnEnterado.Name = "btnEnterado";
            this.btnEnterado.Size = new System.Drawing.Size(75, 23);
            this.btnEnterado.TabIndex = 6;
            this.btnEnterado.Text = "¡Enterado!";
            this.btnEnterado.UseVisualStyleBackColor = true;
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(633, 467);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(75, 23);
            this.btnVer.TabIndex = 7;
            this.btnVer.Text = "Ver Archivos";
            this.btnVer.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(162, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(448, 303);
            this.listBox1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tiempo para el Siguiente Escaneo: ";
            // 
            // lblMinutos
            // 
            this.lblMinutos.AutoSize = true;
            this.lblMinutos.Location = new System.Drawing.Point(540, 72);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.Size = new System.Drawing.Size(44, 13);
            this.lblMinutos.TabIndex = 10;
            this.lblMinutos.Text = "00  min:";
            // 
            // lblSegundos
            // 
            this.lblSegundos.AutoSize = true;
            this.lblSegundos.Location = new System.Drawing.Point(580, 72);
            this.lblSegundos.Name = "lblSegundos";
            this.lblSegundos.Size = new System.Drawing.Size(27, 13);
            this.lblSegundos.TabIndex = 11;
            this.lblSegundos.Text = "00 s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cada 5min se realiza un escaneo";
            // 
            // SIDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 497);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSegundos);
            this.Controls.Add(this.lblMinutos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnEnterado);
            this.Controls.Add(this.lblErrores);
            this.Controls.Add(this.lblAgregados);
            this.Controls.Add(this.pBEscaneando);
            this.Controls.Add(this.label1);
            this.Name = "SIDR";
            this.Text = "S.I.D. - Receptor";
            this.Load += new System.EventHandler(this.SIDR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pBEscaneando;
        private System.Windows.Forms.Label lblAgregados;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Button btnEnterado;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMinutos;
        private System.Windows.Forms.Label lblSegundos;
        private System.Windows.Forms.Label label3;
    }
}

