using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class LineaBaseFotones
    {
        public static bool hayLineaBase(Equipo equipo, EnergiaFotones energia)
        {
            bool hayLB = false;
            foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                if (cali.Equipo == equipo && cali.Energia == energia && cali.EsReferencia)
                {
                    hayLB = true;
                    break;
                }
            }
            return hayLB;
        }

        public static CalibracionFot obtenerCaliLineaBase(Equipo equipo)
        {
            CalibracionFot caliLB = new CalibracionFot();
            foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                if (cali.Equipo == equipo && cali.EsReferencia)
                {
                    caliLB = cali;
                    break;
                }
            }
            return caliLB;
        }

        public static void establecerComoLB(Equipo equipo, CalibracionFot califot)
        {
            foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                if (cali.Equipo == equipo)
                {
                    cali.EsReferencia = false;
                }
            }
            califot.EsReferencia = true;
        }
    }
}
