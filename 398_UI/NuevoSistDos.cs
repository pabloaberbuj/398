﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _398_UI
{
    public partial class NuevoSistDos : Form
    {
        bool editaSD = false;
        int indice = -1;
        public NuevoSistDos(bool editaSistDos, int indiceEditar)
        {
            InitializeComponent();
           
            CB_Tension.SelectedIndex = 0;
            CB_HazRef.SelectedIndex = 0;
            foreach (var reg in Camara.lista())
            {
                string aux = reg.EtiquetaCam;
                CB_Camara.Items.Add(aux);
            }
            foreach (var reg in Electrometro.lista())
            {
                string aux = reg.EtiquetaElec;
                CB_Electrometro.Items.Add(aux);
            }
            if (editaSistDos == true)
            {
                editaSD = true;
                indice = indiceEditar;
                SistemaDosimetrico.editar(CB_Camara, CB_Electrometro, TB_FCal, CB_Tension, TB_Tension, CB_HazRef,
                    TB_Temp, TB_Presion, TB_Humedad, DTP_FechaCal.Value, TB_LabCal, indiceEditar);
            }
        }

        private void Leave_ObligatoriosparaGuardar(object sender, EventArgs e)
        {
            
        }

        private void Leave_EsNumeroObligatoriosparaGuardar(object sender, EventArgs e)
        {
            
        }


        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            int auxSignoTension;
            string auxFecha = DTP_FechaCal.Value.ToShortDateString();
            if (CB_Tension.Text == "+") { auxSignoTension = 1; }
            else { auxSignoTension = -1; }
            
            SistemaDosimetrico.guardar(SistemaDosimetrico.crear(Camara.lista()[CB_Camara.SelectedIndex],Electrometro.lista()[CB_Electrometro.SelectedIndex],
                Convert.ToDouble(TB_FCal.Text),
                auxSignoTension, Convert.ToDouble(TB_Tension.Text),
                CB_HazRef.Text,
                Convert.ToDouble(TB_Temp.Text),
                Convert.ToDouble(TB_Presion.Text),
                Calcular.doubleNaN(TB_Humedad),
                auxFecha,
                TB_LabCal.Text),editaSD,indice);
            editaSD = false;

            Close();
        }

        private void BT_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
