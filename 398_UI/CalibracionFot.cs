using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class CalibracionFot
    {
        public Equipo Equipo { get; set; }
        public EnergiaFotones Energia { get; set; }
        public SistemaDosimetrico SistemaDosim { get; set; }
        public double DFSoISO { get; set; } //1 DFSfija 2 ISO
        public double LadoCampo { get; set; }
        public double Profundidad { get; set; }
        public DateTime Fecha { get; set; }
        public string RealizadoPor { get; set; }
        public double Ktp { get; set; }
        public double TPR2010 { get; set; }
        public double Kqq0 { get; set; }
        public int mideKqq0 { get; set; } //1 si 2 usaLB
        public double kpol { get; set; }
        public int mideKpol { get; set; } //1 si 2 usaLB 3 no corrige
        public double Vred { get; set; }
        public double ks { get; set; }
        public int mideKs { get; set; } //1 si 2 usaLB 3 no corrige
        public double Mref { get; set; }
        public double Dwzref { get; set; }
        public double Dwzmax { get; set; }
        public bool EsReferencia { get; set; }
        public static string file = @"caliFotones.txt";


        //operaciones        

        public static BindingList<CalibracionFot> lista()
        {
            return IO.readJsonList<CalibracionFot>(file);
        }

        public static CalibracionFot crear(Equipo _equipo, EnergiaFotones _energia, SistemaDosimetrico _sistdos, double _DFSoISO, double _ladoCampo, double _profundidad, DateTime _fecha,
            string _realizadoPor, double _ktp, double _TPR2010, double _kqq0, int _mideKqq0, double _kpol, int _mideKpol, double _vred, double _ks, int _mideKs, double _mref, double _dwzref, double _dwzmax)
        {
            return new CalibracionFot()
            {
                Equipo = _equipo,
                Energia = _energia,
                SistemaDosim = _sistdos,
                DFSoISO = _DFSoISO,
                LadoCampo = _ladoCampo,
                Profundidad = _profundidad,
                Fecha = _fecha,
                RealizadoPor = _realizadoPor,
                Ktp = _ktp,
                TPR2010 = _TPR2010,
                Kqq0 = _kqq0,
                mideKqq0 = _mideKqq0,
                kpol = _kpol,
                mideKpol = _mideKpol,
                Vred = _vred,
                ks = _ks,
                mideKs = _mideKs,
                Mref = _mref,
                Dwzref = _dwzref,
                Dwzmax = _dwzmax,
                EsReferencia = false,
            };
        }

        public static bool guardar(CalibracionFot _nuevo, bool esRef)
        {
            var auxLista = lista();
            auxLista.Add(_nuevo);
            if (esRef)
            {
                if (hayReferencia(_nuevo.Equipo, _nuevo.Energia, _nuevo.DFSoISO))
                {
                    if (MessageBox.Show("Ya existe una referencia \n ¿Desea sobreescribirla?", "Establecer Referencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        establecerComoReferencia(_nuevo, auxLista);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    establecerComoReferencia(_nuevo, auxLista);
                }
            }
            IO.writeObjectAsJson(file, auxLista);
            return true;
        }

        public static void exportarUnaCalibracion(CalibracionFot _nuevo)
        {
            try
            {
                string fileName = IO.GetUniqueFilename(@"..\..\", "calibracionesExportadas");
                IO.writeObjectAsJson(fileName, _nuevo);

                MessageBox.Show("Se ha exportado equipos correctamente", "Exportar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error. No se ha podido exportar: " + e.ToString());
            }
        }

        //calculos

        public static double CalcularKtp(double T0, double T, double P0, double P)
        {
            return Math.Round((273.2 + T) * P0 / (273.2 + T0) / P, 4);
        }

        public static double calcularKpol(int signopol, double LVmas, double LVmenos, bool noUsa, bool usaLB, Equipo equipo, EnergiaFotones energia, double DFSoISO)
        {
            if (noUsa)
            {
                return 1;
            }
            else if (usaLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).kpol;
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

        public static double calcularKs(double Vtot, double Vred, double LVtot, double LVred, int ALEoCo, int pulsadoOBarrido, bool noUsa, bool usaLB, Equipo equipo, EnergiaFotones energia, double DFSoISO)
        {
            if (noUsa)
            {
                return 1;
            }
            else if (usaLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).ks;
            }
            else
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
        }

        public static double calcularTPR2010(double LV20, double LV10, int PDDoTPR, bool usarLB, Equipo equipo, EnergiaFotones energia, double DFSoISO)
        {
            if (usarLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).TPR2010;
            }
            else if (PDDoTPR == 2)//está tildado D2010
            {
                double PDD20_10 = Math.Abs(LV20 / LV10);
                return Math.Round(1.2661 * PDD20_10 - 0.0595, 4);
            }
            else
            {
                return Math.Round(Math.Abs(LV20 / LV10), 4);
            }
        }

        public static double calcularKqq0(double TPR2010, Camara camara, Equipo equipo, bool usarLB, EnergiaFotones energia, double DFSoISO)
        {
            if (equipo.Fuente == 1)
            {
                return 1;
            }
            else if (usarLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).Kqq0;
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

        public static double calcularDifConRef(double Dwref, Equipo equipo, EnergiaFotones energia, double DFSoISO)
        {
            double DwrefLB = obtenerCaliReferencia(equipo, energia, DFSoISO).Dwzref;
            return Math.Round((Dwref - DwrefLB) / DwrefLB * 100,4);
        }

        //linea base

        public static bool hayReferencia(Equipo equipo, EnergiaFotones energia, double DFSoISO)
        {
            bool hayRef = false;
            foreach (CalibracionFot cali in lista())
            {
                if (cali.Equipo.EqualsParaCali(equipo) && cali.Energia.EqualsParaCali(energia) && cali.DFSoISO.Equals(DFSoISO) && cali.EsReferencia)
                {
                    hayRef = true;
                    break;
                }
            }
            return hayRef;
        }

        public static CalibracionFot obtenerCaliReferencia(Equipo equipo, EnergiaFotones energia, double DFSoISO)
        {
            CalibracionFot caliLB = new CalibracionFot();
            foreach (CalibracionFot cali in lista())
            {
                if (cali.Equipo.EqualsParaCali(equipo) && cali.Energia.EqualsParaCali(energia) && cali.DFSoISO.Equals(DFSoISO) && cali.EsReferencia)
                {
                    caliLB = cali;
                    break;
                }
            }
            return caliLB;
        }

        public static void establecerComoReferencia(CalibracionFot califot, BindingList<CalibracionFot> auxLista)
        {
            foreach (CalibracionFot cali in auxLista)
            {
                if (cali.Equipo.Equals(califot.Equipo) && cali.Energia.Equals(califot.Energia) && cali.DFSoISO.Equals(califot.DFSoISO))
                {
                    cali.EsReferencia = false;
                    if (cali.Equals(califot))
                    {
                        cali.EsReferencia = true;
                    }
                }
            }

        }

    }
}



