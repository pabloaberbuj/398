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
            CB_HazRef.SelectedIndex = 0;
            foreach (var cam in Camara.lista())
            {
                CB_Camara.Items.Add(cam);
            }
            foreach (var elec in Electrometro.lista())
            {
                CB_Electrometro.Items.Add(elec);
            }
            if (editaSistDos == true)
            {
                editaSD = true;
                indice = indiceEditar;
                SistemaDosimetrico.editar(CB_Camara, CB_Electrometro, TB_FCal, CB_Tension, TB_Tension, CB_HazRef,
                    TB_Temp, TB_Presion, TB_Humedad, DTP_FechaCal.Value, TB_LabCal, indiceEditar);
            }
            CB_Camara.DisplayMember = "Etiqueta";
            CB_Electrometro.DisplayMember = "Etiqueta";
        }


        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            int auxSignoTension;
            string auxFecha = DTP_FechaCal.Value.ToShortDateString();
            if (CB_Tension.Text == "+") { auxSignoTension = 1; }
            else { auxSignoTension = -1; }

            SistemaDosimetrico.guardar(SistemaDosimetrico.crear((Camara)CB_Camara.SelectedItem, (Electrometro)CB_Electrometro.SelectedItem,
                Convert.ToDouble(TB_FCal.Text),
                auxSignoTension, Convert.ToDouble(TB_Tension.Text),
                CB_HazRef.Text,
                Convert.ToDouble(TB_Temp.Text),
                Convert.ToDouble(TB_Presion.Text),
                Calcular.doubleNaN(TB_Humedad),
                auxFecha,
                TB_LabCal.Text), editaSD, indice);
            editaSD = false;

            Close();
        }

        private void BT_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void habilitarBoton(bool test, Button bt)
        {
            if (test)
            {
                bt.Enabled = true;
            }
            else
            {
                bt.Enabled = false;
            }
        }

        private void esNumeroTB(object sender, EventArgs e)
        {
            if (estaLleno((TextBox)sender))
            {
                if (!Calcular.esNumero(((TextBox)sender).Text))
                {
                    MessageBox.Show("Debe ingresar un número");
                    ((TextBox)sender).Focus(); ((TextBox)sender).SelectAll();
                }
            }
        }

        public static bool estaLleno(TextBox tb)
        {
            return tb.Text != "";
        }

        private void habilitarNuevoSistDosBotones(object sender, EventArgs e)
        {
            habilitarBoton(CB_Camara.SelectedIndex != -1 && CB_Electrometro.SelectedIndex != -1 && TB_FCal.Text != "" &&
                CB_Tension.SelectedIndex != -1 && TB_Tension.Text != "" && CB_HazRef.SelectedIndex != -1 &&
                TB_Temp.Text != "" && TB_Presion.Text != "", BT_Guardar);
        }
    }
}
