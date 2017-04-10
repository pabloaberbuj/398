using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class Equipo
    {
        string Marca;
        string Modelo;
        string NumSerie;
        string Alias;
        int Fuente; //1 para Co 2 para Ale
        int TipoDeHaz;//inicializa 0, 0 para Co, 1 para Ale pulsado, 2 para Ale barrido y pulsado
        List<double> EnergiaFot;
        List<double> ZRefFot;
        List<double> PddzRefFot;
        List<double> TmrzRefFot;
        double EnergiaFotPredet;
        List<double> EnergiaElec;
        List<double> ZRefElec;
        List<double> PddzRefElec;
        double EnergiaElecPredet;
        bool EsPredet;
    }
}
