using CommonSolution.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class JugadorMapper
    {
        public dtoJugador toDto(Jugador entity)
        {
            dtoJugador dto = new dtoJugador();

            dto.documento = entity.documento;
            dto.apellido = entity.apellido;
            dto.nombre = entity.nombre;
            dto.NumJugador = entity.NumJugador;

            return dto;
        }

        public Jugador toEntity(dtoJugador dto)
        {
            Jugador entity = new Jugador();

            entity.documento = dto.documento;
            entity.apellido = dto.apellido;
            entity.nombre = dto.nombre;
            entity.NumJugador = dto.NumJugador;

            return entity;
        }

        public List<dtoJugador> toDto(List<Jugador> colEntity)
        {
            List<dtoJugador> colDto = new List<dtoJugador>();

            foreach (Jugador entity in colEntity)
            {
                dtoJugador dto = this.toDto(entity);
                colDto.Add(dto);
            }

            return colDto;
        }
    }
}
