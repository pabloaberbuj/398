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

        public static Font fuenteTitulo = new Font("Arial", 14, FontStyle.Bold);
        public static Font fuenteSubtitulo = new Font("Arial", 11, FontStyle.Bold);
        public static Font fuenteSubtitulo2 = new Font("Arial", 10, FontStyle.Bold);
        public static Font fuenteTexto = new Font("Arial", 9, FontStyle.Regular);
        public static Font fuenteSubindice = new Font("Arial", 5, FontStyle.Regular);
        public static Font fuenteTextoNegrita = new Font("Arial", 9, FontStyle.Bold);
        public static Font fuenteTabla = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        public static Font fuenteTablaHeader = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        public static SolidBrush negro = new SolidBrush(Color.Black);
        public static Pen penNegra = new Pen(Color.Black, 2);
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
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(100, 100, 50, 50);

            anchoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Width) - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            altoTotal = Convert.ToInt32(printDocument1.DefaultPageSettings.PrintableArea.Height) - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;

            return printDocument1;
        }



        public static int imprimirTextoSubindice(PrintPageEventArgs e, string textoNormal, string textoSubindice, int posicionlinea, int x)
        {
            int largoTexto = Convert.ToInt32(e.Graphics.MeasureString(textoNormal, fuenteTexto).Width);
            Rectangle rectTexto = new Rectangle(0, posicionlinea, anchoTotal, altoTexto);
            e.Graphics.DrawString(textoNormal, fuenteTexto, negro, rectTexto);
            int largoSubindice = Convert.ToInt32(e.Graphics.MeasureString(textoSubindice, fuenteSubindice).Width);
            Rectangle rectSubindice = new Rectangle(largoTexto-3, posicionlinea + 5, anchoTotal, altoTexto);
            e.Graphics.DrawString(textoSubindice, fuenteSubindice, negro, rectSubindice);
            return largoTexto + largoSubindice;
        }

        public static int imprimirSubti2Subindice(PrintPageEventArgs e, string textoNormal, string textoSubindice, int posicionlinea, int x)
        {
            int largoTexto = Convert.ToInt32(e.Graphics.MeasureString(textoNormal, fuenteSubtitulo2).Width);
            Rectangle rectTexto = new Rectangle(0, posicionlinea, anchoTotal, altoSubtitulo2);
            e.Graphics.DrawString(textoNormal, fuenteSubtitulo2, negro, rectTexto);
            int largoSubindice = Convert.ToInt32(e.Graphics.MeasureString(textoSubindice, fuenteSubindice).Width);
            Rectangle rectSubindice = new Rectangle(largoTexto - 3, posicionlinea + 5, anchoTotal, altoTexto);
            e.Graphics.DrawString(textoSubindice, fuenteSubindice, negro, rectSubindice);
            return largoTexto + largoSubindice;
        }

        public static void imprimirLinea(PrintPageEventArgs e, int posicionlinea)
        {
            e.Graphics.DrawLine(penNegra, new Point(0, posicionlinea), new Point(anchoTotal, posicionlinea));
        }

        public static int imprimirTitulo(PrintPageEventArgs e, string titulo, int posicionlinea, int numlineas)
        {
            Rectangle rect = new Rectangle(0, posicionlinea, anchoTotal, altoTitulo * numlineas);
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
            return Convert.ToInt32(largoString.Width) + 1;
        }

        public static int imprimirFactor(PrintPageEventArgs e, int posicionlinea, string nombreFactor, double valor, string nota = "")
        {
            int margen = 4;
            int x = 10;
            posicionlinea += Convert.ToInt32(altoTexto / 2);
            string aux = "  " + nombreFactor + " = " + valor.ToString();
            imprimirSubtitulo2(e,aux , posicionlinea);
            SizeF largoString = e.Graphics.MeasureString(aux, fuenteSubtitulo2);
            x += Convert.ToInt32(largoString.Width) + 10;
            imprimirTexto(e, nota, posicionlinea, 1, x);
            Rectangle rect = new Rectangle(0, posicionlinea-margen, Convert.ToInt32(largoString.Width)+margen*2, altoTexto+ margen * 2);
            e.Graphics.DrawRectangle(penNegra, rect);
            posicionlinea += Convert.ToInt32(altoTexto / 2);
            return posicionlinea;
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
                imprimirEtiquetaYValorx3(e, posicionlinea, "Tamaño de campo: ", tamCampo + "cm x " + tamCampo + "cm", "Profundidad: ", prof + "cm", "PDD(zref): ", TPRoPDD + "%");
                posicionlinea += altoTexto + espacioParrafo;
            }
            else if (DFSoISO == 2)
            {
                imprimirEtiquetaYValor(e, posicionlinea, "Técnica: ", "Isocéntrico", 0);
                posicionlinea += altoTexto + espacioParrafo;
                imprimirEtiquetaYValorx3(e, posicionlinea, "Tamaño de campo: ", tamCampo + "cm x " + tamCampo + "cm", "Profundidad: ", prof + "cm", "TPR(zref): ", TPRoPDD + "%");
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
            imprimirEtiquetaYValorx3(e, posicionlinea, "T0: ", sistemaDosimetrico.TempRef.ToString() + "ºC", "P0: ", sistemaDosimetrico.PresionRef.ToString() + "hPa", "Hum: ", sistemaDosimetrico.HumedadRef.ToString()+"%");
            posicionlinea += altoTexto + espacioParrafo;
            if (sistemaDosimetrico.SignoTension==+1)
            {
                imprimirEtiquetaYValorx2(e, posicionlinea, "Tensión: ", sistemaDosimetrico.Tension.ToString()+"V", "Signo: ", "Positivo");
            }
            else
            {
                imprimirEtiquetaYValorx2(e, posicionlinea, "Tensión: ", sistemaDosimetrico.Tension.ToString() + "V", "Signo: ", "Negativo");
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
            imprimirEtiquetaYValorx3(e, posicionlinea, "T: ", T + "ºC", "P: ", P + "hPa", "Hum: ", Hum + "%");
            posicionlinea += altoTexto+ espacioParrafo;
            imprimirFactor(e, posicionlinea, "KTP", KTP);
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirKpol(PrintPageEventArgs e,int posicionlinea, double LMasV, double LMenosV, double Kpol, int medido)
        {
            if (medido==1)
            {
                imprimirEtiquetaYValorx2(e, posicionlinea, "Lect(V) = ", LMasV.ToString() + "nC", "Lect(-V) = ", LMenosV.ToString() + "nC");
                posicionlinea += altoTexto + espacioParrafo;
                imprimirFactor(e, posicionlinea, "Kpol", Kpol);
            }
            else if (medido == 2) //usa LB
            {
                imprimirFactor(e, posicionlinea, "Kpol", Kpol,"(extraído de calibración de referencia)");
            }
            else if (medido == 3) //no corrige
            {
                imprimirFactor(e, posicionlinea, "Kpol", Kpol, "(no se corrigió por ese factor)");
            }
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirKs(PrintPageEventArgs e, int posicionlinea, double Ltot, double Lred, string Vred, double Ks, int medido)
        {
            if (medido == 1)
            {
                imprimirEtiquetaYValorx2(e, posicionlinea, "Lect(V) = ", Ltot.ToString() + "nC", "Lect(Vred=" + Vred + "V) = ", Lred.ToString() + "nC");
                posicionlinea += altoTexto + espacioParrafo;
                imprimirFactor(e, posicionlinea, "Ks", Ks);
            }
            else if (medido == 2) //usa LB
            {
                imprimirFactor(e, posicionlinea, "Ks", Ks, "(extraído de calibración de referencia)");
            }
            else if (medido == 3) //no corrige
            {
                imprimirFactor(e, posicionlinea, "Ks", Ks, "(no se corrigió por ese factor)");
            }
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirTPRyKqq0(PrintPageEventArgs e,int posicionlinea, double L20, double L10, double TPR2010, double kqq0, int medido, int DoTPR)
        {
            if (medido ==1)
            {
                if (DoTPR==1)//D2010
                {
                    imprimirEtiquetaYValorx3(e, posicionlinea, "Lect20 = ", L20.ToString() + "nC", "Lect10 = ", L10.ToString() + "nC", "", " (medidos a DFS fija)");
                }
                else if (DoTPR==2)//TPR2010
                {
                    imprimirEtiquetaYValorx3(e, posicionlinea, "Lect20 = ", L20.ToString() + "nC", "Lect10 = ", L10.ToString() + "nC", "", " (medidos en isocentro)");
                }
                posicionlinea += altoTexto + espacioParrafo;
                imprimirFactor(e, posicionlinea, "TPR2010", TPR2010);
                posicionlinea += altoTexto + espacioParrafo*3;
                imprimirFactor(e, posicionlinea, "Kqq0", kqq0);
            }
            else if (medido ==2) //usa LB
            {
                imprimirFactor(e, posicionlinea, "Kqq0", kqq0, "(extraído de calibración de referencia)");
            }
            posicionlinea += altoTexto + espacioParrafo;
            return posicionlinea;
        }

        public static int imprimirTodoEnRef(PrintPageEventArgs e, int posicionlinea, double Lref, double Mref, double DwzRef, double DwzMax, double DifLB, bool hayPDDoTPR, bool hayLB)
        {
            imprimirEtiquetaYValor(e, posicionlinea, "Lectref: ", Lref.ToString() + "nC", 0);
            posicionlinea += altoTexto + espacioParrafo;
            int inicio = posicionlinea;
            int margen = 2;
            int x = 10;
            //int x = 10+anchoTotal/3;
            int numeroLineas = 2;
            posicionlinea += Convert.ToInt32(altoTexto / 2);
            string aux = "  Mref  = " + Mref.ToString();
            imprimirSubtitulo(e, aux, posicionlinea);
            double largoMax = e.Graphics.MeasureString(aux, fuenteSubtitulo2).Width;
            posicionlinea += altoTexto + espacioParrafo;
            aux = "  Dwzref  = " + DwzRef.ToString() + "cGy/UM";
            imprimirSubtitulo(e, aux, posicionlinea);
            largoMax = Math.Max(largoMax, e.Graphics.MeasureString(aux, fuenteSubtitulo2).Width);
            if (hayPDDoTPR)
            {
                posicionlinea += altoTexto + espacioParrafo;
                aux = "  Dwzmax  = " + DwzMax.ToString() + "cGy/UM";
                imprimirSubtitulo(e, aux, posicionlinea);
                largoMax = Math.Max(largoMax, e.Graphics.MeasureString(aux, fuenteSubtitulo2).Width);
                numeroLineas++;
            }
            if (hayLB)
            {
                posicionlinea += altoTexto + espacioParrafo;
                aux = "  Dif con referencia  = " + DifLB.ToString() + "%";
                imprimirSubtitulo(e, aux, posicionlinea);
                largoMax = Math.Max(largoMax, e.Graphics.MeasureString(aux, fuenteSubtitulo2).Width);
                numeroLineas++;
            }

            x += Convert.ToInt32(largoMax) + 10;
            Rectangle rect = new Rectangle(0, inicio  - margen, x + margen * 2, numeroLineas*(altoSubtitulo+espacioParrafo) + margen * 2);
            e.Graphics.DrawRectangle(penNegra, rect);
            posicionlinea += Convert.ToInt32(altoTexto / 2);
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

        
    }
}
