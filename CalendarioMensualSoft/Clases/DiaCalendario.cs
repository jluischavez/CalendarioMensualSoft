using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarioMensualSoft.Clases
{
    public class DiaCalendario
    {
        public DateTime Fecha { get; set; }
        public bool EsFinDeSemana => Fecha.DayOfWeek == DayOfWeek.Saturday || Fecha.DayOfWeek == DayOfWeek.Sunday;
        public bool EsFestivo { get; set; } // Puedes marcarlo según una lista
        public bool EstaFueraDeRango { get; set; }

        public DiaCalendario(DateTime fecha)
        {
            Fecha = fecha;
        }

    }
}
