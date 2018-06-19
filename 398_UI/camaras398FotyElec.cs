using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    public class Camaras398FotyElec
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public string submodelo { get; set; }
        public bool paraFotones { get; set; }
        public double[] kqq0Fot { get; set; }
        public bool paraElectrones { get; set; }
        public double[] kqq0Elec { get; set; }

        public static BindingList<Camaras398FotyElec> lista()
        {
            return IO.readJsonList<Camaras398FotyElec>(@"..\..\camaras398new.txt");
        }
        public override bool Equals(object obj) //distingue solo por marca
        {
            var objetoRecibidoCasteado = obj as Camaras398FotyElec;
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
