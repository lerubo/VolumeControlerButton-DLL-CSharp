using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace ControlVolumen2
{
    [ToolboxBitmap(typeof(Controlador), "audio-speaker-on.png")]
    public partial class Controlador : UserControl
    {
        int porcentaje = 50;
        Boolean sonido = true;
        Brush colorVolumen = new SolidBrush(Color.LightGreen);
        Boolean arrastre = false;
        int alto;
        int ancho;
        int puntoVolumen;
        Point[] parametros = new Point[3];

        public Controlador()
        {
            InitializeComponent();
            alto = this.Height;
            ancho = this.Width;
            parametros[0] = new System.Drawing.Point(img_Altavoz.Width, alto);
            nuevoTriangulo(porcentaje);
            lbl_Porcentaje.Text = (porcentaje.ToString() + "%");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.FillPolygon(colorVolumen, parametros, System.Drawing.Drawing2D.FillMode.Alternate);

        }

        private void Controlador_MouseDown(object sender, MouseEventArgs e)
        {
            arrastre = true;
            if ((arrastre) && (e.X < this.Width) && (e.X > 0) && (e.Y < this.Height) && (e.Y > 0))
            {
                nuevoTriangulo(e);
            }
        }

        private void Controlador_MouseMove(object sender, MouseEventArgs e)
        {
            if ((arrastre) && (e.X < this.Width) && (e.X > 0) && (e.Y < this.Height) && (e.Y > 0))
            {
                nuevoTriangulo(e);
            }
        }

        private void Controlador_MouseUp(object sender, MouseEventArgs e)
        {
            arrastre = false;
        }

        private void img_Altavoz_Click(object sender, EventArgs e)
        {
            if (sonido)
            {
                img_Altavoz.Image = Properties.Resources.altavozSilenciado;
                sonido = false;
                nuevoTriangulo(0);
                lbl_Porcentaje.Text = ("0" + "%");
            }
            else
            {
                nuevoTriangulo(porcentaje);
                lbl_Porcentaje.Text = (porcentaje.ToString() + "%");
                sonido = true;
            }
        }

        private void nuevoTriangulo(MouseEventArgs e)
        {
            int porcentajeW = (((e.X - img_Altavoz.Width) * 100) / (ancho - img_Altavoz.Width));
            int porcentajeH = ((porcentajeW * alto) / 100);
            puntoVolumen = (alto - porcentajeH);

            parametros[1] = new Point(e.X, alto);
            parametros[2] = new Point(e.X, puntoVolumen);

            porcentaje = porcentajeW;

          

            if (porcentajeW == 0)
            {
                img_Altavoz.Image = Properties.Resources.altavozSilenciado;               
                lbl_Porcentaje.Text = (porcentaje.ToString() + "%");
                sonido = false;
            }

            if ((porcentajeW > 0) && (porcentajeW <= 50))
            {
                img_Altavoz.Image = Properties.Resources.altavozBajo;
                colorVolumen = new SolidBrush(Color.LightGreen);             
                lbl_Porcentaje.Text = (porcentaje.ToString() + "%");
                sonido = true;
            }

            if ((porcentajeW > 50) && (porcentajeW <= 90))
            {
                img_Altavoz.Image = Properties.Resources.altavozMedio;
                colorVolumen = new SolidBrush(Color.FromArgb(255, (255), (205), (0)));
                porcentaje = porcentajeW;
                lbl_Porcentaje.Text = (porcentaje.ToString() + "%");
                sonido = true;
            }

            if ((porcentajeW > 90) && (porcentajeW <= 100))
            {
                img_Altavoz.Image = Properties.Resources.altavozAlto;
                colorVolumen = new SolidBrush(Color.IndianRed);
                if (porcentajeW > 96) { porcentaje += 1; }
                lbl_Porcentaje.Text = (porcentaje.ToString() + "%");
                sonido = true;
            }
            Invalidate();

            var evento = this.PorcentajeCambiado;
            if (evento != null)
            {
                evento(this, new PorcentajeArgs(porcentaje));
                MessageBox.Show("cambio de porcenjate ");
            }
        }
        private void nuevoTriangulo(int posicion)
        {
            int p = posicion;
            int porcentajeH = ((p * alto) / 100);
            puntoVolumen = (alto - porcentajeH);
            int x = ((p * (ancho - img_Altavoz.Width)) / 100);
            x = x + img_Altavoz.Width;

            parametros[1] = new Point(x, alto);
            parametros[2] = new Point(x, puntoVolumen);

            if ((posicion > 0) && (posicion <= 50)) {
                img_Altavoz.Image = Properties.Resources.altavozBajo;
                colorVolumen = new SolidBrush(Color.LightGreen);
            }
            if ((posicion > 50) && (posicion <= 90))
            {
                img_Altavoz.Image = Properties.Resources.altavozMedio;
                colorVolumen = new SolidBrush(Color.FromArgb(255, (255), (205), (0)));
            }
            if ((posicion > 90) && (posicion <= 100))
            {
                img_Altavoz.Image = Properties.Resources.altavozAlto;
                colorVolumen = new SolidBrush(Color.IndianRed);
            }
            Invalidate();
        }

        public class PorcentajeArgs : EventArgs
        {
            private int porcentajes = 50;
            public PorcentajeArgs(int nuevoPorcentaje)
            {
                if (this.porcentajes != nuevoPorcentaje){
                    MessageBox.Show("Aqui");
                }
                porcentajes = nuevoPorcentaje;                   
            }
            public int nuevoPorcentaje
            {
                get
                {
                    return porcentajes;
                }
            }
        }
        public delegate void cambioPorcentaje(Object sender, PorcentajeArgs e);
        public event cambioPorcentaje PorcentajeCambiado;
    }
}
