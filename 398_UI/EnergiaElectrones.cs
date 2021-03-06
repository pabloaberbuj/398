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
    public class EnergiaElectrones : Objeto
    {
        [DisplayName(" ")]
        public bool EsPredet { get; set; }
        [Browsable(false)]
        public double Energia { get; set; }
        [DisplayName("Energía")]
        public string Etiqueta { get; set; }
        [DisplayName("R50 I")]
        public double R50ion { get; set; }
        [DisplayName("Lado")]
        public double LadoCampo { get; set; }
        [DisplayName("R50 D")]
        public double R50D { get; set; }
        [DisplayName("Zref")]
        public double Zref { get; set; }
        [DisplayName("PDD")]
        public double PDDZrefElec { get; set; }
        [Browsable(false)]
        public string ID { get; set; }


        public static EnergiaElectrones crear(double _energia, double _lado, double _r50Ion, double _r50D, double _zRef, double _pddZref)
        {
            return new EnergiaElectrones()
            {
                Energia = _energia,
                Etiqueta = _energia.ToString(),
                LadoCampo = _lado,
                R50ion = _r50Ion,
                R50D = _r50D,
                Zref = _zRef,
                PDDZrefElec = _pddZref,
            };
        }

        public static double calcularR50D(double R50ion)
        {
            if (double.IsNaN(R50ion))
            {
                return double.NaN;
            }
            else if (R50ion <= 10)
            {
                return (Math.Round(1.029 * R50ion - 0.06, 2));
            }
            else
            {
                return Math.Round((1.059 * R50ion - 0.37), 2);
            }
        }

        public static double calcularZref(double r50D)
        {
            return Math.Round((0.6 * r50D - 0.1), 2);
        }

        public static ListaElectrones lista(DataGridView DGV)
        {
            if (DGV.Rows.Count == 0)
            {
                return new ListaElectrones();
            }
            else
            {
                return (ListaElectrones)DGV.DataSource;
            }

        }

        public static void guardar(EnergiaElectrones _nuevo, bool edita, DataGridView DGV)
        {
            if (edita)
            {
                string IDvieja = ((EnergiaElectrones)DGV.SelectedRows[0].DataBoundItem).ID;
                var auxlista = lista(DGV);
                int indice = DGV.SelectedRows[0].Index;
                bool auxPredet = auxlista[indice].EsPredet;
                auxlista.RemoveAt(indice);
                _nuevo.ID = IDvieja;
                auxlista.Insert(indice, _nuevo);
                auxlista[indice].EsPredet = auxPredet;
                DGV.DataSource = auxlista;
                DGV.ClearSelection();
                DGV.Rows[indice].Selected = true;
                edita = false;
            }
            else
            {
                if (DGV.RowCount == 0)
                {
                    _nuevo.EsPredet = true;
                }
                var auxlista = lista(DGV);
                _nuevo.ID = _nuevo.Etiqueta;
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
                    List<EnergiaElectrones> elementosARemover = new List<EnergiaElectrones>();
                    foreach (DataGridViewRow fila in DGV.SelectedRows)
                    {
                        elementosARemover.Add(auxLista[fila.Index]);
                    }
                    foreach (EnergiaElectrones ee in elementosARemover)
                    {
                        auxLista.Remove(ee);
                        if (ee.EsPredet && auxLista.Count > 0)
                        {
                            auxLista[0].EsPredet = true;
                        }
                    }
                    DGV.DataSource = auxLista;
                }
            }
        }

        public static void editar(TextBox Energia, TextBox R50Ion, TextBox Lado, Label R50D, Label Zref, TextBox PDDZref, DataGridView DGV)
        {
            EnergiaElectrones aux = lista(DGV)[DGV.SelectedRows[0].Index];
            Energia.Text = aux.Energia.ToString();
            R50Ion.Text = Calcular.stringNaN(aux.R50ion);
            Lado.Text = Calcular.stringNaN(aux.LadoCampo);
            R50D.Text = Calcular.stringNaN(aux.R50D);
            Zref.Text = Calcular.stringNaN(aux.Zref);
            PDDZref.Text = Calcular.stringNaN(aux.PDDZrefElec);
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
            DGV.Columns[2].Width = 45;
            DGV.Columns[3].Width = 45;
            DGV.Columns[4].Width = 38;
            DGV.Columns[5].Width = 38;

        }

        public override bool Equals(object obj)
        {

            if (obj == null || this.GetType() != obj.GetType() || this == null)
            {
                return false;
            }
            if (Energia == ((EnergiaElectrones)obj).Energia &&
                 R50ion == ((EnergiaElectrones)obj).R50ion &&
                 LadoCampo == ((EnergiaElectrones)obj).LadoCampo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
