using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _398_UI
{
    public class camaras398
    {
        public string marca { get; set; }
        public List<string> modelos { get; set; }

        public static BindingList<camaras398> lista()
        {
            return IO.readJsonList<camaras398>(@"..\..\camaras398.txt");
        }

        public static string[] listaCamaraModelo()
        {
            List<string> CamaraModelo = new List<string>();
            foreach (var Marca in (BindingList<camaras398>)lista())
            {
                foreach (var Modelo in Marca.modelos)
                {
                    CamaraModelo.Add(Marca.marca + Modelo);
                }
            }
            return CamaraModelo.ToArray();
        }
    }
            
}
