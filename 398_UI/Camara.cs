using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _398_UI
{
    public class Camara
    {
        static string file = "camaras.txt";
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumSerie { get; set; }

        public static BindingList<Camara> lista()
        {
            return IO.readJsonList<Camara>(file);
        }
        public static void guardarCamara(Camara _nuevaCamara)
        {
            var auxLista = lista();
            auxLista.Add(_nuevaCamara);
            IO.writeObjectAsJson(file, auxLista);
        }
        public static Camara crearCamara(string _marca, string _modelo, string _numSerie)
        {
            return new Camara()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie
            };
        }
    }
}

        