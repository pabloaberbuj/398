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

        
#region Paneles

        //Método para traer paneles
        private void TraerPanel(int nropanel, Panel nombrepanel)
        {
            if (panel != nropanel)
            { nombrepanel.Visible = true; nombrepanel.BringToFront(); panel = nropanel; };
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
#endregion

#region Ir y volver de calibración
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

        #endregion

#region Promedios
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

        private void Prom_masV(object sender, EventArgs e)
        {
            Metodos.promediar(Panel_LectmasV, LB_LectmasVprom);
        }

        private void Prom_menosV(object sender, EventArgs e)
        {
            Metodos.promediar(Panel_LectmenosV, LB_LectmenosVprom);
        }

        private void Prom_Vtot(object sender, EventArgs e)
        {
            Metodos.promediar(Panel_lectVtot, LB_lectVtotProm);
        }

        private void Prom_Vred(object sender, EventArgs e)
        {
            Metodos.promediar(Panel_LectVred, LB_LectVredProm);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        #endregion

        #region UI Equipos

        private void CHB_EnFotEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_EnFotEquipo.Checked == true)
            { Panel_EnFotEquipo.Enabled = true; }
            else { Panel_EnFotEquipo.Enabled = false; }
        }

        private void CHB_EnElecEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_EnElecEquipo.Checked==true)
            { Panel_EnElecEquipo.Enabled = true; }
            else { Panel_EnElecEquipo.Enabled = false; }
        }

        private void RB_FuenteCo_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_FuenteCo.Checked == true)
            { Panel_TipoHazEquipo.Enabled = false; LB_TipoHaz.Enabled = false; }
        }

        private void RB_FuenteALE_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_FuenteALE.Checked == true)
            { Panel_TipoHazEquipo.Enabled = true; LB_TipoHaz.Enabled = true; }

        }
        #endregion

        #region UI Calibración Fotones
        private void CHB_UsarKqq0LB_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_UsarKqq0LB.Checked==true)
            { Panel_TPRoPDD.Enabled = false; Panel_LecKqq0.Enabled = false; }
            else { Panel_TPRoPDD.Enabled = true; Panel_LecKqq0.Enabled = true; }
        }

        private void CHB_UsaKpolLB_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_UsaKpolLB.Checked == true)
            { CHB_NoUsaKpol.Checked = false; Panel_LecKpol.Enabled = false; }
            else { Panel_LecKpol.Enabled = true; }
        }

        private void CHB_NoUsaKpol_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_NoUsaKpol.Checked==true)
            { CHB_UsaKpolLB.Checked = false; Panel_LecKpol.Enabled = false; LB_KpolRes.Text = "Kpol = 1"; }
            else { Panel_LecKpol.Enabled = true; LB_KpolRes.Text = "Kpol = "; }
        }

        private void CHB_UsaKsLB_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_UsaKsLB.Checked == true)
            { CHB_NoUsaKs.Checked = false; Panel_LecKs.Enabled = false; Panel_Vred.Enabled = false; }
            else { Panel_LecKs.Enabled = true; Panel_Vred.Enabled = false; }
        }

        private void CHB_NoUsaKs_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_NoUsaKs.Checked == true)
            { CHB_UsaKsLB.Checked = false; Panel_LecKs.Enabled = false; LB_KsRes.Text = "Kpol = 1"; Panel_Vred.Enabled = false; }
            else { Panel_LecKs.Enabled = true; LB_KsRes.Text = "Kpol = "; Panel_Vred.Enabled = false; }
        }
        #endregion
        
    }

    

}
