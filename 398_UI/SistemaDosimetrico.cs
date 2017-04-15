using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    public class SistemaDosimetrico
    {
        public string MarcaCam { get; set; }
        public string ModeloCam { get; set; }
        public string NumSerieCam { get; set; }
        public string MarcaElec { get; set; }
        public string ModeloElec { get; set; }
        public string NumSerieElec { get; set; }
        public double FactorCalibracion { get; set; }
        public double Tension { get; set; }
        public string HazDeRef { get; set; } //ver si cambiar el nombre
        public double TempRef { get; set; }
        public double PresionRef { get; set; }
        public double HumedadRef { get; set; }
        public string FechaCalibracion { get; set; }
        public string LaboCalibracion { get; set; }
        public bool EsPredet { get; set; }
    }
}
