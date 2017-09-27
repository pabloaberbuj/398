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
        [DisplayName("Predeterminado")]
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
        [DisplayName("Fecha Calibración")]
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
            bool hayPredet = false;
            if (DGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea borrar el/los registro/s?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (DataGridViewRow fila in DGV.SelectedRows)
                    {
                        if ((bool)fila.Cells["EsPredet"].Value == true)
                        {
                            hayPredet = true;
                        }
                        DGV.Rows.Remove(fila);
                    }
                    if (hayPredet && DGV.RowCount > 0)
                    { DGV.Rows[0].Cells["EsPredet"].Value = true; }
                    IO.writeObjectAsJson(file, DGV.DataSource);
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
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    fila.Cells["EsPredet"].Value = false;
                }

                DGV.SelectedRows[0].Cells["EsPredet"].Value = true;
                IO.writeObjectAsJson(file, DGV.DataSource);
            }
        }

        public static BindingList<SistemaDosimetrico> importar(string file)
        {
            BindingList<SistemaDosimetrico> listaImportada = IO.readJsonList<SistemaDosimetrico>(file);
            BindingList<SistemaDosimetrico> listaFiltrada = new BindingList<SistemaDosimetrico>();
            try
            {
                foreach (SistemaDosimetrico sdImp in listaImportada)
                {
                    if (!(lista().Any(sd=>sdImp.EqualsSinEsPredet(sd))))
                    {
                        listaFiltrada.Add(sdImp);
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

        public static void agregarImportados(BindingList<SistemaDosimetrico>listaFiltrada, DataGridView DGV)
        {
            try
            {
                foreach (SistemaDosimetrico sd in listaFiltrada)
                {
                    sd.EsPredet = false;
                    ((BindingList<SistemaDosimetrico>)DGV.DataSource).Add(sd);
                }
                if (DGV.Rows.Count == listaFiltrada.Count()) //no había elementos antes
                {
                    ((BindingList<SistemaDosimetrico>)DGV.DataSource).ElementAt(0).EsPredet = true;
                }
                MessageBox.Show("Se han agregado " + listaFiltrada.Count().ToString() + " Sistemas Dosimetricos");
                IO.writeObjectAsJson(file,DGV.DataSource);

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
    }
}
