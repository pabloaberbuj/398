using System;
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
        public NuevoSistDos()
        {
            InitializeComponent();
            CB_Tension.SelectedIndex = 0;

        }

        private void Leave_ObligatoriosparaGuardar(object sender, EventArgs e)
        {
            if (CB_Camara.SelectedIndex!=-1 && CB_Electrometro.SelectedIndex!=-1 &&
                TB_FCal.Text!="" && CB_Tension.SelectedIndex!=-1 && TB_Tension.Text!="" &&
                CB_HazRef.SelectedIndex!=-1 && TB_Temp.Text!="" && TB_Presion.Text!="")
            { BT_Guardar.Enabled = true; }
            else { BT_Guardar.Enabled = false; }

        }

        private void Leave_EsNumeroObligatoriosparaGuardar(object sender, EventArgs e)
        {
            if (MetodosCalculos.EsNumero((TextBox)sender) == true)
            {
                if (CB_Camara.SelectedIndex != -1 && CB_Electrometro.SelectedIndex != -1 &&
                  TB_FCal.Text != "" && CB_Tension.SelectedIndex != -1 && TB_Tension.Text != "" &&
                  CB_HazRef.SelectedIndex != -1 && TB_Temp.Text != "" && TB_Presion.Text != "")
                { BT_Guardar.Enabled = true; }
                else { BT_Guardar.Enabled = false; }
            }

        }
        private void TB_EsNumero(object sender, EventArgs e)
        {
            MetodosCalculos.EsNumero((TextBox)sender);
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            string[] auxCam = CB_Camara.Text.Split(',');
            string[] auxElec = CB_Electrometro.Text.Split(',');
            int auxSignoTension;
            string auxFecha = DTP_FechaCal.Value.ToShortDateString();
            if (CB_Tension.Text == "+") { auxSignoTension = 1; }
            else { auxSignoTension = -1; }
            
            SistemaDosimetrico SistDosAux = CrearInstancia.CrearSistDosim(
                auxCam[0], auxCam[1], auxCam[2],
                auxElec[0], auxElec[1], auxElec[2],
                Convert.ToDouble(TB_FCal.Text),
                auxSignoTension, Convert.ToDouble(TB_Tension.Text),
                CB_HazRef.Text,
                Convert.ToDouble(TB_Temp.Text),
                Convert.ToDouble(TB_Presion.Text),
                Convert.ToDouble(TB_Humedad.Text),
                auxFecha,
                TB_LabCal.Text);
            Form1.AddSistDos(SistDosAux);

            Close();
        }
    }
}
