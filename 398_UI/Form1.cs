using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _398_UI
{
    public partial class Form1 : Form
    {
        int panel = 0;
        BindingList<Camara> Camaras = new BindingList<Camara>();
        BindingList<Electrometro> Electrometros = new BindingList<Electrometro>();
        static BindingList<SistemaDosimetrico> SistemasDosimetricos = new BindingList<SistemaDosimetrico>();
        BindingList<Equipo> Equipos = new BindingList<Equipo>();
        BindingList<CalibracionFot> CalibracionesFot = new BindingList<CalibracionFot>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Carga registros

            Camaras = IO.readJsonList<Camara>("camaras.txt");
            Electrometros = IO.readJsonList<Electrometro>("electrometros.txt");
            SistemasDosimetricos = IO.readJsonList<SistemaDosimetrico>("sistdos.txt");

            //Carga DGV
            DGV_Cam.DataSource = Camaras;
            DGV_Elec.DataSource = Electrometros;
            DGV_SistDos.DataSource = SistemasDosimetricos;

            //Carga UI
            Panel_AnalizarReg.Visible = false; Panel_Equipos.Visible = false;
            Panel_CalFot.Visible = false; Panel_SistDos.Visible = false;
            DGV_EnFot.ColumnCount = 4;
            DGV_EnFot.Columns[0].Name = "E [MV]"; DGV_EnFot.Columns[0].Width = 65;
            DGV_EnFot.Columns[1].Name = "Zref"; DGV_EnFot.Columns[1].Width = 38;
            DGV_EnFot.Columns[2].Name = "PDD"; DGV_EnFot.Columns[2].Width = 38;
            DGV_EnFot.Columns[3].Name = "TPR"; DGV_EnFot.Columns[3].Width = 38;
        }


        #region Paneles
        //Ir a paneles
        private void Bt_Inicio_Click(object sender, EventArgs e)
        {
            MetodosControles.TraerPanel(panel,0, Panel_Inicio);
        }
        private void Bt_NuevaCal_Click(object sender, EventArgs e)
        {
            MetodosControles.TraerPanel(panel,1, Panel_CalFot);
        }

        private void Bt_SistDos_Click(object sender, EventArgs e)
        {
            MetodosControles.TraerPanel(panel,2, Panel_SistDos);
        }

        private void Bt_Equipos_Click(object sender, EventArgs e)
        {
            MetodosControles.TraerPanel(panel,3, Panel_Equipos);
        }

        private void Bt_AnalizarReg_Click(object sender, EventArgs e)
        {
            MetodosControles.TraerPanel(panel,4, Panel_AnalizarReg);
        }

        //Ir y volver de calibración
        private void btClick_IraEquipo(object sender, EventArgs e)
        {
            MetodosControles.TraerPanel(panel, 3, Panel_Equipos);
            BT_EqIraCal.Text = "Seleccionar y volver a calibración";
            Panel_Equipos.Visible = true;
        }

        private void btCkick_IraSistDos(object sender, EventArgs e)
        {
            MetodosControles.TraerPanel(panel, 2, Panel_SistDos);
            BT_SistDosIraCal.Text = "Seleccionar y volver a calibración";
            Panel_SistDos.Visible = true;
        }

        private void BT_EqIraCal_Click(object sender, EventArgs e)
        {
            //falta que seleccione ese equipo en calibración
            MetodosControles.TraerPanel(panel, 1, Panel_CalFot);
            BT_EqIraCal.Text = "Seleccionar e ir a calibración";
        }

        private void BT_SistDosIraCal_Click(object sender, EventArgs e)
        {
            //falta que seleccione ese sist dos en calibración
            MetodosControles.TraerPanel(panel, 1, Panel_CalFot);
            BT_SistDosIraCal.Text = "Seleccionar e ir a calibración";
        }
        #endregion


        #region Cali Fotones Promedios
        private void Prom_Lref(object sender, EventArgs e)
        {
            MetodosCalculos.promediar(Panel_LecRef, LB_LecRefProm);
        }

        private void Prom_L20(object sender, EventArgs e)
        {
            MetodosCalculos.promediar(Panel_Lect20, LB_Lect20prom);
        }

        private void Prom_L10(object sender, EventArgs e)
        {
            MetodosCalculos.promediar(Panel_Lect10, LB_Lect10prom);
        }

        private void Prom_masV(object sender, EventArgs e)
        {
            MetodosCalculos.promediar(Panel_LectmasV, LB_LectmasVprom);
        }

        private void Prom_menosV(object sender, EventArgs e)
        {
            MetodosCalculos.promediar(Panel_LectmenosV, LB_LectmenosVprom);
        }

        private void Prom_Vtot(object sender, EventArgs e)
        {
            MetodosCalculos.promediar(Panel_lectVtot, LB_lectVtotProm);
        }

        private void Prom_Vred(object sender, EventArgs e)
        {
            MetodosCalculos.promediar(Panel_LectVred, LB_LectVredProm);
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        #endregion

        #region Cali Fotones UI
        private void CHB_UsarKqq0LB_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_UsarKqq0LB.Checked == true)
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
            if (CHB_NoUsaKpol.Checked == true)
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
            { CHB_UsaKsLB.Checked = false; Panel_LecKs.Enabled = false; LB_KsRes.Text = "Ks = 1"; Panel_Vred.Enabled = false; }
            else { Panel_LecKs.Enabled = true; LB_KsRes.Text = "Ks = "; Panel_Vred.Enabled = false; }
        }
        #endregion

        #region Equipos UI

        private void CHB_EnFotEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_EnFotEquipo.Checked == true)
            { Panel_EnFotEquipo.Enabled = true; }
            else { Panel_EnFotEquipo.Enabled = false; }
        }

        private void CHB_EnElecEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_EnElecEquipo.Checked == true)
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

        #region Energia

        private void BT_EnFotGuardar_Click(object sender, EventArgs e)
        {
            string[] aux = { TB_EnFotEn.Text, TB_EnFotZref.Text, TB_EnFotPDD.Text, TB_EnFotTMR.Text };
            DGV_EnFot.Rows.Add(aux);
            DGV_EnFot.Visible = true;
       
            MetodosControles.LimpiarRegistro(Panel_EnFotEquipo);
            TB_EnFotEn.Focus(); // para que vuelva a energía para cargar uno nuevo
            BT_EnFotGuardar.Enabled = false;
        }

        private void TB_EnFotEnLeave(object sender, EventArgs e)
        {
            if (MetodosCalculos.EsNumero((TextBox)sender) == true)
            { BT_EnFotGuardar.Enabled = true; }
        }

        private void TB_EsNumero(object sender, EventArgs e)
        {
            MetodosCalculos.EsNumero((TextBox)sender);
        }

        private void TB_EnElecEn_Leave(object sender, EventArgs e)
        {
            if (MetodosCalculos.EsNumero((TextBox)sender) == true)
            { BT_EnElecGuardar.Enabled = true; }
        }

        private void BT_EnElecGuardar_Click(object sender, EventArgs e)
        {
            {
                string aux = TB_EnElecEn.Text + "MeV";
                string aux2 = " (";
                if (string.IsNullOrEmpty(TB_EnElecZref.Text)) { }
                else
                {
                    aux2 += "Zref=" + TB_EnElecZref.Text + "cm ";
                }
                if (string.IsNullOrEmpty(TB_EnElecPDD.Text)) { }
                else
                {
                    aux2 += "PDD" + TB_EnElecPDD.Text + "%";
                }
                aux2 += ")"; if (aux2 != " ()") { aux += aux2; }
                LB_EnElec.Items.Add(aux);
                MetodosControles.LimpiarRegistro(Panel_EnElecEquipo);
                TB_EnElecEn.Focus(); // para que vuelva a energía para cargar uno nuevo
                BT_EnElecGuardar.Enabled = false;
            }
        }

        private void LB_EnElec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_EnElec.SelectedIndex != -1)
            { BT_EnElecEditar.Enabled = true; BT_EnElecEliminar.Enabled = true; BT_EnElecPredet.Enabled = true; }
        }

        #endregion

        #endregion

        #region Sist Dosimetrico Botones

        //Camara
        private void BT_GuardarCam_Click(object sender, EventArgs e)
        {
            Camara camara = CrearInstancia.CrearCamara(CB_MarcaCam.Text, CB_ModCam.Text, TB_SNCam.Text);
            Camaras.Add(camara);
            MetodosControles.LimpiarRegistro(GB_Camaras);
            IO.writeObjectAsJson("camaras.txt", Camaras);
        }

        private void BT_EliminarCam_Click(object sender, EventArgs e)
        {
            MetodosControles.EliminarRegistro<Camara>(DGV_Cam, Camaras, "camaras.txt");
        }

        //Electrometro
        private void BT_GuardarElec_Click(object sender, EventArgs e)
        {
            Electrometro electrometro = CrearInstancia.CrearElectrometro(TB_MarcaElec.Text, TB_ModeloElec.Text, TB_SNElec.Text);
            Electrometros.Add(electrometro);
            MetodosControles.LimpiarRegistro(GB_Electrómetros);
            IO.writeObjectAsJson("electrometros.txt", Electrometros);
        }

        private void BT_EliminarElec_Click(object sender, EventArgs e)
        {
            MetodosControles.EliminarRegistro<Electrometro>(DGV_Elec, Electrometros, "electrometros.txt");
        }


        //Sistema Dosimétrico
        public static void AddSistDos(SistemaDosimetrico SistDos) //Para poder acceder desde NuevoSistDos a la Lista
        {
            SistemasDosimetricos.Add(SistDos);
        }

        private void BT_NuevSistDos_Click(object sender, EventArgs e)
        {
            NuevoSistDos nsd = new NuevoSistDos();
            nsd.ShowDialog();
            IO.writeObjectAsJson("sistdos.txt", SistemasDosimetricos);
        }

        private void BT_EliminarSistDos_Click(object sender, EventArgs e)
        {
            MetodosControles.EliminarRegistro<SistemaDosimetrico>(DGV_SistDos, SistemasDosimetricos, "sistdos.txt");
        }

        #endregion


    }
}




