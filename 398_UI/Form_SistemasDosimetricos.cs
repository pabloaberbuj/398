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

    public partial class Form_SistemasDosimetricos : Form
    {
        bool editaCam = false;
        bool editaElec = false;
        Form1 form1;

        public Form_SistemasDosimetricos(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form_SistemasDosimetricos_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            //Carga DGV
            DGV_Cam.DataSource = Camara.lista();
            DGV_Elec.DataSource = Electrometro.lista();
            DGV_SistDos.DataSource = SistemaDosimetrico.lista();


            //lista de cámaras 398
            CB_MarcaCam.DataSource = Camaras398FotyElec.lista().Distinct().ToList();
            CB_MarcaCam.DisplayMember = "marca";
            CB_MarcaCam.ValueMember = "marca";
            CB_MarcaCam.SelectedIndex = 0;


            //Carga UI
            //actualizarComboBoxCaliFotones();
            //inicializarPredeterminados(100, 10);
        }

        #region SistDosimetricos UI
        private void CB_MarcaCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_MarcaCam.SelectedIndex != -1)
            {
                CB_ModCam.DataSource = Camaras398FotyElec.lista().Where(elemento => elemento.marca == CB_MarcaCam.Text).ToList();
                CB_ModCam.DisplayMember = "modelo";
            }
            else
            {
                CB_ModCam.SelectedIndex = -1;
            }
            habilitarCamBotones(sender, e);
        }

        private void camaraFuncionaParaFotonesYElectrones(Camaras398FotyElec camara)
        {
            if (camara.paraElectrones)
            {
                L_CamElectronesTrue.Visible = true;
            }
            else
            {
                L_CamElectronesTrue.Visible = false;
            }
            if (camara.paraFotones)
            {
                L_CamFotonesTrue.Visible = true;
            }
            else
            {
                L_CamFotonesTrue.Visible = false;
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
            if (CB_MarcaCam.SelectedIndex != -1 && CB_ModCam.SelectedIndex != -1)
            {
                Camaras398FotyElec camara398Seleccionada = Camaras398FotyElec.lista().Where(c => c.marca == CB_MarcaCam.Text && c.modelo == CB_ModCam.Text).FirstOrDefault();
                camaraFuncionaParaFotonesYElectrones(camara398Seleccionada);
            }
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
            actualizarComboBoxCaliFotones(true);
        }

        private void BT_EditarSistDos_Click(object sender, EventArgs e)
        {
            NuevoSistDos nsd = new NuevoSistDos(true, DGV_SistDos.SelectedRows[0].Index);
            nsd.ShowDialog();
            DGV_SistDos.DataSource = SistemaDosimetrico.lista();
            DGV_SistDos.ClearSelection();
            actualizarComboBoxCaliFotones(true);
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
            actualizarComboBoxCaliFotones();

        }

        private void BT_ExportarSistDos_Click(object sender, EventArgs e)
        {
            SistemaDosimetrico.exportar(DGV_SistDos);
        }

        private void habilitarSistDosBotones(object sender, EventArgs e)
        {
            habilitarBoton(DGV_SistDos.SelectedRows.Count == 1, BT_EditarSistDos);
            habilitarBoton(DGV_SistDos.SelectedRows.Count == 1, BT_PredSistDos);
            habilitarBoton(DGV_SistDos.SelectedRows.Count > 0, BT_EliminarSistDos);
            habilitarBoton(DGV_SistDos.SelectedRows.Count > 0, BT_ExportarSistDos);
        }

        private void actualizarComboBoxCaliFotones(bool guardarSeleccion = false)
        {
            foreach (Form_CaliFotones cali in form1.listaFormsCaliFotones)
            {
                cali.actualizarComboBoxCaliFotones(guardarSeleccion);
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

        

        
        #endregion

       

       
    }
}




