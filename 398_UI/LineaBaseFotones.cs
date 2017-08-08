using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class LineaBaseFotones
    {
        public static bool hayLineaBase(Equipo equipo)
        {
            bool hayLB = false;
            foreach (CalibracionFot cali in CalibracionFot.lista())
            {
                if (cali.EquipoCali == equipo && cali.EsLineaBase)
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
                if (cali.EquipoCali == equipo && cali.EsLineaBase)
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
                if (cali.EquipoCali == equipo)
                {
                    cali.EsLineaBase = false;
                }
            }
            califot.EsLineaBase = true;
        }
    }
}
