using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace _398_UI
{
    class EnergiaFotones
    {
        public string Energia { get; set; }
        public double ZRefFot { get; set; }
        public double PddZrefFot { get; set; }
        public double TmrZrefFot { get; set; }
        public bool EsPredet { get; set; }

        public static EnergiaFotones crear(string _energia, double _zRefFot, double _pddZrefFot, double _tmrZrefFot)
        {
            return new EnergiaFotones()
            {
                Energia = _energia,
                ZRefFot = _zRefFot,
                PddZrefFot = _pddZrefFot,
                TmrZrefFot = _tmrZrefFot,
                EsPredet = false,
            };
        }

        public static BindingList<EnergiaFotones> lista()
        {
            return new BindingList<EnergiaFotones>();
        }
        public static void guardar(EnergiaFotones _nuevo, bool edita, DataGridView DGV)
        {
            if (edita)
            {
                int indice = DGV.SelectedRows[0].Index;
                DGV.Rows.Remove(DGV.SelectedRows[0]);
                DGV.DataSource
                DGV.DataSource = auxLista;
            }
        }
    }
}
