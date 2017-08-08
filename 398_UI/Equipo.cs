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
        [DisplayName("Predeterminado")]
        public bool EsPredet { get; set; }
        public string Alias { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Browsable(false)]
        public string NumSerie { get; set; }
        [Browsable(false)]
        public int Fuente { get; set; } //1 para Co 2 para Ale
        [Browsable(false)]
        public int TipoDeHaz;//inicializa 0, 0 para Co, 1 para Ale pulsado, 2 para Ale barrido y pulsado
        [Browsable(false)]
        public BindingList<EnergiaFotones> energiaFot { get; set; }
        [DisplayName("Energías Fotones")]
        public string EnergiasFotones { get; set; }
        [Browsable(false)]
        public BindingList<EnergiaElectrones> energiaElec { get; set; }
        [DisplayName("Energías Electrones")]
        public string EnergiasElectrones { get; set; }
        [DisplayName("Institucion")]
        public string Institucion { get; set; }



        public static Equipo crearAle(string _marca, string _modelo, string _numSerie, string _alias, int _fuente, int _tipoDeHaz,
             DataGridView DGVFot, DataGridView DGVElec, string _institucion)
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
                Institucion = _institucion,
            };
        }

        public static Equipo crearCo(string _marca, string _modelo, string _numSerie, string _alias, int _fuente, int _tipoDeHaz,
             double zref, double PDDzref, double TMRzref, string _institucion)
        {
            return new Equipo()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie,
                Alias = _alias,
                Fuente = _fuente,
                TipoDeHaz = _tipoDeHaz,
                energiaFot = EnergiaFotones.energiaCo(zref, PDDzref, TMRzref),
                EnergiasFotones = "Co",
                Institucion = _institucion,
            };
        }
        public static BindingList<Equipo> lista()
        {
            return IO.readJsonList<Equipo>(file);
        }
        public static void guardar(Equipo _nuevo, bool edita, DataGridView DGV)
        {
            if (edita)
            {
                int indice = DGV.SelectedRows[0].Index;
                DGV.Rows.Remove(DGV.Rows[indice]); IO.writeObjectAsJson(file, DGV.DataSource);
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
                if (auxLista.Count() == 0)
                {
                    _nuevo.EsPredet = true;
                }
                auxLista.Add(_nuevo);
                IO.writeObjectAsJson(file, auxLista);
                DGV.DataSource = lista();
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

        public static void editarAle(TextBox Marca, TextBox Modelo, TextBox NumSerie, TextBox Alias, TextBox Institucion, Panel Fuente, Panel TipoHaz,
            DataGridView DGVEnFot, DataGridView DGVEnElec, DataGridView DGVEquipo)
        {
            Equipo aux = lista()[DGVEquipo.SelectedRows[0].Index];
            Marca.Text = aux.Marca;
            Modelo.Text = aux.Modelo;
            NumSerie.Text = aux.NumSerie;
            Alias.Text = aux.Alias;
            Institucion.Text = aux.Institucion;
            Fuente.Controls.OfType<RadioButton>().ElementAt(1).Checked = false; //Control ALE
            Fuente.Controls.OfType<RadioButton>().ElementAt(0).Checked = true; //Control Co
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

        public static void editarCo(TextBox Marca, TextBox Modelo, TextBox NumSerie, TextBox Alias, TextBox Institucion, Panel Fuente, Panel TipoHaz,
            TextBox Zref, TextBox PDDZref, TextBox TMRZref, DataGridView DGVEquipo)
        {
            Equipo aux = lista()[DGVEquipo.SelectedRows[0].Index];
            Marca.Text = aux.Marca;
            Modelo.Text = aux.Modelo;
            NumSerie.Text = aux.NumSerie;
            Alias.Text = aux.Alias;
            Institucion.Text = aux.Institucion;
            Fuente.Controls.OfType<RadioButton>().ElementAt(1).Checked = true;
            Fuente.Controls.OfType<RadioButton>().ElementAt(0).Checked = false;
            Zref.Text = aux.energiaFot[0].ZRefFot.ToString();
            PDDZref.Text = aux.energiaFot[0].PddZrefFot.ToString();
            TMRZref.Text = aux.energiaFot[0].TmrZrefFot.ToString();
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

        public static void exportar(DataGridView DGV)
        {
            try
            {
                if (DGV.SelectedRows.Count > 0)
                {
                    List<Equipo> listaAExportar = new List<Equipo>();
                    string fileName = IO.GetUniqueFilename(@"..\..\", "equiposExportados");
                    foreach (DataGridViewRow fila in DGV.SelectedRows)
                    {
                        listaAExportar.Add(lista()[fila.Index]);
                    }
                    IO.writeObjectAsJson(fileName, listaAExportar);
                }
                MessageBox.Show("Se han exportado " + DGV.SelectedRows.Count.ToString() + " equipos correctamente", "Exportar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error. No se ha podido exportar: " + e.ToString());
            }
        }
    }
}