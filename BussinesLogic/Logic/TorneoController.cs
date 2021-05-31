using CommonSolution.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Logic
{
    public class TorneoController
    {
        private Repository _Repository;

        public TorneoController()
        {
            this._Repository = new Repository();
        }

        //D
        public dtoJugador DarGanador(long idTorneo)
        {
            dtoJugador jugadorGanador = null;
            List<dtoJugadorCantVictorias> colJugadoresGanadores = new List<dtoJugadorCantVictorias>();
            List<dtoPartido> getPartidosTorneo = this._Repository.getPartidoRepository().GetPartidosTorneo(idTorneo);

            foreach (dtoPartido dto in getPartidosTorneo)
            {
                long idJugadorGanador = 0;
                dtoJugadorCantVictorias nuevoGanador = new dtoJugadorCantVictorias();

                if (dto.PuntosJugador1 > dto.PuntosJugador2)
                {
                    idJugadorGanador = dto.idJugador1;
                }
                else
                {
                    idJugadorGanador = dto.idJugador2;
                }

                dtoJugadorCantVictorias ganador = colJugadoresGanadores.FirstOrDefault(f => f.idJugador == idJugadorGanador);
                if (ganador == null)
                {
                    ganador = new dtoJugadorCantVictorias();
                    ganador.idJugador = idJugadorGanador;
                    ganador.cantVictorias = 1;
                    colJugadoresGanadores.Add(ganador);
                }
                else
                {
                    ganador.cantVictorias++;
                }
            }

            dtoJugadorCantVictorias ganadorDelTorneo = colJugadoresGanadores.OrderByDescending(o => o.cantVictorias).FirstOrDefault();
            jugadorGanador = this._Repository.getJugadorRepository().GetJugadorById(ganadorDelTorneo.idJugador);

            return jugadorGanador;
        }

    }
}
