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
    public partial class Form1 : Form
    {
        int panel = 0;
        NuevoSistDos nsd = new NuevoSistDos();
        public Form1()
        {

            InitializeComponent();
            Panel_AnalizarReg.Visible = false; Panel_Equipos.Visible = false;
            Panel_CalFot.Visible = false; Panel_SistDos.Visible = false;
        }

        private void Bt_Inicio_Click(object sender, EventArgs e)
        {
            TraerPanel(0, Panel_Inicio);
        }
        private void Bt_NuevaCal_Click(object sender, EventArgs e)
        {
            TraerPanel(1, Panel_CalFot);
        }

        private void Bt_SistDos_Click(object sender, EventArgs e)
        {
            TraerPanel(2, Panel_SistDos);
        }

        private void Bt_Equipos_Click(object sender, EventArgs e)
        {
            TraerPanel(3, Panel_Equipos);
        }

        private void Bt_AnalizarReg_Click(object sender, EventArgs e)
        {
            TraerPanel(4, Panel_AnalizarReg);
        }

        private void BT_NuevSistDos_Click(object sender, EventArgs e)
        {
            nsd.Show();
        }

        private void btClick_IraEquipo(object sender, EventArgs e)
        {
            TraerPanel(3, Panel_Equipos); 
            BT_EqIraCal.Text="Seleccionar y volver a calibración";
            GB_Equipos.Visible = true; GB_CondRef.Visible = false; Panel_Equipos.Visible = true;
        }

        private void btCkick_IraSistDos(object sender, EventArgs e)
        {
            TraerPanel(2, Panel_SistDos);
            BT_SistDosIraCal.Text = "Seleccionar y volver a calibración";
            Panel_SistDos.Visible = true;
        }

        private void btClick_IraCondic(object sender, EventArgs e)
        {
            TraerPanel(3, Panel_Equipos);
            BT_CondIraCal.Text = "Seleccionar y volver a calibración";
            GB_CondRef.Visible = true; GB_Equipos.Visible = false; Panel_Equipos.Visible = true;
        }

        private void BT_EqIraCal_Click(object sender, EventArgs e)
        {
            //falta que seleccione ese equipo en calibración
            TraerPanel(1, Panel_CalFot);
            BT_EqIraCal.Text = "Seleccionar e ir a calibración"; GB_CondRef.Visible = true;
        }

        private void BT_CondIraCal_Click(object sender, EventArgs e)
        {
            //falta que seleccione esa condicion en calibración
            TraerPanel(1, Panel_CalFot);
            BT_CondIraCal.Text = "Seleccionar e ir a calibración"; GB_Equipos.Visible = true;
        }

        private void BT_SistDosIraCal_Click(object sender, EventArgs e)
        {
            //falta que seleccione ese sist dos en calibración
            TraerPanel(1, Panel_CalFot);
            BT_SistDosIraCal.Text = "Seleccionar e ir a calibración";
        }

        private void TraerPanel(int nropanel, Panel nombrepanel)
        {
            if (panel != nropanel)
            { nombrepanel.Visible= true; nombrepanel.BringToFront(); panel = nropanel; };
        }

        private void Prom_Lref(object sender, EventArgs e)
        {
            Metodos.promediar(Panel_LecRef, LB_LecRefProm);
             
        }
        private void Prom_L20(object sender, EventArgs e)
        {
            Metodos.promediar(Panel_Lect20, LB_Lect20prom);
        }
        private void Prom_L10(object sender, EventArgs e)
        {
            Metodos.promediar(Panel_Lect10, LB_Lect10prom);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
    }

    
}
