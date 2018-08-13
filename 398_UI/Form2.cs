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
using System.Reflection;

namespace _398_UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void nuevoToolTip(PictureBox figura, string mensaje)
        {
            ToolTip tooltip = new ToolTip()
            {
                Active = true,
                UseAnimation = true,
                
            };
            tooltip.SetToolTip(figura, mensaje);
        }

        private void habilitarImagen(bool test, PictureBox figura, string texto)
        {
            if (test)
            {
                figura.Visible = true;
                nuevoToolTip(figura, texto);
            }
            else
            {
                figura.Visible = false;
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            habilitarImagen(textBox1.Text == "casa", pictureBox1,"casa");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            habilitarImagen(textBox2.Text == "perro", pictureBox2,"perro");
        }
    }
}
