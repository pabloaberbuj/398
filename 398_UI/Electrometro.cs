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
        public string NumSerie { get; set; }
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
            }
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

        public static void editar(TextBox Marca, TextBox Modelo, TextBox NumSerie, DataGridView DGV)
        {
            Electrometro aux = lista()[DGV.SelectedRows[0].Index];
            Marca.Text = aux.Marca;
            Modelo.Text = aux.Modelo;
            NumSerie.Text = aux.NumSerie;
        }

        public static void darFormatoADGV(DataGridView DGV)
        {
            DGV.Columns[3].Visible = false;
            DGV.Columns[2].Name = "Nº de serie";
        }
    }
}
