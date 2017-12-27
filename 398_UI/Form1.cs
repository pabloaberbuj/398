using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        bool calculaKtpFot = false;
        bool calculaTPR2010Fot = false;
        bool calculaKqq0Fot = false;
        bool calculaKsFot = false;
        bool calculaKpolFot = false;
        bool calculaMrefFot = false;
        bool calculaDwzrefFot = false;
        bool calculaDwzmaxFot = false;
        bool calculaDifLBFot = false;




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
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
            chb_EditarVKpol.Checked = false;
            chb_EditarVKs.Checked = false;
            InicializarInstitucionYMarcaEquipo();
            inicializacionesRegistro();


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
                string aux = seleccionado.camara.Etiqueta + seleccionado.electrometro.Etiqueta;
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
            if (Equipo.lista().Count > 0)
            {
                foreach (var equipo in Equipo.lista())
                {
                    CB_CaliEquipos.Items.Add(equipo);
                    CB_CaliEquipos.DisplayMember = "Etiqueta";
                    //string aux = equipo.Marca + " " + equipo.Modelo + " Nº Serie: " + equipo.NumSerie;
                    //CB_CaliEquipos.Items.Add(aux);
                    if (equipo.EsPredet == true)
                    {
                        CB_CaliEquipos.SelectedItem = equipo;
                    }
                }
            }
        }

        private void InicializarComboBoxSistDosim()
        {
            CB_CaliSistDosimetrico.Items.Clear();
            if (SistemaDosimetrico.lista().Count > 0)
            {
                foreach (var sistdos in SistemaDosimetrico.lista())
                {
                    //string aux = sistdos.camara.Etiqueta + sistdos.electrometro.Etiqueta;
                    //CB_CaliSistDosimetrico.Items.Add(aux);
                    CB_CaliSistDosimetrico.Items.Add(sistdos);
                    CB_CaliSistDosimetrico.DisplayMember = "Etiqueta";
                    if (sistdos.EsPredet == true)
                    {
                        CB_CaliSistDosimetrico.SelectedItem = sistdos;
                    }
                }
            }
        }
        private void InicializarComboBoxEnergias()
        {
            CB_CaliEnergias.Items.Clear();

            if (CB_CaliEquipos.SelectedIndex != -1)
            {
                if (equipoSeleccionado().Fuente == 1) //Co
                {
                    CB_CaliEnergias.Items.Add(equipoSeleccionado().energiaFot[0]);
                    CB_CaliEnergias.SelectedIndex = 0;
                    CB_CaliEnergias.Enabled = false;
                }
                else if (equipoSeleccionado().Fuente == 2)
                {
                    foreach (var energia in equipoSeleccionado().energiaFot)
                    {
                        CB_CaliEnergias.Items.Add(energia);
                        CB_CaliEnergias.DisplayMember = "Etiqueta";
                        if (energia.EsPredet == true)
                        {
                            CB_CaliEnergias.SelectedItem = energia;
                        }
                    }
                    CB_CaliEnergias.Enabled = true;
                }
                CB_CaliEnergias.DisplayMember = "Etiqueta";
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
                TB_CaliPRof.Enabled = false;
            }
            else
            {
                TB_CaliPRof.Text = "";
                TB_CaliPRof.Enabled = true;
            }
        }

        private void inicializarLadoCampoReferencia()
        {
            if (CB_CaliEnergias.SelectedIndex != -1 && !Double.IsNaN(ladoCampoReferencia()))
            {
                TB_CaliLadoCampo.Text = ladoCampoReferencia().ToString();
                TB_CaliLadoCampo.Enabled = false;
            }
            else
            {
                TB_CaliLadoCampo.Text = "";
                TB_CaliPRof.Enabled = true;
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
            TB_UM.Text = Configuracion.umPredet.ToString();
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
            return CalibracionFot.calcularTPR2010(lec20(), lec10(), TPRoD2010(), CHB_UsarKqq0LB.Checked, equipoSeleccionado(), energiaSeleccionada(), DFSoISO());
        }

        private double calculokQQ0()
        {

            return CalibracionFot.calcularKqq0(calculoTPR2010(), sistDosimSeleccionado().camara, equipoSeleccionado(), CHB_UsarKqq0LB.Checked, energiaSeleccionada(), DFSoISO());
        }

        private double lec20()
        {
            if (CHB_UsarKqq0LB.Checked)
            {
                return Double.NaN;
            }
            else
            {
                return promediarPanel(Panel_Lect20);
            }
        }
        private void Prom_L20(object sender, EventArgs e)
        {
            escribirLabel(lec20(), LB_Lect20prom);
            actualizarCalculos();
        }

        private double lec10()
        {
            if (CHB_UsarKqq0LB.Checked)
            {
                return Double.NaN;
            }
            else
            {
                return promediarPanel(Panel_Lect10);
            }
        }
        private void Prom_L10(object sender, EventArgs e)
        {
            escribirLabel(lec10(), LB_Lect10prom);
            actualizarCalculos();
        }

        private void RB_CaliFTPR2010_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCalculos();
        }

        //Kpol

        private double calculoKpol()
        {
            return CalibracionFot.calcularKpol(sistDosimSeleccionado().SignoTension, lecVmas(),lecVmenos(), CHB_NoUsaKpol.Checked, CHB_UsaKpolLB.Checked, equipoSeleccionado(), energiaSeleccionada(), DFSoISO());
        }

        private double lecVmas()
        {
            if (CHB_NoUsaKpol.Checked || CHB_UsaKpolLB.Checked)
            {
                return Double.NaN;
            }
            if (sistDosimSeleccionado().SignoTension == 1 && !chb_EditarVKpol.Checked)
            {
                return promediarPanel(Panel_LecRef);
            }
            else
            {
                return promediarPanel(Panel_LectmasV);
            }
        }


        private void Prom_masV(object sender, EventArgs e)
        {
            escribirLabel(lecVmas(), LB_LectmasVprom);
            actualizarCalculos();
        }

        private double lecVmenos()
        {
            if (CHB_NoUsaKpol.Checked || CHB_UsaKpolLB.Checked)
            {
                return Double.NaN;
            }
            if (sistDosimSeleccionado().SignoTension == -1 && !chb_EditarVKpol.Checked)
            {
                return promediarPanel(Panel_LecRef);
            }
            else
            {
                return promediarPanel(Panel_LectmenosV);
            }
        }

        private void Prom_menosV(object sender, EventArgs e)
        {
            escribirLabel(lecVmenos(), LB_LectmenosVprom);
            actualizarCalculos();
        }

        //Ks
        private double calculoKs()
        {
            double Vred = Double.NaN;
            if (!CHB_NoUsaKs.Checked && !CHB_UsaKsLB.Checked)
            {
                Vred = Convert.ToDouble(TB_Vred.Text);
            }
            return CalibracionFot.calcularKs(sistDosimSeleccionado().Tension, lecVTotal(), lecVred(), CHB_NoUsaKs.Checked, CHB_UsaKsLB.Checked, equipoSeleccionado(), energiaSeleccionada(), DFSoISO(), Vred);
        }


        private double lecVTotal()
        {
            if (CHB_NoUsaKs.Checked || CHB_UsaKsLB.Checked)
            {
                return Double.NaN;
            }
            if (chb_EditarVKs.Checked)
            {
                return promediarPanel(Panel_lectVtot);
            }
            else
            {
                return promediarPanel(Panel_LecRef);
            }
        }

        private void Prom_Vtot(object sender, EventArgs e)
        {
            escribirLabel(lecVTotal(), LB_lectVtotProm);
            actualizarCalculos();
        }

        private double lecVred()
        {
            if (CHB_NoUsaKs.Checked || CHB_UsaKsLB.Checked)
            {
                return Double.NaN;
            }
            return promediarPanel(Panel_LectVred);
        }
        private void Prom_Vred(object sender, EventArgs e)
        {
            escribirLabel(lecVred(), LB_LectVredProm);
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
            return CalibracionFot.CalcularMref(lecRef(), calculoKTP(), calculoKs(), calculoKpol(), Convert.ToDouble(TB_UM.Text));
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

        private double calculoDifConRef()
        {
            return CalibracionFot.calcularDifConRef(calculoDwRef(), equipoSeleccionado(), energiaSeleccionada(), DFSoISO());
        }

        private double lecRef()
        {
            return promediarPanel(Panel_LecRef);
        }
        private void Prom_Lref(object sender, EventArgs e)
        {
            escribirLabel(lecRef(), LB_LecRefProm);
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
                calculaKtpFot = escribirLabel(tbTemp.Text != "" && tbPresion.Text != "", calculoKTP, L_CaliFKTP);
                calculaTPR2010Fot = escribirLabel((RB_CaliFTPR2010.Checked || RB_CaliFD2010.Checked) && LB_Lect10prom.Text != "Vacio" && LB_Lect20prom.Text != "Vacio" || CHB_UsarKqq0LB.Checked == true, calculoTPR2010, L_CaliFTPR2010);
                calculaKqq0Fot = escribirLabel((L_CaliFTPR2010.Text != "Vacio" && CB_CaliSistDosimetrico.SelectedIndex != -1) || equipoSeleccionado().Fuente == 1 || CHB_UsarKqq0LB.Checked == true, calculokQQ0, L_CaliFKqq0, GB_FactorDeCalidad);
                calculaKpolFot = escribirLabel((LB_LectmasVprom.Text != "Vacio" && LB_LectmenosVprom.Text != "Vacio") || CHB_UsaKpolLB.Checked == true || CHB_NoUsaKpol.Checked == true, calculoKpol, L_Kpol);
                calculaKsFot = escribirLabel((LB_lectVtotProm.Text != "Vacio" && LB_LectVredProm.Text != "Vacio" && TB_Vred.Text != "") || CHB_UsaKsLB.Checked || CHB_NoUsaKs.Checked, calculoKs, L_Ks);
                calculaMrefFot = escribirLabel(LB_LecRefProm.Text != "Vacio" && L_CaliFKTP.Text != "Vacio" && L_Ks.Text != "Vacio" && L_Kpol.Text != "Vacio" && TB_UM.Text != "", CalculoMref, L_CaliFMref);
                calculaDwzrefFot = escribirLabel(L_CaliFMref.Text != "Vacio", calculoDwRef, L_CaliFDwZref);
                calculaDwzmaxFot = escribirLabel((RB_CaliFDFSfija.Checked || RB_CaliFIso.Checked) && TB_CaliFPDDref.Text != "" && L_CaliFDwZref.Text != "Vacio", calculoDwZmax, L_CaliFDwZmax);
                calculaDifLBFot = escribirLabel(calculaDwzrefFot && hayLBsinCartel(), calculoDifConRef, L_CaliFDifLB);
                chequearKqq0();
                chequearKpol();
                chequearKs();
                habilitarBotonesCaliFotones();
            }
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
            inicializarLadoCampoReferencia();
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
                escribirLabel(lec20(), LB_Lect20prom);
                escribirLabel(lec10(), LB_Lect10prom);
                CHB_UsarKqq0LB.Checked = false;

            }
            else if (CHB_UsarKqq0LB.Checked)
            {
                if (!hayLB())
                {
                    CHB_UsarKqq0LB.Checked = false;
                    L_CaliFTPR2010.Visible = false;
                    L_CaliFKqq0.Visible = false;
                    L_CaliFTPR2010.Text = "Vacio";
                    L_CaliFKqq0.Text = "Vacio";
                }
                else
                {
                    Panel_LecKqq0.Enabled = false;
                    Panel_TPRoPDD.Enabled = false;
                    limpiarRegistro(Panel_Lect20);
                    limpiarRegistro(Panel_Lect10);
                    limpiarRegistro(Panel_TPRoPDD);
                    escribirLabel(lec20(), LB_Lect20prom);
                    escribirLabel(lec10(), LB_Lect10prom);
                }
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
                escribirLabel(lecVmas(), LB_LectmasVprom);
                escribirLabel(lecVmenos(), LB_LectmenosVprom);
                CHB_UsaKpolLB.Enabled = false;
                CHB_UsaKpolLB.Checked = false;
            }
            else if (CHB_UsaKpolLB.Checked)
            {
                if (!hayLB())
                {
                    CHB_UsaKpolLB.Checked = false;
                    L_Kpol.Visible = false;
                    L_Kpol.Text = "Vacio";
                }
                else
                {
                    Panel_LecKpol.Enabled = false;
                    limpiarRegistro(Panel_LectmasV);
                    limpiarRegistro(Panel_LectmenosV);
                    escribirLabel(lecVmas(), LB_LectmasVprom);
                    escribirLabel(lecVmenos(), LB_LectmenosVprom);
                    CHB_NoUsaKpol.Enabled = false;
                    CHB_NoUsaKpol.Checked = false;
                }

            }
            else
            {
                Panel_LecKpol.Enabled = true;
                CHB_NoUsaKpol.Enabled = true;
                CHB_UsaKpolLB.Enabled = true;
            }
            if (!chb_EditarVKpol.Checked)
            {
                if (sistDosimSeleccionado().SignoTension==1)
                {
                    Panel_LectmenosV.Enabled = true;
                    limpiarRegistro(Panel_LectmasV);
                    Panel_LectmasV.Enabled = false;
                }
                else
                {
                    Panel_LectmasV.Enabled = true;
                    limpiarRegistro(Panel_LectmenosV);
                    Panel_LectmenosV.Enabled = false;
                }
                escribirLabel(lecVmas(), LB_LectmasVprom);
                escribirLabel(lecVmenos(), LB_LectmenosVprom);
            }
            else
            {
                if (L_Kpol.Text == "NaN")
                {
                    L_Kpol.Visible = false;
                    L_Kpol.Text = "Vacio";
                }
                escribirLabel(lecVmas(), LB_LectmasVprom);
                escribirLabel(lecVmenos(), LB_LectmenosVprom);
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
                escribirLabel(lecVTotal(), LB_lectVtotProm);
                escribirLabel(lecVred(), LB_LectVredProm);
                CHB_UsaKsLB.Enabled = false;
                CHB_UsaKsLB.Checked = false;
            }
            else if (CHB_UsaKsLB.Checked)
            {
                if (!hayLB())
                {
                    CHB_UsaKsLB.Checked = false;
                    L_Ks.Visible = false;
                    L_Ks.Text = "Vacio";
                }
                else
                {
                    Panel_LecKs.Enabled = false;
                    Panel_Vred.Enabled = false;
                    TB_Vred.Clear();
                    limpiarRegistro(Panel_lectVtot);
                    limpiarRegistro(Panel_LectVred);
                    escribirLabel(lecVTotal(), LB_lectVtotProm);
                    escribirLabel(lecVred(), LB_LectVredProm);
                    CHB_NoUsaKs.Enabled = false;
                    CHB_NoUsaKs.Checked = false;
                }

            }
            else
            {
                Panel_LecKs.Enabled = true;
                Panel_Vred.Enabled = true;
                CHB_NoUsaKs.Enabled = true;
                CHB_UsaKsLB.Enabled = true;
            }
            if (!chb_EditarVKs.Checked)
            {
                limpiarRegistro(Panel_lectVtot);
                Panel_lectVtot.Enabled = false;
                escribirLabel(lecVTotal(), LB_lectVtotProm);
            }
            else
            {
                if (L_Ks.Text == "NaN")
                {
                    L_Ks.Visible = false;
                    L_Ks.Text = "Vacio";
                }
                escribirLabel(lecVTotal(), LB_lectVtotProm);
                escribirLabel(lecVred(), LB_LectVredProm);
                Panel_lectVtot.Enabled = true;
            }
        }

        private bool hayLB()
        {
            if (!(RB_CaliFDFSfija.Checked || RB_CaliFIso.Checked) || CB_CaliEquipos.SelectedIndex == -1 || CB_CaliEnergias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir equipo, energía y condiciones de medición \npara poder cargar valores de referencia");
                return false;
            }
            else if (!CalibracionFot.hayReferencia(equipoSeleccionado(), energiaSeleccionada(), DFSoISO()))
            {
                MessageBox.Show("No se registra una calibración de referencia para este equipo, energía y condición");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool hayLBsinCartel()
        {
            if (!(RB_CaliFDFSfija.Checked || RB_CaliFIso.Checked) || CB_CaliEquipos.SelectedIndex == -1 || CB_CaliEnergias.SelectedIndex == -1)
            {
                return false;
            }
            else if (!CalibracionFot.hayReferencia(equipoSeleccionado(), energiaSeleccionada(), DFSoISO()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Cali Fotones Botones

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CalibracionFot.guardar(calibracionActual(), CHB_caliFotEstablecerComoRef.Checked))
            {
                MessageBox.Show("Calibración guardada");
                if (MessageBox.Show("¿Desea limpiar el registro?", "Limpiar Registro", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    CHB_UsarKqq0LB.Checked = false;
                    CHB_UsaKpolLB.Checked = false;
                    CHB_UsaKsLB.Checked = false;                
                    limpiarRegistro2Niveles(Panel_CalFot);
                    actualizarComboBoxCaliFotones();
                    inicializarPredeterminados(100, 10);
                    chb_EditarVKpol.Checked = false;
                    chb_EditarVKs.Checked = false;
                    actualizarCalculos();
                    CB_caliFotRealizadoPor.Text = "";
                }
            }

        }

        private CalibracionFot calibracionActual()
        {
            double difConRef = Double.NaN;
            if (hayLBsinCartel())
            {
                difConRef = calculoDifConRef();
            }
            return CalibracionFot.crear(equipoSeleccionado(), energiaSeleccionada(), sistDosimSeleccionado(), DFSoISO(), Calcular.validarYConvertirADouble(TB_CaliLadoCampo.Text),
                Calcular.validarYConvertirADouble(TB_CaliPRof.Text), DTP_FechaCaliFot.Value, CB_caliFotRealizadoPor.Text, calculoKTP(), calculoTPR2010(), calculokQQ0(), mideKqq0(), calculoKpol(), mideKpol(),
                Calcular.validarYConvertirADouble(TB_Vred.Text), calculoKs(), mideKs(), CalculoMref(), calculoDwRef(), calculoDwZmax(),
                Convert.ToDouble(TB_UM.Text), Convert.ToDouble(tbTemp.Text), Convert.ToDouble(tbPresion.Text), Convert.ToDouble(tbHumedad.Text),
                lecVmas(), lecVmenos(), lecVTotal(), lecVred(), lecRef(), lec20(), lec10(), TPRoD2010(), difConRef);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            limpiarRegistro2Niveles(Panel_CalFot);
            actualizarComboBoxCaliFotones();
            inicializarPredeterminados(100, 10);
            chb_EditarVKpol.Checked = false;
            chb_EditarVKs.Checked = false;
            actualizarCalculos();
            CB_caliFotRealizadoPor.Text = "";
        }

        private void BT_ExportarCaliFot_Click(object sender, EventArgs e)
        {
            CalibracionFot.exportarUnaCalibracion(calibracionActual());
        }

        private void habilitarBotonesCaliFotones()
        {
            habilitarBoton(calculaDwzrefFot, BT_CaliFGuardar);
            habilitarBoton(calculaDwzrefFot, Bt_ReporteVP);
            habilitarBoton(calculaDwzrefFot, BT_ReporteImp);
            habilitarBoton(calculaDwzrefFot, BT_ExportarCaliFot);
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
                TB_EnFotLado.Text = Configuracion.ladoCampoPredetFot.ToString();
            }
            else { Panel_EnFotEquipo.Enabled = false; }
        }

        private void CHB_EnElecEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_EnElecEquipo.Checked == true)
            {
                Panel_EnElecEquipo.Enabled = true;
                TB_EnElecLado.Text = Configuracion.ladoCampoPredetElec.ToString();
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
                TB_EnCoZref.Text = Configuracion.profPredetCo.ToString();
                RB_Pulsado.Checked = false;
                RB_PulsadoYBarrido.Checked = false;
                TB_EnCoLado.Text = Configuracion.ladoCampoPredetFot.ToString();
            }
            else
            {
                Panel_EnCoEquipo.Enabled = false;
                TB_EnCoZref.Text = "";
            }
            habilitarEquipoBotones(sender, e);
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
            habilitarEquipoBotones(sender, e);
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
                Equipo.guardar(Equipo.crearCo(cb_MarcaEq.Text, TB_ModeloEq.Text, TB_NumSerieEq.Text, TB_AliasEq.Text, 1, 0, Calcular.doubleNaN(TB_EnCoZref), Calcular.doubleNaN(TB_EnCoLado), Calcular.doubleNaN(TB_EnCoPDD), Calcular.doubleNaN(TB_EnCoTMR), cb_InstitucionEq.Text), editaEquipo, DGV_Equipo);
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
                Equipo.editarAle(cb_MarcaEq, TB_ModeloEq, TB_NumSerieEq, TB_AliasEq, cb_InstitucionEq, Panel_FuenteEq, Panel_TipoHazEq, DGV_EnFot, DGV_EnElec, DGV_Equipo);
                CHB_EnElecEquipo.Checked = true;
                if (DGV_EnFot.Rows.Count > 0)
                {
                    CHB_EnFotEquipo.Checked = true;
                    DGV_EnFot.Visible = true;
                }
                else
                {
                    CHB_EnFotEquipo.Checked = false;
                    DGV_EnFot.Visible = false;
                }
                if (DGV_EnElec.Rows.Count > 0)
                {
                    CHB_EnElecEquipo.Checked = true;
                    DGV_EnElec.Visible = true;
                }
                else
                {
                    CHB_EnElecEquipo.Checked = false;
                    DGV_EnElec.Visible = false;
                }
            }
            editaEquipo = true;
            actualizarComboBoxCaliFotones();
        }

        private void BT_ExportarEq_Click(object sender, EventArgs e)
        {
            Equipo.exportar(DGV_Equipo);
        }

        private void BT_ImportarEq_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Filter = "Archivos txt(.txt)|*.txt|All Files (*.*)|*.*"
            };
            openFileDialog1.ShowDialog();
            BindingList<Equipo> listaImportada = Equipo.importar(openFileDialog1.FileName);
            if (listaImportada.Count() == 0)
            {
                MessageBox.Show("No hay nuevos equipos para importar en el archivo seleccionado");
            }
            else
            {
                if (MessageBox.Show("Está por importar " + listaImportada.Count() + " equipos. ¿Continuar?", "Importar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Equipo.agregarImportados(listaImportada, DGV_Equipo);
                }
            }
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

        private void habilitarEquipoBotones(object sender, EventArgs e)
        {
            bool tieneFuente = RB_FuenteCo.Checked || RB_FuenteALE.Checked;
            bool tieneTipoDeHaz = false;
            bool tieneEnergia = false;
            if (RB_FuenteALE.Checked)
            {
                tieneTipoDeHaz = RB_Pulsado.Checked || RB_PulsadoYBarrido.Checked;
                if (DGV_EnFot.Rows.Count + DGV_EnElec.Rows.Count > 0)
                {
                    tieneEnergia = true;
                }
            }
            if (RB_FuenteCo.Checked)
            {
                tieneTipoDeHaz = true;
                tieneEnergia = true;
            }

            habilitarBoton(cb_InstitucionEq.Text != "" && cb_MarcaEq.Text != "" && TB_ModeloEq.Text != "" &&
                tieneFuente && tieneTipoDeHaz && tieneEnergia, BT_GuardarEq);
            habilitarBoton(DGV_Equipo.SelectedRows.Count == 1, BT_EditarEq);
            habilitarBoton(DGV_Equipo.SelectedRows.Count == 1, BT_PredetEqu);
            habilitarBoton(DGV_Equipo.SelectedRows.Count == 1, BT_EqIraCal);
            habilitarBoton(DGV_Equipo.SelectedRows.Count > 0, BT_EliminarEq);
            habilitarBoton(DGV_Equipo.SelectedRows.Count > 0, BT_ExportarEq);
        }

        #endregion

        #region Equipos EnergiaFotonesBotones

        private void BT_EnFotGuardar_Click(object sender, EventArgs e)
        {
            DGV_EnFot.Visible = true;
            EnergiaFotones.guardar(EnergiaFotones.crear(Convert.ToDouble(TB_EnFotEn.Text), Calcular.doubleNaN(TB_EnFotLado), Calcular.doubleNaN(TB_EnFotZref), Calcular.doubleNaN(TB_EnFotPDD), Calcular.doubleNaN(TB_EnFotTMR)), editaEnergiaFot, DGV_EnFot);
            limpiarRegistro(Panel_EnFotEquipo);
            TB_EnFotLado.Text = Configuracion.ladoCampoPredetFot.ToString();
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
            EnergiaFotones.editar(TB_EnFotEn, TB_EnFotZref, TB_EnFotLado, TB_EnFotPDD, TB_EnFotTMR, DGV_EnFot);
            editaEnergiaFot = true;
        }

        private void BT_EnFotPredet_Click(object sender, EventArgs e)
        {
            EnergiaFotones.hacerPredeterminado(DGV_EnFot);
        }


        private void BT_EqEnergiaFot_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(Panel_EnFotEquipo);
            DGV_EnFot.Enabled = true;
            editaEnergiaFot = false;
        }

        private void habilitarEqEnFotBotones(object sender, EventArgs e)
        {
            habilitarBoton(TB_EnFotEn.Text != "", BT_EnFotGuardar);
            habilitarBoton(DGV_EnFot.SelectedRows.Count == 1, BT_EnFotEditar);
            habilitarBoton(DGV_EnFot.SelectedRows.Count == 1, BT_EnFotPredet);
            habilitarBoton(DGV_EnFot.SelectedRows.Count > 0, BT_EnFotEliminar);
            habilitarEquipoBotones(sender, e);
        }
        #endregion

        #region Equipos EnergiaElectronesBotones

        private void BT_EnElecGuardar_Click(object sender, EventArgs e)
        {
            DGV_EnElec.Visible = true;
            EnergiaElectrones.guardar(EnergiaElectrones.crear(Convert.ToDouble(TB_EnElecEn.Text), Calcular.doubleNaN(TB_EnElecLado), Calcular.doubleNaN(TB_EnElecR50ion), Calcular.doubleNaN(L_EnElecR50dosis), Calcular.doubleNaN(L_EnElecZref), Calcular.doubleNaN(TB_EnElecPDDZref)), editaEnergiaElect, DGV_EnElec);
            limpiarRegistro(Panel_EnElecEquipo);
            TB_EnElecLado.Text = Configuracion.ladoCampoPredetElec.ToString();
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
            EnergiaElectrones.editar(TB_EnElecEn, TB_EnElecR50ion, TB_EnElecLado, L_EnElecR50dosis, L_EnElecZref, TB_EnElecPDDZref, DGV_EnElec);
            editaEnergiaElect = true;
        }

        private void BT_EnElecPredet_Click(object sender, EventArgs e)
        {
            EnergiaElectrones.hacerPredeterminado(DGV_EnElec);
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

        private void habilitarEqEnElecBotones(object sender, EventArgs e)
        {
            habilitarBoton(TB_EnElecEn.Text != "", BT_EnElecGuardar);
            habilitarBoton(DGV_EnElec.SelectedRows.Count == 1, BT_EnElecEditar);
            habilitarBoton(DGV_EnElec.SelectedRows.Count == 1, BT_EnElecPredet);
            habilitarBoton(DGV_EnElec.SelectedRows.Count > 0, BT_EnElecEliminar);
            habilitarEquipoBotones(sender, e);
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
            habilitarCamBotones(sender, e);
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
            habilitarCamBotones(sender, e);
        }

        private void BT_Camara_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(GB_Camaras);
            DGV_Cam.Enabled = true;
            editaCam = false;
        }

        private void habilitarCamBotones(object sender, EventArgs e)
        {
            habilitarBoton(CB_MarcaCam.SelectedIndex != -1 && CB_ModCam.SelectedIndex != -1 && TB_SNCam.Text != "", BT_GuardarCam);
            habilitarBoton(DGV_Cam.SelectedRows.Count == 1, BT_EditarCam);
            habilitarBoton(DGV_Cam.SelectedRows.Count > 0, BT_EliminarCam);
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
            habilitarElecBotones(sender, e);
        }

        private void BT_Electrometro_Cancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro(GB_Electrómetros);
            DGV_Elec.Enabled = true;
            editaElec = false;
        }

        private void habilitarElecBotones(object sender, EventArgs e)
        {
            habilitarBoton(TB_MarcaElec.Text != "" && TB_ModeloElec.Text != "" && TB_SNElec.Text != "", BT_GuardarElec);
            habilitarBoton(DGV_Elec.SelectedRows.Count == 1, BT_EditarElec);
            habilitarBoton(DGV_Elec.SelectedRows.Count > 0, BT_EliminarElec);
        }
        #endregion

        #region SistDosimetricos SistDosimetricoBotones

        private void BT_NuevSistDos_Click(object sender, EventArgs e)
        {
            NuevoSistDos nsd = new NuevoSistDos(false, 0);
            nsd.ShowDialog();
            DGV_SistDos.DataSource = SistemaDosimetrico.lista();
            actualizarComboBoxCaliFotones();
            habilitarSistDosBotones(sender, e);
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

        private void BT_ImportarSistDos_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Filter = "Archivos txt(.txt)|*.txt|All Files (*.*)|*.*"
            };
            openFileDialog1.ShowDialog();
            BindingList<SistemaDosimetrico> listaImportada = SistemaDosimetrico.importar(openFileDialog1.FileName);
            if (listaImportada.Count() == 0)
            {
                MessageBox.Show("No hay nuevos sistemas dosimétricos para importar en el archivo seleccionado");
            }
            else
            {
                if (MessageBox.Show("Está por importar " + listaImportada.Count() + " sistemas dosimétricos. ¿Continuar?", "Importar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SistemaDosimetrico.agregarImportados(listaImportada, DGV_SistDos);
                }
                if (MessageBox.Show("¿Desea agregar también las cámaras y electrómetros a sus listas? ", "Importar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Camara.importar(listaImportada, DGV_Cam);
                    Electrometro.importar(listaImportada, DGV_Elec);
                }
            }

        }

        private void BT_ExportarSistDos_Click(object sender, EventArgs e)
        {
            SistemaDosimetrico.exportar(DGV_SistDos);
        }

        private void habilitarSistDosBotones(object sender, EventArgs e)
        {
            habilitarBoton(DGV_SistDos.SelectedRows.Count == 1, BT_EditarSistDos);
            habilitarBoton(DGV_SistDos.SelectedRows.Count == 1, BT_PredSistDos);
            habilitarBoton(DGV_SistDos.SelectedRows.Count == 1, BT_SistDosIraCal);
            habilitarBoton(DGV_SistDos.SelectedRows.Count > 0, BT_EliminarSistDos);
            habilitarBoton(DGV_SistDos.SelectedRows.Count > 0, BT_ExportarSistDos);
        }

        #endregion

        #region Analizar Registros Inicializaciones

        private void inicializarRegistrosEquipos()
        {
             foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                if (!ListBox_RegistrosEquipos.Items.Contains(cali.Equipo))
                {
                    ListBox_RegistrosEquipos.Items.Add(cali.Equipo);
                    ListBox_RegistrosEquipos.DisplayMember = "Etiqueta";
                }
            }
        }

        private void registroChequeoEnergias(object sender, EventArgs e)
        {
            inicializarRegistrosEnergias();
            if (RB_RegistroEnergiaFot.Checked)
            {
                CB_RegistroEnergiaFot.Enabled = true;
                CB_RegistroEnergiaFot.SelectedIndex = 0;
            }
            else
            {
                CB_RegistroEnergiaFot.Enabled = false;
                CB_RegistroEnergiaFot.SelectedIndex = -1;
            }
            if (RB_RegistroEnergiaElec.Checked)
            {
                CB_RegistroEnergiaElec.Enabled = true;
                CB_RegistroEnergiaElec.SelectedIndex = 0;
            }
            else
            {
                CB_RegistroEnergiaElec.Enabled = false;
                CB_RegistroEnergiaElec.SelectedIndex = -1;
            }
        }
        private void inicializarRegistrosEnergias()
        {
            CB_RegistroEnergiaFot.Items.Clear();
            CB_RegistroEnergiaElec.Items.Clear();
            if (ListBox_RegistrosEquipos.SelectedIndex != -1)
            {
                if (registroEquipoSeleccionado().energiaFot.Count() > 0)
                {
                    foreach (EnergiaFotones eF in registroEquipoSeleccionado().energiaFot)
                    {
                        CB_RegistroEnergiaFot.Items.Add(eF);
                    }
                    RB_RegistroEnergiaFot.Enabled = true;
                    if (registroEquipoSeleccionado().energiaElec.Count == 0)
                    {
                        RB_RegistroEnergiaFot.Checked = true;
                    }
                }
                else
                {
                    RB_RegistroEnergiaFot.Enabled = false;
                }
                if (registroEquipoSeleccionado().energiaElec.Count() > 0)
                {
                    foreach (EnergiaElectrones eE in registroEquipoSeleccionado().energiaElec)
                    {
                        CB_RegistroEnergiaElec.Items.Add(eE);
                    }
                    RB_RegistroEnergiaElec.Enabled = true;
                    if (registroEquipoSeleccionado().energiaFot.Count == 0)
                    {
                        RB_RegistroEnergiaElec.Checked = true;
                    }
                }
                else
                {
                    RB_RegistroEnergiaElec.Enabled = false;
                }
                CB_RegistroEnergiaFot.DisplayMember = "Etiqueta";
                CB_RegistroEnergiaElec.DisplayMember = "Etiqueta";
            }
        }
    
        private Equipo registroEquipoSeleccionado()
        {
            return (Equipo)ListBox_RegistrosEquipos.SelectedItem;
        }

        private EnergiaFotones registroEnergiaFotonesSeleccionada()
        {
            return (EnergiaFotones)CB_RegistroEnergiaFot.SelectedItem;
        }

        private EnergiaElectrones registroEnergiaElectronesSeleccionada()
        {
            return (EnergiaElectrones)CB_RegistroEnergiaElec.SelectedItem;
        }

        private int registroDFSoISO()
        {
            int DFSoISO = 0;
            if (RB_RegistroDFSFija.Checked)
            {
                DFSoISO = 1;
            }
            else if (RB_RegistroIso.Checked)
            {
                DFSoISO = 2;
            }
            return DFSoISO;
        }


        private void inicializacionesRegistro()
        {
            inicializarRegistrosEquipos();
            inicializarRegistrosEnergias();
            DTPRegDesde.Value = primerFechaCali();
            DTPRegHasta.Value = ultimaFechaCali();
        }

        private void ListBox_RegistrosEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            inicializacionesRegistro();
            registroChequeoEnergias(sender, e);
            habilitarBotonAnalizar(sender, e);
        }

        private DateTime primerFechaCali()
        {
            if (CalibracionFot.lista().Count > 0)
            {
                return (CalibracionFot.lista().OrderBy(c => c.Fecha).First()).Fecha;
            }
            else
            {
                return new DateTime(2017, 11, 8);
            }
        }
        private DateTime ultimaFechaCali()
        {
            if (CalibracionFot.lista().Count > 0)
            {
                return (CalibracionFot.lista().OrderByDescending(c => c.Fecha).First()).Fecha;
            }
            else
            {
                return new DateTime(2017, 11, 8);
            }
            
        }

        private BindingList<CalibracionFot> listaCalibracionesFotonesRegistro()
        {
            
            List<CalibracionFot> lista = new List<CalibracionFot>();
            foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                if (cali.Equipo.Equals(registroEquipoSeleccionado()) && cali.Energia.Equals(registroEnergiaFotonesSeleccionada()) && cali.DFSoISO.Equals(registroDFSoISO())
                    && DateTime.Compare(cali.Fecha.Date,DTPRegDesde.Value.Date)>=0 && DateTime.Compare(cali.Fecha.Date,DTPRegHasta.Value.Date)<=0)
                {
                    lista.Add(cali);
                }
            }
            lista.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
            BindingList<CalibracionFot> lista2 = new BindingList<CalibracionFot>(lista);
            return lista2;
        }

        private void habilitarBotonAnalizar(object sender, EventArgs e)
        {
            bool test = (ListBox_RegistrosEquipos.SelectedIndex != -1 && (CB_RegistroEnergiaElec.SelectedIndex >-1 || CB_RegistroEnergiaFot.SelectedIndex > -1) && (RB_RegistroDFSFija.Checked || RB_RegistroIso.Checked));
            habilitarBoton(test, BtAnalizar);
        }

        private void BtAnalizar_Click(object sender, EventArgs e)
        {
            BindingList<CalibracionFot> lista = listaCalibracionesFotonesRegistro();
            BindingList<Analisis> analisis = Analisis.analizar(lista, registroEquipoSeleccionado(), registroEnergiaFotonesSeleccionada(), registroDFSoISO());
            if (lista.Count() > 0)
            {
                DGVRegistros.DataSource = lista;
                DGVRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DGVAnalisis.DataSource = analisis;
                DGVAnalisis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                int tam = 0;
                foreach (DataGridViewColumn col in DGVAnalisis.Columns)
                {
                    tam += col.Width;
                }
                DGVAnalisis.Width = tam+10;
                DGVAnalisis.Height = DGVAnalisis.Rows[0].Height * 5;
                DGVAnalisis.BackgroundColor = Form1.DefaultBackColor;
                DGVAnalisis.BorderStyle = BorderStyle.None;
                //Analisis.llenarDGV(Analisis.analizar2(lista, registroEquipoSeleccionado(), registroEnergiaFotonesSeleccionada(), registroDFSoISO()), DGVAnalisis);
                Graficar.graficarRegistrosCaliFotones(lista, Chart_Registros);
            }
            else
            {
                MessageBox.Show("No existen calibraciones con las condiciones descriptas");
                DGVRegistros.DataSource = null;
                DGVAnalisis.DataSource = null;
                Chart_Registros.Legends.Clear(); Chart_Registros.ChartAreas.Clear(); Chart_Registros.Series.Clear();
            }

        }

        private void ChBRegRango_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBRegRango.Checked)
            {
                L_RegFechaHasta.Enabled = true;
                L_regFechaDesde.Enabled = true;
                DTPRegDesde.Enabled = true;
                DTPRegHasta.Enabled = true;
            }
            else
            {
                L_RegFechaHasta.Enabled = false;
                L_regFechaDesde.Enabled = false;
                DTPRegDesde.Enabled = false;
                DTPRegHasta.Enabled = false;
            }
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
        
        public static bool escribirLabel(double valor, Label label)
        {
            if (!Double.IsNaN(valor))
            {
                label.Text = valor.ToString();
                label.Visible = true;
                return true;
            }
            else
            {
                label.Text = "Vacio";
                label.Visible = false;
                return false;
            }
        }

        public static bool escribirLabel(bool test, Func<double> metodo, Label label)
        {
            if (test)
            {
                label.Text = metodo().ToString();
                label.Visible = true;
                return true;
            }
            else
            {
                label.Text = "Vacio";
                label.Visible = false;
                return false;
            }
        }

        public static bool escribirLabel(bool test, Func<double> metodo, Label label, GroupBox gb)
        {
            if (test)
            {
                label.Text = metodo().ToString();
                label.Visible = true;
                return true;
            }
            else
            {
                label.Text = "Vacio";
                label.Visible = false;
                foreach (Panel panel in gb.Controls.OfType<Panel>())
                {
                    panel.Enabled = true;
                }
                return false;
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

        private SistemaDosimetrico sistDosimSeleccionado()
        {
            if (SistemaDosimetrico.lista().Count > 0)
            {
                return (SistemaDosimetrico)CB_CaliSistDosimetrico.SelectedItem;
            }
            else
            {
                return new SistemaDosimetrico();
            }

        }

        private Equipo equipoSeleccionado()
        {
            if (Equipo.lista().Count > 0)
            {
                return (Equipo)CB_CaliEquipos.SelectedItem;
            }
            else
            {
                return new Equipo();
            }
        }

        private EnergiaFotones energiaSeleccionada()
        {
            if (equipoSeleccionado().energiaFot != null && equipoSeleccionado().energiaFot.Count > 0)
            {
                return (EnergiaFotones)CB_CaliEnergias.SelectedItem;
            }
            else
            {
                return new EnergiaFotones();
            }
        }

        private double ladoCampoReferencia()
        {
            return energiaSeleccionada().LadoCampo;
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

        private int DFSoISO()
        {
            int DFSoISO = 0;
            if (RB_CaliFDFSfija.Checked)
            {
                DFSoISO = 1;
            }
            else if (RB_CaliFIso.Checked)
            {
                DFSoISO = 2;
            }
            return DFSoISO;
        }
        private int TPRoD2010()
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
            return TPRoD;
        }

        private int mideKqq0()
        {
            int mideKqq0 = 1;
            if (CHB_UsarKqq0LB.Checked)
            {
                mideKqq0 = 2;
            }
            return mideKqq0;
        }
        private int mideKs()
        {
            int mideKs = 1;
            if (CHB_UsaKsLB.Checked)
            {
                mideKs = 2;
            }
            else if (CHB_NoUsaKs.Checked)
            {
                mideKs = 3;
            }
            return mideKs;
        }

        private int mideKpol()
        {
            int mideKpol = 1;
            if (CHB_UsaKpolLB.Checked)
            {
                mideKpol = 2;
            }
            else if (CHB_NoUsaKpol.Checked)
            {
                mideKpol = 3;
            }
            return mideKpol;
        }


        #endregion

        #region Imprimir

        private void Bt_ReporteVP_Click(object sender, EventArgs e)
        {

            PrintDocument pd = new PrintDocument();
            pd = Imprimir.cargarConfiguracion();
            printPreviewDialog1.Document = pd;
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage_1);

            printPreviewDialog1.ShowDialog();


        }

        private void BT_ReporteImp_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd = Imprimir.cargarConfiguracion();
            printDialog1.Document = pd;
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage_1);
            pd.PrinterSettings = printDialog1.PrinterSettings;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
            // printDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            int DFSoISO = 0;
            string TPRoPDD = "";
            if (RB_CaliFDFSfija.Checked)
            {
                DFSoISO = 1;
                TPRoPDD = TB_CaliFPDDref.Text;
            }
            else if (RB_CaliFIso.Checked)
            {
                DFSoISO = 2;
                TPRoPDD = TB_CaliFTMRref.Text;
            }
            int corrigeKpol = 1;
            if (CHB_UsaKpolLB.Checked)
            {
                corrigeKpol = 2;
            }
            else if (CHB_NoUsaKpol.Checked)
            {
                corrigeKpol = 3;
            }
            int corrigeKs = 1;
            if (CHB_UsaKsLB.Checked)
            {
                corrigeKs = 2;
            }
            else if (CHB_NoUsaKs.Checked)
            {
                corrigeKs = 3;
            }
            int corrigeKqq0 = 1;
            double TPR2010reporte = 0;
            int DoTPR2010 = 1;
            if (RB_CaliFD2010.Checked)
            {
                DoTPR2010 = 1;
            }
            if (RB_CaliFTPR2010.Checked)
            {
                DoTPR2010 = 2;
            }
            if (CHB_UsarKqq0LB.Checked)
            {
                corrigeKqq0 = 2;
            }
            else
            {
                TPR2010reporte = calculoTPR2010();
            }
            bool hayPDDoTPR = false;
            double dwzmaxreporte = 0;
            bool hayLB = false;
            double difLBreporte = 0;
            if (TB_CaliFPDDref.Text != "" || TB_CaliFTMRref.Text != "")
            {
                hayPDDoTPR = true;
                dwzmaxreporte = calculoDwZmax();
            }
            if (true)//falta armar bien los métodos
                     //if (LineaBaseFotones.hayLineaBase(equipoSeleccionado(), energiaSeleccionada())) 
            {
                hayLB = true;
                difLBreporte = 5;
            }

            int posicionlinea = 30;
            posicionlinea = Imprimir.imprimirTituloCaliFotones(e, posicionlinea);

            posicionlinea = Imprimir.imprimirUsuarioYFecha(e, posicionlinea, CB_caliFotRealizadoPor.Text, DTP_FechaCaliFot.Value);
            posicionlinea += Imprimir.altoTexto;
            posicionlinea = Imprimir.imprimirEquipo(e, posicionlinea, equipoSeleccionado(), energiaSeleccionada());
            posicionlinea += Imprimir.altoTexto;
            posicionlinea = Imprimir.imprimirCondiciones(e, posicionlinea, DFSoISO, TB_CaliLadoCampo.Text, TB_CaliPRof.Text, TPRoPDD);
            posicionlinea += Imprimir.altoTexto;
            posicionlinea = Imprimir.imprimirSistemaDosimetrico(e, posicionlinea, sistDosimSeleccionado());
            posicionlinea += Imprimir.altoTexto;
            posicionlinea = Imprimir.imprimirUMyKTP(e, posicionlinea, TB_UM.Text, tbTemp.Text, tbPresion.Text, tbHumedad.Text, calculoKTP());
            posicionlinea += Imprimir.altoTexto;
            if (chb_EditarVKpol.Checked)
            {
                posicionlinea = Imprimir.imprimirKpol(e, posicionlinea, promediarPanel(Panel_LectmasV), promediarPanel(Panel_LectmenosV), calculoKpol(), corrigeKpol);
            }
            else
            {
                posicionlinea = Imprimir.imprimirKpol(e, posicionlinea, promediarPanel(Panel_LecRef), promediarPanel(Panel_LectmenosV), calculoKpol(), corrigeKpol);
            }
            posicionlinea += Imprimir.altoTexto;
            if (chb_EditarVKs.Checked)
            {
                posicionlinea = Imprimir.imprimirKs(e, posicionlinea, promediarPanel(Panel_lectVtot), promediarPanel(Panel_LectVred), TB_Vred.Text, calculoKs(), corrigeKs);
            }
            else
            {
                posicionlinea = Imprimir.imprimirKs(e, posicionlinea, promediarPanel(Panel_LecRef), promediarPanel(Panel_LectVred), TB_Vred.Text, calculoKs(), corrigeKs);
            }
            posicionlinea += Imprimir.altoTexto;
            if (equipoSeleccionado().Fuente == 2) //ALE
            {
                posicionlinea = Imprimir.imprimirTPRyKqq0(e, posicionlinea, promediarPanel(Panel_Lect20), promediarPanel(Panel_Lect10), TPR2010reporte, calculokQQ0(), corrigeKqq0, DoTPR2010);
                posicionlinea += Imprimir.altoTexto;
            }
            posicionlinea = Imprimir.imprimirTodoEnRef(e, posicionlinea, promediarPanel(Panel_LecRef), CalculoMref(), calculoDwRef(), dwzmaxreporte, difLBreporte, hayPDDoTPR, hayLB);
        }






        #endregion

        private void BT_RegistrosResumen_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CalibracionFot.resumenCalibracion((CalibracionFot)DGVRegistros.SelectedRows[0].DataBoundItem));
        }


    }
}




