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
        bool editaSD = false;
        int indice = -1;
        public NuevoSistDos(bool editaSistDos, int indiceEditar)
        {
            InitializeComponent();
           
            CB_Tension.SelectedIndex = 0;
            DTP_FechaCal.Value = new DateTime(1900, 1, 1);
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
            /*if (editaSD == true)
            {
                var auxLista = SistemaDosimetrico.lista(); auxLista.RemoveAt(indice);
                IO.writeObjectAsJson(SistemaDosimetrico.file,auxLista);
            }*/
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
                Convert.ToDouble(TB_Humedad.Text),
                auxFecha,
                TB_LabCal.Text),editaSD,indice);

            Close();
        }
    }
}
