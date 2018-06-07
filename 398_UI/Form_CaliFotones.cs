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

    public partial class Form_CaliFotones : Form
    {
        bool calculaKtpFot = false;
        bool calculaTPR2010Fot = false;
        bool calculaKqq0Fot = false;
        bool calculaKsFot = false;
        bool calculaKpolFot = false;
        bool calculaMrefFot = false;
        bool calculaDwzrefFot = false;
        bool calculaDwzmaxFot = false;
        bool calculaDifLBFot = false;

        public Form_CaliFotones()
        {
            InitializeComponent();
        }

        private void Form_CaliFotones_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
  
            //Carga UI
            actualizarComboBoxCaliFotones();
            inicializarPredeterminados(100, 10);
            chb_EditarVKpol.Checked = false;
            chb_EditarVKs.Checked = false;
        }


        #region Pestana

        private void actualizarNombrePestana()
        {
            string nombrePestana = equipoSeleccionado().Marca + " " + equipoSeleccionado().Modelo;
            if (equipoSeleccionado().Fuente==2)
            {
                nombrePestana += " " + energiaSeleccionada().Etiqueta + "MV";
            }
            this.Parent.Text = nombrePestana;
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
                if (realizador != "" && !CB_caliFotRealizadoPor1.Items.Contains(realizador))
                {
                    CB_caliFotRealizadoPor1.Items.Add(cali.RealizadoPor);
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
            TB_tiempo.Text = Configuracion.tiempoPredet.ToString();
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
            if (equipoSeleccionado().Fuente==1)//Co
            {
                return CalibracionFot.CalcularMref(lecRef(), calculoKTP(), calculoKs(), calculoKpol(), Convert.ToDouble(TB_tiempo.Text));
            }
            else //ALE
            {
                return CalibracionFot.CalcularMref(lecRef(), calculoKTP(), calculoKs(), calculoKpol(), Convert.ToDouble(TB_UM.Text));
            }
            
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
                actualizarNombrePestana();
                UMoTiempo();
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

        private void UMoTiempo()
        {
            if (equipoSeleccionado().Fuente==1) //Co
            {
                Panel_UM.Enabled = false;
                Panel_Tiempo.Enabled = true;
            }
            else if (equipoSeleccionado().Fuente == 2) //ALE
            {
                Panel_UM.Enabled = true;
                Panel_Tiempo.Enabled = false;
            }
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
                    CB_caliFotRealizadoPor1.Text = "";
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
                Calcular.validarYConvertirADouble(TB_CaliPRof.Text), DTP_FechaCaliFot.Value, CB_caliFotRealizadoPor1.Text, calculoKTP(), calculoTPR2010(), calculokQQ0(), mideKqq0(), calculoKpol(), mideKpol(),
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
            CB_caliFotRealizadoPor1.Text = "";
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

            posicionlinea = Imprimir.imprimirUsuarioYFecha(e, posicionlinea, CB_caliFotRealizadoPor1.Text, DTP_FechaCaliFot.Value);
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
    }
}




