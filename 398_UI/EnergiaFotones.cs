﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    public class EnergiaFotones
    {
        [DisplayName(" ")]
        public bool EsPredet { get; set; }
        public double Energia { get; set; }
        [DisplayName("Zref")]
        public double ZRefFot { get; set; }
        [DisplayName("PDD")]
        public double PddZrefFot { get; set; }
        [DisplayName("TMR")]
        public double TmrZrefFot { get; set; }

        

        public static EnergiaFotones crear(double _energia, double _zRefFot, double _pddZrefFot, double _tmrZrefFot)
        {
            return new EnergiaFotones()
            {
                Energia = _energia,
                ZRefFot = _zRefFot,
                PddZrefFot = _pddZrefFot,
                TmrZrefFot = _tmrZrefFot,
            };
        }

        public static BindingList<EnergiaFotones> lista(DataGridView DGV)
        {
            if (DGV.Rows.Count == 0)
            {
                return new BindingList<EnergiaFotones>();
            }
            else
            {
                return (BindingList<EnergiaFotones>)DGV.DataSource;
            }

        }

        public static void guardar(EnergiaFotones _nuevo, bool edita, DataGridView DGV)
        {
            if (edita)
            {
                var auxlista = lista(DGV);
                int indice = DGV.SelectedRows[0].Index;
                bool auxPredet = auxlista[indice].EsPredet;
                auxlista.RemoveAt(indice);
                auxlista.Insert(indice, _nuevo);
                auxlista[indice].EsPredet = auxPredet;
                DGV.DataSource = auxlista;
                DGV.ClearSelection();
                DGV.Rows[indice].Selected = true;
                edita = false;
            }
            else
            {
                if (DGV.RowCount==0)
                {
                    _nuevo.EsPredet = true;
                }
                var auxlista = lista(DGV);
                auxlista.Add(_nuevo);
                DGV.DataSource = auxlista;
            }
            darFormatoADGV(DGV);
        }
        public static void eliminar(DataGridView DGV)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea borrar el/los registro/s?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var auxLista = lista(DGV);
                    List<EnergiaFotones> elementosARemover = new List<EnergiaFotones>();
                    foreach(DataGridViewRow fila in DGV.SelectedRows)
                    {
                        elementosARemover.Add(auxLista[fila.Index]);
                    }
                    foreach (EnergiaFotones ef in elementosARemover)
                    {
                        auxLista.Remove(ef);
                        if (ef.EsPredet && auxLista.Count>0)
                        {
                            auxLista[0].EsPredet = true;
                        }
                    }
                    DGV.DataSource = auxLista;
                }
            }
        }

        public static void editar(TextBox Energia, TextBox Zref, TextBox PDDZref, TextBox TMRZref, DataGridView DGV)
        {
            EnergiaFotones aux = lista(DGV)[DGV.SelectedRows[0].Index];
            Energia.Text = aux.Energia.ToString();
            Zref.Text = Calcular.stringNaN(aux.ZRefFot);
            PDDZref.Text = Calcular.stringNaN(aux.PddZrefFot);
            TMRZref.Text = Calcular.stringNaN(aux.TmrZrefFot);
        }

        public static BindingList<EnergiaFotones> energiaCo(double Zref, double PDDZref, double TMRZref)
        {
            BindingList<EnergiaFotones> aux = new BindingList<EnergiaFotones>
            {
                new EnergiaFotones
                {
                    Energia = 1.25,
                    ZRefFot = Zref,
                    PddZrefFot = PDDZref,
                    TmrZrefFot = TMRZref,
                    EsPredet = true,
                }
            };
            return aux;
        }

        public static void hacerPredeterminado(DataGridView DGV)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                var auxLista = lista(DGV);
                foreach (var reg in auxLista)
                {
                    reg.EsPredet = false;
                }

                int aux = DGV.SelectedRows[0].Index;
                auxLista[aux].EsPredet = true;
                DGV.DataSource = null;
                DGV.DataSource = auxLista;
                darFormatoADGV(DGV);
            }
        }
        public static void darFormatoADGV(DataGridView DGV)
        {
            DGV.Columns[0].Width = 20;
            DGV.Columns[1].Width = 50;
            DGV.Columns[2].Width = 38;
            DGV.Columns[3].Width = 38;
            DGV.Columns[4].Width = 38;
        }

    }
}
