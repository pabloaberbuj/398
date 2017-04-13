using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class CalibracionFot
    {
        List<string> Equipo { get; set; }
        double Energia { get; set; }
        List<string> SistemaDosim { get; set; }
        double DFSoISO { get; set; } //1 DFSfija 2 ISO
        double LadoCampo { get; set; }
        double Profundidad { get; set; }
        double Ktp { get; set; }
        DateTime Fecha { get; set; }
        string RealizadoPor { get; set; }
        double TPR2010 { get; set; }
        double Kqq0 { get; set; }
        double kpol { get; set; }
        double Vred { get; set; }
        double ks { get; set; }
        double Mref { get; set; }
        double Dwzref { get; set; }
        double Dwzmax { get; set; }
    }
}
