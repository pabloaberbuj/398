using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _398_UI
{
    class Validar
    {

        public static bool estaLleno(string str)
        {
            return !String.IsNullOrEmpty(str);
        }

        public static bool esNumero(string str)
        {
            CultureInfo alternative = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            alternative.NumberFormat.NumberDecimalSeparator = ",";
            bool esNumero;
            esNumero = Double.TryParse(str, out double salida);
            if (!esNumero)
            {
                esNumero = Double.TryParse(str, NumberStyles.Float, alternative, out salida);
            }
            return esNumero;
        }


    }
}
