﻿using System;
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

        public static double[] Vtot_Vred_Ks = { 2, 2.5, 3, 3.5, 4, 5 };
        public static string[] a0a1a2 = { "a0", "a1", "a2" };
        public static double[,] a0a1a2Pulsados = new double[2, 2]; //INVENTADO. CARGAR TABLA
        public static double[,] a0a1a2Barridos = new double[2, 2]; //INVENTADO. CARGAR TABLA

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
            return Math.Round((273.2 + T) * P0 / (273.2 + T0) / P,3);
        }

        public static double CalcularKpol(int signopol, double LVmas, double LVmenos)
        {
            if (signopol == 1) //polaridad positiva
            {
                return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmas),3);
            }
            else
            {
                return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * LVmenos),3);
            }
        }

        public static double CalcularKs(double Vtot, double Vred, double LVtot, double LVred, int ALEoCo, int pulsadoOBarrido)
        {
            if (ALEoCo == 1)//Co
            {
                return Math.Round((Math.Pow((Vtot / Vred), 2) - 1) / (Math.Pow((Vtot / Vred), 2) - Math.Pow((LVtot / LVred), 2)),3);
            }
            else
            {
                double a0 = 0; double a1 = 0; double a2 = 0;
                if (pulsadoOBarrido == 1) //Pulsado
                {
                    a0 = MetodosCalculos.interpolatabla(Vtot / Vred, "a0", Vtot_Vred_Ks,a0a1a2, a0a1a2Pulsados);
                    a1 = MetodosCalculos.interpolatabla(Vtot / Vred, "a1", Vtot_Vred_Ks,a0a1a2, a0a1a2Pulsados);
                    a2 = MetodosCalculos.interpolatabla(Vtot / Vred, "a2", Vtot_Vred_Ks,a0a1a2, a0a1a2Pulsados);
                }
                else
                {
                    a0 = MetodosCalculos.interpolatabla(Vtot / Vred, "a0", Vtot_Vred_Ks,a0a1a2, a0a1a2Barridos);
                    a1 = MetodosCalculos.interpolatabla(Vtot / Vred, "a1", Vtot_Vred_Ks,a0a1a2, a0a1a2Barridos);
                    a2 = MetodosCalculos.interpolatabla(Vtot / Vred, "a2", Vtot_Vred_Ks,a0a1a2, a0a1a2Barridos);
                }
                return Math.Round(a0 + a1 * Math.Abs((LVtot / LVred)) + a2 * Math.Pow((LVtot / LVred), 2),3);
            }
        }

        public static double CalcularTPR2010(double LV20, double LV10, int PDDoTPR)

        {
            if (PDDoTPR == 2)//está tildado D2010
            {
                double PDD20_10 = Math.Abs(LV20 / LV10);
                return Math.Round(1.2661 * PDD20_10 - 0.0595,3);
            }
            else
            {
                return Math.Round(Math.Abs(LV20 / LV10),3);
            }
        }
    }


}
