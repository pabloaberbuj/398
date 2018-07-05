using System;
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
        public static string file = @"camaras.txt";
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Browsable(false)]
        public string submodelo { get; set; }
        [DisplayName("Nº de serie")]
        public string NumSerie { get; set; }
        [Browsable(false)]
        public bool paraFotones { get; set; }
        [Browsable(false)]
        public double[] kqq0Fot { get; set; }
        [Browsable(false)]
        public bool paraElectrones { get; set; }
        [Browsable(false)]
        public double[] kqq0Elec { get; set; }
        [Browsable(false)]
        public string Etiqueta { get; set; }

    /*    public static Camara crear(string _marca, string _modelo, string _numSerie)
        {
            return new Camara()
            {
                Marca = _marca,
                Modelo = _modelo,
                NumSerie = _numSerie,
                Etiqueta = _marca + " " + _modelo + " " + _numSerie,
            };
        }*/

        public static Camara crear(string _marca, string _modelo, string _numSerie)
        {
            Camaras398FotyElec camara398 = Camaras398FotyElec.lista().Where(c => c.marca == _marca && c.modelo == _modelo).FirstOrDefault();
            return new Camara()
            {
                Marca = camara398.marca,
                Modelo = camara398.modelo,
                submodelo = camara398.submodelo,
                NumSerie = _numSerie,
                paraFotones = camara398.paraFotones,
                kqq0Fot = camara398.kqq0Fot,
                paraElectrones = camara398.paraElectrones,
                kqq0Elec = camara398.kqq0Elec,
                Etiqueta = camara398.marca + " " + camara398.modelo + " " + _numSerie,
            };
        }
        public static BindingList<Camara> lista()
        {
            return IO.readJsonList<Camara>(file);
        }
        public static void guardar(Camara _nuevo, bool edita, DataGridView DGV)
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
                    if (SistemaDosimetrico.lista().FirstOrDefault(s => s.camara.Equals(lista()[fila.Index])) != null)
                    {
                        mensaje = "Al menos una de las cámaras seleccionadas pertenece a un sistema dosimétrico \n ¿Desea borrar el/los registro/s?";
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

        public static void editar(ComboBox Marca, ComboBox Modelo, TextBox NumSerie, DataGridView DGV)
        {
            Camara aux = lista()[DGV.SelectedRows[0].Index];
            for (int i=0;i<Marca.Items.Count;i++)
            {
                Camaras398FotyElec item = (Camaras398FotyElec)Marca.Items[i];
                if (item.marca==aux.Marca)
                {
                    Marca.SelectedIndex = i;
                    break;
                }
            }
            var auxLista = Camaras398FotyElec.lista().Where(elemento => elemento.marca == aux.Marca).ToList();
            Modelo.DataSource = auxLista;
            Modelo.DisplayMember = "modelo";
            for (int i = 0; i < Modelo.Items.Count; i++)
            {
                Camaras398FotyElec item = (Camaras398FotyElec)Modelo.Items[i];
                if (item.modelo == aux.Modelo)
                {
                    Modelo.SelectedIndex = i;
                    break;
                }
            }
            NumSerie.Text = aux.NumSerie;
        }

        public static void importar(BindingList<SistemaDosimetrico> listSd, DataGridView DGV)
        {
            int count = 0;
            foreach (SistemaDosimetrico sd in listSd)
            {
                if (!lista().Any(cam => sd.camara.Equals(cam)))
                {
                    ((BindingList<Camara>)DGV.DataSource).Add(sd.camara);
                    count++;
                }
            }
            if (count>0)
            {
                MessageBox.Show("Se han importado " + count + "cámaras");
            }
            else
            {
                MessageBox.Show("No hay nuevas cámaras para importar");
            }
        }

     /*   public static double[] obtenerLineakQQ0(Camara camara)
        {
            return Camara398new.lista().SingleOrDefault(c => c.marca == camara.Marca && c.modelo == camara.Modelo).kqq0;
        }*/

    }
}

