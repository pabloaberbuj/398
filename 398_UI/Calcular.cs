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
            double salida;
            bool esNumero = Double.TryParse(entrada, out salida);
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

        public static double interpolarLinea(double X, double[] etiquetasX, double[] valores)
        {
            double Y = Double.NaN;
            double X1 = 0; double Y1;
            double X2 = 0; double Y2;
            int iX = Array.IndexOf(etiquetasX, X);
            if (X > etiquetasX.Max())
            {
                MessageBox.Show("El valor es mayor que todos los tabulados. No se puede interpolar");
            }
            else if (X < etiquetasX.Min())
            {
                MessageBox.Show("El valor es menor que todos los tabulados. No se puede interpolar");
            }
            else
            {
                if (iX != -1) //no hace falta interpolar
                {
                    Y = valores[iX];
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
                    else if (Math.Sign(etiquetasX[1] - etiquetasX[0]) == -1) //decreciente
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
                    Y1 = valores[Array.IndexOf(etiquetasX, X1)];
                    Y2 = valores[Array.IndexOf(etiquetasX, X2)];
                    Y = interpolar(X1, X2, Y1, Y2, X);
                }
            }
            return Y;
        }
        public static double interpolaryExtrapolarLinea(double X, double[] etiquetasX, double[] valores)
        {
            double Y = Double.NaN;
            double X1 = 0; double Y1;
            double X2 = 0; double Y2;
            int iX = Array.IndexOf(etiquetasX, X);
            if (iX != -1) //no hace falta interpolar
            {
                Y = valores[iX];
            }
            else
            {
                if (Math.Sign(etiquetasX[1] - etiquetasX[0]) == 1) //creciente
                {
                    if (X > etiquetasX.Max())
                    {
                        MessageBox.Show("El valor es mayor que todos los tabulados. El resultado se obtendrá por extrapolación");
                        X1 = etiquetasX[etiquetasX.Count() - 2]; //anteulitmo
                        X2 = etiquetasX[etiquetasX.Count() - 1]; //ultimo
                    }
                    else if (X < etiquetasX.Min())
                    {
                        MessageBox.Show("El valor es menor que todos los tabulados. El resultado se obtendrá por extrapolación");
                        X1 = etiquetasX[0];
                        X2 = etiquetasX[1];
                    }
                    else
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
                    Y1 = valores[Array.IndexOf(etiquetasX, X1)];
                    Y2 = valores[Array.IndexOf(etiquetasX, X2)];
                    Y = interpolar(X1, X2, Y1, Y2, X);
                }
                else if (Math.Sign(etiquetasX[1] - etiquetasX[0]) == -1) //decreciente
                {
                    if (X > etiquetasX.Max())
                    {
                        MessageBox.Show("El valor es mayor que todos los tabulados. El resultado se obtendrá por extrapolación");
                        X1 = etiquetasX[0];
                        X2 = etiquetasX[1];
                    }
                    else if (X < etiquetasX.Min())
                    {
                        MessageBox.Show("El valor es menor que todos los tabulados. El resultado se obtendrá por extrapolación");
                        X1 = etiquetasX[etiquetasX.Count() - 2]; //anteulitmo
                        X2 = etiquetasX[etiquetasX.Count() - 1]; //ultimo
                    }
                    else
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
                    Y1 = valores[Array.IndexOf(etiquetasX, X1)];
                    Y2 = valores[Array.IndexOf(etiquetasX, X2)];
                    Y = interpolar(X1, X2, Y1, Y2, X);
                }
            }
            return Y;
        }

        public static double interpolatabla(double X, string Y, double[] etiquetasX, string[] etiquetasY, double[,] valores)
        {
            int iY = Array.IndexOf(etiquetasY, Y);
            double[] valoresLinea = new double[etiquetasX.Count()];
            for (int i = 0; i < etiquetasX.Count(); i++) //obtiene la fila en la cual interpolar
            {
                valoresLinea[i] = valores[i, iY];
            }
            return interpolarLinea(X, etiquetasX, valoresLinea);
        }

        public static double desvEstandar(List<double> lista)
        {
            double promedio = lista.Average();
            double varianza = 0;
            foreach (double valor in lista)
            {
                varianza += Math.Pow((valor - promedio), 2);
            }
            return Math.Round(Math.Sqrt(varianza / lista.Count()), 2);
        }

        public static double pendienteCuadradosMinimos(List<double> xLista, List<double> yLista)
        {
            if (xLista.Count!=yLista.Count)
            {
                MessageBox.Show("Las listas no tienen el mismo numero de elementos");
                return double.NaN;
            }
            double sumaXY = 0;
            double sumaX = 0;
            double sumaY = 0;
            double sumaXcuadrado = 0;
            for (int i=0;i<xLista.Count;i++)
            {
                sumaXY += xLista[i] * yLista[i];
                sumaX += xLista[i];
                sumaY += yLista[i];
                sumaXcuadrado += Math.Pow(xLista[i], 2);
            }
            return (xLista.Count * sumaXY - sumaX * sumaY) / (xLista.Count * sumaXcuadrado - Math.Pow(sumaX, 2));
        }
    }
}
