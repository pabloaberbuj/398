using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _398_UI
{
    class Metodos
    {
        public static void promediar(Panel panel, Label texto)
        {
            double suma = 0; double aux; int contador = 0; Nullable<double> promedio = null;
            foreach (TextBox tb in panel.Controls)
            {
                if (tb.Text != "")
                {
                    bool esnumero = Double.TryParse(tb.Text, out aux);
                    if (esnumero == true)
                    { suma += aux; contador++;}
                    else { MessageBox.Show("Debe ingresarse un número"); tb.Focus(); tb.SelectAll(); break; }
                }
                if (contador != 0) { promedio = Math.Round(suma / contador,3); }
            }
            texto.Visible = true;
            texto.Text = Convert.ToString(promedio);
        }
    }
}
