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

    public partial class Form_Equipos : Form
    {
        int indiceEquipo = 0;
        bool editaEquipo = false;
        bool editaEnergiaFot = false;
        bool editaEnergiaElect = false;
        Form1 form1;
        

        public Form_Equipos(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form_Equipos_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            //Carga DGV
            DGV_Equipo.DataSource = Equipo.lista();

            //inicializar combobox


            
            //Carga UI
            //actualizarComboBoxCaliFotones();
            //inicializarPredeterminados(100, 10);
            InicializarInstitucionYMarcaEquipo();
        }


        


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
            cb_MarcaEq.SelectedItem = -1;

            if (editaEquipo)
            {
                foreach (DataGridViewRow row in DGV_Equipo.Rows)
                {
                    row.Selected = false;
                }
                DGV_Equipo.Rows[indiceEquipo].Selected = true;
            }
            actualizarComboBoxCaliFotones(true);
            editaEquipo = false;
            Panel_TipoHazEq.Enabled = false;
            
            DGV_Equipo.Enabled = true;
            InicializarInstitucionYMarcaEquipo();
        }

        private void BT_PredetEqu_Click(object sender, EventArgs e)
        {
            Equipo.hacerPredeterminado(DGV_Equipo);
            actualizarComboBoxCaliFotones(true);
        }

        private void BT_EliminarEq_Click(object sender, EventArgs e)
        {
            Equipo.eliminar(DGV_Equipo);
            actualizarComboBoxCaliFotones(true);
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
            actualizarComboBoxCaliFotones(true);
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
            habilitarBoton(DGV_Equipo.SelectedRows.Count > 0, BT_EliminarEq);
            habilitarBoton(DGV_Equipo.SelectedRows.Count > 0, BT_ExportarEq);
        }

      /*  private void BT_EqIraCal_Click(object sender, EventArgs e)
        {
            if (DGV_Equipo.SelectedRows.Count == 1)
            {
                Equipo seleccionado = Equipo.lista()[DGV_Equipo.SelectedRows[0].Index];
                CB_CaliEquipos.SelectedIndex = CB_CaliEquipos.FindStringExact(aux);
                actualizarComboBoxCaliFotones();
                panel = traerPanel(panel, 1, Panel_CalFot, Bt_CalFot, Panel_Botones);
                BT_EqIraCal.Text = "Seleccionar e ir a calibración";
            }

        }*/

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
                L_EnElecR50dosis.Text = EnergiaElectrones.calcularR50D(Convert.ToDouble(TB_EnElecR50ion.Text)).ToString();
                L_EnElecR50dosis.Visible = true;
                L_EnElecZref.Text = EnergiaElectrones.calcularZref(Convert.ToDouble(TB_EnElecR50ion.Text)).ToString();
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
            habilitarBoton(TB_EnElecEn.Text != "" && TB_EnElecR50ion.Text!= "", BT_EnElecGuardar);
            habilitarBoton(DGV_EnElec.SelectedRows.Count == 1, BT_EnElecEditar);
            habilitarBoton(DGV_EnElec.SelectedRows.Count == 1, BT_EnElecPredet);
            habilitarBoton(DGV_EnElec.SelectedRows.Count > 0, BT_EnElecEliminar);
            habilitarEquipoBotones(sender, e);
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






        #endregion


        private void actualizarComboBoxCaliFotones(bool guardarSeleccion = false)
        {
            foreach (Form_CaliFotones cali in form1.listaFormsCaliFotones)
            {
                cali.actualizarComboBoxCaliFotones(guardarSeleccion);
            }
        }
    }
}




