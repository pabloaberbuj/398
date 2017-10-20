using System;
using System.Reflection;
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
        public static string file = @"equipos.txt";
        [DisplayName("Predeterminado")]
        public bool EsPredet { get; set; }
        public string Alias { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Browsable(false)]
        public string Etiqueta { get; set; }
        [Browsable(false)]
        public string NumSerie { get; set; }
        [Browsable(false)]
        public int Fuente { get; set; } //1 para Co 2 para Ale
        [Browsable(false)]
        public int TipoDeHaz;//inicializa 0, 0 para Co, 1 para Ale pulsado, 2 para Ale barrido y pulsado
        [Browsable(false)]
        public ListaFotones energiaFot { get; set; }
        [DisplayName("Energías Fotones")]
        public string EnergiasFotones { get; set; }
        [Browsable(false)]
        public ListaElectrones energiaElec { get; set; }
        [DisplayName("Energías Electrones")]
        public string EnergiasElectrones { get; set; }
        [DisplayName("Institucion")]
        public string Institucion { get; set; }
        [Browsable(false)]
        public string Nota { get; set; }



        public static Equipo crearAle(string _marca, string _modelo, string _numSerie, string _alias, int _fuente, int _tipoDeHaz,
             DataGridView DGVFot, DataGridView DGVElec, string _institucion)
        //EsPredet inicia como false siempre
        {
            string auxEnergiasFot = "";
            string auxEnergiasElec = "";
            ListaFotones listaF = new ListaFotones();
            if (EnergiaFotones.lista(DGVFot).Count>0)
            {
                listaF = EnergiaFotones.lista(DGVFot);
            }
            ListaElectrones listaE = new ListaElectrones();
            if (EnergiaElectrones.lista(DGVElec).Count > 0)
            {
                listaE = EnergiaElectrones.lista(DGVElec);
            }
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
                energiaFot = listaF,
                EnergiasFotones = auxEnergiasFot,
                energiaElec = listaE,
                EnergiasElectrones = auxEnergiasElec,
                Institucion = _institucion,
                Etiqueta = _marca + " " + _modelo + " " + _alias,
                Nota = "",
            };
        }

        public static Equipo crearCo(string _marca, string _modelo, string _numSerie, string _alias, int _fuente, int _tipoDeHaz,
             double zref, double lado, double PDDzref, double TMRzref, string _institucion)
        {
            return new Equipo()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie,
                Alias = _alias,
                Fuente = _fuente,
                TipoDeHaz = _tipoDeHaz,
                energiaFot = EnergiaFotones.energiaCo(zref, lado,PDDzref, TMRzref),
                EnergiasFotones = "Co",
                energiaElec = new ListaElectrones(),
                EnergiasElectrones = "",
                Institucion = _institucion,
                Etiqueta = _marca + " " + _modelo + " " + _alias,
                Nota = "",
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
                if (((Equipo)DGV.SelectedRows[0].DataBoundItem).EsPredet)
                {
                    _nuevo.EsPredet = true;
                }
                DGV.Rows.Remove(DGV.Rows[indice]); IO.writeObjectAsJson(file, DGV.DataSource);
                var auxLista = lista();
                if (auxLista.Count() == 0)
                {
                    _nuevo.EsPredet = true;
                }
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
                        if (((Equipo)fila.DataBoundItem).EsPredet)
                        {
                            hayPredet = true;
                        }
                        DGV.Rows.Remove(fila);
                    }
                    if (hayPredet && DGV.RowCount > 0)
                    { ((Equipo)DGV.Rows[0].DataBoundItem).EsPredet = true; }
                    IO.writeObjectAsJson(file, DGV.DataSource);
                };
            }
        }

        public static void editarAle(ComboBox Marca, TextBox Modelo, TextBox NumSerie, TextBox Alias, ComboBox Institucion, Panel Fuente, Panel TipoHaz,
            DataGridView DGVEnFot, DataGridView DGVEnElec, DataGridView DGVEquipo)
        {
            Equipo aux = (Equipo)DGVEquipo.SelectedRows[0].DataBoundItem;
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

        public static void editarCo(ComboBox Marca, TextBox Modelo, TextBox NumSerie, TextBox Alias, ComboBox Institucion, Panel Fuente, Panel TipoHaz,
            TextBox Zref, TextBox PDDZref, TextBox TMRZref, DataGridView DGVEquipo)
        {
            Equipo aux = (Equipo)DGVEquipo.SelectedRows[0].DataBoundItem;
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
            if (DGV.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    ((Equipo)fila.DataBoundItem).EsPredet = false;
                }

                ((Equipo)DGV.SelectedRows[0].DataBoundItem).EsPredet= true;
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
                        listaAExportar.Add((Equipo)fila.DataBoundItem);
                    }
                    IO.writeObjectAsJson(fileName, listaAExportar);
                }
                MessageBox.Show("Se han exportado " + DGV.SelectedRows.Count.ToString() + " equipos correctamente", "Exportar");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error. No se ha podido exportar\n" + e.ToString());
            }
        }

        public static BindingList<Equipo> importar(string file)
        {
            BindingList<Equipo> listaImportada = IO.readJsonList<Equipo>(file);
            BindingList<Equipo> listaFiltrada = new BindingList<Equipo>();
            try
            {
                foreach (Equipo eqImp in listaImportada)
                {
                    if (!(lista().Any(eq => eqImp.EqualsSinEsPredet(eq))))
                    {
                        listaFiltrada.Add(eqImp);
                    }
                }
                return listaFiltrada;
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido importar desde el archivo seleccionado.\nEs posible que el archivo no tenga el formato correcto");
                throw;
            }

        }

        public static void agregarImportados(BindingList<Equipo> listaFiltrada, DataGridView DGV)
        {
            try
            {
                foreach (Equipo eq in listaFiltrada)
                {
                    eq.EsPredet = false;
                    ((BindingList<Equipo>)DGV.DataSource).Add(eq);
                }
                if (DGV.Rows.Count == listaFiltrada.Count()) //no había elementos antes
                {
                    ((BindingList<Equipo>)DGV.DataSource).ElementAt(0).EsPredet = true;
                }
                MessageBox.Show("Se han agregado " + listaFiltrada.Count().ToString() + " equipos");
                IO.writeObjectAsJson(file, DGV.DataSource);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error. No se han podido importar");
                throw;
            }
        }

    }
}