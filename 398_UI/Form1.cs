﻿using System;
using System.Globalization;
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
        int indiceEquipo = 0;
        bool editaCam = false;
        bool editaElec = false;
        bool editaEquipo = false;
        bool editaEnergiaFot = false;
        bool editaEnergiaElect = false;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Carga DGV
            DGV_Cam.DataSource = Camara.lista();
            DGV_Elec.DataSource = Electrometro.lista();
            DGV_SistDos.DataSource = SistemaDosimetrico.lista();
            DGV_Equipo.DataSource = Equipo.lista();

            //inicializar combobox


            //lista de cámaras 398
            CB_MarcaCam.DataSource = Camara398new.lista().Distinct().ToList();
            CB_MarcaCam.DisplayMember = "marca";
            CB_MarcaCam.ValueMember = "marca";
            CB_MarcaCam.SelectedIndex = -1;


            //Carga UI
            Panel_AnalizarReg.Visible = false; Panel_Equipos.Visible = false;
            Panel_CalFot.Visible = false; Panel_SistDos.Visible = false;
            actualizarComboBoxCaliFotones();
            inicializarPredeterminados(100, 10);
            chEditarVKpol.Checked = false;
            chEditarVKs.Checked = false;
            InicializarInstitucionYMarcaEquipo();


        }


        #region Paneles
        //Ir a paneles
        private void Bt_Inicio_Click(object sender, EventArgs e)
        {
            panel = traerPanel(panel, 0, Panel_Inicio, Bt_Inicio, Panel_Botones);
        }
        private void Bt_CalFot_Click(object sender, EventArgs e)
        {
            panel = traerPanel(panel, 1, Panel_CalFot, Bt_CalFot, Panel_Botones);
        }
        private void Bt_SistDos_Click(object sender, EventArgs e)
        {
            panel = traerPanel(panel, 2, Panel_SistDos, Bt_SistDos, Panel_Botones);
        }
        private void Bt_Equipos_Click(object sender, EventArgs e)
        {
            panel = traerPanel(panel, 3, Panel_Equipos, Bt_Equipos, Panel_Botones);
        }

        private void Bt_AnalizarReg_Click(object sender, EventArgs e)
        {
            panel = traerPanel(panel, 4, Panel_AnalizarReg, Bt_AnalizarReg, Panel_Botones);
        }

        //Ir y volver de calibración
        private void btClick_IraEquipo(object sender, EventArgs e)
        {
            panel = traerPanel(panel, 3, Panel_Equipos, Bt_Equipos, Panel_Botones);
            BT_EqIraCal.Text = "Seleccionar y volver a calibración";
            Panel_Equipos.Visible = true;
        }

        private void btCkick_IraSistDos(object sender, EventArgs e)
        {
            panel = traerPanel(panel, 2, Panel_SistDos, Bt_SistDos, Panel_Botones);
            BT_SistDosIraCal.Text = "Seleccionar y volver a calibración";
            Panel_SistDos.Visible = true;
        }

        private void BT_EqIraCal_Click(object sender, EventArgs e)
        {
            if (DGV_Equipo.SelectedRows.Count == 1)
            {
                Equipo seleccionado = Equipo.lista()[DGV_Equipo.SelectedRows[0].Index];
                string aux = seleccionado.Marca + " " + seleccionado.Modelo + " Nº Serie: " + seleccionado.NumSerie;
                CB_CaliEquipos.SelectedIndex = CB_CaliEquipos.FindStringExact(aux);
                actualizarComboBoxCaliFotones();
                panel = traerPanel(panel, 1, Panel_CalFot, Bt_CalFot, Panel_Botones);
                BT_EqIraCal.Text = "Seleccionar e ir a calibración";
            }

        }

        private void BT_SistDosIraCal_Click(object sender, EventArgs e)
        {
            if (DGV_SistDos.SelectedRows.Count == 1)
            {
                SistemaDosimetrico seleccionado = SistemaDosimetrico.lista()[DGV_SistDos.SelectedRows[0].Index];
                string aux = seleccionado.camara.EtiquetaCam + seleccionado.electrometro.EtiquetaElec;
                CB_CaliSistDosimetrico.SelectedIndex = CB_CaliSistDosimetrico.FindStringExact(aux);
                panel = traerPanel(panel, 1, Panel_CalFot, Bt_CalFot, Panel_Botones);
                BT_SistDosIraCal.Text = "Seleccionar e ir a calibración";
            }
        }
        #endregion


        #region Cali Fotones Inicializaciones

        private void InicializarComboBoxEquipos()
        {
            CB_CaliEquipos.Items.Clear();
            foreach (var equipo in Equipo.lista())
            {
                string aux = equipo.Marca + " " + equipo.Modelo + " Nº Serie: " + equipo.NumSerie;
                CB_CaliEquipos.Items.Add(aux);
                if (equipo.EsPredet == true)
                {
                    CB_CaliEquipos.SelectedIndex = CB_CaliEquipos.FindStringExact(aux);
                }
            }
        }

        private void InicializarComboBoxSistDosim()
        {
            CB_CaliSistDosimetrico.Items.Clear();
            foreach (var sistdos in SistemaDosimetrico.lista())
            {
                string aux = sistdos.camara.EtiquetaCam + sistdos.electrometro.EtiquetaElec;
                CB_CaliSistDosimetrico.Items.Add(aux);
                if (sistdos.EsPredet == true)
                {
                    CB_CaliSistDosimetrico.SelectedIndex = CB_CaliSistDosimetrico.FindStringExact(aux);
                }
            }
        }
        private void InicializarComboBoxEnergias()
        {
            CB_CaliEnergias.Items.Clear();
            if (CB_CaliEquipos.SelectedIndex != -1)
            {
                if (Equipo.lista()[CB_CaliEquipos.SelectedIndex].Fuente == 1) //Co
                {
                    CB_CaliEnergias.Items.Add("Co");
                    CB_CaliEnergias.SelectedIndex = 0;
                }
                else
                {
                    foreach (var energia in Equipo.lista()[CB_CaliEquipos.SelectedIndex].energiaFot)
                    {
                        CB_CaliEnergias.Items.Add(energia.Energia.ToString());
                        if (energia.EsPredet == true)
                        {
                            CB_CaliEnergias.SelectedIndex = CB_CaliEnergias.FindStringExact(energia.Energia.ToString());
                        }
                    }
                }
            }
        }

        private void InicializarRealizadoPor()
        {
            foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                string realizador = cali.RealizadoPor;
                if (realizador != "" && !CB_caliFotRealizadoPor.Items.Contains(realizador))
                {
                    CB_caliFotRealizadoPor.Items.Add(cali.RealizadoPor);
                }
            }
        }


        private void inicializarProfundidadReferencia()
        {
            if (CB_CaliEnergias.SelectedIndex != -1 && !Double.IsNaN(profundidadDeReferencia()))
            {
                TB_CaliPRof.Text = profundidadDeReferencia().ToString();
            }
            else
            {
                TB_CaliPRof.Text = "";
            }
        }


        private void InicializarPDDyTMRref()
        {
            if (!Double.IsNaN(PDDref()))
            {
                TB_CaliFPDDref.Text = PDDref().ToString();
                TB_CaliFPDDref.Enabled = false;
            }
            else
            {
                TB_CaliFPDDref.Text = "";
                TB_CaliFPDDref.Enabled = true;
            }

            if (!Double.IsNaN(TMRref()))
            {
                TB_CaliFTMRref.Text = TMRref().ToString();
                TB_CaliFTMRref.Enabled = false;
            }
            else
            {
                TB_CaliFTMRref.Text = "";
                TB_CaliFTMRref.Enabled = true;
            }
        }

        private void inicializarPredeterminados(double umPred, double ladoCampopred)
        {
            TB_UM.Text = umPred.ToString();
            TB_CaliLadoCampo.Text = ladoCampopred.ToString();
        }

        #endregion

        #region Cali Fotones Calculos
        //KTP
        private double calculoKTP()
        {
            double T0 = sistDosimSeleccionado().TempRef;
            double P0 = sistDosimSeleccionado().PresionRef;
            return CalibracionFot.CalcularKtp(T0, Convert.ToDouble(tbTemp.Text), P0, Convert.ToDouble(tbPresion.Text));
        }

        private void tbKTP_Leave(object sender, EventArgs e)
        {
            esNumeroTB(sender, e);
            actualizarCalculos();
        }



        //TPR 2010 y Kqq0
        private double calculoTPR2010()
        {
            int TPRoD = 0;
            if (RB_CaliFTPR2010.Checked)
            {
                TPRoD = 1;
            }
            else if (RB_CaliFD2010.Checked)
            {
                TPRoD = 2;
            }
            return CalibracionFot.CalcularTPR2010(promediarPanel(Panel_Lect20), promediarPanel(Panel_Lect10), TPRoD);
        }

        private double calculokQQ0()
        {
            return CalibracionFot.CalcularKqq0(calculoTPR2010(), sistDosimSeleccionado().camara, equipoSeleccionado(), CHB_UsarKqq0LB.Checked);
        }


        private void Prom_L20(object sender, EventArgs e)
        {
            escribirLabel(promediarPanel(Panel_Lect20), LB_Lect20prom);
            actualizarCalculos();
        }

        private void Prom_L10(object sender, EventArgs e)
        {
            escribirLabel(promediarPanel(Panel_Lect10), LB_Lect10prom);
            actualizarCalculos();
        }

        private void RB_CaliFTPR2010_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCalculos();
        }

        //Kpol

        private double calculoKpol()
        {
            if (!chEditarVKpol.Checked)
            {
                return CalibracionFot.CalcularKpol(sistDosimSeleccionado().SignoTension, promediarPanel(Panel_LecRef), promediarPanel(Panel_LectmenosV), CHB_NoUsaKpol.Checked, CHB_UsaKpolLB.Checked);
            }
            else
            {
                return CalibracionFot.CalcularKpol(sistDosimSeleccionado().SignoTension, promediarPanel(Panel_LectmasV), promediarPanel(Panel_LectmenosV), CHB_NoUsaKpol.Checked, CHB_UsaKpolLB.Checked);
            }

        }

        private void Prom_masV(object sender, EventArgs e)
        {
            if (!chEditarVKpol.Checked)
            {
                escribirLabel(promediarPanel(Panel_LecRef), LB_LectmasVprom);
            }
            else
            {
                escribirLabel(promediarPanel(Panel_LectmasV), LB_LectmasVprom);
            }
            actualizarCalculos();
        }

        private void Prom_menosV(object sender, EventArgs e)
        {
            escribirLabel(promediarPanel(Panel_LectmenosV), LB_LectmenosVprom);
            actualizarCalculos();
        }

        //Ks
        private double calculoKs()
        {
            if (CHB_NoUsaKs.Checked || CHB_UsaKsLB.Checked)
            {
                return CalibracionFot.CalcularKs(sistDosimSeleccionado().Tension, Double.NaN, promediarPanel(Panel_lectVtot), promediarPanel(Panel_LectVred), equipoSeleccionado().Fuente, equipoSeleccionado().TipoDeHaz, CHB_NoUsaKs.Checked, CHB_UsaKsLB.Checked);
            }
            else if (!chEditarVKs.Checked)
            {
                return CalibracionFot.CalcularKs(sistDosimSeleccionado().Tension, Convert.ToDouble(TB_Vred.Text), promediarPanel(Panel_LecRef), promediarPanel(Panel_LectVred), equipoSeleccionado().Fuente, equipoSeleccionado().TipoDeHaz, CHB_NoUsaKs.Checked, CHB_UsaKsLB.Checked);
            }
            else
            {
                return CalibracionFot.CalcularKs(sistDosimSeleccionado().Tension, Convert.ToDouble(TB_Vred.Text), promediarPanel(Panel_lectVtot), promediarPanel(Panel_LectVred), equipoSeleccionado().Fuente, equipoSeleccionado().TipoDeHaz, CHB_NoUsaKs.Checked, CHB_UsaKsLB.Checked);
            }

        }
        private void Prom_Vtot(object sender, EventArgs e)
        {
            if (!chEditarVKs.Checked)
            {
                escribirLabel(promediarPanel(Panel_LecRef), LB_lectVtotProm);
            }
            else
            {
                escribirLabel(promediarPanel(Panel_lectVtot), LB_lectVtotProm);
            }
            actualizarCalculos();
        }

        private void Prom_Vred(object sender, EventArgs e)
        {
            escribirLabel(promediarPanel(Panel_LectVred), LB_LectVredProm);
            actualizarCalculos();
        }

        private void TB_Vred_Leave(object sender, EventArgs e)
        {
            esNumeroTB(sender, e);
            actualizarCalculos();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }



        //Referencia

        private double CalculoMref()
        {
            return CalibracionFot.CalcularMref(promediarPanel(Panel_LecRef), calculoKTP(), calculoKs(), calculoKpol(), Convert.ToDouble(TB_UM.Text));
        }

        private double calculoDwRef()
        {
            return CalibracionFot.CalcularDwRef(CalculoMref(), sistDosimSeleccionado());
        }

        private double calculoDwZmax()
        {
            if (RB_CaliFDFSfija.Checked)
            {
                return CalibracionFot.calcularDwZmax(calculoDwRef(), Convert.ToDouble(TB_CaliFPDDref.Text));
            }
            else if (RB_CaliFIso.Checked)
            {
                return CalibracionFot.calcularDwZmax(calculoDwRef(), Convert.ToDouble(TB_CaliFTMRref.Text));
            }
            else
            {
                return double.NaN;
            }
        }

        private void Prom_Lref(object sender, EventArgs e)
        {
            escribirLabel(promediarPanel(Panel_LecRef), LB_LecRefProm);
            Prom_masV(sender, e);
            Prom_Vtot(sender, e);
            actualizarCalculos();
        }

        private void TB_UM_Leave(object sender, EventArgs e)
        {
            esNumeroTB(sender, e);
            actualizarCalculos();
        }

        private void LeaveCalcularDwzmax(object sender, EventArgs e)
        {
            actualizarCalculos();
        }

        private void actualizarCalculos()
        {
            if (CB_CaliEquipos.SelectedIndex > -1 && CB_CaliSistDosimetrico.SelectedIndex > -1 && CB_CaliEnergias.SelectedIndex > -1)
            {
                escribirLabel(tbTemp.Text != "" && tbPresion.Text != "", calculoKTP, L_CaliFKTP);
                escribirLabel((RB_CaliFTPR2010.Checked || RB_CaliFD2010.Checked) && LB_Lect10prom.Text != "Vacio" && LB_Lect20prom.Text != "Vacio", calculoTPR2010, L_CaliFTPR2010);
                escribirLabel((L_CaliFTPR2010.Text != "Vacio" && CB_CaliSistDosimetrico.SelectedIndex != -1) || equipoSeleccionado().Fuente == 1 || CHB_UsarKqq0LB.Checked == true, calculokQQ0, L_CaliFKqq0, GB_FactorDeCalidad);
                escribirLabel((LB_LectmasVprom.Text != "Vacio" && LB_LectmenosVprom.Text != "Vacio") || CHB_UsaKpolLB.Checked == true || CHB_NoUsaKpol.Checked == true, calculoKpol, L_Kpol);
                escribirLabel((LB_lectVtotProm.Text != "Vacio" && LB_LectVredProm.Text != "Vacio" && TB_Vred.Text != "") || CHB_UsaKsLB.Checked || CHB_NoUsaKs.Checked, calculoKs, L_Ks);
                escribirLabel(LB_LecRefProm.Text != "Vacio" && L_CaliFKTP.Text != "Vacio" && L_Ks.Text != "Vacio" && L_Kpol.Text != "Vacio" && TB_UM.Text != "", CalculoMref, L_CaliFMref);
                escribirLabel(L_CaliFMref.Text != "Vacio", calculoDwRef, L_CaliFDwZref);
                escribirLabel((RB_CaliFDFSfija.Checked || RB_CaliFIso.Checked) && TB_CaliFPDDref.Text != "" && L_CaliFDwZref.Text != "Vacio", calculoDwZmax, L_CaliFDwZmax);
                chequearKqq0();
                chequearKpol();
                chequearKs();
            }

        }

        private double kqq0LineaBase()
        {
            return 234324;
        }
        private double kpolLineaBase()
        {
            return 78237498;
        }
        public double ksLineaBase()
        {
            return 7432894;
        }
        #endregion

        #region Cali Fotones UI

        private void CB_CaliEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicializarComboBoxEnergias();
            if (equipoSeleccionado().Fuente == 2)
            {
                GB_FactorDeCalidad.Enabled = true;
            }
            actualizarCalculos();
        }

        private void CB_CaliEnergias_SelectedIndexChanged(object sender, EventArgs e)
        {
            inicializarProfundidadReferencia();
            InicializarPDDyTMRref();
            actualizarCalculos();
        }

        private void CB_CaliSistDosimetrico_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarCalculos();
        }

        private void actualizarCalculos(object sender, EventArgs e)
        {
            actualizarCalculos();
        }

        private void actualizarComboBoxCaliFotones()
        {
            InicializarComboBoxSistDosim();
            InicializarComboBoxEquipos();
            InicializarComboBoxEnergias();
            InicializarRealizadoPor();
            InicializarPDDyTMRref();
        }

        private void chequearKqq0()
        {
            if (equipoSeleccionado().Fuente == 1) //Co
            {
                GB_FactorDeCalidad.Enabled = false;
                limpiarRegistro(Panel_Lect20);
                limpiarRegistro(Panel_Lect10);
                limpiarRegistro(Panel_TPRoPDD);
                escribirLabel(promediarPanel(Panel_Lect20), LB_Lect20prom);
                escribirLabel(promediarPanel(Panel_Lect10), LB_Lect10prom);
                CHB_UsarKqq0LB.Checked = false;

            }
            else if (CHB_UsarKqq0LB.Checked)
            {
                Panel_LecKqq0.Enabled = false;
                Panel_TPRoPDD.Enabled = false;
                limpiarRegistro(Panel_Lect20);
                limpiarRegistro(Panel_Lect10);
                limpiarRegistro(Panel_TPRoPDD);
                escribirLabel(promediarPanel(Panel_Lect20), LB_Lect20prom);
                escribirLabel(promediarPanel(Panel_Lect10), LB_Lect10prom);
            }
            else
            {
                GB_FactorDeCalidad.Enabled = true;
                CHB_UsarKqq0LB.Enabled = true;
            }
        }

        private void chequearKpol()
        {
            if (CHB_NoUsaKpol.Checked)
            {
                Panel_LecKpol.Enabled = false;
                limpiarRegistro(Panel_LectmasV);
                limpiarRegistro(Panel_LectmenosV);
                escribirLabel(promediarPanel(Panel_LectmasV), LB_LectmasVprom);
                escribirLabel(promediarPanel(Panel_LectmenosV), LB_LectmenosVprom);
                CHB_UsaKpolLB.Enabled = false;
                CHB_UsaKpolLB.Checked = false;
            }
            else if (CHB_UsaKpolLB.Checked)
            {
                Panel_LecKpol.Enabled = false;
                limpiarRegistro(Panel_LectmasV);
                limpiarRegistro(Panel_LectmenosV);
                escribirLabel(promediarPanel(Panel_LectmasV), LB_LectmasVprom);
                escribirLabel(promediarPanel(Panel_LectmenosV), LB_LectmenosVprom);
                CHB_NoUsaKpol.Enabled = false;
                CHB_NoUsaKpol.Checked = false;
            }
            else
            {
                Panel_LecKpol.Enabled = true;
                CHB_NoUsaKpol.Enabled = true;
                CHB_UsaKpolLB.Enabled = true;
            }
            if (!chEditarVKpol.Checked)
            {
                limpiarRegistro(Panel_LectmasV);
                Panel_LectmasV.Enabled = false;
                escribirLabel(promediarPanel(Panel_LecRef), LB_LectmasVprom);
            }
            else
            {
                if (L_Kpol.Text == "NaN")
                {
                    L_Kpol.Visible = false;
                    L_Kpol.Text = "Vacio";
                }
                escribirLabel(promediarPanel(Panel_LectmasV), LB_LectmasVprom);
                escribirLabel(promediarPanel(Panel_LectmenosV), LB_LectmenosVprom);
                Panel_LectmasV.Enabled = true;
            }

        }

        private void chequearKs()
        {
            if (CHB_NoUsaKs.Checked)
            {
                Panel_LecKs.Enabled = false;
                Panel_Vred.Enabled = false;
                TB_Vred.Clear();
                limpiarRegistro(Panel_lectVtot);
                limpiarRegistro(Panel_LectVred);
                escribirLabel(promediarPanel(Panel_lectVtot), LB_lectVtotProm);
                escribirLabel(promediarPanel(Panel_LectVred), LB_LectVredProm);
                CHB_UsaKsLB.Enabled = false;
                CHB_UsaKsLB.Checked = false;
            }
            else if (CHB_UsaKsLB.Checked)
            {
                Panel_LecKs.Enabled = false;
                Panel_Vred.Enabled = false;
                TB_Vred.Clear();
                limpiarRegistro(Panel_lectVtot);
                limpiarRegistro(Panel_LectVred);
                escribirLabel(promediarPanel(Panel_lectVtot), LB_lectVtotProm);
                escribirLabel(promediarPanel(Panel_LectVred), LB_LectVredProm);
                CHB_NoUsaKs.Enabled = false;
                CHB_NoUsaKs.Checked = false;
            }
            else
            {
                Panel_LecKs.Enabled = true;
                Panel_Vred.Enabled = true;
                CHB_NoUsaKs.Enabled = true;
                CHB_UsaKsLB.Enabled = true;
            }
            if (!chEditarVKs.Checked)
            {
                limpiarRegistro(Panel_lectVtot);
                Panel_lectVtot.Enabled = false;
                escribirLabel(promediarPanel(Panel_LecRef), LB_lectVtotProm);
            }
            else
            {
                if (L_Ks.Text == "NaN")
                {
                    L_Ks.Visible = false;
                    L_Ks.Text = "Vacio";
                }
                escribirLabel(promediarPanel(Panel_lectVtot), LB_lectVtotProm);
                escribirLabel(promediarPanel(Panel_LectVred), LB_LectVredProm);
                Panel_lectVtot.Enabled = true;
            }

        }

        #endregion

        #region Cali Fotones Botones

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            double DFSoISO = 0;
            if (RB_CaliFDFSfija.Checked)
            {
                DFSoISO = 1;
            }
            else if (RB_CaliFIso.Checked)
            {
                DFSoISO = 2;
            }
            if (CalibracionFot.guardar(CalibracionFot.crear(equipoSeleccionado(), energiaSeleccionada(), sistDosimSeleccionado(), DFSoISO, Calcular.validarYConvertirADouble(TB_CaliLadoCampo.Text),
                Calcular.validarYConvertirADouble(TB_CaliPRof.Text), DTP_FechaCaliFot.Value, CB_caliFotRealizadoPor.Text, calculoKTP(), calculoTPR2010(), calculokQQ0(), calculoKpol(),
                Calcular.validarYConvertirADouble(TB_Vred.Text), calculoKs(), CalculoMref(), calculoDwRef(), calculoDwZmax()), CHB_caliFotEstablecerComoRef.Checked))
            {
                MessageBox.Show("Calibración guardada");
                if (MessageBox.Show("¿Desea limpiar el registro?", "Limpiar Registro", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    limpiarRegistro2Niveles(Panel_CalFot);
                    actualizarComboBoxCaliFotones();
                    inicializarPredeterminados(100, 10);
                    chEditarVKpol.Checked = false;
                    chEditarVKs.Checked = false;
                    actualizarCalculos();
                    CB_caliFotRealizadoPor.Text = "";
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            limpiarRegistro2Niveles(Panel_CalFot);
            actualizarComboBoxCaliFotones();
            inicializarPredeterminados(100, 10);
            chEditarVKpol.Checked = false;
            chEditarVKs.Checked = false;
            actualizarCalculos();
            CB_caliFotRealizadoPor.Text = "";
        }

        private void BT_ExportarCaliFot_Click(object sender, EventArgs e)
        {
            double DFSoISO = 0;
            if (RB_CaliFDFSfija.Checked)
            {
                DFSoISO = 1;
            }
            else if (RB_CaliFIso.Checked)
            {
                DFSoISO = 2;
            }
            CalibracionFot.exportarUnaCalibracion(CalibracionFot.crear(equipoSeleccionado(), energiaSeleccionada(), sistDosimSeleccionado(), DFSoISO, Calcular.validarYConvertirADouble(TB_CaliLadoCampo.Text),
                Calcular.validarYConvertirADouble(TB_CaliPRof.Text), DTP_FechaCaliFot.Value, CB_caliFotRealizadoPor.Text, calculoKTP(), calculoTPR2010(), calculokQQ0(), calculoKpol(),
                Calcular.validarYConvertirADouble(TB_Vred.Text), calculoKs(), CalculoMref(), calculoDwRef(), calculoDwZmax()));
        }

        #endregion



        #region Equipos UI

        private void InicializarInstitucionYMarcaEquipo()
        {
            foreach (Equipo equipo in Equipo.lista())
            {
                if (equipo.Institucion != "" && !cb_InstitucionEq.Items.Contains(equipo.Institucion))
                {
                    cb_InstitucionEq.Items.Add(equipo.Institucion);
                }
                if (equipo.Marca != "" && !cb_MarcaEq.Items.Contains(equipo.Marca))
                {
                    cb_MarcaEq.Items.Add(equipo.Marca);
                }
            }
        }

        private void CHB_EnFotEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_EnFotEquipo.Checked == true)
            {
                Panel_EnFotEquipo.Enabled = true;
            }
            else { Panel_EnFotEquipo.Enabled = false; }
        }

        private void CHB_EnElecEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_EnElecEquipo.Checked == true)
            {
                Panel_EnElecEquipo.Enabled = true;
            }
            else { Panel_EnElecEquipo.Enabled = false; }
        }

        private void RB_FuenteCo_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_FuenteCo.Checked == true)
            {
                Panel_TipoHazEq.Enabled = false;
                LB_TipoHaz.Enabled = false;
                GB_EquiposEnergias.Enabled = true;
                Panel_EnCoEquipo.Enabled = true;
                CHB_EnElecEquipo.Enabled = false;
                CHB_EnFotEquipo.Enabled = false;
                TB_EnCoZref.Text = 5.ToString();
                RB_Pulsado.Checked = false;
                RB_PulsadoYBarrido.Checked = false;
            }
            else
            {
                Panel_EnCoEquipo.Enabled = false;
                TB_EnCoZref.Text = "";
            }
        }

        private void RB_FuenteALE_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_FuenteALE.Checked == true)
            {
                Panel_EnCoEquipo.Enabled = false;
                Panel_TipoHazEq.Enabled = true;
                LB_TipoHaz.Enabled = true;
                GB_EquiposEnergias.Enabled = true;
                CHB_EnElecEquipo.Enabled = true;
                CHB_EnFotEquipo.Enabled = true;
            }
            else
            {
                CHB_EnElecEquipo.Enabled = false;
                CHB_EnFotEquipo.Enabled = false;
            }

        }

        #endregion

        #region Equipos EquipoBotones

        private void BT_GuardarEq_Click(object sender, EventArgs e)
        {
            if (editaEquipo)
            {
                indiceEquipo = DGV_Equipo.SelectedRows[0].Index;
            }
            int auxHaz = 0;
            if (RB_FuenteCo.Checked == true)
            {
                Equipo.guardar(Equipo.crearCo(cb_MarcaEq.Text, TB_ModeloEq.Text, TB_NumSerieEq.Text, TB_AliasEq.Text, 1, 0, Calcular.doubleNaN(TB_EnCoZref), Calcular.doubleNaN(TB_EnCoPDD), Calcular.doubleNaN(TB_EnCoTMR), cb_InstitucionEq.Text), editaEquipo, DGV_Equipo);
            }
            else if (RB_FuenteALE.Checked == true)
            {

                if (RB_Pulsado.Checked == true)
                {
                    auxHaz = 1;
                }
                else if (RB_PulsadoYBarrido.Checked == true)
                {
                    auxHaz = 2;
                }
                Equipo.guardar(Equipo.crearAle(cb_MarcaEq.Text, TB_ModeloEq.Text, TB_NumSerieEq.Text, TB_AliasEq.Text, 2, auxHaz, DGV_EnFot, DGV_EnElec, cb_InstitucionEq.Text), editaEquipo, DGV_Equipo);
            }

            DGV_Equipo.DataSource = Equipo.lista();
            limpiarRegistro(GB_Equipos);
            limpiarRegistro(Panel_FuenteEq);
            limpiarRegistro(Panel_TipoHazEq);
            limpiarRegistro(Panel_EnCoEquipo);
            limpiarRegistro(Panel_EnElecEquipo);
            limpiarRegistro(Panel_EnFotEquipo);
            DGV_EnFot.Rows.Clear();
            DGV_EnFot.Visible = false;
            DGV_EnElec.Rows.Clear();
            DGV_EnElec.Visible = false;
            CHB_EnFotEquipo.Checked = false;
            CHB_EnElecEquipo.Checked = false;
            TB_EnElecR50ion_Leave(sender, e);

            if (editaEquipo)
            {
                foreach (DataGridViewRow row in DGV_Equipo.Rows)
                {
                    row.Selected = false;
                }
                DGV_Equipo.Rows[indiceEquipo].Selected = true;
            }
            editaEquipo = false;
            Panel_TipoHazEq.Enabled = false;
            actualizarComboBoxCaliFotones();
            DGV_Equipo.Enabled = true;
            InicializarInstitucionYMarcaEquipo();
        }

        private void BT_PredetEqu_Click(object sender, EventArgs e)
        {
            Equipo.hacerPredeterminado(DGV_Equipo);
            actualizarComboBoxCaliFotones();
        }

        private void BT_EliminarEq_Click(object sender, EventArgs e)
        {
            Equipo.eliminar(DGV_Equipo);
            actualizarComboBoxCaliFotones();
        }

        private void BT_EditarEq_Click(object sender, EventArgs e)
        {
            DGV_Equipo.Enabled = false;
            if (Equipo.lista()[DGV_Equipo.SelectedRows[0].Index].Fuente == 1)
            {
                Panel_EnCoEquipo.Enabled = true;
                Equipo.editarCo(cb_MarcaEq, TB_ModeloEq, TB_NumSerieEq, TB_AliasEq, cb_InstitucionEq, Panel_FuenteEq, Panel_TipoHazEq, TB_EnCoZref, TB_EnCoPDD, TB_EnCoTMR, DGV_Equipo);
            }
            else
            {
                CHB_EnFotEquipo.Checked = true;
                CHB_EnElecEquipo.Checked = true;
                DGV_EnFot.Visible = true;
                DGV_EnElec.Visible = true;

                Equipo.editarAle(cb_MarcaEq, TB_ModeloEq, TB_NumSerieEq, TB_AliasEq, cb_InstitucionEq, Panel_FuenteEq, Panel_TipoHazEq, DGV_EnFot, DGV_EnElec, DGV_Equipo);
            }
            editaEquipo = true;
            actualizarComboBoxCaliFotones();
        }

        private void BT_ExportarEq_Click(object sender, EventArgs e)
        {
            Equipo.exportar(DGV_Equipo);
        }

        private void BT_EquiposCancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(GB_Equipos);
            limpiarRegistro(Panel_FuenteEq);
            limpiarRegistro(Panel_TipoHazEq);
            limpiarRegistro(Panel_EnCoEquipo);
            limpiarRegistro(Panel_EnElecEquipo);
            limpiarRegistro(Panel_EnFotEquipo);
            DGV_EnFot.Rows.Clear();
            DGV_EnFot.Visible = false;
            DGV_EnElec.Rows.Clear();
            DGV_EnElec.Visible = false;
            CHB_EnFotEquipo.Checked = false;
            CHB_EnElecEquipo.Checked = false;
            editaEquipo = false;
            DGV_Equipo.Enabled = true;
            TB_EnElecR50ion_Leave(sender, e);
        }

        #endregion

        #region Equipos EnergiaFotonesBotones

        private void BT_EnFotGuardar_Click(object sender, EventArgs e)
        {
            DGV_EnFot.Visible = true;
            EnergiaFotones.guardar(EnergiaFotones.crear(Convert.ToDouble(TB_EnFotEn.Text), Calcular.doubleNaN(TB_EnFotZref), Calcular.doubleNaN(TB_EnFotPDD), Calcular.doubleNaN(TB_EnFotTMR)), editaEnergiaFot, DGV_EnFot);
            limpiarRegistro(Panel_EnFotEquipo);
            TB_EnFotEn.Focus(); // para que vuelva a energía para cargar uno nuevo
            if (RB_FuenteCo.Checked == true && DGV_EnFot.ColumnCount > 0)
            {
                GB_EquiposEnergias.Enabled = false;
            }
            DGV_EnFot.Enabled = true;
        }

        private void BT_EnFotEliminar_Click(object sender, EventArgs e)
        {
            EnergiaFotones.eliminar(DGV_EnFot);
            limpiarRegistro(Panel_EnFotEquipo);
        }

        private void BT_EnFotEditar_Click(object sender, EventArgs e)
        {
            DGV_EnFot.Enabled = false;
            EnergiaFotones.editar(TB_EnFotEn, TB_EnFotZref, TB_EnFotPDD, TB_EnFotTMR, DGV_EnFot);
            editaEnergiaFot = true;
        }

        private void BT_EnFotPredet_Click(object sender, EventArgs e)
        {
            EnergiaFotones.hacerPredeterminado(DGV_EnFot);
        }

        private void TB_EnFotEnLeave(object sender, EventArgs e)
        {

        }

        private void BT_EqEnergiaFot_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(Panel_EnFotEquipo);
            DGV_EnFot.Enabled = true;
            editaEnergiaFot = false;
        }


        #endregion

        #region Equipos EnergiaElectronesBotones

        private void BT_EnElecGuardar_Click(object sender, EventArgs e)
        {
            DGV_EnElec.Visible = true;
            EnergiaElectrones.guardar(EnergiaElectrones.crear(Convert.ToDouble(TB_EnElecEn.Text), Calcular.doubleNaN(TB_EnElecR50ion), Calcular.doubleNaN(L_EnElecR50dosis), Calcular.doubleNaN(L_EnElecZref), Calcular.doubleNaN(TB_EnElecPDDZref)), editaEnergiaElect, DGV_EnElec);
            limpiarRegistro(Panel_EnElecEquipo);
            L_EnElecR50dosis.Text = null;
            L_EnElecZref.Text = null;
            TB_EnElecEn.Focus(); // para que vuelva a energía para cargar uno nuevo
            BT_EnElecGuardar.Enabled = false;
            DGV_EnElec.Enabled = true;
        }

        private void BT_EnElecEliminar_Click(object sender, EventArgs e)
        {
            EnergiaElectrones.eliminar(DGV_EnElec);
            limpiarRegistro(Panel_EnElecEquipo);
        }

        private void BT_EnElecEditar_Click(object sender, EventArgs e)
        {
            DGV_EnElec.Enabled = false;
            EnergiaElectrones.editar(TB_EnElecEn, TB_EnElecR50ion, L_EnElecR50dosis, L_EnElecZref, TB_EnElecPDDZref, DGV_EnElec);
            editaEnergiaElect = true;
        }

        private void BT_EnElecPredet_Click(object sender, EventArgs e)
        {
            EnergiaElectrones.hacerPredeterminado(DGV_EnElec);
        }


        private void TB_EnElecEn_Leave(object sender, EventArgs e)
        {

        }

        private void TB_EnElecR50ion_Leave(object sender, EventArgs e)
        {
            if (TB_EnElecR50ion.Text != "")
            {
                L_EnElecR50dosis.Text = EnergiaElectrones.calcularR50D(Convert.ToDouble(TB_EnElecR50ion.Text));
                L_EnElecR50dosis.Visible = true;
                L_EnElecZref.Text = EnergiaElectrones.calcularZref(Convert.ToDouble(TB_EnElecR50ion.Text));
                L_EnElecZref.Visible = true;
            }
            else
            {
                L_EnElecR50dosis.Text = "Vacio";
                L_EnElecR50dosis.Visible = false;
                L_EnElecZref.Text = "Vacio";
                L_EnElecZref.Visible = false;
            }
        }

        private void BT_EqEnergiaElec_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(Panel_EnElecEquipo);
            TB_EnElecR50ion_Leave(sender, e);
            DGV_EnElec.Enabled = true;
            editaEnergiaElect = false;
        }

        #endregion


        #region SistDosimetricos UI
        private void CB_MarcaCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_MarcaCam.SelectedIndex != -1)
            {
                CB_ModCam.DataSource = Camara398new.lista().Where(elemento => elemento.marca == CB_MarcaCam.Text).ToList();
                CB_ModCam.DisplayMember = "modelo";
            }
            else
            {
                CB_ModCam.SelectedIndex = -1;
            }
        }
        #endregion

        #region SistDosimetricos CamaraBotones
        private void BT_GuardarCam_Click(object sender, EventArgs e)
        {
            Camara.guardar(Camara.crear(CB_MarcaCam.Text, CB_ModCam.Text, TB_SNCam.Text), editaCam, DGV_Cam);
            limpiarRegistro(GB_Camaras);
            DGV_Cam.Enabled = true;
        }

        private void BT_EliminarCam_Click(object sender, EventArgs e)
        {
            Camara.eliminar(DGV_Cam);
        }

        private void BT_EditarCam_Click(object sender, EventArgs e)
        {
            DGV_Cam.Enabled = false;
            Camara.editar(CB_MarcaCam, CB_ModCam, TB_SNCam, DGV_Cam);
            editaCam = true;
        }

        private void BT_Camara_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(GB_Camaras);
            DGV_Cam.Enabled = true;
            editaCam = false;
        }

        #endregion

        #region SistDosimetrico ElectrometroBotones
        private void BT_GuardarElec_Click(object sender, EventArgs e)
        {
            Electrometro.guardar(Electrometro.crear(TB_MarcaElec.Text, TB_ModeloElec.Text, TB_SNElec.Text), editaElec, DGV_Elec);
            limpiarRegistro(GB_Electrómetros);
            DGV_Elec.Enabled = true;
        }

        private void BT_EliminarElec_Click(object sender, EventArgs e)
        {
            Electrometro.eliminar(DGV_Elec);
        }

        private void BT_EditarElec_Click(object sender, EventArgs e)
        {
            DGV_Elec.Enabled = false;
            Electrometro.editar(TB_MarcaElec, TB_ModeloElec, TB_SNElec, DGV_Elec);
            editaElec = true;
        }

        private void BT_Electrometro_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(GB_Electrómetros);
            DGV_Elec.Enabled = true;
            editaElec = false;
        }
        #endregion

        #region SistDosimetricos SistDosimetricoBotones

        private void BT_NuevSistDos_Click(object sender, EventArgs e)
        {
            NuevoSistDos nsd = new NuevoSistDos(false, 0);
            nsd.ShowDialog();
            DGV_SistDos.DataSource = SistemaDosimetrico.lista();
            actualizarComboBoxCaliFotones();
        }

        private void BT_EliminarSistDos_Click(object sender, EventArgs e)
        {
            SistemaDosimetrico.eliminar(DGV_SistDos);
            actualizarComboBoxCaliFotones();
        }

        private void BT_EditarSistDos_Click(object sender, EventArgs e)
        {
            NuevoSistDos nsd = new NuevoSistDos(true, DGV_SistDos.SelectedRows[0].Index);
            nsd.ShowDialog();
            DGV_SistDos.DataSource = SistemaDosimetrico.lista();
            DGV_SistDos.ClearSelection();
            actualizarComboBoxCaliFotones();
        }

        private void BT_PredSistDos_Click(object sender, EventArgs e)
        {
            SistemaDosimetrico.hacerPredeterminado(DGV_SistDos);
            actualizarComboBoxCaliFotones();
        }

        private void BT_ExportarSistDos_Click(object sender, EventArgs e)
        {
            SistemaDosimetrico.exportar(DGV_SistDos);
        }

        #endregion


        #region Métodos
        public static void limpiarRegistro(Panel panel)
        {
            foreach (TextBox tb in panel.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (ComboBox cb in panel.Controls.OfType<ComboBox>())
            { cb.SelectedIndex = -1; } // ojo que -1 puede hacer que levante error el evento "on index change" porque se va de rango
            foreach (RadioButton rb in panel.Controls.OfType<RadioButton>())
            { rb.Checked = false; }
        }

        public static void limpiarRegistro(GroupBox gb)
        {
            foreach (TextBox tb in gb.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (ComboBox cb in gb.Controls.OfType<ComboBox>())
            { cb.SelectedIndex = -1; }
            foreach (RadioButton rb in gb.Controls.OfType<RadioButton>())
            { rb.Checked = false; }

        }

        public static void limpiarRegistro2Niveles(Panel panel)
        {
            foreach (TextBox tb in panel.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (RadioButton rb in panel.Controls.OfType<RadioButton>())
            { rb.Checked = false; }
            foreach (CheckBox chb in panel.Controls.OfType<CheckBox>())
            {
                chb.Checked = false;
            }
            foreach (Panel pl in panel.Controls.OfType<Panel>())
            {
                limpiarRegistro2Niveles(pl);
            }
            foreach (GroupBox gb in panel.Controls.OfType<GroupBox>())
            {
                limpiarRegistro2Niveles(gb);
            }
        }

        public static void limpiarRegistro2Niveles(GroupBox grb)
        {
            foreach (TextBox tb in grb.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (RadioButton rb in grb.Controls.OfType<RadioButton>())
            { rb.Checked = false; }
            foreach (CheckBox chb in grb.Controls.OfType<CheckBox>())
            {
                chb.Checked = false;
            }
            foreach (Panel pl in grb.Controls.OfType<Panel>())
            {
                limpiarRegistro2Niveles(pl);
            }
            foreach (GroupBox gb in grb.Controls.OfType<GroupBox>())
            {
                limpiarRegistro2Niveles(gb);
            }
        }

        public static int traerPanel(int indicepanel, int nropanel, Panel nombrepanel, Button boton, Panel panelbotones)
        {
            if (indicepanel != nropanel)
            {
                nombrepanel.Visible = true; nombrepanel.BringToFront(); indicepanel = nropanel;
                colorBoton(boton, panelbotones);
            };
            return indicepanel;
        }
        public static void colorBoton(Button boton, Panel panelbotones)
        {
            {
                foreach (Button bt in panelbotones.Controls)
                {
                    bt.BackColor = SystemColors.Control;
                }
                if (boton.Name != "Bt_Inicio") { boton.BackColor = SystemColors.ActiveBorder; }
            }
        }

        public static bool estaLleno(TextBox tb)
        {
            return tb.Text != "";
        }

        public static double convertirTBaDouble(TextBox tb)
        {
            double salida = Double.NaN;
            if (estaLleno(tb))
            {
                salida = Calcular.validarYConvertirADouble(tb.Text);
                if (Double.IsNaN(salida))
                {
                    MessageBox.Show("Debe ingresar un número");
                    tb.Focus(); tb.SelectAll();
                }
            }
            return salida;
        }
        public static double promediarPanel(Panel panel)
        {
            double promedio = Double.NaN; List<double> valores = new List<double>();
            foreach (TextBox tb in panel.Controls.OfType<TextBox>())
            {
                double aux = Double.NaN;
                aux = convertirTBaDouble(tb);
                if (!Double.IsNaN(aux))
                { valores.Add(aux); }
            }
            promedio = Calcular.promediar(valores);
            return promedio;

        }
        public static void escribirLabel(double valor, Label label)
        {
            if (!Double.IsNaN(valor))
            {
                label.Text = valor.ToString();
                label.Visible = true;
            }
            else
            {
                label.Text = "Vacio";
                label.Visible = false;
            }
        }

        public static void escribirLabel(bool test, Func<double> metodo, Label label)
        {
            if (test)
            {
                label.Text = metodo().ToString();
                label.Visible = true;
            }
            else
            {
                label.Text = "Vacio";
                label.Visible = false;
            }
        }

        public static void escribirLabel(bool test, Func<double> metodo, Label label, GroupBox gb)
        {
            if (test)
            {
                label.Text = metodo().ToString();
                label.Visible = true;
            }
            else
            {
                label.Text = "Vacio";
                label.Visible = false;
                foreach (Panel panel in gb.Controls.OfType<Panel>())
                {
                    panel.Enabled = true;
                }
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

        private SistemaDosimetrico sistDosimSeleccionado()
        {
            return SistemaDosimetrico.lista()[CB_CaliSistDosimetrico.SelectedIndex];
        }

        private Equipo equipoSeleccionado()
        {
            return Equipo.lista()[CB_CaliEquipos.SelectedIndex];
        }

        private EnergiaFotones energiaSeleccionada()
        {
            return equipoSeleccionado().energiaFot[CB_CaliEnergias.SelectedIndex];
        }

        private double profundidadDeReferencia()
        {
            return energiaSeleccionada().ZRefFot;
        }

        private double PDDref()
        {
            return energiaSeleccionada().PddZrefFot;
        }

        private double TMRref()
        {
            return energiaSeleccionada().TmrZrefFot;
        }






        #endregion

        #region Imprimir

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int posicionlinea = 30;
            Imprimir.imprimirTituloCaliFotones(e, posicionlinea,printDocument1);
            posicionlinea += Imprimir.altoTitulo;
            Imprimir.imprimirUsuarioYFecha(e, posicionlinea, "Pablo", DTP_FechaCaliFot.Value,printDocument1);
        }

        #endregion

        private void Bt_ReporteVP_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)

            { printDocument1.Print(); }
        }

        private void BT_ReporteImp_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            if (printDialog1.ShowDialog() == DialogResult.OK)

            { printDocument1.Print(); }
        }
    }
}




