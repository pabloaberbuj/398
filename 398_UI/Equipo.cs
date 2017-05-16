using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class Equipo : Objeto
    {
        public static string file = @"..\..\equipos.txt";
        public string Marca;
        public string Modelo;
        public string NumSerie;
        public string Alias;
        public int Fuente; //1 para Co 2 para Ale
        public int TipoDeHaz;//inicializa 0, 0 para Co, 1 para Ale pulsado, 2 para Ale barrido y pulsado
        public List<Estructuras.EnergiaFot> energiaFot;
        public List<Estructuras.EnergiaElec> energiaElec;
        public bool EsPredet;


        public static Equipo crear(string _marca, string _modelo, string _numSerie, string _alias, int _fuente, int _tipoDeHaz,
            List<Estructuras.EnergiaFot> _energiaFot, List<Estructuras.EnergiaElec> _energiaElec)
        //EsPredet inicia como false siempre
        {
            return new Equipo()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie,
                Alias = _alias,
                Fuente = _fuente,
                TipoDeHaz = _tipoDeHaz,
                energiaFot = _energiaFot,
                energiaElec = _energiaElec,
                EsPredet = false,
            };
        }
        public static BindingList<Equipo> lista()
        {
            return IO.readJsonList<Equipo>(file);
        }
        public static void guardar(Equipo _nuevo)
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
          //      llenarDGV(DGV);
            }
        }
        /*public static void llenarDGV(DataGridView DGV)
        {
            DGV.DataSource = SistemaDosimetrico.lista().Select(SistemaDosimetrico => new
            {
                SistemaDosimetrico.EsPredet,
                SistemaDosimetrico.camara.EtiquetaCam,
                SistemaDosimetrico.electrometro.EtiquetaElec,
                SistemaDosimetrico.FactorCalibracion,
                SistemaDosimetrico.Tension,
                SistemaDosimetrico.TempRef,
                SistemaDosimetrico.PresionRef,
            }).ToList();
        }*/
    }
}