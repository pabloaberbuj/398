using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    class CalibracionFot
    {
        public Equipo EquipoCali { get; set; }
        public EnergiaFotones EnergiaCali { get; set; }
        public SistemaDosimetrico SistemaDosim { get; set; }
        public double DFSoISO { get; set; } //1 DFSfija 2 ISO
        public double LadoCampo { get; set; }
        public double Profundidad { get; set; }
        public double Ktp { get; set; }
        public DateTime Fecha { get; set; }
        public string RealizadoPor { get; set; }
        public double TPR2010 { get; set; }
        public double Kqq0 { get; set; }
        public double kpol { get; set; }
        public double Vred { get; set; }
        public double ks { get; set; }
        public double Mref { get; set; }
        public double Dwzref { get; set; }
        public double Dwzmax { get; set; }



        public static double CalcularKtp(double T0, double T, double P0, double P)
        {
            return Math.Round((273.2 + T) * P0 / (273.2 + T0) / P, 4);
        }

        public static double CalcularKpol(int signopol, double LVmas, double LVmenos, bool noUsa, bool usaLB)
        {
            if (noUsa)
            {
                return 1;
            }
            else if (usaLB)
            {
                return 21432432;
            }
            else
            {
                if (signopol == 1) //polaridad positiva
                {
                    return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmas), 4);
                }
                else
                {
                    return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmenos), 4);
                }
            }
        }

        public static double CalcularKs(double Vtot, double Vred, double LVtot, double LVred, int ALEoCo, int pulsadoOBarrido)
        {
            if (ALEoCo == 1)//Co
            {
                return Math.Round((Math.Pow((Vtot / Vred), 2) - 1) / (Math.Pow((Vtot / Vred), 2) - (LVtot / LVred)), 4);
            }
            else
            {
                double a0 = 0; double a1 = 0; double a2 = 0;
                if (pulsadoOBarrido == 1) //Pulsado
                {
                    string[] fid = Tabla.Cargar(Tabla.tabla_Ks_pulsados);
                    double[] v1_v2Etiquetas = Tabla.extraerDoubleArray(fid, 0);
                    string[] a0a1a2Etiquetas = Tabla.extraerStringArray(fid, 1);
                    double[,] tabla = Tabla.extraerMatriz(fid, 3, 5, v1_v2Etiquetas.Count(), a0a1a2Etiquetas.Count());

                    a0 = Calcular.interpolatabla(Vtot / Vred, "a0", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    a1 = Calcular.interpolatabla(Vtot / Vred, "a1", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    a2 = Calcular.interpolatabla(Vtot / Vred, "a2", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                }
                else
                {
                    string[] fid = Tabla.Cargar(Tabla.tabla_Ks_pulsadosYbarridos);
                    double[] v1_v2Etiquetas = Tabla.extraerDoubleArray(fid, 0);
                    string[] a0a1a2Etiquetas = Tabla.extraerStringArray(fid, 1);
                    double[,] tabla = Tabla.extraerMatriz(fid, 3, 5, v1_v2Etiquetas.Count(), a0a1a2Etiquetas.Count());

                    a0 = Calcular.interpolatabla(Vtot / Vred, "a0", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    a1 = Calcular.interpolatabla(Vtot / Vred, "a1", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    a2 = Calcular.interpolatabla(Vtot / Vred, "a2", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                }
                return Math.Round(a0 + a1 * Math.Abs((LVtot / LVred)) + a2 * Math.Pow((LVtot / LVred), 2), 4);
            }
        }

        public static double CalcularTPR2010(double LV20, double LV10, int PDDoTPR)
        {
            if (PDDoTPR == 2)//está tildado D2010
            {
                double PDD20_10 = Math.Abs(LV20 / LV10);
                return Math.Round(1.2661 * PDD20_10 - 0.0595, 4);
            }
            else
            {
                return Math.Round(Math.Abs(LV20 / LV10), 4);
            }
        }

        public static double CalcularKqq0(double TPR2010, Camara camara, Equipo equipo, bool usarLB)
        {
            if (equipo.Fuente == 1)
            {
                return 1;
            }
            else if (usarLB)
            {
                return 32425;
            }
            else
            {
                string[] fid = Tabla.Cargar(Tabla.tabla_Kqq0);
                double[] TPR2010Etiquetas = Tabla.extraerDoubleArray(fid, 0);
                double[] valoresKqq0 = Camara.obtenerLineakQQ0(camara);
                return Math.Round(Calcular.interpolarLinea(TPR2010, TPR2010Etiquetas, valoresKqq0), 4);
            }
        }
        public static double CalcularMref(double Lref, double Ktp, double Ks, double Kpol, double UM)
        {
            return Math.Round(Lref * Ktp * Ks * Kpol / UM, 4);
        }

        public static double CalcularDwRef(double Mref, SistemaDosimetrico sistDosim)
        {
            return Math.Round(Mref * sistDosim.FactorCalibracion, 4);
        }

        public static double calcularDwZmax(double Dwref, double rendimientoEnRef)
        {
            return Math.Round(Dwref * rendimientoEnRef / 100, 4);
        }
    }


}
