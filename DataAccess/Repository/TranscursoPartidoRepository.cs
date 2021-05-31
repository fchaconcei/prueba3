using CommonSolution.DTO;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TranscursoPartidoRepository
    {
        private TranscursoPartidoMapper _TranscursoPartidoMapper;

        public TranscursoPartidoRepository()
        {
            this._TranscursoPartidoMapper = new TranscursoPartidoMapper();
        }

        public void AgregarTranscursoPartido(dtoTranscursoPartido dto)
        {
            using (DBEntities context = new DBEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        TranscursoPartido nuevoTranscursoPartido = this._TranscursoPartidoMapper.toEntity(dto);
                        context.TranscursoPartido.Add(nuevoTranscursoPartido);
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }

                }

            }

        }

        public short GetOrdenPartido(int idPartido)
        {
            short ultimoOrden = 0;
            using (DBEntities context = new DBEntities())
            {
                ultimoOrden = context.TranscursoPartido.AsNoTracking().Where(w => w.idPartido == idPartido).Max(m => m.nuOrdenPartido);
                  
            }
            return ultimoOrden;

        }
    }
}
