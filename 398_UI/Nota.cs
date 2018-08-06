using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    public class Nota
    {
        public string Texto { get; set; }
        public List<string> listaImagenes { get; set; }

        public static Nota crear(string _texto, List<string> _listaImagenes)
        {
            return new Nota()
            {
                Texto = _texto,
                listaImagenes = _listaImagenes,
            };
        }
    }
}
