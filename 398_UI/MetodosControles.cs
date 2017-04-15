using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _398_UI
{
    class MetodosControles
    {
        public static void LimpiarRegistroPanel(Panel panel)
        {
            foreach (TextBox tb in panel.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (ComboBox cb in panel.Controls.OfType<ComboBox>())
            { cb.Text = ""; }
        }

        public static void LimpiarRegistroGroupBox(GroupBox gb)
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
    }
}
