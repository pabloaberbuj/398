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
        public static Font fuenteSubtitulo2 = new Font("Arial", 12, FontStyle.Bold);
        public static Font fuenteTexto = new Font("Arial", 11, FontStyle.Regular);
        public static Font fuenteTextoNegrita = new Font("Arial", 11, FontStyle.Bold);
        public static Font fuenteTabla = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
        public static Font fuenteTablaHeader = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        public static SolidBrush negro = new SolidBrush(Color.Black);
        public static Pen penNegra = new Pen(Color.Black,2);
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
        public static int altoSubtitulo2 { get; set; }
        public static int anchoTotal { get; set; }
        public static int altoTotal { get; set; }
        public static int espacioParrafo = 5;
        public static int espacioTitulo = 10;



        public static PrintDocument cargarConfiguracion()
        {
            altoTexto = fuenteTexto.Height;
            altoTitulo = fuenteTitulo.Height;
            altoSubtitulo = fuenteSubtitulo.Height;
            altoSubtitulo2 = fuenteSubtitulo2.Height;

            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.OriginAtMargins = true;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            //printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(300, 150, 500, 50);

            anchoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Width) - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            altoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Height) - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;

            return printDocument1;
        }



        public static void imprimirLinea(PrintPageEventArgs e,int posicionlinea)
        {
            e.Graphics.DrawLine(penNegra, new Point(0, posicionlinea), new Point(anchoTotal, posicionlinea));
        }

        public static int imprimirTitulo(PrintPageEventArgs e, string titulo, int posicionlinea,int numlineas)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoTitulo*numlineas);
            e.Graphics.DrawString(titulo, fuenteTitulo, negro, rect, centro);
            return posicionlinea + altoTitulo * numlineas + espacioTitulo;
        }

        public static int imprimirSubtitulo(PrintPageEventArgs e, string subtitulo, int posicionlinea)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoSubtitulo);
            e.Graphics.DrawString(subtitulo, fuenteSubtitulo, negro, rect, izquierda);
            return posicionlinea + altoSubtitulo + espacioTitulo;
        }

        public static int imprimirSubtitulo2(PrintPageEventArgs e, string subtitulo2, int posicionlinea)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoSubtitulo2);
            e.Graphics.DrawString(subtitulo2, fuenteSubtitulo2, negro, rect, izquierda);
            return posicionlinea + altoSubtitulo2 + espacioTitulo;
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
            return Convert.ToInt32(largoString.Width)+1;
        }

        public static int imprimirTextoNegritaDerecha(PrintPageEventArgs e, string texto, int posicionlinea, int numlineas, int x)
        {
            Rectangle rect = new Rectangle(x, posicionlinea, anchoTotal, altoTexto * numlineas);
            e.Graphics.DrawString(texto, fuenteTextoNegrita, negro, rect, derecha);
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


        public static int imprimirTituloCaliFotones(PrintPageEventArgs e, int posicionlinea)
        {
            posicionlinea += imprimirTitulo(e, "Determinación de dosis absorbida en agua \n según protocolo 398 - IAEA", posicionlinea,2);
            return posicionlinea;
        }

        public static int imprimirUsuarioYFecha(PrintPageEventArgs e,int posicionlinea,string usuario, DateTime fecha)
        {
            imprimirEtiquetaYValorx2Sep(e, posicionlinea, "Usuario: ", usuario, "Fecha: ", fecha.ToShortDateString());
            posicionlinea += altoTexto + espacioTitulo;
            return posicionlinea;
        }

        //public static int imprimirEquipo(PrintPageEventArgs e, int posicionlinea, string institucion, int ALEoCo, string marca, string modelo, string nSerie, string energia)
        public static int imprimirEquipo(PrintPageEventArgs e, int posicionlinea, Equipo equipo, EnergiaFotones energia)
        {
            imprimirSubtitulo(e, "Unidad de tratamiento", posicionlinea);
            posicionlinea += altoSubtitulo;
            imprimirLinea(e, posicionlinea);
            posicionlinea += espacioTitulo;
            imprimirEtiquetaYValor(e, posicionlinea, "Institución: ", equipo.Institucion, 0);
            posicionlinea += altoTexto + espacioParrafo;
            if (equipo.Fuente==1)
            {
                imprimirEtiquetaYValor(e, posicionlinea, "Tipo de equipo: ", "Co-60",0);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValorx3(e, posicionlinea, "Marca: ", equipo.Marca, "Modelo: ", equipo.Modelo, "Nº de serie: ", equipo.NumSerie);
                posicionlinea += (altoTexto + espacioParrafo)*2; //Ver que quede igual que en ALE
            }
            else if (equipo.Fuente == 2)
            {
                imprimirEtiquetaYValor(e, posicionlinea, "Tipo de equipo: ", "Acelerador Lineal de Electrones", 0);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValorx3(e, posicionlinea, "Marca: ", equipo.Marca, "Modelo: ", equipo.Modelo, "Nº de serie: ", equipo.NumSerie);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValor(e, posicionlinea, "Energía Nominal: ", energia.Energia + "MV", 0); 
            }
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirCondiciones(PrintPageEventArgs e, int posicionlinea, int DFSoISO, string tamCampo, string prof, string TPRoPDD)
        {
            imprimirSubtitulo(e, "Condiciones de medición", posicionlinea);
            posicionlinea += altoSubtitulo;
            imprimirLinea(e, posicionlinea);
            posicionlinea += espacioTitulo;
            if (DFSoISO == 1)
            {
                imprimirEtiquetaYValor(e, posicionlinea, "Técnica: ", "DFS fija", 0);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValor(e, posicionlinea, "Tamaño de campo: ", tamCampo + "cm", 0);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValorx2(e, posicionlinea, "Profundidad: ", prof + "cm", "PDD: ", TPRoPDD+"%");
                posicionlinea += altoTexto + espacioParrafo;
            }
            else if (DFSoISO == 2)
            {
                imprimirEtiquetaYValor(e, posicionlinea, "Técnica: ", "Isocéntrico", 0);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValor(e, posicionlinea, "Tamaño de campo: ", tamCampo+"cm", 0);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValorx2(e, posicionlinea, "Profundidad: ", prof+"cm", "TPR: ", TPRoPDD+"%");
                posicionlinea += altoTexto + espacioParrafo;
            }

            return posicionlinea;            
        }

        public static int imprimirSistemaDosimetrico(PrintPageEventArgs e, int posicionlinea,SistemaDosimetrico sistemaDosimetrico)
        {
            imprimirSubtitulo(e, "Sistema Dosimetrico", posicionlinea);
            posicionlinea += altoSubtitulo;
            imprimirLinea(e, posicionlinea);
            posicionlinea += espacioTitulo;
            imprimirSubtitulo2(e, "Cámara", posicionlinea);
            posicionlinea += altoSubtitulo2+espacioParrafo;
            imprimirEtiquetaYValorx3(e, posicionlinea, "Marca: ", sistemaDosimetrico.camara.Marca, "Modelo: ", sistemaDosimetrico.camara.Modelo, "Nº de serie: ", sistemaDosimetrico.camara.NumSerie);
            posicionlinea += altoSubtitulo + espacioParrafo;
            imprimirSubtitulo2(e, "Electrómetro", posicionlinea);
            posicionlinea += altoSubtitulo2 + espacioParrafo;
            imprimirEtiquetaYValorx3(e, posicionlinea, "Marca: ", sistemaDosimetrico.electrometro.Marca, "Modelo: ", sistemaDosimetrico.electrometro.Modelo, "Nº de serie: ", sistemaDosimetrico.electrometro.NumSerie);
            posicionlinea += altoSubtitulo + espacioParrafo;
            imprimirSubtitulo2(e, "Calibración", posicionlinea);
            posicionlinea += altoSubtitulo2 + espacioParrafo;
            imprimirEtiquetaYValorx2(e, posicionlinea,"Calibrado por: ",sistemaDosimetrico.LaboCalibracion , "Fecha: ", sistemaDosimetrico.FechaCalibracion);
            posicionlinea += altoTexto + espacioParrafo;
            imprimirEtiquetaYValorx2(e, posicionlinea, "Factor de calibración: ", sistemaDosimetrico.FactorCalibracion.ToString() + "cGy/nC", "Haz de referencia: ", sistemaDosimetrico.HazDeRef);
            posicionlinea += altoTexto + espacioParrafo;
            imprimirEtiquetaYValorx3(e, posicionlinea, "T0: ", sistemaDosimetrico.TempRef.ToString() + "ºC", "P0: ", sistemaDosimetrico.PresionRef.ToString() + "hPa", "Humedad: ", sistemaDosimetrico.HumedadRef.ToString()+"%");
            posicionlinea += altoTexto + espacioParrafo;
            if (sistemaDosimetrico.SignoTension==+1)
            {
                imprimirEtiquetaYValorx2(e, posicionlinea, "Tensión: ", sistemaDosimetrico.Tension.ToString()+"V", "Signo: ", "+");
            }
            else
            {
                imprimirEtiquetaYValorx2(e, posicionlinea, "Tensión: ", sistemaDosimetrico.Tension.ToString() + "V", "Signo: ", "-");
            }
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirUMyKTP(PrintPageEventArgs e,int posicionlinea, string UM, string T, string P, string Hum, double KTP)//falta opción tiempo
        {
            imprimirSubtitulo(e, "Promedios de lecturas y factores", posicionlinea);
            posicionlinea += altoSubtitulo;
            imprimirLinea(e, posicionlinea);
            posicionlinea += espacioTitulo;
            imprimirEtiquetaYValor(e, posicionlinea, "UM: ", UM, 0);
            posicionlinea += altoSubtitulo+ espacioParrafo;
            imprimirEtiquetaYValorx3(e, posicionlinea, "Temp: ", T, "Presión: ", P, "Humedad: ", Hum);
            posicionlinea += altoTexto+ espacioParrafo;
            imprimirSubtitulo2(e, "KTP =" + KTP.ToString(), posicionlinea);
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirKpol(PrintPageEventArgs e,int posicionlinea, double LMasV, double LMenosV, double Kpol, int medido)
        {
            imprimirEtiquetaYValorx2(e, posicionlinea, "Lect(V) = ", LMasV.ToString(), "Lect(-V) = ", LMenosV.ToString());
            posicionlinea += altoTexto + espacioParrafo;
            string aux = "Kpol = " + Kpol.ToString();
            if (medido == 2) //usa LB
            {
                aux += " (kpol extraído de calibración de referencia)";
            }
            if (medido == 3) //no corrige
            {
                aux += " (no corrige por kpol)";
            }
            imprimirSubtitulo(e, aux, posicionlinea);
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirEtiquetaYValor(PrintPageEventArgs e, int posicionlinea, string etiqueta, string valor, int x)
        {
            x += imprimirTextoNegrita(e, etiqueta, posicionlinea, 1, x);
            x += imprimirTexto(e, valor, posicionlinea, 1, x);
            return x;
        }

        public static int imprimirEtiquetaYValorx2(PrintPageEventArgs e, int posicionlinea, string etiqueta1, string valor1, string etiqueta2, string valor2)
        {
            int x = 0;
            x += imprimirEtiquetaYValor(e, posicionlinea, etiqueta1, valor1, x);
            x += 10;
            x += imprimirEtiquetaYValor(e, posicionlinea, etiqueta2, valor2, x);
            return x;
        }

        public static int imprimirEtiquetaYValorx2Sep(PrintPageEventArgs e, int posicionlinea, string etiqueta1, string valor1, string etiqueta2, string valor2)
        {
            int x = 0;
            x += imprimirEtiquetaYValor(e, posicionlinea, etiqueta1, valor1, x);
            SizeF largoetiqueta = e.Graphics.MeasureString(etiqueta2, fuenteTextoNegrita);
            SizeF largovalor = e.Graphics.MeasureString(valor2, fuenteTexto);
            x = Convert.ToInt32(anchoTotal - largoetiqueta.Width - largovalor.Width);
            imprimirEtiquetaYValor(e, posicionlinea, etiqueta2, valor2, x);
            return x;
        }

        public static int imprimirEtiquetaYValorx3(PrintPageEventArgs e, int posicionlinea, string etiqueta1, string valor1, string etiqueta2, string valor2, string etiqueta3, string valor3)
        {
            int x = 0;
            x = imprimirEtiquetaYValor(e, posicionlinea, etiqueta1, valor1, x);
            x += 20;
            x = imprimirEtiquetaYValor(e, posicionlinea, etiqueta2, valor2, x);
            x += 20;
            x = imprimirEtiquetaYValor(e, posicionlinea, etiqueta3, valor3, x);
            return x;
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
