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

    public partial class Form_AnalizarReg : Form
    {
        Form1 form1;
        string pathExportarTablaCalibraciones = IO.GetUniqueFilename(@"..\..\", "Registros Calibraciones " + DateTime.Today.ToString("dd-MM-yyyy"));


        public Form_AnalizarReg(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form_AnalizarReg_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            inicializacionesRegistro();
        }









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

            foreach (CalibracionElec cali in CalibracionElec.lista())
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
                    && DateTime.Compare(cali.Fecha.Date, DTPRegDesde.Value.Date) >= 0 && DateTime.Compare(cali.Fecha.Date, DTPRegHasta.Value.Date) <= 0)
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
            bool test = (ListBox_RegistrosEquipos.SelectedIndex != -1 && (CB_RegistroEnergiaElec.SelectedIndex > -1 || CB_RegistroEnergiaFot.SelectedIndex > -1) && (RB_RegistroDFSFija.Checked || RB_RegistroIso.Checked));
            habilitarBoton(test, BtAnalizar);
        }



        private string stringEtiquetaLista()
        {
            string sDFSoISO = "";
            if (registroDFSoISO() == 1)
            {
                sDFSoISO = "DFS fija";
            }
            else
            {
                sDFSoISO = "Isocéntrica";
            }
            string fechas = "";
            if (ChBRegRango.Checked)
            {
                fechas = " desde: " + DTPRegDesde.Value.ToShortDateString() + " hasta: " + DTPRegHasta.Value.ToShortDateString();
            }

            return " (" + registroEquipoSeleccionado().Etiqueta + " " + registroEnergiaFotonesSeleccionada().Etiqueta + "MV " + sDFSoISO + fechas + ")";
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

        private void CHB_RangoTendenciaRegistros_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_RangoTendenciaRegistros.Checked)
            {
                DTP_TendenciaDesde.Enabled = true;
                DTP_TendenciaDesde.Value = DTPRegDesde.Value;
                DTP_TendenciaHasta.Enabled = true;
                DTP_TendenciaHasta.Value = DTPRegHasta.Value;
                L_regFechaDesde.Enabled = true;
                L_RegFechaHasta.Enabled = true;
            }
            else
            {
                DTP_TendenciaDesde.Enabled = false;
                DTP_TendenciaHasta.Enabled = false;
                L_regFechaDesde.Enabled = false;
                L_RegFechaHasta.Enabled = false;
            }
        }
        #endregion

        #region Analizar Registros Botones

        private void BT_RegistrosResumen_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CalibracionFot.resumenCalibracion((CalibracionFot)DGV_Registros.SelectedRows[0].DataBoundItem));
        }

        private void BT_RegistroImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Filter = "Archivos txt(.txt)|*.txt|All Files (*.*)|*.*"
            };
            openFileDialog1.ShowDialog();
            BindingList<CalibracionFot> listaImportada = CalibracionFot.importar(openFileDialog1.FileName);
            if (listaImportada.Count() == 0)
            {
                MessageBox.Show("No hay nuevas calibraciones para importar en el archivo seleccionado");
            }
            else
            {
                if (MessageBox.Show("Está por importar " + listaImportada.Count() + " calibraciones. ¿Continuar?", "Importar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    CalibracionFot.agregarImportados(listaImportada);
                }
            }
            BtAnalizar_Click(sender, e);
        }

        private void BT_RegistroExportar_Click(object sender, EventArgs e)
        {
            CalibracionFot.exportar(DGV_Registros);
        }

        private void BT_RegistroReferencia_Click(object sender, EventArgs e)
        {
            CalibracionFot.hacerReferencia(DGV_Registros);
            BtAnalizar_Click(sender, e);
        }

        private void BtAnalizar_Click(object sender, EventArgs e)
        {
            BindingList<CalibracionFot> lista = listaCalibracionesFotonesRegistro();
            //BindingList<Analisis> analisis = Analisis.analizar(lista, registroEquipoSeleccionado(), registroEnergiaFotonesSeleccionada(), registroDFSoISO());
            if (lista.Count() > 0)
            {
                DGV_Registros.DataSource = lista;
                DGV_Registros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DGV_Analisis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                DGV_Analisis.BackgroundColor = DefaultBackColor;
                DGV_Analisis.BorderStyle = BorderStyle.None;
                Analisis.llenarDGV(Analisis.analizar2(lista, registroEquipoSeleccionado(), registroEnergiaFotonesSeleccionada(), registroDFSoISO()), DGV_Analisis, L_Tendencia);
                Graficar.graficarRegistrosCaliFotones(lista, Chart_Registros);
                L_RegistroCalibraciones.Text = "Calibraciones" + stringEtiquetaLista();
                GB_Tendencia.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existen calibraciones con las condiciones descriptas");
                DGV_Registros.DataSource = null;
                DGV_Analisis.DataSource = null;
                Chart_Registros.Legends.Clear(); Chart_Registros.ChartAreas.Clear(); Chart_Registros.Series.Clear();
                L_RegistroCalibraciones.Text = "Calibraciones";
                GB_Tendencia.Enabled = false;
            }
            L_Tendencia.Visible = false;

        }

        private void BT_AnalisisRegistroTendencia_Click(object sender, EventArgs e)
        {
            double valor = Analisis.calcularTendencia(listaCalibracionesFotonesRegistro(), CHB_RangoTendenciaRegistros.Checked, DTP_TendenciaDesde.Value, DTP_TendenciaHasta.Value, registroEquipoSeleccionado(), registroEnergiaFotonesSeleccionada(), registroDFSoISO(), Chart_Registros);
            if (!Double.IsNaN(valor))
            {
                L_Tendencia.Visible = true;
                L_Tendencia.Text = "Tendencia: " + valor.ToString() + " %/mes";
            }
            else
            {
                L_Tendencia.Visible = false;
            }

        }

        private void BT_RegistroExportarLista_Click(object sender, EventArgs e)
        {
            IO.tablaaString(pathExportarTablaCalibraciones, DGV_Registros);
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

        #region Imprimir

        #region imprimir Analisis

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd = Imprimir.cargarConfiguracion();
            printDialog1.Document = pd;
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage_2);
            pd.PrinterSettings = printDialog1.PrinterSettings;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd = Imprimir.cargarConfiguracion();
            printPreviewDialog1.Document = pd;
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage_2);

            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage_2(object sender, PrintPageEventArgs e)
        {
            Imprimir.analisis(sender, e, registroEquipoSeleccionado(), registroEnergiaFotonesSeleccionada(), Chart_Registros, DGV_Registros, DGV_Analisis, registroDFSoISO());
        }












        #endregion

        #endregion


    }
}




