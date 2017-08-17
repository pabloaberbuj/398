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
        public static Font fuenteTitulo { get; set; }
        public static Font fuenteSubtitulo { get; set; }
        public static Font fuenteTexto { get; set; }
        public static Font fuenteTextoNegrita { get; set; }
        public static Font fuenteTabla { get; set; }
        public static Font fuenteTablaHeader { get; set; }
        public static SolidBrush negro { get; set; }
        public static StringFormat centro { get; set; }
        public static StringFormat izquierda { get; set; }
        public static StringFormat derecha { get; set; }

        public static int altoTexto { get; set; }
        public static int altoTitulo { get; set; }
        public static int altoSubtitulo { get; set; }
        public static int anchoTotal { get; set; }
        public static int altoTotal { get; set; }


        public static void cargarFormatos(PrintDocument printDocument1)
        {
            fuenteTitulo = new Font("Arial", 18, FontStyle.Bold);
            fuenteSubtitulo = new Font("Arial", 14, FontStyle.Bold);
            fuenteTexto = new Font("Arial", 11, FontStyle.Regular);
            fuenteTextoNegrita = new Font("Arial", 11, FontStyle.Bold);
            fuenteTabla = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            fuenteTablaHeader = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            negro = new SolidBrush(Color.Black);

            centro.Alignment = StringAlignment.Center;
            centro.LineAlignment = StringAlignment.Center;
            izquierda.Alignment = StringAlignment.Near;
            izquierda.LineAlignment = StringAlignment.Center;
            derecha.Alignment = StringAlignment.Far;
            derecha.LineAlignment = StringAlignment.Center;

            altoTexto = fuenteTexto.Height;
            altoTitulo = fuenteTitulo.Height;
            altoSubtitulo = fuenteSubtitulo.Height;

            printDocument1.OriginAtMargins = true;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);

            anchoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Width) - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            altoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Height) - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;
        }

        public static void imprimirTitulo(PrintPageEventArgs e, string titulo, int posicionlinea)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoTitulo);
            e.Graphics.DrawString(titulo, fuenteTitulo, negro, rect, centro);
        }

        public static void imprimirSubtitulo(PrintPageEventArgs e, string subtitulo, int posicionlinea)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoSubtitulo);
            e.Graphics.DrawString(subtitulo, fuenteSubtitulo, negro, rect, izquierda);
        }

        public static void imprimirTexto(PrintPageEventArgs e, string texto, int posicionlinea, int numlineas, int x)
        {
            Rectangle rect = new Rectangle(x, posicionlinea, anchoTotal, altoTexto * numlineas);
            e.Graphics.DrawString(texto, fuenteTexto, negro, rect, izquierda);
        }

        public static void imprimirTextoNegrita(PrintPageEventArgs e, string texto, int posicionlinea, int numlineas, int x)
        {
            Rectangle rect = new Rectangle(x, posicionlinea, anchoTotal, altoTexto * numlineas);
            e.Graphics.DrawString(texto, fuenteTextoNegrita, negro, rect, izquierda);
        }

        public static void imprimirTextoDerecha(PrintPageEventArgs e, string texto, int posicionlinea, int numlineas, int x)
        {
            Rectangle rect = new Rectangle(x, posicionlinea, anchoTotal, altoTexto * numlineas);
            e.Graphics.DrawString(texto, fuenteTexto, negro, rect, derecha);
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


        public static void imprimirTituloCaliFotones(PrintPageEventArgs e, int posicionlinea, PrintDocument printDocument1)
        {
            cargarFormatos(printDocument1);
            imprimirTitulo(e, "Determinación de dosis absorbida en agua según protocolo 398 - IAEA", posicionlinea);
        }

        public static void imprimirUsuarioYFecha(PrintPageEventArgs e,int posicionlinea,string usuario, DateTime fecha, PrintDocument printDocument1)
        {
            cargarFormatos(printDocument1);
            imprimirTextoNegrita(e, "Usuario:", posicionlinea, 1, 0);
            imprimirTexto(e, usuario, posicionlinea, 1, 50);
            imprimirTextoNegrita(e, "Fecha:", posicionlinea, 1, 200);
            imprimirTexto(e, fecha.ToShortDateString(), posicionlinea, 1, 250);
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
