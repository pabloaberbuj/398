using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class Analisis
    {
        [DisplayName("Referencia")]
        public string valorReferenciaYFecha { get; set; }
        //public DateTime fechaReferencia { get; set; } Ver si poner
        // public double desviacionEstandar { get; set; } La tengo que hacer a mano. Ver fórmula
        [DisplayName("Máximo")]
        public string valorMaximoYFecha { get; set; }
        [DisplayName("Mínimo")]
        public string valorMinimoYFecha { get; set; }
        [DisplayName("Promedio")]
        public double valorPromedio { get; set; }
        [DisplayName("Desv Est")]
        public double desvEstandar { get; set; }


        public static BindingList<Analisis> analizar (BindingList<CalibracionFot> lista, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            BindingList<Analisis> listaAnalisis = new BindingList<Analisis>();
            Analisis analisis = new Analisis();
            if (CalibracionFot.hayReferencia(equipo,energia,DFSoISO))
            {
                CalibracionFot caliRef = CalibracionFot.obtenerCaliReferencia(equipo, energia, DFSoISO);
                analisis.valorReferenciaYFecha = caliRef.Dwzref.ToString() + " (" + caliRef.Fecha.ToShortDateString() + ")";
            }
            else
            {
                analisis.valorReferenciaYFecha = "";
            }
            List<Double> valores = lista.Select(q => q.Dwzref).ToList();
            analisis.valorPromedio = Math.Round(valores.Average(),2);
            //analisis.desviacionEstandar = valores.
            analisis.valorMaximoYFecha = valores.Max().ToString() + " (" + (lista[valores.IndexOf(valores.Max())].Fecha).ToShortDateString() + ")";
            analisis.valorMinimoYFecha = valores.Min().ToString() + " (" + (lista[valores.IndexOf(valores.Min())].Fecha).ToShortDateString() + ")";
            analisis.desvEstandar = Calcular.desvEstandar(valores);

            listaAnalisis.Add(analisis);
            return listaAnalisis;
        }
      

    }
}
