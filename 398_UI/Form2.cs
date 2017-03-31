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
    public partial class Form2 : Form
    {
        double[] etiquetasX = { 1, 2, 3 };
        string[] etiquetasY = { "a0", "a1", "a2" };
        double[,] valores = { { 2, 4, 6 }, { 3, 6, 9 }, { 4, 8, 12 } };


        public Form2()
        {
            InitializeComponent();
            /* foreach (double x in etiquetasX)
             {
                 CB_X.Items.Add(x);
             }*/
            foreach (string y in etiquetasY)
            {
                CB_Y.Items.Add(y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double aux = Metodos.interpolar(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text));
            label1.Text = aux.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double XY = Metodos.interpolatabla(Convert.ToDouble(TB_Xint.Text), CB_Y.Text, etiquetasX, etiquetasY, valores);
            LB_XY.Text = XY.ToString();

        }
    }
}
