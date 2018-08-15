using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _398_UI
{
    public static class ToolTips
    {
        public static string stringErrorInterpolacion = "Uno o más valores están fuera del rango.\nNo se puede interpolar";
        public static string stringErrorkQQ0Elec = "El valor de kQQ0 no se puede obtener para esa combinación de cámara y haz.\nRevisar que la cámara esté recomendada para esa calidad de haz";
        public static string stringErrorkQQ0Fot = "El valor de kQQ0 no se puede obtener para esa combinación de cámara y haz. \n Revisar las lecturas a 20cm y 10cm y la cámara elegida";
        public static System.Drawing.Image imagenError = Resources.error;
        public static System.Drawing.Image imagenAdvertencia = Resources.advertencia;
        public static System.Drawing.Image imagenInformacion = Resources.informacion;
        public static List<System.Drawing.Image> imagenes = new List<System.Drawing.Image>() {imagenError, imagenAdvertencia, imagenInformacion };

        private static void crear(string mensaje, PictureBox figura)
        {
            ToolTip tooltip = new ToolTip()
            {
                Active = true,
            };
            tooltip.SetToolTip(figura, mensaje);
        }

        public static void habilitar(bool test, PictureBox figura, string mensaje, int tipoMensaje) //0 error, 1 advertencia, 2 info
        {
            if (test)
            {
                figura.Image = imagenes[tipoMensaje];
                figura.Visible = true;
                crear(mensaje, figura);
            }
            else
            {
                figura.Visible = false;
            }
            
        }


    }

}
