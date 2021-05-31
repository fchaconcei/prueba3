using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class Repository
    {
        private PartidoRepository _PartidoRepository;
        private TorneoRepository _TorneoRepository;
        private JugadorRepository _JugadorRepository;
        private TranscursoPartidoRepository _TranscursoPartidoRepository;

        public Repository()
        {
            this._PartidoRepository = new PartidoRepository();
            this._TorneoRepository = new TorneoRepository();
            this._JugadorRepository = new JugadorRepository();
            this._TranscursoPartidoRepository = new TranscursoPartidoRepository();
        }


        public PartidoRepository getPartidoRepository()
        {
            return this._PartidoRepository;
        }

        public TorneoRepository getTorneoRepository()
        {
            return this._TorneoRepository;
        }

        public JugadorRepository getJugadorRepository()
        {
            return this._JugadorRepository;
        }

        public TranscursoPartidoRepository getTranscursoPartidoRepository()
        {
            return this._TranscursoPartidoRepository;
        }
    }
}
