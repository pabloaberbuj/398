using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _398_UI
{
    class Imprimir
    {
        public static Font fuenteTitulo = new Font("Arial", 18, FontStyle.Bold);
        public static Font fuenteSubtitulo = new Font("Arial", 14, FontStyle.Bold);
        public static Font fuenteTexto = new Font("Arial", 11, FontStyle.Regular);
        public static Font fuenteTextoNegrita = new Font("Arial", 11, FontStyle.Bold);
        public static Font fuenteTabla = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
        public static Font fuenteTablaHeader = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        public static SolidBrush negro = new SolidBrush(Color.Black);
        public static StringFormat centro = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
        };
        public static StringFormat izquierda = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
        };
        public static StringFormat derecha = new StringFormat
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center,
        };

        public static int altoTexto { get; set; }
        public static int altoTitulo { get; set; }
        public static int altoSubtitulo { get; set; }
        public static int anchoTotal { get; set; }
        public static int altoTotal { get; set; }



            public static PrintDocument cargarConfiguracion()
        {
            altoTexto = fuenteTexto.Height;
            altoTitulo = fuenteTitulo.Height;
            altoSubtitulo = fuenteSubtitulo.Height;

            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.OriginAtMargins = true;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            //printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(300, 150, 500, 50);

            anchoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Width) - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            altoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Height) - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;

            return printDocument1;
        }

            
        

        public static void imprimirTitulo(PrintPageEventArgs e, string titulo, int posicionlinea,int numlineas)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoTitulo*numlineas);
            e.Graphics.DrawString(titulo, fuenteTitulo, negro, rect, centro);
        }

        public static void imprimirSubtitulo(PrintPageEventArgs e, string subtitulo, int posicionlinea)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoSubtitulo);
            e.Graphics.DrawString(subtitulo, fuenteSubtitulo, negro, rect, izquierda);
        }

        public static int imprimirTexto(PrintPageEventArgs e, string texto, int posicionlinea, int numlineas, int x)
        {
            Rectangle rect = new Rectangle(x, posicionlinea, anchoTotal, altoTexto * numlineas);
            e.Graphics.DrawString(texto, fuenteTexto, negro, rect, izquierda);
            SizeF largoString = e.Graphics.MeasureString(texto, fuenteTexto);
            return Convert.ToInt32(largoString.Width)+1;
        }

        public static int imprimirTextoNegrita(PrintPageEventArgs e, string texto, int posicionlinea, int numlineas, int x)
        {
            Rectangle rect = new Rectangle(x, posicionlinea, anchoTotal, altoTexto * numlineas);
            e.Graphics.DrawString(texto, fuenteTextoNegrita, negro, rect, izquierda);
            SizeF largoString = e.Graphics.MeasureString(texto, fuenteTextoNegrita);
            return Convert.ToInt32(largoString.Width) + 1;
        }

        public static int imprimirTextoDerecha(PrintPageEventArgs e, string texto, int posicionlinea, int numlineas, int x)
        {
            Rectangle rect = new Rectangle(x, posicionlinea, anchoTotal, altoTexto * numlineas);
            e.Graphics.DrawString(texto, fuenteTexto, negro, rect, derecha);
            SizeF largoString = e.Graphics.MeasureString(texto, fuenteTexto);
            return Convert.ToInt32(largoString.Width) + 1;
        }

        public static void imprimirGraficoChico(PrintPageEventArgs e, Chart grafico, int x, int y, int ancho, int alto)
        {
            Rectangle rect = new Rectangle(x, y, ancho, alto);
            grafico.Printing.PrintPaint(e.Graphics, rect);
        }
        public static void imprimirGraficoGrande(PrintPageEventArgs e, Chart grafico, int anchohoja, int posicionlinea)
        {
            Rectangle rect = new Rectangle((anchohoja - grafico.Width) / 2, posicionlinea, grafico.Width, grafico.Height);
            grafico.Printing.PrintPaint(e.Graphics, rect);
        }
        public static int imprimirtabla(PrintPageEventArgs e, DataGridView tabla, int anchohoja, int posicionlinea, Font textoHeader, Font texto, StringFormat alineacion, SolidBrush color)
        {
            int x = 70;
            int y = posicionlinea;

            foreach (DataGridViewColumn dc in tabla.Columns)
            {
                e.Graphics.DrawString(dc.HeaderText, textoHeader, color, x, y, alineacion);
                x += Convert.ToInt32(dc.Width * 10 / 8 + 5);

            }
            y += texto.Height + 5;
            for (int i = 0; i < tabla.RowCount; i++)
            {

                DataGridViewRow dr = tabla.Rows[i];
                x = 70;
                int j = 0;
                e.Graphics.DrawLine(Pens.Black, new Point(x - 40, y), new Point(x + tabla.Width + 50, y));
                foreach (DataGridViewColumn dc in tabla.Columns)
                {
                    string text = tabla[j, i].Value.ToString();
                    e.Graphics.DrawString(text, texto, color, x, y + 10f, alineacion);
                    x += Convert.ToInt32(dc.Width * 10 / 8 + 5);
                    j++;
                }
                y += 40;

            }
            return y;
        }

        // generacion reporte


        public static void imprimirTituloCaliFotones(PrintPageEventArgs e, int posicionlinea)
        {
            imprimirTitulo(e, "Determinación de dosis absorbida en agua \n según protocolo 398 - IAEA", posicionlinea,2);
        }

        public static void imprimirUsuarioYFecha(PrintPageEventArgs e,int posicionlinea,string usuario, DateTime fecha)
        {
            imprimirEtiquetaYValorx2(e, posicionlinea, "Usuario: ", usuario, "Fecha: ", fecha.ToShortDateString());
        }

        public static int imprimirEtiquetaYValor(PrintPageEventArgs e, int posicionlinea, string etiqueta, string valor, int x)
        {
            x += imprimirTextoNegrita(e, etiqueta, posicionlinea, 1, x);
            x += imprimirTexto(e, valor, posicionlinea, 1, x);
            return x;
        }

        public static void imprimirEtiquetaYValorx2(PrintPageEventArgs e, int posicionlinea, string etiqueta1, string valor1, string etiqueta2, string valor2)
        {
            int x = 0;
            x += imprimirEtiquetaYValor(e, posicionlinea, etiqueta1, valor1, x);
            x += Convert.ToInt32(anchoTotal / 2);
            x += imprimirEtiquetaYValor(e, posicionlinea, etiqueta2, valor2, x);
        }
        public static void imprimirReporteCaliFotones(string Usuario, DateTime fecha, Equipo equipo, SistemaDosimetrico sistDosim,
            int DFSoISO, double tamCampo, double profundidad, double UM, double Temp, double Presion, double Humedad, double KTP,
            double LectVmas, double LectVmenos, double kpol, bool kpolNo, bool kpolUsaLB,
            double LectVtot, double LectVred, double Vred, double ks, bool ksNo, bool ksUsaLB,
            double L20, double L10, int TPRoPDD, double TPR210, double kqq0,
            double Lref, double Mref, double Dwref, double Dwmax, double LB, double difLB, string nota, PrintEventArgs e, PrintDocument printDocument1)
        {


        }
    }
}
