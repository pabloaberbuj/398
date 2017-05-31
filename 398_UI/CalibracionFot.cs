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

        public static void InicializarComboBoxSistDosim (ComboBox CBSistDos)
        {
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
    }

    
}
