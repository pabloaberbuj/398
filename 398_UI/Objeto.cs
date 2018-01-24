using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class Objeto
    {
        public override bool Equals(object obj)
        {
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            foreach (PropertyInfo propiedad in propiedades)
            {
                if (!propiedad.GetValue(this).Equals(propiedad.GetValue(obj)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
