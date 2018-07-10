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
        int numeroPestanasCaliFotones = 0;
        public Form_AnalizarReg formAnalizarReg;
        public Form_Equipos formEquipos;
        public Form_SistemasDosimetricos formSistemasDosimetricos;
        public Form_Inicio formInicio;
        public List<Form_CaliFotones> listaFormsCaliFotones = new List<Form_CaliFotones>();
        public Form_CaliFotones formCaliFotones1;

        //string pathExportarTablaCalibraciones = IO.GetUniqueFilename(@"..\..\", "Registros Calibraciones " + DateTime.Today.ToString("dd-MM-yyyy"));

        public Form1()
        {
            InitializeComponent();
            //inicializar Forms en Paneles
            formEquipos = (Form_Equipos)cargarForm(f => new Form_Equipos(this), "Form_Equipos", Panel_Equipos);
            formAnalizarReg = (Form_AnalizarReg)cargarForm(f => new Form_AnalizarReg(this), "Form_AnalizarReg", Panel_AnalizarReg);
            formInicio = (Form_Inicio)cargarForm(f => new Form_Inicio(this), "Form_Inicio", Panel_Inicio);
            formSistemasDosimetricos = (Form_SistemasDosimetricos)cargarForm(f => new Form_SistemasDosimetricos(this), "Form_SistemasDosimetricos", Panel_SistDos);
            formCaliFotones1 = nuevaTabCaliFotones();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;

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
            foreach (TabPage tab in TabC_CaliFotones.TabPages)
            {
                Form_CaliFotones form = tab.Controls.OfType<Form_CaliFotones>().FirstOrDefault();
                form.inicializarDesdeAfuera();
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

        private Form cargarForm(Func<string, Form> formConstructor, string formNombre, Panel panel)
        {
            Form form = formConstructor(formNombre);
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.Show();

            return form;
        }

        #endregion

        #region pestanas

        
        private Form_CaliFotones nuevaTabCaliFotones()
        {
            string nombrePestana = "tab" + numeroPestanasCaliFotones.ToString();
            string nombreForm = "formCaliFotones" + numeroPestanasCaliFotones.ToString();
            TabPage tabCaliFotones = new TabPage()
            {
                Name = nombrePestana,
                Text = "Nueva Calibracion",
            };
            TabC_CaliFotones.TabPages.Add(tabCaliFotones);
            Form_CaliFotones formCF = new Form_CaliFotones(this)
            {
                Name = nombreForm,
                TopLevel = false,
            };

            TabC_CaliFotones.TabPages[nombrePestana].Controls.Add(formCF);
            TabC_CaliFotones.TabPages[nombrePestana].Controls[nombreForm].Show();
            TabC_CaliFotones.SelectedTab = TabC_CaliFotones.TabPages[nombrePestana];
            numeroPestanasCaliFotones++;
            listaFormsCaliFotones.Add(formCF);
            return formCF;
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




