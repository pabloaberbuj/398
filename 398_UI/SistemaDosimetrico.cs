using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class SistemaDosimetrico : Objeto
    {
        public static string file = @"..\..\sistemasdosimetricos.txt";
        [DisplayName(" ")]
        public bool EsPredet { get; set; }
        [Browsable(false)]
        public Camara camara { get; set; }
        [DisplayName("Cámara")]
        public string etiquetaCamara { get; set; }
        [Browsable(false)]
        public Electrometro electrometro { get; set; }
        [DisplayName("Electrómetro")]
        public string etiquetaElectrometro { get; set; }
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
        [DisplayName("Fecha")]
        public string FechaCalibracion { get; set; }
        [Browsable(false)]
        public string LaboCalibracion { get; set; }
        

        public static SistemaDosimetrico crear(Camara _camara, Electrometro _electrometro, double _factorCal,
            int _signoTension, double _tension, string _hazRef, double _tempRef, double _presionRef, double _humedadRef,
            string _fechaCal, string _laboCal)
        //EsPredet inicia como false siempre
        {
            return new SistemaDosimetrico()
            {
                camara = _camara,
                etiquetaCamara = _camara.EtiquetaCam,
                electrometro = _electrometro,
                etiquetaElectrometro = _electrometro.EtiquetaElec,
                FactorCalibracion = _factorCal,
                SignoTension = _signoTension,
                Tension = _tension,
                HazDeRef = _hazRef,
                TempRef = _tempRef,
                PresionRef = _presionRef,
                HumedadRef = _humedadRef,
                FechaCalibracion = _fechaCal,
                LaboCalibracion = _laboCal,
            };
        }
        public static BindingList<SistemaDosimetrico> lista()
        {
            return IO.readJsonList<SistemaDosimetrico>(file);
        }
        public static void guardar(SistemaDosimetrico _nuevo, bool edita, int indice)
        {
            var auxLista = lista();
            if (edita)
            {
                bool auxPredet = auxLista[indice].EsPredet;
                auxLista.RemoveAt(indice);
                auxLista.Insert(indice, _nuevo);
                auxLista[indice].EsPredet = auxPredet;
                IO.writeObjectAsJson(file, auxLista);
            }
            else
            {
                if (auxLista.Count() == 0)
                {
                    _nuevo.EsPredet = true;
                }
                auxLista.Add(_nuevo);
                IO.writeObjectAsJson(file, auxLista);
            }
        }

        public static void eliminar(DataGridView DGV)
        {

            if (DGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea borrar el/los registro/s?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var auxLista = lista();
                    List<SistemaDosimetrico> elementosARemover = new List<SistemaDosimetrico>();
                    foreach(DataGridViewRow fila in DGV.SelectedRows)
                    {
                        elementosARemover.Add(auxLista[fila.Index]);
                    }
                    foreach (SistemaDosimetrico sd in elementosARemover)
                    {
                        auxLista.Remove(sd);
                        if (sd.EsPredet && auxLista.Count > 0)
                        {
                            auxLista[0].EsPredet = true;
                        }
                    }
                    IO.writeObjectAsJson(file, auxLista);
                    llenarDGV(DGV);
                };
            }
        }

        public static void editar(ComboBox Camara, ComboBox Electrometro, TextBox FactorCali, ComboBox SignoTension, TextBox Tension,
            ComboBox HazRef, TextBox TempRef, TextBox PresRef, TextBox HumRef, DateTime FechaCal, TextBox LaboCalibracion,
            int indice)
        {
            SistemaDosimetrico aux = lista()[indice];
            Camara.SelectedItem = aux.camara.EtiquetaCam;
            Electrometro.SelectedItem = aux.electrometro.EtiquetaElec;
            FactorCali.Text = Convert.ToString(aux.FactorCalibracion);
            if (aux.SignoTension == 1)
            { SignoTension.SelectedItem = "+"; }
            else { SignoTension.SelectedItem = "-"; }
            Tension.Text = Convert.ToString(aux.Tension);
            HazRef.SelectedItem = aux.HazDeRef;
            TempRef.Text = Convert.ToString(aux.TempRef);
            PresRef.Text = Convert.ToString(aux.PresionRef);
            HumRef.Text = Calcular.stringNaN(aux.HumedadRef);
            FechaCal = Convert.ToDateTime(aux.FechaCalibracion);
            LaboCalibracion.Text = aux.LaboCalibracion;
        }

        public static void hacerPredeterminado(DataGridView DGV)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                var auxLista = lista();
                foreach (var reg in auxLista)
                {
                    reg.EsPredet = false;
                }

                int aux = DGV.SelectedRows[0].Index;
                auxLista[aux].EsPredet = true;
                IO.writeObjectAsJson(file, auxLista);
                llenarDGV(DGV);
                DGV.ClearSelection();
                DGV.Rows[aux].Selected = true;
            }
        }

        public static void exportar(DataGridView DGV)
        {
            try
            {
                if (DGV.SelectedRows.Count > 0)
                {
                    List<SistemaDosimetrico> listaAExportar = new List<SistemaDosimetrico>();
                    string fileName = IO.GetUniqueFilename(@"..\..\", "sistemasDosimetricosExportados");
                    foreach (DataGridViewRow fila in DGV.SelectedRows)
                    {
                        listaAExportar.Add(lista()[fila.Index]);
                    }
                    IO.writeObjectAsJson(fileName, listaAExportar);
                }
                MessageBox.Show("Se han exportado " + DGV.SelectedRows.Count.ToString() + " sistemas dosimétricos correctamente", "Exportar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error. No se ha podido exportar: " + e.ToString());
            }
        }

        public static void llenarDGV(DataGridView DGV)
        {
            DGV.DataSource = SistemaDosimetrico.lista();
            /*   DGV.DataSource = SistemaDosimetrico.lista().Select(SistemaDosimetrico => new
            {
                SistemaDosimetrico.EsPredet,
                SistemaDosimetrico.camara.EtiquetaCam,
                SistemaDosimetrico.electrometro.EtiquetaElec,
                SistemaDosimetrico.FactorCalibracion,
                SistemaDosimetrico.Tension,
                SistemaDosimetrico.TempRef,
                SistemaDosimetrico.PresionRef,
            }).ToList();*/
        }
    }
}
