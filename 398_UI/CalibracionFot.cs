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

        

        public static void InicializarComboBoxEquipos(ComboBox CBEquipo)
        {

            CBEquipo.Items.Clear();
            foreach (var equipo in Equipo.lista())
            {
                string aux = equipo.Marca + " " + equipo.Modelo + " Nº Serie: " + equipo.NumSerie;
                CBEquipo.Items.Add(aux);
                if (equipo.EsPredet == true)
                {
                    CBEquipo.SelectedIndex = CBEquipo.FindStringExact(aux);
                }
            }
        }

        public static void InicializarComboBoxSistDosim(ComboBox CBSistDos)
        {
            CBSistDos.Items.Clear();
            foreach (var sistdos in SistemaDosimetrico.lista())
            {
                string aux = sistdos.camara.EtiquetaCam + sistdos.electrometro.EtiquetaElec;
                CBSistDos.Items.Add(aux);
                if (sistdos.EsPredet == true)
                {
                    CBSistDos.SelectedIndex = CBSistDos.FindStringExact(aux);
                }
            }
        }
        public static void InicializarComboBoxEnergias(ComboBox CBEquipo, ComboBox CBEnergias)
        {
            CBEnergias.Items.Clear();
            if (CBEquipo.SelectedIndex != -1)
            {
                foreach (var energia in Equipo.lista()[CBEquipo.SelectedIndex].energiaFot)
                {
                    CBEnergias.Items.Add(energia.Energia.ToString());
                    if (energia.EsPredet == true)
                    {
                        CBEnergias.SelectedIndex = CBEnergias.FindStringExact(energia.Energia.ToString());
                    }
                }
            }
        }
        public static void InicializarLadoCampoPredet(TextBox TB)
        {
            TB.Text = 10.ToString();
        }
        public static void InicializarProfundidadReferencia(ComboBox CBEquipo, ComboBox CBEnergias, TextBox TBProf)
        {
            if (CBEnergias.SelectedIndex != -1)
            {
                TBProf.Text = Equipo.lista()[CBEquipo.SelectedIndex].energiaFot[CBEnergias.SelectedIndex].ZRefFot.ToString();
            }
        }

        public static double CalcularKtp(double T0, double T, double P0, double P)
        {
            return Math.Round((273.2 + T) * P0 / (273.2 + T0) / P,4);
        }

        public static double CalcularKpol(int signopol, double LVmas, double LVmenos)
        {
            if (signopol == 1) //polaridad positiva
            {
                return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmas),4);
            }
            else
            {
                return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmenos),4);
            }
        }

        public static double CalcularKs(double Vtot, double Vred, double LVtot, double LVred, int ALEoCo, int pulsadoOBarrido)
        {
            if (ALEoCo == 1)//Co
            {
                return Math.Round((Math.Pow((Vtot / Vred), 2) - 1) / (Math.Pow((Vtot / Vred), 2) - (LVtot / LVred)),4);
            }
            else
            {
                double a0 = 0; double a1 = 0; double a2 = 0;
                if (pulsadoOBarrido == 1) //Pulsado
                {
                    string[] fid = Tabla.Cargar(Tabla.tabla_Ks_pulsados);
                    double[] v1_v2Etiquetas = Tabla.extraerDoubleArray(fid, 0);
                    string[] a0a1a2Etiquetas = Tabla.extraerStringArray(fid, 1);
                    double[,] tabla = Tabla.extraerMatriz(fid, 3, 8, a0a1a2Etiquetas.Count(), v1_v2Etiquetas.Count());

                    a0 = MetodosCalculos.interpolatabla(Vtot / Vred, "a0", v1_v2Etiquetas,a0a1a2Etiquetas, tabla);
                    a1 = MetodosCalculos.interpolatabla(Vtot / Vred, "a1", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    a2 = MetodosCalculos.interpolatabla(Vtot / Vred, "a2", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                }
                else
                {
                    string[] fid = Tabla.Cargar(Tabla.tabla_Ks_pulsadosYbarridos);
                    double[] v1_v2Etiquetas = Tabla.extraerDoubleArray(fid, 0);
                    string[] a0a1a2Etiquetas = Tabla.extraerStringArray(fid, 1);
                    double[,] tabla = Tabla.extraerMatriz(fid, 3, 8, a0a1a2Etiquetas.Count(), v1_v2Etiquetas.Count());

                    a0 = MetodosCalculos.interpolatabla(Vtot / Vred, "a0", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    a1 = MetodosCalculos.interpolatabla(Vtot / Vred, "a1", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    a2 = MetodosCalculos.interpolatabla(Vtot / Vred, "a2", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                }
                return Math.Round(a0 + a1 * Math.Abs((LVtot / LVred)) + a2 * Math.Pow((LVtot / LVred), 2),4);
            }
        }

        public static double CalcularTPR2010(double LV20, double LV10, int PDDoTPR)

        {
            if (PDDoTPR == 2)//está tildado D2010
            {
                double PDD20_10 = Math.Abs(LV20 / LV10);
                return Math.Round(1.2661 * PDD20_10 - 0.0595,4);
            }
            else
            {
                return Math.Round(Math.Abs(LV20 / LV10),4);
            }
        }

       public static double CalcularKqq0 (double TPR2010, Camara camara)
        {
            string[] fid = Tabla.Cargar(Tabla.tabla_Kqq0);
            double[] TPR2010Etiquetas = Tabla.extraerDoubleArray(fid, 0);
            string[] listacamarasmodelos = camaras398.listaCamaraModelo();
            double[,] tabla = Tabla.extraerMatriz(fid, 3, 53, TPR2010Etiquetas.Count(), listacamarasmodelos.Count());
            return Math.Round(MetodosCalculos.interpolatabla(TPR2010, camara.Marca + camara.Modelo, TPR2010Etiquetas, listacamarasmodelos, tabla),4);
        }
    }


}
