using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TorneoRepository
    {
        private TorneoMapper _TorneoMapper;

        public TorneoRepository()
        {
            this._TorneoMapper = new TorneoMapper();
        }

        public bool ExisteTorneo(long idTorneo)
        {
            bool result = false;

            using (DBEntities context = new DBEntities())
            {
                result = context.Torneo.AsNoTracking().Any(a => a.idTorneo == idTorneo);
            }

            return result;
        }

    }
}
