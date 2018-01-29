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
        public ValorARF Referencia { get; set; }
        public ValorARF Maximo { get; set; }
        public ValorARF Minimo { get; set; }
        public ValorARF Promedio { get; set; }
        public ValorARF DesvEst { get; set; }


        /*  public static BindingList<Analisis> analizar(BindingList<CalibracionFot> lista, Equipo equipo, EnergiaFotones energia, int DFSoISO)
          {
              BindingList<Analisis> listaAnalisis = new BindingList<Analisis>();
              Analisis analisis = new Analisis();
              if (CalibracionFot.hayReferencia(equipo, energia, DFSoISO))
              {
                  CalibracionFot caliRef = CalibracionFot.obtenerCaliReferencia(equipo, energia, DFSoISO);
                  analisis.valorReferenciaYFecha = caliRef.Dwzref.ToString() + " (" + caliRef.Fecha.ToShortDateString() + ")";
              }
              else
              {
                  analisis.valorReferenciaYFecha = "";
              }
              List<Double> valores = lista.Select(q => q.Dwzref).ToList();
              analisis.valorPromedio = Math.Round(valores.Average(), 2);
              //analisis.desviacionEstandar = valores.
              analisis.valorMaximoYFecha = valores.Max().ToString() + " (" + (lista[valores.IndexOf(valores.Max())].Fecha).ToShortDateString() + ")";
              analisis.valorMinimoYFecha = valores.Min().ToString() + " (" + (lista[valores.IndexOf(valores.Min())].Fecha).ToShortDateString() + ")";
              analisis.desvEstandar = Calcular.desvEstandar(valores);

              listaAnalisis.Add(analisis);
              return listaAnalisis;
          }*/

        public static Analisis analizar2(BindingList<CalibracionFot> lista, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            Analisis analisis = new Analisis();
            List<Double> valores = lista.Select(q => q.Dwzref).ToList();
            if (CalibracionFot.hayReferencia(equipo, energia, DFSoISO))
            {
                CalibracionFot caliRef = CalibracionFot.obtenerCaliReferencia(equipo, energia, DFSoISO);
                analisis.Referencia = ValorARF.crear(caliRef.Dwzref, caliRef.Dwzref, caliRef.Fecha);
            }
            else
            {
                analisis.Referencia = new ValorARF()
                {
                    absoluto = double.NaN,
                    relativo = double.NaN,
                    fecha = "",

                };
            }
            analisis.Maximo = ValorARF.crear(valores.Max(), analisis.Referencia.absoluto, (lista[valores.IndexOf(valores.Max())].Fecha));
            analisis.Minimo = ValorARF.crear(valores.Min(), analisis.Referencia.absoluto, (lista[valores.IndexOf(valores.Min())].Fecha));
            analisis.Promedio = ValorARF.crear(Math.Round(valores.Average(), 2), analisis.Referencia.absoluto);
            analisis.DesvEst = ValorARF.crear(Calcular.desvEstandar(valores), analisis.Referencia.absoluto);
            
            return analisis;
        }

        public static void llenarDGV(Analisis analisis, DataGridView DGV, Label tendencia)
        {
            DGV.Rows.Clear();
            PropertyInfo[] propiedades = analisis.GetType().GetProperties();
            foreach (PropertyInfo propiedad in propiedades)
            {
                if (propiedad.PropertyType==typeof(ValorARF))
                {
                    DGV.Rows.Add(new DataGridViewRow());
                    int i = DGV.Rows.Count-1;
                    DGV.Rows[i].Cells[0].Value = propiedad.Name;
                    DGV.Rows[i].Cells[1].Value = ((ValorARF)propiedad.GetValue(analisis)).absoluto;
                    DGV.Rows[i].Cells[2].Value = ((ValorARF)propiedad.GetValue(analisis)).relativo;
                    DGV.Rows[i].Cells[3].Value = ((ValorARF)propiedad.GetValue(analisis)).fecha;
                }
            }
            DGV.Visible = true;
            //tendencia.Text += "\n" + analisis.Tendencia.ToString() + "%/día \n " + (analisis.Tendencia*30).ToString() + "%/mes";
            tendencia.Visible = true;
        }

        public static double calcularTendencia(BindingList<CalibracionFot> lista, bool fechas, DateTime desde, DateTime hasta, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            BindingList<CalibracionFot> listaFiltrada = new BindingList<CalibracionFot>();
            if (fechas)
            {
                foreach (CalibracionFot cali in lista)
                {
                    if (DateTime.Compare(cali.Fecha.Date, desde.Date) >= 0 && DateTime.Compare(cali.Fecha.Date, hasta.Date) <= 0)
                    {
                        listaFiltrada.Add(cali);
                    }
                }
            }
            else
            {
                listaFiltrada = lista;
            }
            if (listaFiltrada.Count()==0)
            {
                MessageBox.Show("No hay calibraciones en el rango de fechas seleccionado");
                return Double.NaN;
            }
            else
            {
                List<Double> valores = listaFiltrada.Select(q => q.Dwzref).ToList();
                List<Double> fechasDouble = listaFiltrada.Select(q => q.Fecha.ToOADate()).ToList();
                if (CalibracionFot.hayReferencia(equipo, energia, DFSoISO))
                {
                    return Math.Round(Calcular.pendienteCuadradosMinimos(fechasDouble, valores) / CalibracionFot.obtenerCaliReferencia(equipo, energia, DFSoISO).Dwzref * 100, 2);
                }
                else
                {
                    return Math.Round(Calcular.pendienteCuadradosMinimos(fechasDouble, valores) / valores.Average() * 100, 2);
                }
            }
        }
    }
}