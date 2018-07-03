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
        //int indiceEquipo = 0;
        int numeroPestanasCaliFotones = 0;
        //string pathExportarTablaCalibraciones = IO.GetUniqueFilename(@"..\..\", "Registros Calibraciones " + DateTime.Today.ToString("dd-MM-yyyy"));

        



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            //Carga DGV
            

            //inicializar Forms en Paneles
            Form_Equipos formEquipos = new Form_Equipos();
            formEquipos.TopLevel = false;
            Panel_Equipos.Controls.Add(formEquipos);
            formEquipos.Show();

            Form_SistemasDosimetricos formSistDos = new Form_SistemasDosimetricos();
            formSistDos.TopLevel = false;
            Panel_SistDos.Controls.Add(formSistDos);
            formSistDos.Show();

            Form_AnalizarReg formAnalizarReg = new Form_AnalizarReg();
            formAnalizarReg.TopLevel = false;
            Panel_AnalizarReg.Controls.Add(formAnalizarReg);
            formAnalizarReg.Show();

            Form_Inicio formInicio = new Form_Inicio();
            formInicio.TopLevel = false;
            Panel_Inicio.Controls.Add(formInicio);
            formInicio.Show();

            nuevaTabCaliFotones();


            //Carga UI
            Panel_AnalizarReg.Visible = false; Panel_Equipos.Visible = false;
            Panel_CalFot.Visible = false; Panel_SistDos.Visible = false;

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
            if (numeroPestanasCaliFotones==0)
            {
                nuevaTabCaliFotones();
            }
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
          /*  panel = traerPanel(panel, 3, Panel_Equipos, Bt_Equipos, Panel_Botones);
            BT_EqIraCal.Text = "Seleccionar y volver a calibración";
            Panel_Equipos.Visible = true;*/
        }

        private void btCkick_IraSistDos(object sender, EventArgs e)
        {
           /* panel = traerPanel(panel, 2, Panel_SistDos, Bt_SistDos, Panel_Botones);
            BT_SistDosIraCal.Text = "Seleccionar y volver a calibración";
            Panel_SistDos.Visible = true;*/
        }

        private void BT_EqIraCal_Click(object sender, EventArgs e)
        {
            /*if (DGV_Equipo.SelectedRows.Count == 1)
            {
                Equipo seleccionado = Equipo.lista()[DGV_Equipo.SelectedRows[0].Index];
                //string aux = seleccionado.Marca + " " + seleccionado.Modelo + " Nº Serie: " + seleccionado.NumSerie;
                //Form_CaliFotones fcf = TabC_CaliFotones.SelectedTab.Controls.OfType<Form_CaliFotones>().FirstOrDefault();


                CB_CaliEquipos.SelectedIndex = CB_CaliEquipos.FindStringExact(aux);
                actualizarComboBoxCaliFotones();
                panel = traerPanel(panel, 1, Panel_CalFot, Bt_CalFot, Panel_Botones);
                BT_EqIraCal.Text = "Seleccionar e ir a calibración";
            }*/

        }

        private void BT_SistDosIraCal_Click(object sender, EventArgs e)
        {
         /*   if (DGV_SistDos.SelectedRows.Count == 1)
            {
                SistemaDosimetrico seleccionado = SistemaDosimetrico.lista()[DGV_SistDos.SelectedRows[0].Index];
                string aux = seleccionado.camara.Etiqueta + seleccionado.electrometro.Etiqueta;
                CB_CaliSistDosimetrico.SelectedIndex = CB_CaliSistDosimetrico.FindStringExact(aux);
                panel = traerPanel(panel, 1, Panel_CalFot, Bt_CalFot, Panel_Botones);
                BT_SistDosIraCal.Text = "Seleccionar e ir a calibración";
            }*/
        }
        #endregion

        #region pestanas

        
        private void nuevaTabCaliFotones()
        {
            string nombrePestana = "tab" + numeroPestanasCaliFotones.ToString();
            string nombreForm = "form" + numeroPestanasCaliFotones.ToString();
            TabPage tabCaliFotones = new TabPage()
            {
                Name = nombrePestana,
                Text = "Nueva Calibracion",
            };
            TabC_CaliFotones.TabPages.Add(tabCaliFotones);
            TabC_CaliFotones.TabPages[nombrePestana].Controls.Add(new Form_CaliFotones()
            {
                Name = nombreForm,
                TopLevel = false,
            });
            TabC_CaliFotones.TabPages[nombrePestana].Controls[nombreForm].Show();
            TabC_CaliFotones.SelectedTab = TabC_CaliFotones.TabPages[nombrePestana];
            numeroPestanasCaliFotones++;
        }

        private void cerrarTabCaliFotones()
        {
            if (MessageBox.Show("¿Desea cerrar la calibracion","Cerrar calibracion",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                TabC_CaliFotones.TabPages.Remove(TabC_CaliFotones.SelectedTab);
                numeroPestanasCaliFotones--;
            }
            if (numeroPestanasCaliFotones==0)
            {
                nuevaTabCaliFotones();
            }

        }

        private void BT_NuevaCalFotones_Click(object sender, EventArgs e)
        {
            nuevaTabCaliFotones();
        }

        private void BT_CerrarCalFotones_Click(object sender, EventArgs e)
        {
            cerrarTabCaliFotones();
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




