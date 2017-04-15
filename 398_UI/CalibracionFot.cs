using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class CalibracionFot
    {
        public List<string> Equipo { get; set; }
        public double Energia { get; set; }
        public List<string> SistemaDosim { get; set; }
        public double DFSoISO { get; set; } //1 DFSfija 2 ISO
        public double LadoCampo { get; set; }
        public double Profundidad { get; set; }
        public double Ktp { get; set; }
        public DateTime Fecha { get; set; }
        public string RealizadoPor { get; set; }
        public double TPR2010 { get; set; }
        public double Kqq0 { get; set; }
        public double kpol { get; set; }
        public double Vred { get; set; }
        public double ks { get; set; }
        public double Mref { get; set; }
        public double Dwzref { get; set; }
        public double Dwzmax { get; set; }
    }
}
