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
        public BindingList<EnergiaFotones> energiaFot;
        public string EnergiasFotones;
        public BindingList<EnergiaElectrones> energiaElec;
        public string EnergiasElectrones;
        public bool EsPredet;


        public static Equipo crear(string _marca, string _modelo, string _numSerie, string _alias, int _fuente, int _tipoDeHaz,
             DataGridView DGVFot, DataGridView DGVElec)
        //EsPredet inicia como false siempre
        {
            string auxEnergiasFot = "";
            string auxEnergiasElec = "";
            foreach (var energia in EnergiaFotones.lista(DGVFot))
            {
                auxEnergiasFot += energia.Energia + " ";
            }
            foreach (var energia in EnergiaElectrones.lista(DGVElec))
            {
                auxEnergiasElec += energia.Energia + "";
            }
            return new Equipo()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie,
                Alias = _alias,
                Fuente = _fuente,
                TipoDeHaz = _tipoDeHaz,
                energiaFot = EnergiaFotones.lista(DGVFot),
                EnergiasFotones = auxEnergiasFot,
                energiaElec = EnergiaElectrones.lista(DGVElec),
                EnergiasElectrones = auxEnergiasElec,
            };
        }
        public static BindingList<Equipo> lista()
        {
            return IO.readJsonList<Equipo>(file);
        }
        public static void guardar(Equipo _nuevo, bool edita, int indice)
        {
            var auxLista = lista();
            if (edita)
            {
                auxLista.RemoveAt(indice);
                auxLista.Insert(indice, _nuevo);
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
                if (MessageBox.Show("¿Desea borrar el registro?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var auxLista = lista();
                    if (auxLista[DGV.SelectedRows[0].Index].EsPredet && DGV.RowCount>1)
                    {
                        auxLista.RemoveAt(DGV.SelectedRows[0].Index);
                        auxLista[0].EsPredet = true;
                    }
                    else
                    {
                        auxLista.RemoveAt(DGV.SelectedRows[0].Index);
                    }
                    IO.writeObjectAsJson(file, auxLista);
                    llenarDGV(DGV);
                };
            }
        }

        public static void editar(TextBox Marca, TextBox Modelo, TextBox NumSerie, TextBox Alias, Panel Fuente, Panel TipoHaz,
            DataGridView DGVEnFot, DataGridView DGVEnElec, DataGridView DGVEquipo)
        {
            Equipo aux = lista()[DGVEquipo.SelectedRows[0].Index];
            Marca.Text = aux.Marca;
            Modelo.Text = aux.Modelo;
            NumSerie.Text = aux.NumSerie;
            Alias.Text = aux.Alias;
            if (aux.Fuente == 1)
            {
                Fuente.Controls.OfType<RadioButton>().ElementAt(1).Checked = true; //Control ALE
                Fuente.Controls.OfType<RadioButton>().ElementAt(0).Checked = false; //Control Co
            }
            else if (aux.Fuente == 2)
            {
                Fuente.Controls.OfType<RadioButton>().ElementAt(1).Checked = false;
                Fuente.Controls.OfType<RadioButton>().ElementAt(0).Checked = true;
            }

            if (aux.TipoDeHaz == 1)
            {
                TipoHaz.Controls.OfType<RadioButton>().ElementAt(1).Checked = true; //pulsado
                TipoHaz.Controls.OfType<RadioButton>().ElementAt(0).Checked = false; //pulsado y barrido
            }
            else if (aux.TipoDeHaz == 2)
            {
                TipoHaz.Controls.OfType<RadioButton>().ElementAt(1).Checked = false;
                TipoHaz.Controls.OfType<RadioButton>().ElementAt(0).Checked = true;
            }
            DGVEnFot.DataSource = aux.energiaFot;
            EnergiaFotones.darFormatoADGV(DGVEnFot);
            DGVEnElec.DataSource = aux.energiaElec;
            EnergiaElectrones.darFormatoADGV(DGVEnElec);

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
                DGV.DataSource = lista();
                llenarDGV(DGV);
                DGV.ClearSelection();
                DGV.Rows[aux].Selected = true;
            }
        }
        public static void llenarDGV(DataGridView DGV)
        {
            DGV.DataSource = lista().Select(Equipo => new
            {
                Equipo.EsPredet,
                Equipo.Alias,
                Equipo.Marca,
                Equipo.Modelo,
                Equipo.NumSerie,
                Equipo.EnergiasFotones,
                Equipo.EnergiasElectrones,
            }).ToList();
        }
    }
}