using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _398_UI
{
    public class Calcular
    {

        public static double doubleNaN(TextBox tb)
        {
            if (tb.Text == "")
            {
                return double.NaN;
            }
            else
            {
                return Convert.ToDouble(tb.Text);
            }
        }

        public static double doubleNaN(Label lb)
        {
            if (lb.Text == "Vacio")
            {
                return double.NaN;
            }
            else
            {
                return Convert.ToDouble(lb.Text);
            }
        }

        public static string stringNaN(double valor)
        {
            if (Double.IsNaN(valor))
            {
                return "";
            }
            else
            {
                return valor.ToString();
            }
        }

        public static double validarYConvertirADouble(string entrada)
        {
            CultureInfo alternative = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            alternative.NumberFormat.NumberDecimalSeparator = ",";
            bool esNumero; double salida = Double.NaN;
            esNumero = Double.TryParse(entrada, out salida);
            if (!esNumero)
            {
                esNumero = Double.TryParse(entrada, NumberStyles.Float, alternative, out salida);
                if (!esNumero)
                {
                    salida = Double.NaN;
                }
            }

            return salida;
        }

        public static bool esNumero(string entrada)
        {
            CultureInfo alternative = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            alternative.NumberFormat.NumberDecimalSeparator = ",";
            bool esNumero; double salida;
            esNumero = Double.TryParse(entrada, out salida);
            if (!esNumero)
            {
                esNumero = Double.TryParse(entrada, NumberStyles.Float, alternative, out salida);
            }
            return esNumero;
        }

        public static double promediar(List<double> valores)
        {
            double suma = 0; ; int contador = 0; double promedio = Double.NaN;
            if (valores.Count > 0)
            {
                foreach (double valor in valores)
                {
                    suma += valor;
                    contador++;
                }
                promedio = suma / contador;
            }
            return promedio;
        }

        public static double interpolar(double x1, double x2, double y1, double y2, double x)
        {
            double y;
            if (x == x1) { y = y1; }
            else if (x == x2) { y = y2; }

            else { y = y1 + (y2 - y1) / (x2 - x1) * (x - x1); }
            return y;
        }
        public static double buscatabla(double X, string Y, double[] etiquetasX, string[] etiquetasY, double[,] valores)
        {
            int iX = Array.IndexOf(etiquetasX, X);
            int iY = Array.IndexOf(etiquetasY, Y);
            double XY = valores[iX, iY]; //ver que es así y no al revés
            return XY;
        }

        public static double interpolarLinea(double X, double[] etiquetasX, double [] valores)
        {
            double Y = Double.NaN;
            if (X > etiquetasX.Max()) { MessageBox.Show("El valor es mayor que todos los tabulados. No se puede interpolar"); return Y; }
            else if (X < etiquetasX.Min()) { MessageBox.Show("El valor es menor que todos los tabulados. No se puede interpolar"); return Y; }
            else
            {


            }
        }
        public static double interpolatabla(double X, string Y, double[] etiquetasX, string[] etiquetasY, double[,] valores)
        {
            double XY = Double.NaN;

            if (X > etiquetasX.Max()) { MessageBox.Show("El valor es mayor que todos los tabulados. No se puede interpolar"); return XY; }
            else if (X < etiquetasX.Min()) { MessageBox.Show("El valor es menor que todos los tabulados. No se puede interpolar"); return XY; }
            else
            {
                int iX = Array.IndexOf(etiquetasX, X);
                int iY = Array.IndexOf(etiquetasY, Y);

                double X1 = 0; double Y1;
                double X2 = 0; double Y2;
                if (iX != -1) //no hace falta interpolar
                {
                    XY = valores[iX, iY];
                }
                else
                {
                    if (Math.Sign(etiquetasX[1] - etiquetasX[0]) == 1) //creciente
                    {
                        for (int i = 0; i < etiquetasX.Count(); i++)
                        {
                            if (etiquetasX[i] > X)
                            {
                                X1 = etiquetasX[i - 1];
                                X2 = etiquetasX[i];
                                break;
                            }
                        }
                    }
                    else if (Math.Sign(etiquetasX[1] - etiquetasX[0]) == -1) //creciente
                    {
                        for (int i = 0; i < etiquetasX.Count(); i++)
                        {
                            if (etiquetasX[i] < X)
                            {
                                X1 = etiquetasX[i - 1];
                                X2 = etiquetasX[i];
                                break;
                            }
                        }
                    }
                    Y1 = buscatabla(X1, Y, etiquetasX, etiquetasY, valores);
                    Y2 = buscatabla(X2, Y, etiquetasX, etiquetasY, valores);
                    XY = interpolar(X1, X2, Y1, Y2, X);
                }
                return XY;
            }
        }

    }
}
