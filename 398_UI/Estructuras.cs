using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    public static class Estructuras
    {
        public struct EnergiaFot
        {
            public string Energia { get; set; }
            public double ZrefFot{ get; set; }
            public double PddZrefFot { get; set; }
            public double TmrZrefFot { get; set; } 
            public bool EsPredet { get; set; }

            public static List<EnergiaFot> crearLista()
            {
                return new List<EnergiaFot>();
            }
        }
        public struct EnergiaElec
        {
            public string Energia { get; set; }
            public double R50ionElec { get; set; }
            public double R50dosisElec { get; set; }
            public double ZrefElec { get; set; }
            public double PddZrefElec { get; set; }
            public bool EsPredet { get; set; }

            public static List<EnergiaElec> crearLista()
            {
                return new List<EnergiaElec>();
            }
        }
    }
}
