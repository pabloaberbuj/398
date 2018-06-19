using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _398_UI
{
    public partial class Auxiliar : Form
    {
        public Auxiliar()
        {
            InitializeComponent();
        }

        public static void levantarListaCam398Fot(List<Camaras398FotyElec> lista398)
        {
            string[] texto = File.ReadAllLines(@"..\..\tabla_cam398Fot.txt");
            for (int i = 0; i < texto.Length; i++)
            {
                string[] aux = texto[i].Split('\t');
                Camaras398FotyElec camaraFot = extraerCamaraFotones(aux);
                lista398.Add(camaraFot);
            }
            MessageBox.Show(lista398.Count.ToString() + " fotones");
        }

        public static void levantarListaCam398Elec(List<Camaras398FotyElec> lista398)
        {
            string[] texto = File.ReadAllLines(@"..\..\tabla_cam398Elec.txt");
            for (int i = 0; i < texto.Length; i++)
            {
                string[] aux = texto[i].Split('\t');
                Camaras398FotyElec camaraElec = extraerCamaraElectrones(aux);
                agregarALista(camaraElec, lista398);
            }
            MessageBox.Show(lista398.Count.ToString() + " totales");
        }

        public static Camaras398FotyElec extraerCamaraFotones(string[] aux)
        {
            Camaras398FotyElec camaraFot = new Camaras398FotyElec()
            {
                marca = aux[0],
                modelo = aux[1],
                submodelo = aux[2],
                paraFotones = true,
                kqq0Fot = new double[aux.Length -3],
            };
            string[] auxString = new string[aux.Length - 3];
            Array.Copy(aux, 3, auxString, 0, aux.Length - 3);
            for (int j = 0; j < auxString.Length; j++)
            {
                camaraFot.kqq0Fot[j] = Convert.ToDouble(auxString[j]);
            }
            return camaraFot;
        }

        public static Camaras398FotyElec extraerCamaraElectrones(string[] aux)
        {
            Camaras398FotyElec camaraElec = new Camaras398FotyElec()
            {
                marca = aux[0],
                modelo = aux[1],
                submodelo = aux[2],
                paraElectrones = true,
                kqq0Elec = new double[aux.Length - 3],
            };
            string[] auxString = new string[aux.Length - 3];
            Array.Copy(aux, 3, auxString, 0, aux.Length - 3);
            for (int j = 0; j < auxString.Length; j++)
            {
                if (auxString[j]=="")
                {
                    camaraElec.kqq0Elec[j] = Double.NaN;
                }
                else
                {
                    camaraElec.kqq0Elec[j] = Convert.ToDouble(auxString[j]);
                }
            }
            return camaraElec;
        }

        public static void agregarALista(Camaras398FotyElec camaraElec, List<Camaras398FotyElec> lista398)
        {
            bool pertenece = false;
            foreach (Camaras398FotyElec camara in lista398)
            {
                if (camara.marca == camaraElec.marca && camara.modelo == camaraElec.modelo)
                {
                    camara.paraElectrones = true;
                    camara.kqq0Elec = camaraElec.kqq0Elec;
                    pertenece = true;
                    break;
                }
            }
            if (pertenece == false)
            {
                lista398.Add(camaraElec);
            }
        }

        private void escribirArchivoJson(List<Camaras398FotyElec> lista, string path)
        {
            IO.writeObjectAsJson(path, lista);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string archivo = @"..\..\camaras398FotyElec.txt";
            List<Camaras398FotyElec> lista = new List<Camaras398FotyElec>();
            levantarListaCam398Fot(lista);
            levantarListaCam398Elec(lista);
            escribirArchivoJson(lista, archivo);

        }
    }
}
