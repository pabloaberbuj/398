using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _398_UI
{
    public class CalibracionSistDos
    {
        [DisplayName("NDw [cGy/nC]")]
        public double FactorCalibracion { get; set; }
        [Browsable(false)]
        public int SignoTension { get; set; } // -1 negativo 1 positivo
        [DisplayName("Tensión [V]")]
        public double Tension { get; set; }
        [Browsable(false)]
        public string HazDeRef { get; set; } //ver si cambiar el nombre
        [Browsable(false)]
        public double TempRef { get; set; }
        [Browsable(false)]
        public double PresionRef { get; set; }
        [Browsable(false)]
        public double HumedadRef { get; set; }
        [DisplayName("Fecha Calibración")]
        public string FechaCalibracion { get; set; }
        [Browsable(false)]
        public string LaboCalibracion { get; set; }
    }
}
