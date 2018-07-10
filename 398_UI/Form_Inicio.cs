using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _398_UI
{

    public partial class Form_Inicio : Form
    {
        Form1 form1;

        public Form_Inicio(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form_Inicio_Load(object sender, EventArgs e)
        {

            MinimizeBox = false;
            MaximizeBox = false;
            //Carga DGV
            

                   }
       
    }
}




