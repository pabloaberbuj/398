using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    public class ValorARF
    {
        public double absoluto { get; set; }
        public double relativo { get; set; }
        public string fecha { get; set; }

        public static ValorARF crear(double _valor, double _referencia, DateTime _fecha)
        {
            return new ValorARF
            {
                absoluto = _valor,
                relativo = Math.Round((_valor - _referencia) / _referencia * 100, 2),
                fecha = _fecha.ToShortDateString(),
            };
        }

        public static ValorARF crear(double _valor, double _referencia)
        {
            return new ValorARF
            {
                absoluto =  _valor,
                relativo = Math.Round((_valor - _referencia) / _referencia * 100,2),
                fecha = "",
            };
        }
    }

    
}
