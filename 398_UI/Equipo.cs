using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class Equipo
    {
        public string Marca;
        public string Modelo;
        public string NumSerie;
        public string Alias;
        public int Fuente; //1 para Co 2 para Ale
        public int TipoDeHaz;//inicializa 0, 0 para Co, 1 para Ale pulsado, 2 para Ale barrido y pulsado
        public List<double> EnergiaFot;
        public List<double> ZRefFot;
        public List<double> PddzRefFot;
        public List<double> TmrzRefFot;
        public double EnergiaFotPredet;
        public List<double> EnergiaElec;
        public List<double> ZRefElec;
        public List<double> PddzRefElec;
        public double EnergiaElecPredet;
        public bool EsPredet;
    }
}
