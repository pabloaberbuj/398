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

    public partial class Form_CaliElectrones : Form
    {
        bool calculaKtpElec = false;
        bool calculaKqq0Elec = false;
        bool calculaKsElec = false;
        bool calculaKpolElec = false;
        bool calculaMrefElec = false;
        bool calculaDwzrefElec = false;
        bool calculaDwzmaxElec = false;
        bool calculaDifLBElec = false;
        Form1 form1;

        public Form_CaliElectrones(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            //actualizarComboBoxCaliFotones();
        }

        private void Form_CaliElectrones_Load(object sender, EventArgs e)
        {
            actualizarComboBoxCaliFotones();
            MinimizeBox = false;
            MaximizeBox = false;

            //Carga UI
            inicializarPredeterminados(100, 10);
            chb_EditarVKpol.Checked = false;
            chb_EditarVKs.Checked = false;
        }


        #region Pestana

        private void actualizarNombrePestana()
        {
            string nombrePestana = equipoSeleccionado().Marca + " " + equipoSeleccionado().Modelo;
            if (equipoSeleccionado().Fuente == 2)
            {
                nombrePestana += " " + energiaSeleccionada().Etiqueta + "MeV";
            }
            this.Parent.Text = nombrePestana;
        }
        #endregion


        #region Cali Electrones Inicializaciones

        private void InicializarComboBoxEquipos(bool guardarSeleccion = false)
        {
            Equipo equipoASeleccionar = new Equipo();
            if (guardarSeleccion)
            {
                equipoASeleccionar = (Equipo)CB_CaliEquipos.SelectedItem;
            }
            CB_CaliEquipos.Items.Clear();
            if (Equipo.lista().Count > 0)
            {
                foreach (var equipo in Equipo.lista())
                {
                    if (equipo.energiaElec.Count > 0)
                    {
                        CB_CaliEquipos.Items.Add(equipo);
                        CB_CaliEquipos.DisplayMember = "Etiqueta";
                        if (!guardarSeleccion && equipo.EsPredet == true)
                        {
                            equipoASeleccionar = equipo;
                        }
                    }
                }
                CB_CaliEquipos.SelectedItem = Equipo.lista().Where(e => e.ID == equipoASeleccionar.ID).FirstOrDefault();
            }
            if (CB_CaliEquipos.Items.Count > 0 && CB_CaliEquipos.SelectedIndex == -1)
            {
                CB_CaliEquipos.SelectedIndex = 0;
            }
        }


        private void InicializarComboBoxSistDosim(bool guardarSeleccion = false)
        {
            SistemaDosimetrico sistDosASeleccionar = new SistemaDosimetrico();
            if (guardarSeleccion)
            {
                sistDosASeleccionar = (SistemaDosimetrico)CB_CaliSistDosimetrico.SelectedItem;
            }
            CB_CaliSistDosimetrico.Items.Clear();
            if (SistemaDosimetrico.lista().Count > 0)
            {
                foreach (var sistdos in SistemaDosimetrico.lista())
                {
                    if (sistdos.camara.paraElectrones)
                    {
                        CB_CaliSistDosimetrico.Items.Add(sistdos);
                        CB_CaliSistDosimetrico.DisplayMember = "Etiqueta";
                        if (!guardarSeleccion && sistdos.EsPredet == true)
                        {
                            sistDosASeleccionar = sistdos;
                        }
                    }
                }
            }
            CB_CaliSistDosimetrico.SelectedItem = SistemaDosimetrico.lista().Where(s => s.ID == sistDosASeleccionar.ID).FirstOrDefault();
            if (CB_CaliSistDosimetrico.Items.Count > 0 && CB_CaliSistDosimetrico.SelectedIndex == -1)
            {
                CB_CaliSistDosimetrico.SelectedIndex = 0;
            }
        }

        private void InicializarComboBoxEnergias(bool guardarSeleccion = false)
        {
            EnergiaElectrones energiaASeleccionar = new EnergiaElectrones();
            if (guardarSeleccion)
            {
                energiaASeleccionar = (EnergiaElectrones)CB_CaliEnergias.SelectedItem;
            }
            CB_CaliEnergias.Items.Clear();

            if (CB_CaliEquipos.SelectedIndex != -1)
            {
                if (equipoSeleccionado().Fuente == 2)
                {
                    foreach (var energia in equipoSeleccionado().energiaElec)
                    {
                        CB_CaliEnergias.Items.Add(energia);
                        CB_CaliEnergias.DisplayMember = "Etiqueta";
                        if (!guardarSeleccion && energia.EsPredet == true)
                        {
                            energiaASeleccionar = energia;
                        }
                    }
                    CB_CaliEnergias.SelectedItem = energiaASeleccionar;
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
                if (realizador != "" && !CB_caliElecRealizadoPor1.Items.Contains(realizador))
                {
                    CB_caliElecRealizadoPor1.Items.Add(cali.RealizadoPor);
                    CB_caliElecRealizadoPor2.Items.Add(cali.RealizadoPor);
                    CB_caliElecRealizadoPor3.Items.Add(cali.RealizadoPor);
                }
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
                TB_CaliLadoCampo.Enabled = true;
            }
        }


        private void InicializarPDDref()
        {
            if (CB_CaliEnergias.SelectedIndex > -1 && !Double.IsNaN(PDDref()))
            {
                TB_CaliEPDDref.Text = PDDref().ToString();
                TB_CaliEPDDref.Enabled = false;
            }
            else
            {
                TB_CaliEPDDref.Text = "";
                TB_CaliEPDDref.Enabled = true;
            }
        }
        
        private void inicializarR50()
        {
            if (CB_CaliEnergias.SelectedIndex>-1 && !Double.IsNaN(energiaSeleccionada().R50D))
            {
                escribirLabel(energiaSeleccionada().R50ion, L_EnElecR50ion);
                escribirLabel(energiaSeleccionada().R50D, L_EnElecR50dosis);
            }
        }

        private void inicializarPredeterminados(double umPred, double ladoCampopred) //ver si sacar lado campo pred
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



        //Kqq0


        private double calculokQQ0()
        {
            double kqq0 = CalibracionElec.calcularKqq0(sistDosimSeleccionado().camara, equipoSeleccionado(), energiaSeleccionada(),  energiaSeleccionada().R50D);
            if (Double.IsNaN(kqq0))
            {
                MessageBox.Show("El valor de kQQ0 no se puede obtener para esa combinación de cámara y haz.\nRevisar que la cámara esté recomendada para esa calidad de haz");
            }
            return kqq0;
        }

        //Kpol

        private double calculoKpol()
        {
            return CalibracionElec.calcularKpol(sistDosimSeleccionado().SignoTension, lecVmas(), lecVmenos(), CHB_NoUsaKpol.Checked, CHB_UsaKpolLB.Checked, equipoSeleccionado(), energiaSeleccionada());
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
            //actualizarCalculos();
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
            //           actualizarCalculos();
        }

        //Ks
        private double calculoKs()
        {
            double Vred = Double.NaN;
            if (!CHB_NoUsaKs.Checked && !CHB_UsaKsLB.Checked)
            {
                Vred = Convert.ToDouble(TB_Vred.Text);
            }
            return CalibracionElec.calcularKs(sistDosimSeleccionado().Tension, lecVTotal(), lecVred(), CHB_NoUsaKs.Checked, CHB_UsaKsLB.Checked, equipoSeleccionado(), energiaSeleccionada(), Vred);
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
            //         actualizarCalculos();
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
            //         actualizarCalculos();
        }

        private void TB_Vred_Leave(object sender, EventArgs e)
        {
            esNumeroTB(sender, e);
            //           actualizarCalculos();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }



        //Referencia


        private double CalculoMref()
        {
            return CalibracionElec.CalcularMref(lecRef(), calculoKTP(), calculoKs(), calculoKpol(), Convert.ToDouble(TB_UM.Text));
        }

        private double calculoDwRef()
        {
            return CalibracionElec.CalcularDwRef(CalculoMref(), sistDosimSeleccionado());
        }

        private double calculoDwZmax()
        {
            return CalibracionElec.calcularDwZmax(calculoDwRef(), Convert.ToDouble(TB_CaliEPDDref.Text));
        }

        private double calculoDifConRef()
        {
            return CalibracionElec.calcularDifConRef(calculoDwRef(), equipoSeleccionado(), energiaSeleccionada());
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
            //         actualizarCalculos();
        }

        private void TB_UM_Leave(object sender, EventArgs e)
        {
            esNumeroTB(sender, e);
            //          actualizarCalculos();
        }

        private void LeaveCalcularDwzmax(object sender, EventArgs e)
        {
            //         actualizarCalculos();
        }

        private void actualizarCalculos()
        {

            if (CB_CaliEquipos.SelectedIndex > -1 && CB_CaliSistDosimetrico.SelectedIndex > -1 && CB_CaliEnergias.SelectedIndex > -1)
            {
                calculaKtpElec = escribirLabel(tbTemp.Text != "" && tbPresion.Text != "", calculoKTP, L_CaliEKTP);
                calculaKqq0Elec = escribirLabel(energiaSeleccionada().R50D != double.NaN && CB_CaliSistDosimetrico.SelectedIndex != -1 && !Double.IsNaN(calculokQQ0()), calculokQQ0, L_CaliEKqq0, GB_FactorDeCalidad);
                calculaKpolElec = escribirLabel((LB_LectmasVprom.Text != "Vacio" && LB_LectmenosVprom.Text != "Vacio") || CHB_UsaKpolLB.Checked == true || CHB_NoUsaKpol.Checked == true, calculoKpol, L_Kpol);
                calculaKsElec = escribirLabel((LB_lectVtotProm.Text != "Vacio" && LB_LectVredProm.Text != "Vacio" && TB_Vred.Text != "") || CHB_UsaKsLB.Checked || CHB_NoUsaKs.Checked, calculoKs, L_Ks);
                calculaMrefElec = escribirLabel(LB_LecRefProm.Text != "Vacio" && L_CaliEKTP.Text != "Vacio" && L_Ks.Text != "Vacio" && L_Kpol.Text != "Vacio" && TB_UM.Text != "", CalculoMref, L_CaliEMref);
                calculaDwzrefElec = escribirLabel(L_CaliEMref.Text != "Vacio", calculoDwRef, L_CaliEDwZref);
                calculaDwzmaxElec = escribirLabel(TB_CaliEPDDref.Text != "" && L_CaliEDwZref.Text != "Vacio", calculoDwZmax, L_CaliEDwZmax);
                calculaDifLBElec = escribirLabel(calculaDwzrefElec && hayLBsinCartel(), calculoDifConRef, L_CaliEDifLB);
                chequearKpol();
                chequearKs();
                habilitarBotonesCaliFotones();
            }
            if (CB_CaliEquipos.SelectedIndex > -1 && CB_CaliEnergias.SelectedIndex > -1)
            {
                actualizarNombrePestana();
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
            InicializarPDDref();
            inicializarR50();
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

        public void actualizarComboBoxCaliFotones(bool guardarSeleccion = false)
        {
            InicializarComboBoxSistDosim(guardarSeleccion);
            InicializarComboBoxEquipos(guardarSeleccion);
            InicializarComboBoxEnergias(guardarSeleccion);
            if (!guardarSeleccion)
            {
                inicializarLadoCampoReferencia();
                InicializarRealizadoPor();
                InicializarPDDref();
            }
        }


/*        private void chequearKqq0()
        {
            if (energiaSeleccionada().R50D != double.NaN)
            {
                CHB_EditarR50ion.Checked = false;
                TB_EnElecR50ion.Text = energiaSeleccionada().R50ion.ToString();
                TB_EnElecR50ion.Enabled = false;
            }
            else
            {
                CHB_EditarR50ion.Checked = true;
            }
            if (CHB_EditarR50ion.Checked)
            {
                TB_EnElecR50ion.Enabled = true;
                TB_EnElecR50ion.Text = "";
            }
            else
            {
                TB_EnElecR50ion.Enabled = false;
            }
        }*/

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
            /*         else if (CHB_UsaKpolLB.Checked)
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

                     }*/
            else
            {
                Panel_LecKpol.Enabled = true;
                CHB_NoUsaKpol.Enabled = true;
                CHB_UsaKpolLB.Enabled = true;
            }
            if (!chb_EditarVKpol.Checked)
            {
                if (sistDosimSeleccionado().SignoTension == 1)
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
                /*      if (!hayLB())
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
                      */
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
            if (CB_CaliEquipos.SelectedIndex == -1 || CB_CaliEnergias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir equipo, energía y condiciones de medición \npara poder cargar valores de referencia");
                return false;
            }
            else if (!CalibracionElec.hayReferencia(equipoSeleccionado(), energiaSeleccionada()))
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
            if (CB_CaliEquipos.SelectedIndex == -1 || CB_CaliEnergias.SelectedIndex == -1)
            {
                return false;
            }
            else if (!CalibracionElec.hayReferencia(equipoSeleccionado(), energiaSeleccionada()))
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
            /* if (CalibracionFot.guardar(calibracionActual(), CHB_caliElecEstablecerComoRef.Checked))
             {
                 MessageBox.Show("Calibración guardada");
                 if (MessageBox.Show("¿Desea limpiar el registro?", "Limpiar Registro", MessageBoxButtons.OKCancel) == DialogResult.OK)
                 {
                     CHB_EditarR50ion.Checked = false;
                     CHB_UsaKpolLB.Checked = false;
                     CHB_UsaKsLB.Checked = false;
                     limpiarRegistro2Niveles(Panel_CalElec);
                     actualizarComboBoxCaliFotones();
                     inicializarPredeterminados(100, 10);
                     chb_EditarVKpol.Checked = false;
                     chb_EditarVKs.Checked = false;
                     actualizarCalculos();
                     CB_caliElecRealizadoPor1.Text = "";
                     CB_caliElecRealizadoPor2.Text = "";
                     CB_caliElecRealizadoPor3.Text = "";
                 }
             }*/

        }

        /*   private CalibracionFot calibracionActual()
           {
               double difConRef = Double.NaN;
               if (hayLBsinCartel())
               {
                   difConRef = calculoDifConRef();
               }
               return CalibracionFot.crear(equipoSeleccionado(), energiaSeleccionada(), sistDosimSeleccionado(), DFSoISO(), Calcular.validarYConvertirADouble(TB_CaliLadoCampo.Text),
                   Calcular.validarYConvertirADouble(TB_CaliPRof.Text), DTP_FechaCaliElec.Value, realizadoPor(), calculoKTP(), calculoTPR2010(), calculokQQ0(), mideKqq0(), calculoKpol(), mideKpol(),
                   Calcular.validarYConvertirADouble(TB_Vred.Text), calculoKs(), mideKs(), CalculoMref(), calculoDwRef(), calculoDwZmax(),
                   Convert.ToDouble(TB_UM.Text), Convert.ToDouble(tbTemp.Text), Convert.ToDouble(tbPresion.Text), Convert.ToDouble(tbHumedad.Text),
                   lecVmas(), lecVmenos(), lecVTotal(), lecVred(), lecRef(), lec20(), lec10(), TPRoD2010(), difConRef);
           }*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            limpiarRegistro2Niveles(Panel_CalElec);
            actualizarComboBoxCaliFotones();
            inicializarPredeterminados(100, 10);
            chb_EditarVKpol.Checked = false;
            chb_EditarVKs.Checked = false;
            //actualizarCalculos();
            CB_caliElecRealizadoPor1.Text = "";
            CB_caliElecRealizadoPor2.Text = "";
            CB_caliElecRealizadoPor3.Text = "";
        }

        private void BT_ExportarCaliFot_Click(object sender, EventArgs e)
        {
            //CalibracionFot.exportarUnaCalibracion(calibracionActual());
        }

        private void habilitarBotonesCaliFotones()
        {
            habilitarBoton(calculaDwzrefElec, BT_CaliEGuardar);
            habilitarBoton(calculaDwzrefElec, Bt_ReporteVP);
            habilitarBoton(calculaDwzrefElec, BT_ReporteImp);
            habilitarBoton(calculaDwzrefElec, BT_ExportarCaliElec);
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

        private EnergiaElectrones energiaSeleccionada()
        {
            if (equipoSeleccionado().energiaFot != null && equipoSeleccionado().energiaFot.Count > 0)
            {
                return (EnergiaElectrones)CB_CaliEnergias.SelectedItem;
            }
            else
            {
                return new EnergiaElectrones();
            }
        }

        private double ladoCampoReferencia()
        {
            return energiaSeleccionada().LadoCampo;
        }
        private double profundidadDeReferencia()
        {
            return energiaSeleccionada().Zref;
        }

        private double PDDref()
        {
            return energiaSeleccionada().PDDZrefElec;
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

        private string realizadoPor()
        {
            string aux = CB_caliElecRealizadoPor1.Text;
            if (!String.IsNullOrWhiteSpace(CB_caliElecRealizadoPor2.Text))
            {
                aux += " / " + CB_caliElecRealizadoPor2.Text;
            }
            if (!String.IsNullOrWhiteSpace(CB_caliElecRealizadoPor3.Text))
            {
                aux += " / " + CB_caliElecRealizadoPor3.Text;
            }
            return aux;

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
            /*if (RB_CaliFD2010.Checked)
            {
                DoTPR2010 = 1;
            }
            if (RB_CaliFTPR2010.Checked)
            {
                DoTPR2010 = 2;
            }*/
            bool hayPDDoTPR = false;
            double dwzmaxreporte = 0;
            bool hayLB = false;
            double difLBreporte = 0;
            //        if (TB_CaliEPDDref.Text != "" || TB_CaliETMRref.Text != "")
            {
                hayPDDoTPR = true;
                //   dwzmaxreporte = calculoDwZmax();
            }
            if (true)//falta armar bien los métodos
                     //if (LineaBaseFotones.hayLineaBase(equipoSeleccionado(), energiaSeleccionada())) 
            {
                hayLB = true;
                difLBreporte = 5;
            }

            int posicionlinea = 30;
            posicionlinea = Imprimir.imprimirTituloCaliFotones(e, posicionlinea);

            posicionlinea = Imprimir.imprimirUsuarioYFecha(e, posicionlinea, realizadoPor(), DTP_FechaCaliElec.Value);
            posicionlinea += Imprimir.altoTexto;
            //posicionlinea = Imprimir.imprimirEquipo(e, posicionlinea, equipoSeleccionado(), energiaSeleccionada());
            posicionlinea += Imprimir.altoTexto;
            //posicionlinea = Imprimir.imprimirCondiciones(e, posicionlinea, DFSoISO, TB_CaliLadoCampo.Text, TB_CaliPRof.Text, TPRoPDD);
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
                //posicionlinea = Imprimir.imprimirTPRyKqq0(e, posicionlinea, promediarPanel(Panel_Lect20), promediarPanel(Panel_Lect10), TPR2010reporte, calculokQQ0(), corrigeKqq0, DoTPR2010);
                posicionlinea += Imprimir.altoTexto;
            }
            posicionlinea = Imprimir.imprimirTodoEnRef(e, posicionlinea, promediarPanel(Panel_LecRef), CalculoMref(), calculoDwRef(), dwzmaxreporte, difLBreporte, hayPDDoTPR, hayLB);
        }















        #endregion


    }
}




