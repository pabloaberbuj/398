using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _398_UI
{
    public partial class Form_Nota : Form
    {
        public Form_Nota(SistemaDosimetrico sitDos = null, Equipo equipo = null, bool creaNota = false) //si no crea es porque solo estoy viendola
        {
            InitializeComponent();
        }
    }
}
