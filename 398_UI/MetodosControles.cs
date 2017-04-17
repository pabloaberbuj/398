using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace _398_UI
{
    class MetodosControles
    {
        public static void TraerPanel(int indicepanel, int nropanel, Panel nombrepanel)
        {
            if (indicepanel != nropanel)
            { nombrepanel.Visible = true; nombrepanel.BringToFront(); indicepanel = nropanel; };
        }

        public static void LimpiarRegistro(Panel panel)
        {
            foreach (TextBox tb in panel.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (ComboBox cb in panel.Controls.OfType<ComboBox>())
            { cb.Text = ""; }
        }

        public static void LimpiarRegistro(GroupBox gb)
        {
            foreach (TextBox tb in gb.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (ComboBox cb in gb.Controls.OfType<ComboBox>())
            { cb.Text= ""; }
        }
        public static double CopiarAListaD(Control objeto)
        {
            return Convert.ToDouble(objeto.Text);
        }
        public static string CopiarAListaS(Control objeto)
        {
            return objeto.Text;
        }

        public static void EliminarRegistro<T>(DataGridView DGV, BindingList<T> lista,string archivo)
        {

            if (DGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea borrar el registro?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                { DGV.Rows.Remove(DGV.SelectedRows[0]); IO.writeObjectAsJson(archivo, lista); };
            }
        }
    }
}
