using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    public class Camara398new
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public double[] kqq0 { get; set; }

        public static BindingList<Camara398new> lista()
        {
            return IO.readJsonList<Camara398new>(@"..\..\camaras398new.txt");
        }
        public override bool Equals(object obj)
        {
            var objetoRecibidoCasteado = obj as Camara398new;
            if (objetoRecibidoCasteado == null)
            {
                return false;
            }
            return this.marca == objetoRecibidoCasteado.marca;
        }
        public override int GetHashCode()
        {
            return this.marca.GetHashCode();
        }
    }
}
