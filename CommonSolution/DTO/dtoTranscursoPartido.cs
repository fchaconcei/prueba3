using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTO
{
    public class dtoTranscursoPartido
    {
        public int idPartido { get; set; }
        public Nullable<short> puntoJugador1 { get; set; }
        public Nullable<short> puntoJugador2 { get; set; }
        public long nuTranscursoPartido { get; set; }
        public short nuOrdenPartido { get; set; }
    }
}
