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

public static class Imprimir
{
	public static void imprimirTitulo(PrintPageEventArgs e, string titulo, int anchohoja, int posicionlinea, Font fuente, StringFormat formato, SolidBrush color)
    {
        Rectangle rect = new Rectangle(0, posicionlinea, anchohoja, posicionlinea);
        e.Graphics.DrawString(titulo, fuente, color, rect, formato);
    }

    public static void imprimirTexto(PrintPageEventArgs e, string texto, int anchohoja, int posicionlinea, int numlineas, Font fuente, StringFormat formato, SolidBrush color, int x)
    {
        Rectangle rect = new Rectangle(x, posicionlinea, anchohoja, posicionlinea * numlineas);
        e.Graphics.DrawString(texto, fuente, color, rect, formato);
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

}
}
