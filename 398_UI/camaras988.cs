using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _398_UI
{
    class camaras398
    {
        public string marca { get; set; }
        List<string> modelos { get; set; }

    public static BindingList<camaras398> lista()
        {
            return IO.readJsonList<camaras398>("camaras3.txt");
        }
        public static List<string> listaDeMarcas()
        {
            List<string> marcas = new List<string>();
            foreach(camaras398 cam in lista())
            {
                marcas.Add(cam.marca);
            }
            return marcas;
        }
    }
}
