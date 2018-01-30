using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
//using System.Web.UI.DataVisualization.Charting;


namespace _398_UI
{
    class Graficar
    {
        public static FontFamily fuente = new FontFamily("Segoe UI");

        public static void graficarXY(string titulo, List<Series> series, Chart grafico, double referencia, double tolerancia)
        {
            grafico.Legends.Clear(); grafico.ChartAreas.Clear(); grafico.Series.Clear();
            ChartArea area = new ChartArea();
            grafico.ChartAreas.Add(area);
            double xMin = series[0].Points[0].XValue;
            double xMax = series[0].Points[0].XValue;
            double yMin = series[0].Points[0].YValues[0];
            double yMax = series[0].Points[0].YValues[0];

            foreach (Series serie in series)
            {
                grafico.Series.Add(serie);
            }
            foreach (var punto in series[0].Points)
            {
                xMin = Math.Min(xMin, punto.XValue);
                xMax = Math.Max(xMax, punto.XValue);
                yMin = Math.Min(yMin, punto.YValues[0]);
                yMax = Math.Max(yMax, punto.YValues[0]);
            }
            if (!Double.IsNaN(referencia))
            {
                grafico.Series.Insert(0, crearSerieLinea(Color.Orange, xMin, xMax, referencia)); //para que vaya al fondo y no tape
                grafico.Series.Insert(0, crearSerieLinea(Color.Gray, xMin, xMax, referencia * (1 - tolerancia / 100)));
                grafico.Series.Insert(0, crearSerieLinea(Color.Gray, xMin, xMax, referencia * (1 + tolerancia / 100)));
                yMin = Math.Min(yMin, referencia * (1 - tolerancia / 100));
                yMax = Math.Max(yMax, referencia * (1 + tolerancia / 100));
                yMin = referencia - Math.Max(yMax - referencia, referencia - yMin);
                yMax = referencia + Math.Max(yMax - referencia, referencia - yMin);
            }
            area.AxisX = crearEje(xMin, xMax, series[0].Points.Count(), 10);
            area.AxisY = crearEje(yMin, yMax, series[0].Points.Count(), 10);
            Legend leyenda = new Legend()
            {
                Enabled = true,
                Docking = Docking.Right,
                MaximumAutoSize = 20,
            };
            grafico.Legends.Add(leyenda);

            foreach (Series serie in grafico.Series)
            {
                serie.XValueType = ChartValueType.DateTime;
            }
        }

        public static Series crearSerie(SeriesChartType tipo, Color color, string leyenda, bool hayLeyenda, List<DataPoint> puntos)
        {
            Series serie = new Series()
            {
                ChartType = tipo,
                LegendText = leyenda,
                IsVisibleInLegend = hayLeyenda,
                MarkerColor = color,
                MarkerSize = 8,
                MarkerStyle = MarkerStyle.Circle,
                ToolTip = "#VALY \n #VALX",
            };
            foreach (DataPoint punto in puntos)
            {
                serie.Points.Add(punto);
            }
            return serie;
        }

        public static void agregarLineaTendencia(Chart grafico, Tuple<double,double> parametros, double desde, double hasta)
        {
            Series serie = new Series()
            {
                ChartType = SeriesChartType.Line,
                LegendText = "tendencia",
                IsVisibleInLegend = true,
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.Dash,
                Color = Color.Black,
                
            };
            desde = desde - (hasta - desde) / 5;
            hasta = hasta + (hasta - desde) / 5;
            DataPoint p1 = new DataPoint(desde, parametros.Item1 * desde + parametros.Item2);
            DataPoint p2 = new DataPoint(hasta, parametros.Item1 * hasta + parametros.Item2);
            serie.Points.Add(p1);
            serie.Points.Add(p2);
            grafico.Series.Add(serie);
        }

        public static Series crearSerieLinea(Color color, double xMin, double xMax, double valor)
        {
            Series serie = new Series();
            serie.Points.Add(new DataPoint(xMin - 5, valor));
            serie.Points.Add(new DataPoint(xMax + 5, valor));
            serie.MarkerSize = 0;
            serie.IsVisibleInLegend = false;

            serie.ChartType = SeriesChartType.Line;
            serie.Color = color;
            return serie;
        }



        public static Axis crearEje(double min, double max, int numPuntos, double escala)
        {
            Axis eje = new Axis()
            {
                Minimum = Math.Floor(min - (max - min) / escala),
                Maximum = Math.Ceiling(max + (max - min) / escala),
                LineColor = Color.Black,
            };
            double intervalo = Math.Min(Math.Ceiling((max - min) / numPuntos) + 1, 5);
            eje.MajorGrid.Interval = intervalo;
            eje.MajorTickMark.Interval = intervalo;
            eje.LabelStyle.Interval = intervalo;
            //eje.IsLabelAutoFit = false;
            eje.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            eje.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            return eje;
        }

        public static void graficarRegistrosCaliFotones(BindingList<CalibracionFot> calibraciones, Chart grafico)
        {
            List<DataPoint> puntos = new List<DataPoint>();
            List<DataPoint> referencia = new List<DataPoint>();
            double DwZRef = Double.NaN;
            foreach (CalibracionFot cali in calibraciones)
            {
                if (cali.EsReferencia)
                {
                    DwZRef = cali.Dwzref;
                    DataPoint puntoRef = new DataPoint();
                    puntoRef.XValue = cali.Fecha.ToOADate();
                    puntoRef.YValues[0] = cali.Dwzref;
                    referencia.Add(puntoRef);
                }
                DataPoint punto = new DataPoint()
                {
                    XValue = cali.Fecha.ToOADate(),
                };

                punto.YValues[0] = cali.Dwzref;
                puntos.Add(punto);

            }
            List<Series> series = new List<Series>();
            Series serie = crearSerie(SeriesChartType.Point, Color.Blue, "Tasa de dosis\nen zref", true, puntos);
            series.Add(serie);
            if (!Double.IsNaN(DwZRef))
            {
                Series serieRef = crearSerie(SeriesChartType.Point, Color.Black, "Referencia", true, referencia);
                serieRef.MarkerSize = 10;
                series.Add(serieRef);
            }
            graficarXY("Titulo", series, grafico, DwZRef, 2);
        }
    }
}
