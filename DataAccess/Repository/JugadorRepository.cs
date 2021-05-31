using CommonSolution.DTO;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class JugadorRepository
    {
        private JugadorMapper _JugadorMapper;

        public JugadorRepository()
        {
            this._JugadorMapper = new JugadorMapper();
        }

        public bool ExisteJugador(long nuJugador)
        {
            bool result = false;

            using (DBEntities context = new DBEntities())
            {
                result = context.Jugador.AsNoTracking().Any(a => a.NumJugador == nuJugador);
            }

            return result;
        }

        public dtoJugador GetJugadorById(long nuJugador)
        {
            dtoJugador dto = null;

            using (DBEntities context = new DBEntities())
            {
                dto = this._JugadorMapper.toDto(context.Jugador.AsNoTracking().FirstOrDefault(a => a.NumJugador == nuJugador));
            }

            return dto;
        }

    }
}
