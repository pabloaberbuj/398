using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class Tabla
    {
        public static string tabla_Ks_pulsados = @"..\..\tabla_Ks_pulsados.txt";
        public static string tabla_Ks_pulsadosYbarridos = @"..\..\tabla_Ks_pulsadosYbarridos.txt";
        public static string tabla_Kqq0Fot = @"..\..\tabla_Kqq0Fot.txt";

        public static double[] TPR2010etiquetas = { 0.5, 0.53, 0.56, 0.59, 0.62, 0.65, 0.68, 0.7, 0.72, 0.74, 0.76, 0.78, 0.8, 0.82, 0.84 };
        public static double[] R50etiquetas = { 1, 1.4, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 7, 8, 10, 13, 16, 20 };
        public static string[] Cargar(string archivo)
        {
            return File.ReadAllLines(archivo);
        }

        public static string[] extraerStringArray(string[] fid, int linea,char sepHeader= '=', char separador='\t')
        {
            string aux = fid[linea]; string aux2 = aux.Split(sepHeader)[1];
            return aux2.Split(separador);
        }

        public static double[] extraerDoubleArray(string[] fid, int linea, char sepHeader = '=', char separador = '\t')
        {
            return extraerStringArray(fid, linea, sepHeader, separador).Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        public static double[,] extraerMatriz(string[] fid, int lineaI, int lineaF, int Tam1, int Tam2)
        {
            double[,] M = new double[Tam1, Tam2];
            for (int i = 0; i < Tam2; i++)
            {
                string[] stringLinea = fid[lineaI + i].Split('\t');
                double[] aux1 = stringLinea.Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
                for (int j = 0; j < Tam1; j++)
                {
                    M[j, i] = aux1[j];
                }
            }
            return M;
        }
    }
}
