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
        public double valorReferencia { get; set; }
        //public DateTime fechaReferencia { get; set; } Ver si poner
        public double valorPromedio { get; set; }
       // public double desviacionEstandar { get; set; } La tengo que hacer a mano. Ver fórmula
        public double valorMaximo { get; set; }
        public string fechaMaximo { get; set; }
        public double valorMinimo { get; set; }
        public string fechaMinimo { get; set; }

        public static BindingList<Analisis> analizar (BindingList<CalibracionFot> lista, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            BindingList<Analisis> listaAnalisis = new BindingList<Analisis>();
            Analisis analisis = new Analisis();
            if (CalibracionFot.hayReferencia(equipo,energia,DFSoISO))
            {
                CalibracionFot caliRef = CalibracionFot.obtenerCaliReferencia(equipo, energia, DFSoISO);
                analisis.valorReferencia = caliRef.Dwzref;
                //analisis.fechaReferencia = caliRef.Fecha;
            }
            else
            {
                analisis.valorReferencia = Double.NaN;
            }
            List<Double> valores = lista.Select(q => q.Dwzref).ToList();
            analisis.valorPromedio = Math.Round(valores.Average(),2);
            //analisis.desviacionEstandar = valores.
            analisis.valorMaximo = valores.Max();
            analisis.fechaMaximo = (lista[valores.IndexOf(valores.Max())].Fecha).ToShortDateString();
            analisis.valorMinimo = valores.Min();
            analisis.fechaMinimo = (lista[valores.IndexOf(valores.Min())].Fecha).ToShortDateString();

            listaAnalisis.Add(analisis);
            return listaAnalisis;
        }

        public static Analisis analizar2 (BindingList<CalibracionFot> lista, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            Analisis analisis = new Analisis();
            if (CalibracionFot.hayReferencia(equipo, energia, DFSoISO))
            {
                CalibracionFot caliRef = CalibracionFot.obtenerCaliReferencia(equipo, energia, DFSoISO);
                analisis.valorReferencia = caliRef.Dwzref;
                //analisis.fechaReferencia = caliRef.Fecha;
            }
            else
            {
                analisis.valorReferencia = Double.NaN;
            }
            List<Double> valores = lista.Select(q => q.Dwzref).ToList();
            analisis.valorPromedio = Math.Round(valores.Average(), 2);
            //analisis.desviacionEstandar = valores.
            analisis.valorMaximo = valores.Max();
            analisis.fechaMaximo = (lista[valores.IndexOf(valores.Max())].Fecha).ToShortDateString();
            analisis.valorMinimo = valores.Min();
            analisis.fechaMinimo = (lista[valores.IndexOf(valores.Min())].Fecha).ToShortDateString();
            return analisis;
        }

        public static void llenarDGV(Analisis analisis, DataGridView DGV)
        {
            DGV.Rows.Clear();
            DGV.Columns.Add("propiedad", null);
            DGV.Columns.Add("valor", null);
            PropertyInfo[] propiedades = analisis.GetType().GetProperties();
            {
                int i = 0;
                foreach (PropertyInfo propiedad in propiedades)
                {
                    DGV.Rows.Add();
                    DGV.Rows[i].Cells[0].Value = propiedad.Name;
                    DGV.Rows[i].Cells[1].Value = propiedad.GetValue(analisis);
                    i++;
                }
            }
        }
    }
}
