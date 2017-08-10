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
    class ListaElectrones: BindingList<EnergiaElectrones>
    {
        public override bool Equals(object obj)
        {
            BindingList<EnergiaElectrones> other = obj as BindingList<EnergiaElectrones>;
            for (int i=0;i<this.Count();i++)
            {
                if (!this[i].Equals(other[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
