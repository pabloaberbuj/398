using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class SistemaDosimetrico:Objeto
    {
        public static string file = "sistemasdosimetricos.txt";
        public Camara camara { get; set; }
        public Electrometro electrometro { get; set; }
        public double FactorCalibracion { get; set; }
        public int SignoTension { get; set; } // -1 negativo 1 positivo
        public double Tension { get; set; }
        public string HazDeRef { get; set; } //ver si cambiar el nombre
        public double TempRef { get; set; }
        public double PresionRef { get; set; }
        public double HumedadRef { get; set; }
        public string FechaCalibracion { get; set; }
        public string LaboCalibracion { get; set; }
        public bool EsPredet { get; set; }

        public static SistemaDosimetrico crear(Camara _camara, Electrometro _electrometro, double _factorCal,
            int _signoTension, double _tension, string _hazRef, double _tempRef, double _presionRef, double _humedadRef,
            string _fechaCal, string _laboCal)
        //EsPredet inicia como false siempre
        {
            return new SistemaDosimetrico()
            {
                camara = _camara,
                electrometro = _electrometro,
                FactorCalibracion = _factorCal,
                SignoTension = _signoTension,
                Tension = _tension,
                HazDeRef = _hazRef,
                TempRef = _tempRef,
                PresionRef = _presionRef,
                HumedadRef = _humedadRef,
                FechaCalibracion = _fechaCal,
                LaboCalibracion = _laboCal,
                EsPredet = false,
            };
        }
        public static BindingList<SistemaDosimetrico> lista()
        {
            return IO.readJsonList<SistemaDosimetrico>(file);
        }
        public static void guardar(SistemaDosimetrico _nuevo)
        {
            var auxLista = lista();
            auxLista.Add(_nuevo);
            IO.writeObjectAsJson(file, auxLista);
        }

        public static void eliminar(DataGridView DGV)
        {

            if (DGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea borrar el registro?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DGV.Rows.Remove(DGV.SelectedRows[0]); IO.writeObjectAsJson(file, DGV.DataSource);
                };
            }
        }
        public static void hacerPredeterminado(DataGridView DGV)
        {
            if (DGV.SelectedRows.Count>0)
            {
                var auxLista = lista();
                foreach (var reg in auxLista)
                {
                    reg.EsPredet = false;
                }

                int aux = DGV.SelectedRows[0].Index;
                auxLista[aux].EsPredet = true;
                IO.writeObjectAsJson(file, auxLista);
                DGV.DataSource = lista();
            }
        }
    }
}
