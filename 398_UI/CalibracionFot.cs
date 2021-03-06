﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class CalibracionFot : ICalibracion
    {
        [Browsable(false)]
        public Equipo Equipo { get; set; }
        [Browsable(false)]
        public EnergiaFotones Energia { get; set; }
        [Browsable(false)]
        public SistemaDosimetrico SistemaDosim { get; set; }

        [DisplayName("Ref")]
        public bool EsReferencia { get; set; }
        [Browsable(false)]
        public double Mref { get; set; }
        public double Dwzref { get; set; }
        public double Dwzmax { get; set; }
        [Browsable(false)]
        public double DifLB { get; set; }
        public double Ktp { get; set; }
        public double TPR2010 { get; set; }
        public double Kqq0 { get; set; }
        [Browsable(false)]
        public int mideKqq0 { get; set; } //1 si 2 usaLB
        public double kpol { get; set; }
        [Browsable(false)]
        public int mideKpol { get; set; } //1 si 2 usaLB 3 no corrige
        [Browsable(false)]
        public double Vred { get; set; }
        public double ks { get; set; }
        [Browsable(false)]
        public int mideKs { get; set; } //1 si 2 usaLB 3 no corrige
        [Browsable(false)]
        public int DFSoISO { get; set; } //1 DFSfija 2 ISO
        [DisplayName("Lado")]
        public double LadoCampo { get; set; }
        [DisplayName("Prof.")]
        public double Profundidad { get; set; }
        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }
        [DisplayName("Realizado Por")]
        public string RealizadoPor { get; set; }
        [Browsable(false)]
        public double UM { get; set; }
        [Browsable(false)]
        public double temperatura { get; set; }
        [Browsable(false)]
        public double presion { get; set; }
        [Browsable(false)]
        public double humedad { get; set; }
        [Browsable(false)]
        public double lectVmas { get; set; }
        [Browsable(false)]
        public double lectVmenos { get; set; }
        [Browsable(false)]
        public double lectVtot { get; set; }
        [Browsable(false)]
        public double lectVred { get; set; }
        [Browsable(false)]
        public double lect20 { get; set; }
        [Browsable(false)]
        public double lect10 { get; set; }
        [Browsable(false)]
        public double lectRef { get; set; }
        [Browsable(false)]
        public int DoTPR2010 { get; set; }


        public static string file = @"caliFotones.txt";


        //operaciones        

        public static BindingList<CalibracionFot> lista()
        {
            return IO.readJsonList<CalibracionFot>(file);
        }

        public static BindingList<CalibracionFot> lista(Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            var filtrada = IO.readJsonList<CalibracionFot>(file).Where(c => c.Equipo.Equals(equipo) && c.Energia.Equals(energia) && c.DFSoISO == DFSoISO).ToList();
            filtrada.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
            return new BindingList<CalibracionFot>(filtrada);
        }

        public static BindingList<CalibracionFot> lista(Equipo equipo, EnergiaFotones energia, int DFSoISO, DateTime fechaDesde, DateTime fechaHasta)
        {
            var filtrada = IO.readJsonList<CalibracionFot>(file).Where(c => c.Equipo.Equals(equipo) && c.Energia.Equals(energia) && c.DFSoISO == DFSoISO
            && DateTime.Compare(c.Fecha, fechaDesde) >= 0 && DateTime.Compare(c.Fecha, fechaHasta) <= 0).ToList();
            filtrada.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
            return new BindingList<CalibracionFot>(filtrada);
        }

        public static CalibracionFot crear(Equipo _equipo, EnergiaFotones _energia, SistemaDosimetrico _sistdos, int _DFSoISO, double _ladoCampo, double _profundidad, DateTime _fecha,
            string _realizadoPor, double _ktp, double _TPR2010, double _kqq0, int _mideKqq0, double _kpol, int _mideKpol, double _vred, double _ks, int _mideKs, double _mref, double _dwzref, double _dwzmax,
            double _um, double _temperatura, double _presion, double _humedad, double _lectVmas, double _lectVmenos, double _lectVtot, double _lectVred,
            double _lectRef, double _lect20, double _lect10, int _DoTPR2010, double _difLB)
        {
            return new CalibracionFot()
            {
                Equipo = _equipo,
                Energia = _energia,
                SistemaDosim = _sistdos,
                DFSoISO = _DFSoISO,
                LadoCampo = _ladoCampo,
                Profundidad = _profundidad,
                Fecha = _fecha,
                RealizadoPor = _realizadoPor,
                UM = _um,
                temperatura = _temperatura,
                presion = _presion,
                humedad = _humedad,
                Ktp = _ktp,
                lect10 = _lect10,
                lect20 = _lect20,
                DoTPR2010 = _DoTPR2010,
                TPR2010 = _TPR2010,
                Kqq0 = _kqq0,
                mideKqq0 = _mideKqq0,
                lectVmas = _lectVmas,
                lectVmenos = _lectVmenos,
                kpol = _kpol,
                mideKpol = _mideKpol,
                Vred = _vred,
                lectVtot = _lectVtot,
                lectVred = _lectVred,
                ks = _ks,
                mideKs = _mideKs,
                lectRef = _lectRef,
                Mref = _mref,
                Dwzref = _dwzref,
                Dwzmax = _dwzmax,
                DifLB = _difLB,
                EsReferencia = false,
            };
        }

        public static bool guardar(CalibracionFot _nuevo, bool esRef)
        {
            var auxLista = lista();
            auxLista.Add(_nuevo);
            if (esRef)
            {
                if (hayReferencia(_nuevo.Equipo, _nuevo.Energia, _nuevo.DFSoISO))
                {
                    if (MessageBox.Show("Ya existe una referencia \n ¿Desea continuar?", "Establecer Referencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        establecerComoReferencia(_nuevo, auxLista);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    establecerComoReferencia(_nuevo, auxLista);
                }
            }
            IO.writeObjectAsJson(file, auxLista);
            return true;
        }

        public static BindingList<CalibracionFot> importar(string file)
        {
            BindingList<CalibracionFot> listaImportada = IO.readJsonList<CalibracionFot>(file);
            BindingList<CalibracionFot> listaFiltrada = new BindingList<CalibracionFot>();
            try
            {
                foreach (CalibracionFot caliImp in listaImportada)
                {
                    if (!(lista().Any(cali => caliImp.Equals(cali))))
                    {
                        listaFiltrada.Add(caliImp);
                    }
                }
                return listaFiltrada;
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido importar desde el archivo seleccionado.\nEs posible que el archivo no tenga el formato correcto");
                throw;
            }
        }

        public static void agregarImportados(BindingList<CalibracionFot> listaFiltrada)
        {
            BindingList<CalibracionFot> listaAux = lista();
            try
            {
                foreach (CalibracionFot cali in listaFiltrada)
                {
                    cali.EsReferencia = false; //las calibraciones importadas no entran como referencia
                    listaAux.Add(cali);
                }
                MessageBox.Show("Se han agregado " + listaFiltrada.Count().ToString() + " calibraciones");
                IO.writeObjectAsJson(file, listaAux);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error. No se han podido importar");
                throw;
            }
        }

        public static void exportar(DataGridView DGV)
        {
            try
            {
                if (DGV.SelectedRows.Count > 0)
                {
                    List<CalibracionFot> listaAExportar = new List<CalibracionFot>();
                    string fileName = IO.GetUniqueFilename(@"..\..\", "caliFotonesExportadas");
                    foreach (DataGridViewRow fila in DGV.SelectedRows)
                    {
                        listaAExportar.Add((CalibracionFot)fila.DataBoundItem);
                    }
                    IO.writeObjectAsJson(fileName, listaAExportar);
                }
                MessageBox.Show("Se han exportado " + DGV.SelectedRows.Count.ToString() + " calibraciones correctamente", "Exportar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error. No se ha podido exportar\n" + e.ToString());
            }
        }

        public static void exportarUnaCalibracion(CalibracionFot _nuevo)
        {
            try
            {
                string fileName = IO.GetUniqueFilename(@"..\..\", "calibracionesExportadas");
                IO.writeObjectAsJson(fileName, _nuevo);

                MessageBox.Show("Se ha exportado la calibracion correctamente", "Exportar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error. No se ha podido exportar: " + e.ToString());
            }
        }

        public static void hacerReferencia(DataGridView DGV)
        {
            var auxLista = lista();
            CalibracionFot cali = (CalibracionFot)DGV.SelectedRows[0].DataBoundItem;
            if (cali.EsReferencia)
            {
                return;
            }
            if (hayReferencia(cali.Equipo, cali.Energia, cali.DFSoISO))
            {
                if (MessageBox.Show("Ya existe una referencia \n ¿Desea continuar?", "Establecer Referencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    establecerComoReferencia(cali, auxLista);
                }
            }
            else
            {
                establecerComoReferencia(cali, auxLista);
            }
            IO.writeObjectAsJson(file, auxLista);
        }

        //calculos

        public static double CalcularKtp(double T0, double T, double P0, double P)
        {
            return Math.Round((273.2 + T) * P0 / (273.2 + T0) / P, 4);
        }

        public static double calcularKpol(int signopol, double LVmas, double LVmenos, bool noUsa, bool usaLB, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            if (noUsa)
            {
                return 1;
            }
            else if (usaLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).kpol;
            }
            else
            {
                if (signopol == 1) //polaridad positiva
                {
                    return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * Math.Abs(LVmas)), 4);
                }
                else
                {
                    return Math.Round((Math.Abs(LVmas) + Math.Abs(LVmenos)) / (2 * Math.Abs(LVmenos)), 4);
                }
            }
        }

        public static double calcularKs(double Vtot, double LVtot, double LVred, bool noUsa, bool usaLB, Equipo equipo, EnergiaFotones energia, int DFSoISO, double Vred)
        {
            if (noUsa)
            {
                return 1;
            }
            else if (usaLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).ks;
            }
            else
            {
                if (equipo.Fuente == 1)//Co
                {
                    return Math.Round((Math.Pow((Vtot / Vred), 2) - 1) / (Math.Pow((Vtot / Vred), 2) - (LVtot / LVred)), 4);
                }
                else
                {
                    double a0 = 0; double a1 = 0; double a2 = 0;
                    if (equipo.TipoDeHaz == 1) //Pulsado
                    {
                        string[] fid = Tabla.Cargar(Tabla.tabla_Ks_pulsados);
                        double[] v1_v2Etiquetas = Tabla.extraerDoubleArray(fid, 0);
                        string[] a0a1a2Etiquetas = Tabla.extraerStringArray(fid, 1);
                        double[,] tabla = Tabla.extraerMatriz(fid, 3, 5, v1_v2Etiquetas.Count(), a0a1a2Etiquetas.Count());

                        a0 = Calcular.interpolatabla(Vtot / Vred, "a0", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                        a1 = Calcular.interpolatabla(Vtot / Vred, "a1", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                        a2 = Calcular.interpolatabla(Vtot / Vred, "a2", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    }
                    else
                    {
                        string[] fid = Tabla.Cargar(Tabla.tabla_Ks_pulsadosYbarridos);
                        double[] v1_v2Etiquetas = Tabla.extraerDoubleArray(fid, 0);
                        string[] a0a1a2Etiquetas = Tabla.extraerStringArray(fid, 1);
                        double[,] tabla = Tabla.extraerMatriz(fid, 3, 5, v1_v2Etiquetas.Count(), a0a1a2Etiquetas.Count());

                        a0 = Calcular.interpolatabla(Vtot / Vred, "a0", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                        a1 = Calcular.interpolatabla(Vtot / Vred, "a1", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                        a2 = Calcular.interpolatabla(Vtot / Vred, "a2", v1_v2Etiquetas, a0a1a2Etiquetas, tabla);
                    }
                    return Math.Round(a0 + a1 * Math.Abs((LVtot / LVred)) + a2 * Math.Pow((LVtot / LVred), 2), 4);
                }
            }
        }

        public static double calcularTPR2010(double LV20, double LV10, int PDDoTPR, bool usarLB, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            if (usarLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).TPR2010;
            }
            else if (PDDoTPR == 2)//está tildado D2010
            {
                double PDD20_10 = Math.Abs(LV20 / LV10);
                return Math.Round(1.2661 * PDD20_10 - 0.0595, 4);
            }
            else
            {
                return Math.Round(Math.Abs(LV20 / LV10), 4);
            }
        }

        public static double calcularKqq0(double TPR2010, Camara camara, Equipo equipo, bool usarLB, EnergiaFotones energia, int DFSoISO)
        {
            if (equipo.Fuente == 1)
            {
                return 1;
            }
            else if (usarLB)
            {
                return obtenerCaliReferencia(equipo, energia, DFSoISO).Kqq0;
            }
            else
            {
                return Math.Round(Calcular.interpolarLinea(TPR2010, Tabla.TPR2010etiquetas, camara.kqq0Fot), 4);
            }
        }
        public static double CalcularMref(double Lref, double Ktp, double Ks, double Kpol, double UMoTiempo)
        {
            return Math.Round(Math.Abs(Lref * Ktp * Ks * Kpol / UMoTiempo), 4);
        }

        public static double CalcularDwRef(double Mref, SistemaDosimetrico sistDosim)
        {
            return Math.Round(Mref * sistDosim.FactorCalibracion, 4);
        }

        public static double calcularDwZmax(double Dwref, double rendimientoEnRef)
        {
            return Math.Round(Dwref * rendimientoEnRef / 100, 4);
        }

        public static double calcularDifConRef(double Dwref, Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            double DwrefLB = obtenerCaliReferencia(equipo, energia, DFSoISO).Dwzref;
            return Math.Round((Dwref - DwrefLB) / DwrefLB * 100, 4);
        }

        //linea base

        public static bool hayReferencia(Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            bool hayRef = false;
            foreach (CalibracionFot cali in lista())
            {
                if (cali.Equipo.Equals(equipo) && cali.Energia.Equals(energia) && cali.DFSoISO.Equals(DFSoISO) && cali.EsReferencia)
                {
                    hayRef = true;
                    break;
                }
            }
            return hayRef;
        }

        public static CalibracionFot obtenerCaliReferencia(Equipo equipo, EnergiaFotones energia, int DFSoISO)
        {
            CalibracionFot caliLB = new CalibracionFot();
            foreach (CalibracionFot cali in lista())
            {
                if (cali.Equipo.Equals(equipo) && cali.Energia.Equals(energia) && cali.DFSoISO.Equals(DFSoISO) && cali.EsReferencia)
                {
                    caliLB = cali;
                    break;
                }
            }
            return caliLB;
        }

        public static void establecerComoReferencia(CalibracionFot califot, BindingList<CalibracionFot> auxLista)
        {
            foreach (CalibracionFot cali in auxLista)
            {
                if (cali.Equipo.Equals(califot.Equipo) && cali.Energia.Equals(califot.Energia) && cali.DFSoISO.Equals(califot.DFSoISO))
                {
                    cali.EsReferencia = false;
                    if (cali.Equals(califot))
                    {
                        cali.EsReferencia = true;
                        cali.DifLB = Double.NaN;
                    }
                }
            }

        }

        public static string resumenCalibracion(CalibracionFot cali) //funciona. COMPLETAR. Ver si vale la pena
        {
            return "Equipo: " + cali.Equipo.Etiqueta + "\n" +
                "Energia: " + cali.Energia.Energia.ToString() + "MV \n" +
                "Sistema Dosimétrico: " + cali.SistemaDosim.Etiqueta + "\n" +
                "Indice de calidad:\n" +
                "TPR2010 = " + cali.TPR2010.ToString() + "\n" +
                "kQQ0 = " + cali.Kqq0.ToString() + "\n" +
                "Factores:\n" +
                "kTP= " + cali.Ktp.ToString() + "\n" +
                "kpol= " + cali.kpol.ToString() + "\n" +
                "ks= " + cali.ks.ToString() + "\n\n" +

                "Mref= " + cali.Mref.ToString() + "\n" +
                "Dwzref= " + cali.Dwzref.ToString();

        }

        public override bool Equals(object obj)
        {
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            foreach (PropertyInfo propiedad in propiedades)
            {
                if (!propiedad.GetValue(this).Equals(propiedad.GetValue(obj)) && !(propiedad.Name == "EsReferencia"))
                {
                    return false;
                }
            }
            return true;
        }


        List<ICalibracion> ICalibracion.prueba()
        {
            CalibracionFot cali = new CalibracionFot();
            List<ICalibracion> lista = new List<ICalibracion>();
            lista.Add(cali);
            return lista;
        }
    }
}


