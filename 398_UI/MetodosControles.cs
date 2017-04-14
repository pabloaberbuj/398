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
        public static void LimpiarRegistro(Panel panel)
        {
            foreach (TextBox tb in panel.Controls.OfType<TextBox>())
            { tb.Clear(); }
            foreach (ComboBox cb in panel.Controls.OfType<ComboBox>())
            { cb.SelectedIndex = -1; }
        }
    }
}
