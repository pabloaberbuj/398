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
            public string Energia;
            public double ZrefFot;
            public double PddZrefFot;
            public double TmrZrefFot;
            public bool EsPredet;
        }
        public struct EnergiaElec
        {
            public string Energia;
            public double ZrefElec;
            public double PddZrefElec;
            //public double R50; // VER ESTO
            public bool EsPredet;
        }
    }
}
