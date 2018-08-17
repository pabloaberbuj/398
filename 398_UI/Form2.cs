using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace _398_UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            List<CalibracionFot> cF = new List<CalibracionFot>();
            foreach (CalibracionFot cf in CalibracionFot.lista())
            {
                cF.Add(cf);
            }
            /*foreach (CalibracionElec ce in CalibracionElec.lista())
            {
                al.Add(ce);
            }*/
            List<Calibracion> al = new List<Calibracion>(cF);
            MessageBox.Show(al.Count.ToString());

        }

    }
}
