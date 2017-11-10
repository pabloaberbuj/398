﻿using System;
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

        public static void graficarXY(string titulo, List<Series> series, Chart grafico, double referencia)
        {
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
            area.AxisX = crearEje(xMin, xMax, series[0].Points.Count(), 10);
            area.AxisY = crearEje(yMin, yMax, series[0].Points.Count(), 10);
            if (!Double.IsNaN(referencia))
            {
                Series serieReferencia = new Series();
                serieReferencia.Points.Add(new DataPoint(xMin-5, referencia));
                serieReferencia.Points.Add(new DataPoint(xMax+5, referencia));
                serieReferencia.MarkerSize = 0;
                
                serieReferencia.ChartType = SeriesChartType.Line;
                serieReferencia.Color = Color.Orange;
                grafico.Series.Insert(0, serieReferencia); //para que vaya al fondo y no tape
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

        public static Axis crearEje(double min, double max, int numPuntos, double escala)
        {
            Axis eje = new Axis()
            {
                Minimum = Math.Floor(min - (max - min) / escala),
                //Minimum = min,
                Maximum = Math.Ceiling(max + (max - min) / escala),
                //Maximum = max,
                LineColor = Color.Black,
            };
            eje.MajorGrid.Interval = Math.Ceiling((max-min)/numPuntos);
            eje.MajorTickMark.Interval = Math.Ceiling((max-min)/numPuntos);
            eje.LabelStyle.Interval = Math.Ceiling((max-min)/numPuntos);
            //eje.IsLabelAutoFit = false;
            eje.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            eje.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            return eje;
        }

        public static void graficarRegistrosCaliFotones(BindingList<CalibracionFot> calibraciones, Chart grafico)
        {
            grafico.ChartAreas.Clear(); grafico.Series.Clear();
            List<DataPoint> puntos = new List<DataPoint>();
            List<DataPoint> referencia = new List<DataPoint>();
            double DwZRef = Double.NaN;
            foreach (CalibracionFot cali in calibraciones)
            {
                if (cali.EsReferencia)
                {
                    DwZRef = cali.Dwzref;
                }
                DataPoint punto = new DataPoint()
                {
                    XValue = cali.Fecha.ToOADate(),
                };
                /*DataPoint puntoRef = new DataPoint()
                {
                    XValue = cali.Fecha.ToOADate(),
                };*/
                punto.YValues[0] = cali.Dwzref;
                puntos.Add(punto);
                //referencia.Add(puntoRef);
            }
            List<Series> series = new List<Series>();
            Series serie = crearSerie(SeriesChartType.Point, Color.Blue, "Tasa de dosis en referencia", true, puntos);
            series.Add(serie);
            series[0].XValueType = ChartValueType.DateTime;
          /*  if (!Double.IsNaN(DwZRef))
            {
                foreach (DataPoint puntoRef in referencia)
                {
                    puntoRef.YValues[0] = DwZRef;
                }

                Series serieRef = crearSerie(SeriesChartType.Line, Color.Orange, "Referencia", true, referencia);
                series.Add(serieRef);
                series[1].XValueType = ChartValueType.DateTime;
            }*/
            graficarXY("Titulo", series, grafico, DwZRef);
        }
     /*   public static void graficarregistros(string nombre, DateTime[] DTFecha, double[] dFecha, double[] Variable, double LBValor, Chart Grafico, double Tol, int ancho, int alto, int x, int y)
        {
            if (nombre == "Dosis Central") { Tol = Tol * LBValor / 100; }
            FontFamily fuente = new FontFamily("Segoe UI");

            Grafico.Titles.Clear(); Grafico.ChartAreas.Clear(); Grafico.Series.Clear(); Grafico.Legends.Clear();
            ChartArea Area = new ChartArea(); Grafico.ChartAreas.Add(Area);

            double Xmin; double Xmax;
            if (dFecha.Min() == dFecha.Max()) { Xmin = dFecha.Min() * 0.95; Xmax = dFecha.Min() * 1.05; }
            else { Xmin = dFecha.Min(); Xmax = dFecha.Max(); }
            double Ymin = Math.Min(Variable.Min(), LBValor - Tol); double Ymax = Math.Max(Variable.Max(), LBValor + Tol);


            Area.AxisX.Minimum = Xmin - (Xmax - Xmin) / 50;
            Area.AxisX.Maximum = Xmax + (Xmax - Xmin) / 50;
            Area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular);
            Area.AxisX.LineColor = System.Drawing.Color.Black;
            Area.AxisX.MajorGrid.Interval = Math.Ceiling(5 / (Xmax - Xmin));
            Area.AxisX.MajorTickMark.Interval = Math.Ceiling(5 / (Xmax - Xmin));
            Area.AxisX.LabelStyle.Interval = Math.Ceiling(5 / (Xmax - Xmin));
            Area.AxisX.LabelStyle.Angle = 45;
            Area.AxisX.IsLabelAutoFit = false;
            Area.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(240, 240, 240);
            Area.AxisY.Minimum = Ymin - (Ymax - Ymin) / 10;
            Area.AxisY.Maximum = Ymax + (Ymax - Ymin) / 10;
            Area.AxisY.LineColor = System.Drawing.Color.Black;
            Area.AxisY.IsLabelAutoFit = false;
            Area.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(240, 240, 240);
            Area.AxisY.LabelStyle.Format = "F3";
            Area.Position.Height = alto;
            Area.Position.Width = ancho;
            Area.Position.X = x;
            Area.Position.Y = y;




            Series SerieLB = new Series(); Grafico.Series.Add(SerieLB);
            double[] LBarray = Enumerable.Repeat(LBValor, Variable.Count()).ToArray();
            SerieLB.Points.DataBindXY(DTFecha, LBarray);
            SerieLB.ChartType = SeriesChartType.Line;
            SerieLB.Color = Color.Orange;
            SerieLB.LegendText = "Linea Base";
            SerieLB.IsVisibleInLegend = true;

            Series SerieMTol = new Series(); Grafico.Series.Add(SerieMTol);
            double[] MTolarray = Enumerable.Repeat(LBValor + Tol, Variable.Count()).ToArray();
            SerieMTol.Points.DataBindXY(DTFecha, MTolarray);
            SerieMTol.ChartType = SeriesChartType.Line;
            SerieMTol.Color = Color.Gray;
            SerieMTol.BorderDashStyle = ChartDashStyle.Dash;
            SerieMTol.LegendText = "Margenes de \n tolerancia";
            SerieMTol.IsVisibleInLegend = true;

            Series SeriemTol = new Series(); Grafico.Series.Add(SeriemTol);
            double[] mTolarray = Enumerable.Repeat(LBValor - Tol, Variable.Count()).ToArray();
            SeriemTol.Points.DataBindXY(DTFecha, mTolarray);
            SeriemTol.ChartType = SeriesChartType.Line;
            SeriemTol.Color = Color.Gray;
            SeriemTol.BorderDashStyle = ChartDashStyle.Dash;
            // SeriemTol.LegendText = "LB-Tol";
            SeriemTol.IsVisibleInLegend = false;

            Series Serievariable = new Series(); Grafico.Series.Add(Serievariable);
            Serievariable.Points.DataBindXY(DTFecha, Variable);
            Serievariable.ChartType = SeriesChartType.Point;
            Serievariable.MarkerColor = System.Drawing.Color.Blue;
            Serievariable.MarkerSize = 8;
            Serievariable.MarkerStyle = MarkerStyle.Circle;
            Serievariable.ToolTip = "#VALY \n #VALX";
            Serievariable.LegendText = "Registro";
            Serievariable.IsVisibleInLegend = true;

            Grafico.Titles.Add(nombre);
            Grafico.Titles[0].Font = new System.Drawing.Font("Segoe UI", 13, System.Drawing.FontStyle.Regular);
            Grafico.Visible = true;
            Legend leyenda = new Legend(); Grafico.Legends.Add(leyenda);
            leyenda.Docking = Docking.Right;
            leyenda.Alignment = StringAlignment.Center;
        }*/
    }
}
