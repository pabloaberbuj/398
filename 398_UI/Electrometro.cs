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
        public static string file = @"..\..\electrometros.txt";
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [DisplayName("Nº de serie")]
        public string NumSerie { get; set; }
        [Browsable(false)]
        public string EtiquetaElec { get; set; }

        public static Electrometro crear(string _marca, string _modelo, string _numSerie)
        {
            return new Electrometro()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie,
                EtiquetaElec = _marca + " " + _modelo + " " + _numSerie,
            };
        }

        public static BindingList<Electrometro> lista()
        {
            return IO.readJsonList<Electrometro>(file);
        }
        public static void guardar(Electrometro _nuevo, bool edita, DataGridView DGV)
        {
            if (edita)
            {
                int indice = DGV.SelectedRows[0].Index;
                DGV.Rows.Remove(DGV.SelectedRows[0]); IO.writeObjectAsJson(file, DGV.DataSource);
                var auxLista = lista();
                auxLista.Insert(indice, _nuevo);
                IO.writeObjectAsJson(file, auxLista);
                DGV.DataSource = lista();
                DGV.ClearSelection();
                DGV.Rows[indice].Selected = true;
                edita = false;
            }
            else
            {
                var auxLista = lista();
                auxLista.Add(_nuevo);
                IO.writeObjectAsJson(file, auxLista);
                DGV.DataSource = lista();
            }
        }

        public static void eliminar(DataGridView DGV)
        {

            string mensaje = "¿Desea borrar el/los registro/s?";
            if (DGV.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.SelectedRows)
                {
                    if (SistemaDosimetrico.lista().SingleOrDefault(s => s.electrometro.EtiquetaElec == lista()[fila.Index].EtiquetaElec) != null)
                    {
                        mensaje = "Al menos una de los electrómetros seleccionados pertenece a un sistema dosimétrico \n ¿Desea borrar el/los registro/s?";
                    }
                }
                if (MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (DataGridViewRow fila in DGV.SelectedRows)
                    {
                        DGV.Rows.Remove(fila);
                    }
                    IO.writeObjectAsJson(file, DGV.DataSource);
                };
            }
        }

        public static void editar(TextBox Marca, TextBox Modelo, TextBox NumSerie, DataGridView DGV)
        {
            Electrometro aux = lista()[DGV.SelectedRows[0].Index];
            Marca.Text = aux.Marca;
            Modelo.Text = aux.Modelo;
            NumSerie.Text = aux.NumSerie;
        }

    }
}
