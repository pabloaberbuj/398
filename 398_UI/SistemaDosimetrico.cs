using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class SistemaDosimetrico
    {
        string MarcaCam { get; set; }
        string ModeloCam { get; set; }
        string NumSerieCam { get; set; }
        string MarcaElec { get; set; }
        string ModeloElec { get; set; }
        string NumSerieElec { get; set; }
        double FactorCalibracion { get; set; }
        int SignoTension { get; set; } //1 positivo -1 negativo
        double Tension { get; set; }
        string HazDeRef { get; set; } //ver si cambiar el nombre
        double TempRef { get; set; }
        double PresionRef { get; set; }
        double Humedad { get; set; }
        DateTime FechaCalibracion { get; set; }
        string LaboCalibracion { get; set; }
        bool EsPredet { get; set; }
    }
}
