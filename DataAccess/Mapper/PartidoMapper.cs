using CommonSolution.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class PartidoMapper
    {
        public Partido toEntity(dtoPartido dtoPartido)
        {
            Partido entity = new Partido();
            entity.idJugador1 = dtoPartido.idJugador1;
            entity.idJugador2 = dtoPartido.idJugador2;
            entity.PuntosJugador1 = dtoPartido.PuntosJugador1;
            entity.PuntosJugador2 = dtoPartido.PuntosJugador2;
            entity.idTorneo = dtoPartido.idTorneo;
            entity.idPartido = dtoPartido.idPartido;
            entity.FechaHoraFin = dtoPartido.FechaHoraFin;
            entity.FechaHoraInicio = dtoPartido.FechaHoraInicio;

            return entity;
        }

        public dtoPartido toDto(Partido entity)
        {
            dtoPartido dto = new dtoPartido();
            dto.idJugador1 = entity.idJugador1;
            dto.idJugador2 = entity.idJugador2;
            dto.PuntosJugador1 = entity.PuntosJugador1;
            dto.PuntosJugador2 = entity.PuntosJugador2;
            dto.idTorneo = entity.idTorneo;
            dto.idPartido = entity.idPartido;
            dto.FechaHoraFin = entity.FechaHoraFin;
            dto.FechaHoraInicio = entity.FechaHoraInicio;

            return dto;
        }

        public List<dtoPartido> toDto(List<Partido> colEntity)
        {
            List<dtoPartido> colDto = new List<dtoPartido>();

            foreach (Partido entity in colEntity)
            {
                dtoPartido dto = this.toDto(entity);
                colDto.Add(dto);
            }

            return colDto;
        }

     
    }
}
