using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class Electrometro:Objeto
    {
        public static string file = "electrometros.txt";
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumSerie { get; set; }

        public static Electrometro crear(string _marca, string _modelo, string _numSerie)
        {
            return new Electrometro()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie
            };
        }

        public static BindingList<Electrometro> lista()
        {
            return IO.readJsonList<Electrometro>(file);
        }
        public static void guardar(Electrometro _nuevo)
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
    }
}
