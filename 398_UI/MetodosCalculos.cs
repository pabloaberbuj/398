using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _398_UI
{
    public class MetodosCalculos
    {
        public static bool EsNumero(TextBox tb)
        {
            double aux=0;
            bool esnumero=true;
            if (tb.Text != "")
            {
                esnumero = Double.TryParse(tb.Text, out aux);
                if (esnumero == true) { }
                else { MessageBox.Show("Debe ingresarse un número"); tb.Focus(); tb.SelectAll();}
            }
            return esnumero;
        }
        public static void promediar(Panel panel, Label texto)
        {
            double suma = 0; double aux; int contador = 0; Nullable<double> promedio = null;
            foreach (TextBox tb in panel.Controls.OfType<TextBox>())
            {
                if (tb.Text != "")
                {
                    bool esnumero = Double.TryParse(tb.Text, out aux);
                    if (esnumero == true)
                    { suma += aux; contador++;}
                    else { MessageBox.Show("Debe ingresarse un número"); tb.Focus(); tb.SelectAll(); break; }
                }
                if (contador != 0) { promedio = Math.Round(suma / contador,3); }
            }
            texto.Visible = true;
            texto.Text = Convert.ToString(promedio);
        }

        public static double Ktp(double T0, double T, double P0, double P)
        {
            double KTP = (273.2 + T) * P0 / (273.2 + T0) / P;
            return KTP;
        }

        public static double Kpol(bool signopol, double LVmas, double LVmenos)
        {
            double KPOL;
            if (signopol == true) //polaridad positiva
            {
                KPOL = (Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmas);
            }
            else
            {
                KPOL = (Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmas);
            }
            return KPOL;
        }

        public static double KsALE (double LVtot, double LVred, double a0, double a1, double a2) 
        {
            double KS = a0 + a1 * Math.Abs((LVtot / LVred)) + a2 * Math.Pow((LVtot / LVred),2);
            return KS;
        }

        public static double KsCo (double LVtot, double LVred, double Vtot, double Vred)
        {
            double KS = (Math.Pow((Vtot / Vred), 2) - 1) / (Math.Pow((Vtot / Vred), 2) - Math.Pow((LVtot / LVred), 2));
            return KS;
        }
        
        public static double TPR2010 (double LV20, double LV10, int PDDoTPR)
        {
            double TPR20_10 = 0;
            if (PDDoTPR == 1)//está tildado PDD
            {
                double PDD20_10 = Math.Abs(LV20 / LV10);
                TPR20_10 = 1.2661 * PDD20_10 - 0.0595;
            }
            else if (PDDoTPR == 2)//está tildado TPR
            {
                TPR20_10 = Math.Abs(LV20 / LV10);
            }
            return TPR20_10;
        }

        public static double interpolar(double x1, double x2, double y1, double y2, double x)
        {
            double y;
            if (x == x1) { y = y1; }
            else if (x==x2) { y = y2; }
            else { y = y1 + (y2 - y1) / (x2 - x1) * (x - x1); }
            return y;
        }
        public static double buscatabla(double X, string Y, double[] etiquetasX, string[] etiquetasY, double[,] valores)
        {
            int iX = Array.IndexOf(etiquetasX, X);
            int iY = Array.IndexOf(etiquetasY, Y);
            double XY = valores[iY, iX]; //ver que es así y no al revés
            return XY;
        }

        public static double interpolatabla(double X, string Y, double[] etiquetasX, string[] etiquetasY, double[,] valores)
        {
            double XY=0;
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
                    XY = valores[iY, iX];
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
