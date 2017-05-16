﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class Camara : Objeto
    {

        public static string file = "camaras.txt";
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumSerie { get; set; }
        public string EtiquetaCam { get; set; }

        public static Camara crear(string _marca, string _modelo, string _numSerie)
        {
            return new Camara()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie,
                EtiquetaCam = _marca + " " + _modelo + " " + _numSerie,
            };
        }
        public static BindingList<Camara> lista()
        {
            return IO.readJsonList<Camara>(file);
        }
        public static void guardar(Camara _nuevo)
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
        public static void darFormatoADGV(DataGridView DGV)
        {
            DGV.Columns[3].Visible = false;
        }

        
    }
}

