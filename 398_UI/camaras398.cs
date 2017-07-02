using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _398_UI
{
    public class camaras398
    {
        public string marca { get; set; }
        public List<string> modelos { get; set; }

        public static BindingList<camaras398> lista()
        {
            return IO.readJsonList<camaras398>(@"..\..\camaras398.txt");
        }
    }
}
