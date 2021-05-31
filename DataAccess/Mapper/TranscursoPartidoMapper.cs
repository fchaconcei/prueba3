using CommonSolution.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TranscursoPartidoMapper
    {
        public TranscursoPartido toEntity(dtoTranscursoPartido dto)
        {
            TranscursoPartido entity = new TranscursoPartido();
            dto.idPartido = dto.idPartido;
            dto.nuOrdenPartido = dto.nuOrdenPartido;
            dto.nuTranscursoPartido = dto.nuTranscursoPartido;
            dto.puntoJugador1 = dto.puntoJugador1;
            dto.puntoJugador2 = dto.puntoJugador2;
         

            return entity;
        }

      
    }
}
