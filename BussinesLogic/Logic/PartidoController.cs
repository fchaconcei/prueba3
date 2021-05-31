using CommonSolution.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Logic
{
    public class PartidoController
    {

        private Repository _Repository;

        public PartidoController()
        {
            this._Repository = new Repository();
        }

        //A)
        public List<string> agregarPartido(dtoPartido dto)
        {
            List<string> errores = validarPartido(dto);

            if (errores.Count == 0)
            {
                this._Repository.getPartidoRepository().agregarPartido(dto);
            }

            return errores;

        }

        public List<string> validarPartido(dtoPartido dto)
        {
            List<string> errores = new List<string>();

            if (!this._Repository.getJugadorRepository().ExisteJugador(dto.idJugador1))
            {
                errores.Add("El jugador 1 no existe");
            }

            if (!this._Repository.getJugadorRepository().ExisteJugador(dto.idJugador2))
            {
                errores.Add("El jugador 2 no existe");
            }

            if (!this._Repository.getTorneoRepository().ExisteTorneo(dto.idTorneo))
            {
                errores.Add("El torneo no existe");
            }

            return errores;
        }









        //B
        public void IniciarPartido(long idPartido)
        {
            dtoPartido partido = this._Repository.getPartidoRepository().GetPartidoById(idPartido);
            partido.FechaHoraInicio = DateTime.Now;
            this._Repository.getPartidoRepository().ModificarPartido(partido);
        }

        //C
        public void PuntoJugado(long idPartido, long nuJugador)
        {
            dtoTranscursoPartido nuevoDto = new dtoTranscursoPartido();
            dtoPartido partido = this._Repository.getPartidoRepository().GetPartidoById(idPartido);

            if (partido.idJugador1 == nuJugador)
            {
                nuevoDto.puntoJugador1 = 1;
                partido.PuntosJugador1++;
            }
            else if (partido.idJugador2 == nuJugador)
            {
                nuevoDto.puntoJugador2 = 1;
                partido.PuntosJugador2++;
            }

            this._Repository.getPartidoRepository().ModificarPartido(partido);

           
            nuevoDto.idPartido = (int)idPartido;
            nuevoDto.nuOrdenPartido = this._Repository.getTranscursoPartidoRepository().GetOrdenPartido(nuevoDto.idPartido);
            nuevoDto.nuOrdenPartido++;
            this._Repository.getTranscursoPartidoRepository().AgregarTranscursoPartido(nuevoDto);
        }

     

    }
}
