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
            inicializaciones();
        }









        #region Analizar Registros Inicializaciones

        private void inicializarEquipos()
        {
            foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                if (!ListBox_Equipos.Items.Contains(cali.Equipo))
                {
                    ListBox_Equipos.Items.Add(cali.Equipo);
                    ListBox_Equipos.DisplayMember = "Etiqueta";
                }
            }

            foreach (CalibracionElec cali in CalibracionElec.lista())
            {
                if (!ListBox_Equipos.Items.Contains(cali.Equipo))
                {
                    ListBox_Equipos.Items.Add(cali.Equipo);
                    ListBox_Equipos.DisplayMember = "Etiqueta";
                }
            }
        }

        private void chequeoEnergias(object sender, EventArgs e)
        {
            inicializarEnergias();
            if (RB_EnergiaFot.Checked)
            {
                CB_EnergiaFot.Enabled = true;
                CB_EnergiaFot.SelectedIndex = 0;
                GB_DFSoISO.Enabled = true;
            }
            else
            {
                CB_EnergiaFot.Enabled = false;
                CB_EnergiaFot.SelectedIndex = -1;
                GB_DFSoISO.Enabled = false;
            }
            if (RB_EnergiaElec.Checked)
            {
                CB_EnergiaElec.Enabled = true;
                CB_EnergiaElec.SelectedIndex = 0;
                RB_DFSFija.Checked = false;
                RB_Iso.Checked = false;
            }
            else
            {
                CB_EnergiaElec.Enabled = false;
                CB_EnergiaElec.SelectedIndex = -1;
            }
        }
        private void inicializarEnergias()
        {
            CB_EnergiaFot.Items.Clear();
            CB_EnergiaElec.Items.Clear();
            if (ListBox_Equipos.SelectedIndex != -1)
            {
                if (equipoSeleccionado().energiaFot.Count() > 0)
                {
                    foreach (EnergiaFotones eF in equipoSeleccionado().energiaFot)
                    {
                        CB_EnergiaFot.Items.Add(eF);
                    }
                    RB_EnergiaFot.Enabled = true;
                    if (equipoSeleccionado().energiaElec.Count == 0)
                    {
                        RB_EnergiaFot.Checked = true;
                    }
                }
                else
                {
                    RB_EnergiaFot.Enabled = false;
                }
                if (equipoSeleccionado().energiaElec.Count() > 0)
                {
                    foreach (EnergiaElectrones eE in equipoSeleccionado().energiaElec)
                    {
                        CB_EnergiaElec.Items.Add(eE);
                    }
                    RB_EnergiaElec.Enabled = true;
                    if (equipoSeleccionado().energiaFot.Count == 0)
                    {
                        RB_EnergiaElec.Checked = true;
                    }
                }
                else
                {
                    RB_EnergiaElec.Enabled = false;
                }
                CB_EnergiaFot.DisplayMember = "Etiqueta";
                CB_EnergiaElec.DisplayMember = "Etiqueta";
            }
        }

        private Equipo equipoSeleccionado()
        {
            return (Equipo)ListBox_Equipos.SelectedItem;
        }

        private EnergiaFotones energiaFotonesSeleccionada()
        {
            return (EnergiaFotones)CB_EnergiaFot.SelectedItem;
        }

        private EnergiaElectrones energiaElectronesSeleccionada()
        {
            return (EnergiaElectrones)CB_EnergiaElec.SelectedItem;
        }

        private int DFSoISO()
        {
            int DFSoISO = 0;
            if (RB_DFSFija.Checked)
            {
                DFSoISO = 1;
            }
            else if (RB_Iso.Checked)
            {
                DFSoISO = 2;
            }
            return DFSoISO;
        }


        private void inicializaciones()
        {
            inicializarEquipos();
            inicializarEnergias();
            DTPDesde.Value = primerFechaCali();
            DTPHasta.Value = ultimaFechaCali();
        }

        private void ListBox_RegistrosEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            inicializaciones();
            chequeoEnergias(sender, e);
            habilitarBotonAnalizar(sender, e);
        }

        private DateTime primerFechaCali()
        {
            DateTime primeraFecha = new DateTime(2017, 11, 8);
            if (CalibracionFot.lista().Count > 0)
            {
                primeraFecha = (CalibracionFot.lista().OrderBy(c => c.Fecha).First()).Fecha;
            }
            if (CalibracionElec.lista().Count > 0)
            {
                DateTime primeraFechaElec = (CalibracionElec.lista().OrderBy(c => c.Fecha).First()).Fecha;
                if (DateTime.Compare(primeraFechaElec, primeraFecha) < 0)
                {
                    primeraFecha = primeraFechaElec;
                }
            }
            return primeraFecha;

        }
        private DateTime ultimaFechaCali()
        {
            DateTime ultimaFecha = new DateTime(2017, 11, 8);
            if (CalibracionFot.lista().Count > 0)
            {
                ultimaFecha = (CalibracionFot.lista().OrderByDescending(c => c.Fecha).First()).Fecha;
            }
            if (CalibracionElec.lista().Count > 0)
            {
                DateTime primeraFechaElec = (CalibracionElec.lista().OrderByDescending(c => c.Fecha).First()).Fecha;
                if (DateTime.Compare(primeraFechaElec, ultimaFecha) > 0)
                {
                    ultimaFecha = primeraFechaElec;
                }
            }
            return ultimaFecha;
        }

        private BindingList<CalibracionFot> listaCalibracionesFotones()
        {
            if (CHB_Rango.Checked)
            {
                return CalibracionFot.lista(equipoSeleccionado(), energiaFotonesSeleccionada(), DFSoISO(), DTPDesde.Value, DTPHasta.Value);
            }
            else
            {
                return CalibracionFot.lista(equipoSeleccionado(), energiaFotonesSeleccionada(), DFSoISO());
            }
        }

        private BindingList<CalibracionElec> listaCalibracionesElectrones()
        {
            if (CHB_Rango.Checked)
            {
                return CalibracionElec.lista(equipoSeleccionado(), energiaElectronesSeleccionada(), DTPDesde.Value, DTPHasta.Value);
            }
            else
            {
                return CalibracionElec.lista(equipoSeleccionado(), energiaElectronesSeleccionada());
            }
        }

        private void habilitarBotonAnalizar(object sender, EventArgs e)
        {
            bool test = ((CB_EnergiaFot.SelectedIndex > -1 && (RB_DFSFija.Checked || RB_Iso.Checked)) || CB_EnergiaElec.SelectedIndex > -1);
            habilitarBoton(test, BtAnalizar);
        }



        private string stringEtiquetaLista()
        {
            string sDFSoISO = "";
            string energia = "";
            if (RB_EnergiaFot.Checked)
            {
                if (DFSoISO() == 1)
                {
                    sDFSoISO = "DFS fija";
                }
                else
                {
                    sDFSoISO = "Isocéntrica";
                }
                if (equipoSeleccionado().Fuente==2)
                {
                    energia = energiaFotonesSeleccionada().Etiqueta + "MV ";
                }
            }
            else
            {
                energia = energiaElectronesSeleccionada().Etiqueta + "MeV ";
            }
            string fechas = "";
            if (CHB_Rango.Checked)
            {
                fechas = " (desde: " + DTPDesde.Value.ToShortDateString() + " hasta: " + DTPHasta.Value.ToShortDateString()+")";
            }

            return ": " + equipoSeleccionado().Etiqueta + " " + energia + sDFSoISO + fechas;
        }
        private void ChBRegRango_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_Rango.Checked)
            {
                L_FechaHasta.Enabled = true;
                L_FechaDesde.Enabled = true;
                DTPDesde.Enabled = true;
                DTPHasta.Enabled = true;
            }
            else
            {
                L_FechaHasta.Enabled = false;
                L_FechaDesde.Enabled = false;
                DTPDesde.Enabled = false;
                DTPHasta.Enabled = false;
            }
        }

        private void CHB_RangoTendenciaRegistros_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_RangoTendencia.Checked)
            {
                DTP_TendenciaDesde.Enabled = true;
                DTP_TendenciaDesde.Value = DTPDesde.Value;
                DTP_TendenciaHasta.Enabled = true;
                DTP_TendenciaHasta.Value = DTPHasta.Value;
                L_FechaDesde.Enabled = true;
                L_FechaHasta.Enabled = true;
            }
            else
            {
                DTP_TendenciaDesde.Enabled = false;
                DTP_TendenciaHasta.Enabled = false;
                L_FechaDesde.Enabled = false;
                L_FechaHasta.Enabled = false;
            }
        }
        #endregion

        #region Analizar Registros Botones

    /*    private void BT_RegistrosResumen_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CalibracionFot.resumenCalibracion((CalibracionFot)DGV_Registros.SelectedRows[0].DataBoundItem));
        }*/

        private void BT_RegistroImportar_Click(object sender, EventArgs e) //INCORPORAR CALIELECTRONES!!!!!!!!!!!
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

        private void BT_RegistroExportar_Click(object sender, EventArgs e)//INCORPORAR CALIELECTRONES!!!!!!!!!!!
        {
            CalibracionFot.exportar(DGV_Registros);
        }

        private void BT_RegistroReferencia_Click(object sender, EventArgs e)//INCORPORAR CALIELECTRONES!!!!!!!!!!!
        {
            CalibracionFot.hacerReferencia(DGV_Registros);
            BtAnalizar_Click(sender, e);
        }

        private void BtAnalizar_Click(object sender, EventArgs e)
        {
            if (RB_EnergiaFot.Checked)
            {
                BindingList<CalibracionFot> lista = listaCalibracionesFotones();
                if (lista.Count() > 0)
                {
                    DGV_Registros.DataSource = lista;
                    DGV_Registros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    DGV_Analisis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    DGV_Analisis.BackgroundColor = DefaultBackColor;
                    DGV_Analisis.BorderStyle = BorderStyle.None;
                    Analisis.llenarDGV(Analisis.analizar2(lista, equipoSeleccionado(), energiaFotonesSeleccionada(), DFSoISO()), DGV_Analisis, L_Tendencia);
                    Graficar.graficarRegistros(lista, Chart_Registros);
                    L_Calibraciones.Text = "Calibraciones" + stringEtiquetaLista();
                    GB_Tendencia.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No existen calibraciones con las condiciones descriptas");
                    DGV_Registros.DataSource = null;
                    DGV_Analisis.DataSource = null;
                    Chart_Registros.Legends.Clear(); Chart_Registros.ChartAreas.Clear(); Chart_Registros.Series.Clear();
                    L_Calibraciones.Text = "Calibraciones";
                    GB_Tendencia.Enabled = false;
                }
                L_Tendencia.Visible = false;
            }
            else if (RB_EnergiaElec.Checked)
            {
                BindingList<CalibracionElec> lista = listaCalibracionesElectrones();
                if (lista.Count() > 0)
                {
                    DGV_Registros.DataSource = lista;
                    DGV_Registros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    DGV_Analisis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    DGV_Analisis.BackgroundColor = DefaultBackColor;
                    DGV_Analisis.BorderStyle = BorderStyle.None;
                    Analisis.llenarDGV(Analisis.analizar2(lista, equipoSeleccionado(), energiaElectronesSeleccionada()), DGV_Analisis, L_Tendencia);
                    Graficar.graficarRegistros(lista, Chart_Registros);
                    L_Calibraciones.Text = "Calibraciones" + stringEtiquetaLista();
                    GB_Tendencia.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No existen calibraciones con las condiciones descriptas");
                    DGV_Registros.DataSource = null;
                    DGV_Analisis.DataSource = null;
                    Chart_Registros.Legends.Clear(); Chart_Registros.ChartAreas.Clear(); Chart_Registros.Series.Clear();
                    L_Calibraciones.Text = "Calibraciones";
                    GB_Tendencia.Enabled = false;
                }
                L_Tendencia.Visible = false;
            }
        }

        private void BT_AnalisisRegistroTendencia_Click(object sender, EventArgs e)
        {
            double valor = Double.NaN;
            if (RB_EnergiaFot.Checked)
            {
                valor = Analisis.calcularTendencia(listaCalibracionesFotones(), CHB_RangoTendencia.Checked, DTP_TendenciaDesde.Value, DTP_TendenciaHasta.Value, equipoSeleccionado(), energiaFotonesSeleccionada(), DFSoISO(), Chart_Registros);
            }
            else if (RB_EnergiaElec.Checked)
            {
                valor = Analisis.calcularTendencia(listaCalibracionesElectrones(), CHB_RangoTendencia.Checked, DTP_TendenciaDesde.Value, DTP_TendenciaHasta.Value, equipoSeleccionado(), energiaElectronesSeleccionada(), Chart_Registros);
            }
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
            Imprimir.analisis(sender, e, equipoSeleccionado(), energiaFotonesSeleccionada(), Chart_Registros, DGV_Registros, DGV_Analisis, DFSoISO());
        }












        #endregion

        #endregion


    }
}




