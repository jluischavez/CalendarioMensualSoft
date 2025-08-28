using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarioMensualSoft.Clases
{
    public class Mes
    {
        public int Id { get; set; }         // Número del mes (1-12)
        public string Nombre { get; set; }  // Nombre del mes

        public override string ToString()
        {
            return Nombre; // Esto es lo que se muestra en el ComboBox
        }
    }
}
