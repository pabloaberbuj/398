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
        public static List<string> listaDeMarcas()
        {
            List<string> marcas = new List<string>();
            foreach (camaras398 cam in lista())
            {
                marcas.Add(cam.marca);
            }
            return marcas;
        }

        internal static List<string> listaDeModelos(int selectedIndex)
        {
            List<string> modelosDeEstaMarca = new List<string>();
            foreach (string modelo in lista().ElementAt(selectedIndex).modelos)
            {
                modelosDeEstaMarca.Add(modelo);
            }
            return modelosDeEstaMarca;
        }
    }
}
