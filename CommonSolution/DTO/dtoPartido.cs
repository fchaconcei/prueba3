using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    public class dtoPartido
    {
        public int idPartido { get; set; }
        public int idJugador1 { get; set; }
        public int idJugador2 { get; set; }
        public Nullable<short> PuntosJugador1 { get; set; }
        public Nullable<short> PuntosJugador2 { get; set; }
        public Nullable<System.DateTime> FechaHoraInicio { get; set; }
        public Nullable<System.DateTime> FechaHoraFin { get; set; }
        public long idTorneo { get; set; }
    }
}
